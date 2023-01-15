using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager.Models
{
    public enum LastConnectionStatus
    {

    }
    public class Ftp
    {
        public Ftp()
        {
            RootDirectories = new List<FtpDirectory>();
            RootFiles = new List<FtpFile>();
        }
        public int Oid { get; set; }
        public string Nickname { get; set; }
        public string HostFullAddress { get; set; }
        public string NotFoundFile { get; set; }
        public LastConnectionStatus LastConnection { get; set; }
        public KeyValuePair<string, string> Credentials { get; set; }
        public List<FtpDirectory> RootDirectories { get; set; }
        public List<FtpFile> RootFiles { get; set; }
    }
}
