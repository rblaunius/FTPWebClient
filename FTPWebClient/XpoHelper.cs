using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using FTPWebClient.Models.xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FTPWebClient
{
    public class XpoHelper
    {
        public static Type[] PersistentTypes
        {
            get
            {
                return new Type[]
                {
                    typeof(FtpCredentials)
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
        public static Connection Connect(string connectionString)
        {
            Connection rtn = Connection.Create(connectionString);
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
        public class Connection
        {
            public bool IsSuccessful { get; internal set; }
            public string? ConStr { get; internal set; }
            public string? ErrMsg { get; internal set; }
            static internal Connection Create(string conStr)
            {
                return new Connection()
                {
                     IsSuccessful = false,
                      ConStr = conStr,
                }; 
            }

        }

        public static class EncryptionEngine
        {
            public static string Encrypt(string plainText)
            {
                try
                {
                    if (!string.IsNullOrEmpty(plainText))
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.KeySize = 256;
                            aes.Key = Get256Key(key);
                            aes.IV = new byte[16];
                            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                            using (MemoryStream mem = new MemoryStream())
                            {
                                using (CryptoStream c = new CryptoStream((Stream)mem, encryptor, CryptoStreamMode.Write))
                                {
                                    using (StreamWriter writer = new StreamWriter((Stream)c))
                                    {
                                        writer.Write(plainText);
                                    }
                                    plainText = Convert.ToBase64String(mem.ToArray());
                                }
                            }
                        }
                    }
                }
                catch { }
                return plainText;
            }
            private static  string key = "xa;lsdkghklqwegbasklqyn78]";
            public static string Decrypt(string cypherText)
            {
                try
                {
                    if (!string.IsNullOrEmpty(cypherText))
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.KeySize = 256;
                            aes.Key = Get256Key(key);
                            aes.IV = new byte[16];
                            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                            using (MemoryStream mem = new MemoryStream(Convert.FromBase64String(cypherText)))
                            {
                                using (CryptoStream c = new CryptoStream((Stream)mem, decryptor, CryptoStreamMode.Read))
                                {
                                    using (StreamReader read = new StreamReader((Stream)c))
                                    {
                                        return read.ReadToEnd();
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
                return cypherText;
            }
            private static byte[] Get256Key(string key)
            {
                byte[] rtn = new byte[32];
                byte[] encoded = Encoding.UTF8.GetBytes(key);
                for (int i = 0; i < encoded.Length; i++)
                {
                    if (i >= 32) break;
                    else
                    {
                        rtn[i] = encoded[i];
                    }
                }
                return rtn;
            }
        }
    }
}
