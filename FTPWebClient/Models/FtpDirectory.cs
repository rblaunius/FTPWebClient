using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPWebClient.Models
{
    public class FtpDirectory
    {
        public string Path { get; set; }
        public FtpFile[] Files { get; set; }
        public FtpDirectory[] SubDirectories { get; set; }
    }
}
