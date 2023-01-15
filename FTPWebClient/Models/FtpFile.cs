using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPWebClient.Models
{
    public class FtpFile
    {
        public FtpDirectory DirectoryRef { get; set; }
        public string FullPath { get; set; }
    }
}