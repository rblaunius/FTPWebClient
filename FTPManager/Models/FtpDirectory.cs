using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager.Models
{
    public class FtpDirectory
    {
        public FtpDirectory(string path)
        {
            Path = path;
        }


        public string Path { get; set; }
        public static List<FtpDirectory> Convert(List<string> rootDirectories)
        {
            List<FtpDirectory> rtn = new List<FtpDirectory>();
            foreach (string item in rootDirectories)
            {
                rtn.Add(new FtpDirectory(item));
            }
            return rtn;
        }
    }
}
