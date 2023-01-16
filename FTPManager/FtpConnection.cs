using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using Newtonsoft.Json;

namespace FTPManager
{
    public class FtpConnection : IDisposable
    {
        public Models.FtpInstanceData InstanceData { get; private set; } //all files and folders are stored and retreived here: can store in cache in future
        public bool WasError { get; set; }
        public string ErrMsg { get; set; }



        private void SetError(string msg = null) { this.WasError = true; this.ErrMsg = msg == null ? "An unknown error has occured" : msg; }
        private FtpClient Client;


        public FtpConnection(Models.xpo.FtpCredential rec)
        {
            if (rec != null)
            {
                this.InstanceData = new Models.FtpInstanceData(rec);
                this.Client = null;
                if (this.InstanceData != null)
                {
                    if (!string.IsNullOrEmpty(this.InstanceData.CredentialsDecrypted.Key))
                    {
                        if (!string.IsNullOrEmpty(this.InstanceData.CredentialsDecrypted.Value))
                        {
                            if (!string.IsNullOrEmpty(this.InstanceData.Host))
                            {
                                try
                                {
                                    this.Client = new FtpClient(CleanDirUrl(rec.FtpHost), InstanceData.CredentialsDecrypted.Key, InstanceData.CredentialsDecrypted.Value);
                                    if (!this.Client.IsConnected) this.Client.Connect(true);
                                    if (!this.Client.IsConnected) { this.Client = null; SetError("Connection was unsuccessful. Check credentials and hostIP and try again."); }
                                }
                                catch (Exception x)
                                {
                                    SetError(x.Message);
                                }
                            }
                            else SetError("Host cannot be blank.");
                        }
                        else SetError("Password cannot be blank.");
                    }
                    else SetError("Username cannot be blank.");
                }
                else SetError();
            }
            else SetError();
        }


        public static string CleanDirUrl(string str, bool slashBefore = false, bool slashAfter = false)
        {
            if (!string.IsNullOrEmpty(str) && str != "/")
            {
                if (str.StartsWith("/")) str = str.Substring(1);
                if (str.EndsWith("/")) str = str.Substring(0, str.Length - 1);
                if (slashBefore) str = $"/{str}";
                if (slashAfter) str = $"{str}/";
            }
            return str;
        }

        public void GetFiles(string endpoint = "/")
        {
            if (!WasError)
            {
                try
                {
                    string[] rootNames = this.Client.GetNameListing(CleanDirUrl(endpoint, true));
                    this.InstanceData.RootDirectories = new List<string>();
                    this.InstanceData.RootDirectories.AddRange(rootNames);
                }
                catch (Exception x)
                {
                    SetError(x.Message);
                }
            }
        }

        public int DeleteAllFiles(string endpoint = "/")
        {
            int rtn = 0;
            if (!WasError)
            {
                try
                {
                    string root = CleanDirUrl(endpoint, true);
                    string[] rootNames = this.Client.GetNameListing(root);
                    if (root == "/") root = string.Empty;
                    foreach (string file in rootNames)
                    {
                        string del = $"{file}";
                        if (file.Contains(".") && !file.Split('/').Last().StartsWith("."))
                        {
                            this.Client.DeleteFile(del);
                        }
                        else
                        {
                            this.Client.DeleteDirectory(del);
                        }
                        rtn++;
                    }
                    rootNames = this.Client.GetNameListing(CleanDirUrl(endpoint, true));
                    this.InstanceData.RootDirectories = new List<string>();
                    this.InstanceData.RootDirectories.AddRange(rootNames);
                }
                catch (Exception x)
                {
                    SetError(x.Message);
                }
            }
            return rtn;
        }

        public void UploadFolder(string folder, string remoteDest)
        {
            try
            {
                if (Directory.Exists(folder) && !string.IsNullOrEmpty(remoteDest))
                {
                    string remoteDir = $"{CleanDirUrl(remoteDest, true, true)}";
                    this.Client.UploadDirectory(folder, remoteDir);
                    string[] rootNames = this.Client.GetNameListing(remoteDir);
                    this.InstanceData.RootDirectories = new List<string>();
                    this.InstanceData.RootDirectories.AddRange(rootNames);
                }
                else SetError("One or more errors occured.");
            }
            catch (Exception x) { SetError(x.Message); }
        }
        public void Upload(string localFile, string dirPath)
        {
            try
            {
                if (File.Exists(localFile) && !string.IsNullOrEmpty(dirPath))
                {
                    string remoteDir = $"{CleanDirUrl(dirPath, true, true)}{Path.GetFileName(localFile)}";
                    this.Client.UploadFile(localFile, remoteDir);
                    string[] rootNames = this.Client.GetNameListing(CleanDirUrl(dirPath, true));
                    if (this.InstanceData.RootDirectories == null) this.InstanceData.RootDirectories = new List<string>();
                    this.InstanceData.RootDirectories.AddRange(rootNames);
                }
                else SetError("One or more errors occured.");
            }
            catch (Exception x) { SetError(x.Message); }
        }
        public string SerializeFilesJson(bool encrypt = true)
        {
            string rtn = null;
            if (this?.InstanceData?.RootDirectories != null)
            {
                try
                {
                    if (encrypt)
                    {
                        List<string> rootDirectoriesEnc = new List<string>();
                        foreach (string item in this.InstanceData.RootDirectories)
                        {
                            rootDirectoriesEnc.Add(EncryptionEngine.Encrypt(item));
                        }
                        rtn = JsonConvert.SerializeObject(rootDirectoriesEnc);
                    }
                    else
                    {
                        rtn = JsonConvert.SerializeObject(this.InstanceData.RootDirectories);
                    }
                }
                catch { rtn = null; }
            }
            return rtn;
        }


        #region disp

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FtpConnection()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
