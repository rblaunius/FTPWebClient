using DevExpress.Xpo;
using FTPManager;
using FTPManager.Models.xpo;
using System.Data;
using System.Windows.Forms;
using xWinForms.xControls;

namespace FTPWebClient.Forms
{
    public partial class AddEditFTP : Form
    {
        public FtpCredential rec { get; set; }
        public AddEditFTP(FtpCredential rec)
        {
            InitializeComponent();
            this.rec = rec;
            if (rec.Oid < 1) this.btnSave.Text = "Add";
            else this.txtTitle.Text = "Update Existing FTP Connection";
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtIP.Text = rec.FtpHost;
            txtName.Text = rec.Nickname;
            txtLogin.Text = EncryptionEngine.Decrypt(rec.UserName);
            txtPW.Text = EncryptionEngine.Decrypt(rec.Password);
            txtFolder.Text = rec.FileUploadPath;
            txtNotFoundFile.Text = rec.NotFoundFile;
            txtIP.Select();
        }

        bool validate()
        {
            string ermsg = string.Empty;
            if (rec == null)
            {
                ermsg = "An Unexpected error has occured.";
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                ermsg = "Server Nickname cannot be blank.";
            }
            else if (string.IsNullOrEmpty(txtFolder.Text))
            {
                ermsg = "Dest. folder cannot be blank.";
            }
            else if (!string.IsNullOrEmpty(txtNotFoundFile.Text))
            {
                if (!System.IO.File.Exists(txtNotFoundFile.Text))
                {
                    ermsg = $"Placeholder file cannot be found:\n'{txtNotFoundFile.Text}'";
                }
            }
            else if (XpoHelper.CheckIfCredentialExists(txtName.Text, rec.Oid))
            {
                ermsg = $"Server Nickname must be unique.";
            }

            if (!string.IsNullOrEmpty(ermsg)) xMessageBox.Show(ermsg);
            return string.IsNullOrEmpty(ermsg);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                Properties.Settings.Default.Login = EncryptionEngine.Encrypt(txtLogin.Text);
                Properties.Settings.Default.PW = EncryptionEngine.Encrypt(txtPW.Text);
                if (!string.IsNullOrEmpty(txtNotFoundFile.Text)) Properties.Settings.Default.NotFoundFile = txtNotFoundFile.Text;
                if (!string.IsNullOrEmpty(txtFolder.Text)) Properties.Settings.Default.FtpUploadFolder = txtFolder.Text;
                Properties.Settings.Default.Save();

                rec.Nickname = txtName.Text;
                rec.FtpHost = txtIP.Text;
                rec.UserName = EncryptionEngine.Encrypt(txtLogin.Text);
                rec.Password = EncryptionEngine.Encrypt(txtPW.Text);
                rec.FileUploadPath = txtFolder.Text;
                rec.NotFoundFile = txtNotFoundFile.Text;
                ((UnitOfWork)rec.Session).CommitChanges();
                DialogResult = DialogResult.OK; 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (rec.Oid <= 0)
            {
                rec.Delete();
                ((UnitOfWork)rec.Session).CommitChanges();
                ((UnitOfWork)rec.Session).DropChanges();
            }
            DialogResult = DialogResult.Cancel;
        }

        private void btnHShow_Click(object sender, EventArgs e)
        {
            this.txtPW.UseSystemPasswordChar = !this.txtPW.UseSystemPasswordChar;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.WhiteSmoke;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = null;
            ofd.Title = "Select a file for the Placeholder";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtNotFoundFile.Text = ofd.FileName;
            }
            ofd.Dispose();
        }
    }
}
