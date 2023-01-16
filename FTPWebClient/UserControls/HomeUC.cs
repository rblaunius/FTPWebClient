using DevExpress.Xpo;
using FTPManager.Models;
using System.Data;
using FTPManager.Models.xpo;

namespace FTPWebClient.UserControls
{
    public partial class HomeUC : UserControl
    {
        public FTPManager.Cache Cache { get; set; } = null;
        private UnitOfWork uow;
        public HomeUC()
        {
            InitializeComponent();
            this.Cache = new FTPManager.Cache();
            RefreshDataSrc(true);
        }
        List<FTPManager.Models.FtpCredFAST> MyServers = new List<FTPManager.Models.FtpCredFAST>();
        void RefreshDataSrc(bool resetUOW = false)
        {
            if (resetUOW)
            {
                uow = new UnitOfWork();
            }
            MyServers = new List<FTPManager.Models.FtpCredFAST>();
            var query = new XPQuery<FtpCredential>(uow).Where(x => x.Oid > 0).ToList();
            foreach (var item in query)
            {
                MyServers.Add(new FTPManager.Models.FtpCredFAST()
                {
                    name = item.Nickname,
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
            FtpCredential rec = new FtpCredential(uow);
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
                var row = dataGridView1.SelectedRows[0].DataBoundItem as FTPManager.Models.FtpCredFAST;
                if (row != null)
                {
                    FtpCredential cred = uow.GetObjectByKey<FtpCredential>(row.oid);
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
                var row = dataGridView1.SelectedRows[0].DataBoundItem as FTPManager.Models.FtpCredFAST;
                if (row != null)
                {
                    var xRow = uow.GetObjectByKey<FtpCredential>(row.oid);
                    if (xRow != null)
                    {
                        this.btnTest.Enabled = true;
                        this.btnDelAllFiles.Enabled = true;
                        this.btnDeleteAndUpload.Enabled = true;
                        this.btnUpload.Enabled = true;
                        this.btnUploadFolder.Enabled = true;
                        if (string.IsNullOrEmpty(xRow.FileUploadPath) || xRow.FileUploadPath == "/")
                        {
                            this.btnDelAllFiles.Enabled = false;
                            this.btnDeleteAndUpload.Enabled = false;
                            this.btnUploadFolder.Enabled = false;
                        }
                        this.ctlMyServerInfo.LoadCredential(xRow);
                        if (this.Cache.FilesByServer.ContainsKey(xRow.Nickname))
                        {
                            this.dataGridView2.DataSource = (List<FTPManager.Models.FtpDirectory>)this.Cache.FilesByServer[xRow.Nickname];
                        }
                        else this.dataGridView2.DataSource = null;
                        this.dataGridView2.Refresh();
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
                            var xRow = row.DataBoundItem as FTPManager.Models.FtpCredFAST;
                            if (xRow != null)
                            {
                                FtpCredential rec = uow.GetObjectByKey<FtpCredential>(xRow.oid);
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

        FtpCredential getSelectedFtp()
        {
            FtpCredential rtn = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var fst = dataGridView1.SelectedRows[0].DataBoundItem as FTPManager.Models.FtpCredFAST;
                if (fst != null)
                {
                    rtn = uow.GetObjectByKey<FtpCredential>(fst.oid);
                }
                fst = null;
            }
            return rtn;
        }
        string cleanPath(string pth)
        {
            if (!string.IsNullOrEmpty(pth))
            {
                if (pth.First() != '/') pth = $"/{pth}";
            }
            else pth = "/";
            return pth;
        }
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            var rec = getSelectedFtp();
            rec.FilesJson = null;
            if (rec != null)
            {
                string errMsg = null;
                Cursor = Cursors.WaitCursor;
                var ftp = new FTPManager.FtpConnection(rec);
                if (!ftp.WasError)
                {
                    errMsg = "Connection successful.";
                    ftp.GetFiles(cleanPath(rec.FileUploadPath));
                    if (!ftp.WasError)
                    {
                        errMsg = errMsg.Replace("Connection", $"FTP '{rec.FtpHost}{cleanPath(rec.FileUploadPath)}' connection was");
                        SetDirFileListing(ftp.InstanceData);
                    }
                    else errMsg = errMsg.Replace(".", $", but attention is required:\n'{ftp.ErrMsg}'");
                }
                else errMsg = ftp.ErrMsg;
                ftp.Dispose();
                Cursor = Cursors.Default;
                if (!string.IsNullOrEmpty(errMsg)) xWinForms.xControls.xMessageBox.Show(errMsg);
            }
        }
        void SetDirFileListing(FtpInstanceData instanceData)
        {
            this.dataGridView2.DataSource = null;
            if (instanceData != null)
            {
                List<FtpDirectory> ftpDirectories = FTPManager.Models.FtpDirectory.Convert(instanceData.RootDirectories);
                this.Cache.FilesByServer[instanceData.Nickname] = ftpDirectories;
                this.dataGridView2.DataSource = ftpDirectories;
            }
            this.dataGridView2.Refresh();
        }

        private void btnDelAllFiles_Click(object sender, EventArgs e)
        {
            var rec = getSelectedFtp();
            if (rec != null)
            {
                string errMsg = null;
                if (rec.FileUploadPath != "/")
                {
                    Cursor = Cursors.WaitCursor;
                    var ftp = new FTPManager.FtpConnection(rec);
                    if (!ftp.WasError)
                    {
                        int deleted = ftp.DeleteAllFiles(rec.FileUploadPath);
                        if (!ftp.WasError)
                        {
                            SetDirFileListing(ftp.InstanceData);
                            errMsg = $"Successfully Deleted {deleted} files.";
                        }
                        else errMsg = ftp.ErrMsg;
                    }
                    else errMsg = ftp.ErrMsg;
                    ftp.Dispose();
                    Cursor = Cursors.Default;
                }
                else errMsg = "Cannot delete files/directories in the root folder.";


                if (!string.IsNullOrEmpty(errMsg)) xWinForms.xControls.xMessageBox.Show(errMsg);
            }
        }

        private void btnDeleteAndUpload_Click(object sender, EventArgs e)
        {
            var rec = getSelectedFtp();
            if (rec != null)
            {
                string errMsg = null;
                if (rec.FileUploadPath != "/")
                {
                    Cursor = Cursors.WaitCursor;
                    var ftp = new FTPManager.FtpConnection(rec);
                    if (!ftp.WasError)
                    {
                        int deleted = ftp.DeleteAllFiles(rec.FileUploadPath);
                        if (!ftp.WasError)
                        {
                            errMsg = $"Successfully Deleted {deleted} files";
                            SetDirFileListing(ftp.InstanceData);
                            if (!string.IsNullOrEmpty(rec.NotFoundFile))
                            {
                                if (System.IO.File.Exists(rec.NotFoundFile))
                                {
                                    ftp.Upload(rec.NotFoundFile, rec.FileUploadPath);
                                    if (!ftp.WasError)
                                    {
                                        SetDirFileListing(ftp.InstanceData);
                                        errMsg += $" and uploaded '{Path.GetFileName(rec.NotFoundFile)}'";
                                    }
                                    else errMsg = ftp.ErrMsg;
                                }
                                else errMsg += $" but the placeholder file '{rec.FileUploadPath}' could not be found.";
                            }
                            else errMsg += " but no placeholder file was found.";
                        }
                        else errMsg = ftp.ErrMsg;
                    }
                    else errMsg = ftp.ErrMsg;
                    ftp.Dispose();
                    Cursor = Cursors.Default;
                }
                else errMsg = "Cannot delete files/directories in the root folder.";


                if (!string.IsNullOrEmpty(errMsg)) xWinForms.xControls.xMessageBox.Show(errMsg);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var rec = getSelectedFtp();
            if (rec != null)
            {
                string errMsg = null;
                Cursor = Cursors.WaitCursor;
                var ftp = new FTPManager.FtpConnection(rec);
                if (!ftp.WasError)
                {
                    SetDirFileListing(ftp.InstanceData);
                    if (!string.IsNullOrEmpty(rec.NotFoundFile))
                    {
                        if (System.IO.File.Exists(rec.NotFoundFile))
                        {
                            ftp.Upload(rec.NotFoundFile, rec.FileUploadPath);
                            if (!ftp.WasError)
                            {
                                SetDirFileListing(ftp.InstanceData);
                                errMsg = $"Successfully uploaded '{Path.GetFileName(rec.NotFoundFile)}'";
                            }
                            else errMsg = ftp.ErrMsg;
                        }
                        else errMsg += $" but the placeholder file '{rec.FileUploadPath}' could not be found.";
                    }
                    else errMsg += " but no placeholder file was found.";
                }
                else errMsg = ftp.ErrMsg;
                ftp.Dispose();
                Cursor = Cursors.Default;


                if (!string.IsNullOrEmpty(errMsg)) xWinForms.xControls.xMessageBox.Show(errMsg);
            }
        }

        private void btnUploadFolder_Click(object sender, EventArgs e)
        {
            var rec = getSelectedFtp();
            if (rec != null)
            {
                string errMsg = null;
                if (rec.FileUploadPath != "/")
                {
                    var ofd = new FolderBrowserDialog();
                    ofd.SelectedPath = null;
                    if (!string.IsNullOrEmpty(rec.NotFoundFile)) ofd.InitialDirectory = Path.GetDirectoryName(rec.NotFoundFile);
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        var ftp = new FTPManager.FtpConnection(rec);
                        if (!ftp.WasError)
                        {
                            ftp.UploadFolder(ofd.SelectedPath, rec.FileUploadPath);
                            if (!ftp.WasError)
                            {
                                SetDirFileListing(ftp.InstanceData);
                                errMsg = $"Successfully uploaded '{ofd.SelectedPath}'";
                            }
                            else errMsg = ftp.ErrMsg;
                        }
                        else errMsg = ftp.ErrMsg;
                        ftp.Dispose();
                        Cursor = Cursors.Default;
                    }
                }
                else errMsg = "Cannot delete files/directories in the root folder.";

                if (!string.IsNullOrEmpty(errMsg)) xWinForms.xControls.xMessageBox.Show(errMsg);
            }
        }
    }
}
