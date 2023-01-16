using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager.Models
{

    public class DefaultFolderPaths
    {
        //for temp-download server data
        public string Root { get; private set; }
        public string SubFolderName { get; set; }
        public string SubFolderFullPath { get; set; }
        public DefaultFolderPaths(Models.FtpInstanceData conn)
        {
            this.Root = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FTPManager-tmp");
            if (!System.IO.Directory.Exists(this.Root)) System.IO.Directory.CreateDirectory(this.Root);
            this.SubFolderName = replaceAll(conn.Nickname, ",./;'[]!@#$%^&*()+|:\"\\?", "_");
            this.SubFolderFullPath = System.IO.Path.Combine(this.Root, this.SubFolderName);
            if (!Directory.Exists(this.SubFolderFullPath)) Directory.CreateDirectory(this.SubFolderFullPath);
        }
        string replaceAll(string src, string stringChars, string replaceChar = null)
        {
            string rtn = null;
            if (!string.IsNullOrEmpty(src))
            {
                rtn = src.Trim();
                foreach (char c in stringChars)
                {
                    rtn = src.Replace(c.ToString(), replaceChar);
                }
            }
            return rtn;
        }
    }
    public class FtpInstanceData
    {
        public FtpInstanceData(Models.xpo.FtpCredential rec)
        {
            RootDirectories = new List<string>();
            CredentialsDecrypted = EncryptionEngine.DecryptKVP(new KeyValuePair<string, string>(rec.UserName, rec.Password));
            Host = rec.FtpHost;
            Nickname = rec.Nickname;
            NotFoundFile = rec.NotFoundFile;
            Oid = rec.Oid;
            FolderPath = new DefaultFolderPaths(this);
        }
        public int Oid { get; }
        public DefaultFolderPaths FolderPath { get; }
        public string Nickname { get; }
        public string Host { get; }
        public string NotFoundFile { get; }
        public KeyValuePair<string, string> CredentialsDecrypted { get; }
        public List<string> RootDirectories { get; set; }
    }
}
