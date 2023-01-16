using FTPManager;
using FTPManager.Models.xpo;

namespace FTPWebClient.UserControls
{
    public partial class MyServerInfo : UserControl
    {
        public MyServerInfo()
        {
            InitializeComponent();
            Clear();
        }

        public void Clear()
        {
            this.txtServerFTP.Text = null;
            this.txtUserName.Text = null;
            this.txtPW.Text = null;
            this.txtContentFile.Text = null;
            this.txtUplPath.Text = null;
        }

        private FtpCredential rec;
        public void LoadCredential(FtpCredential row)
        {
            rec = row;
            if (row != null)
            {
                this.txtServerFTP.Text = row.FtpHost;
                this.txtUserName.Text = EncryptionEngine.Decrypt(row.UserName);
                this.txtPW.Text = "show";
                this.txtContentFile.Text = row.NotFoundFile;
                this.txtUplPath.Text = row.FileUploadPath;
            }
            else Clear();
        }
        private void txtPW_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rec != null)
            {
                if (txtPW.Text == "show")
                {
                    this.txtPW.Text = EncryptionEngine.Decrypt(rec.Password);
                }
                else this.txtPW.Text = "show";
            }
            else this.txtPW.Text = "show";
        }
    }
}
