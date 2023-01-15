using DevExpress.Xpo;
using System;

namespace FTPWebClient.Models.xpo
{
    public class FtpCredentials : XPObject
    {
        public FtpCredentials(Session session) : base(session) { }

        public static FtpCredentials Create(UnitOfWork uow, string ftpHost, string path = "/", string userName = "", string pw = "")
        {
            FtpCredentials rtn = new FtpCredentials(uow)
            {

            };

            return rtn;
        }


        string nickname;
        string notFoundFile;
        string password;
        string userName;
        string fileUploadPath;
        string ftpHost;


        [Size(SizeAttribute.Unlimited)]
        public string Nickname
        {
            get => nickname;
            set => SetPropertyValue(nameof(Nickname), ref nickname, value);
        }

        [Size(SizeAttribute.Unlimited)]
        public string FtpHost
        {
            get => ftpHost;
            set => SetPropertyValue(nameof(FtpHost), ref ftpHost, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string FileUploadPath
        {
            get => fileUploadPath;
            set => SetPropertyValue(nameof(FileUploadPath), ref fileUploadPath, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string UserName
        {
            get => userName;
            set => SetPropertyValue(nameof(UserName), ref userName, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string Password
        {
            get => password;
            set => SetPropertyValue(nameof(Password), ref password, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string NotFoundFile
        {
            get => notFoundFile;
            set => SetPropertyValue(nameof(NotFoundFile), ref notFoundFile, value);
        }

    }
}