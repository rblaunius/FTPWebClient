using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPWebClient.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtIP.Text = Properties.Settings.Default.Host;
            txtLogin.Text = Properties.Settings.Default.Login;
            txtPW.Text = Properties.Settings.Default.PW;
            txtIP.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Host = txtIP.Text;
            Properties.Settings.Default.Login = txtLogin.Text;
            Properties.Settings.Default.PW = txtPW.Text;
            Properties.Settings.Default.Save();
            DialogResult= DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
