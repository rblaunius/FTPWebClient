using FTPWebClient.Models.xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private FtpCredentials? rec;
        public void LoadCredential(FtpCredentials row)
        {
            rec = row;
            if (row != null)
            {
                this.txtServerFTP.Text = row.FtpHost;
                this.txtUserName.Text = XpoHelper.EncryptionEngine.Decrypt(row.UserName);
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
                    this.txtPW.Text = XpoHelper.EncryptionEngine.Decrypt(rec.Password);
                }
                else this.txtPW.Text = "show";
            }
            else this.txtPW.Text = "show";
        }
    }
}
