using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using FTPManager.Models.xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager
{
    public class XpoHelper
    {
        public static Type[] PersistentTypes
        {
            get
            {
                return new Type[]
                {
                    typeof(FtpCredential)
                };
            }
        }

        public static string GetXmlConnectionString(string fullPath)
        {
            return $"XpoProvider=InMemoryDataStore; Data Source={fullPath}; Read Only=false;";
        }
        public static string GetXmlConnectionString(int iteration = 0)
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            fullPath = Path.Combine(fullPath, "Launius Enterprises");
            if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
            fullPath = Path.Combine(fullPath, $"{((typeof(XpoHelper).Namespace) == null ? "Data" : typeof(XpoHelper).Namespace)}{(iteration > 0 ? iteration : null)}.xml");
            return GetXmlConnectionString(fullPath);
        }
        public static XmlDbConnection Connect(string connectionString)
        {
            XmlDbConnection rtn = XmlDbConnection.Create(connectionString);
            if (!string.IsNullOrEmpty(rtn.ConStr))
            {
                try
                {
                    var provider = XpoDefault.GetConnectionProvider(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
                    var dictionary = new ReflectionDictionary();
                    dictionary.GetDataStoreSchema(PersistentTypes);
                    XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, provider);
                    XpoDefault.Session = null;
                    UnitOfWork uow = new UnitOfWork();
                    uow.UpdateSchema();
                    uow.Dispose();
                    rtn.IsSuccessful = true;
                }
                catch (Exception x) { rtn.IsSuccessful = false; rtn.ErrMsg = x.Message; }
            }
            else
            {
                rtn.IsSuccessful = false;
                rtn.ErrMsg = "Connection string cannot be empty.";
            }
            return rtn;
        }
        public static bool CheckIfCredentialExists(string nickname, int excludeOid)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    return uow.Query<FtpCredential>().Where(x => x.Nickname == nickname && x.Oid != excludeOid).Any();
                }
            }
            catch
            {
                return false;
            }
        }
        public class XmlDbConnection
        {
            public bool IsSuccessful { get; internal set; }
            public string ConStr { get; internal set; }
            public string ErrMsg { get; internal set; }
            static internal XmlDbConnection Create(string conStr)
            {
                return new XmlDbConnection()
                {
                    IsSuccessful = false,
                    ConStr = conStr,
                };
            }

        }
    }
}
