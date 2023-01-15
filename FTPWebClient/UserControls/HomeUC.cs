using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using FTPWebClient.Models.xpo;

namespace FTPWebClient.UserControls
{
    public partial class HomeUC : UserControl
    {
        private UnitOfWork uow;
        public HomeUC()
        {
            InitializeComponent();
            RefreshDataSrc(true);
        }
        List<Models.FtpCredLocal> MyServers = new List<Models.FtpCredLocal>();
        void RefreshDataSrc(bool resetUOW = false)
        {
            if (resetUOW)
            {
                uow = new UnitOfWork();
            }
            MyServers = new List<Models.FtpCredLocal>();
            var query = new XPQuery<FtpCredentials>(uow).Where(x => x.Oid > 0).ToList();
            foreach (var item in query)
            {
                MyServers.Add(new Models.FtpCredLocal()
                {
                    Name = item.Nickname,
                    oid = item.Oid
                });
            }
            query = null;
            this.dataGridView1.DataSource = MyServers;
            this.dataGridView1.Refresh();
            this.dataGridView1.Focus();
        }        
        private void HomeUC_Click(object sender, EventArgs e)
        {
            if (Cursor != Cursors.WaitCursor)
            {
                Cursor = Cursors.Default;
                RefreshDataSrc();
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(254, 140, 25);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Transparent;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FtpCredentials rec = new Models.xpo.FtpCredentials(uow);
            rec.Password = Properties.Settings.Default.PW;
            rec.UserName = Properties.Settings.Default.Login;
            rec.NotFoundFile = Properties.Settings.Default.NotFoundFile;
            Forms.AddEditFTP frm = new Forms.AddEditFTP(rec);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                RefreshDataSrc();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0].DataBoundItem as Models.FtpCredLocal;
                if (row != null)
                {
                    FtpCredentials cred = uow.GetObjectByKey<FtpCredentials>(row.oid);
                    if (cred != null)
                    {
                        uow.Delete(cred);
                        uow.CommitChanges();
                        RefreshDataSrc();
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0].DataBoundItem as Models.FtpCredLocal;
                if (row != null)
                {
                    var xRow = uow.GetObjectByKey<FtpCredentials>(row.oid);
                    if (xRow != null)
                    {
                        this.btnTest.Enabled = true;
                        this.btnDelAllFiles.Enabled = true;
                        this.btnDeleteAndUpload.Enabled = true;
                        this.btnUpload.Enabled = true;
                        this.btnUploadFolder.Enabled = true;
                        this.ctlMyServerInfo.LoadCredential(xRow);
                    }
                    else NothingSelected();
                }
                else NothingSelected();
            }
            else NothingSelected();
            void NothingSelected()
            {
                this.ctlMyServerInfo.Clear();
                this.dataGridView2.DataSource = null;
                this.btnTest.Enabled = false;
                this.btnDelAllFiles.Enabled = false;
                this.btnDeleteAndUpload.Enabled = false;
                this.btnUpload.Enabled = false;
                this.btnUploadFolder.Enabled = false;
                this.dataGridView2.Refresh();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var col = dataGridView1.Columns[e.ColumnIndex];
                if (col != null)
                {
                    if (col == colEdit)
                    {
                        var row = dataGridView1.Rows[e.RowIndex];
                        if (row != null)
                        {
                            var xRow = row.DataBoundItem as Models.FtpCredLocal;
                            if (xRow != null)
                            {
                                Models.xpo.FtpCredentials rec = uow.GetObjectByKey<Models.xpo.FtpCredentials>(xRow.oid);
                                if (rec != null)
                                {
                                    Forms.AddEditFTP frm = new Forms.AddEditFTP(rec);
                                    frm.ShowDialog();
                                    if (frm.DialogResult == DialogResult.OK)
                                    {
                                        this.RefreshDataSrc();
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch { }
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {

        }

        private void btnDelAllFiles_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteAndUpload_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadFolder_Click(object sender, EventArgs e)
        {

        }
    }
}
