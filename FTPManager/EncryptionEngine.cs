using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager
{
    public static class EncryptionEngine
    {
        public static KeyValuePair<string, string> DecryptKVP(KeyValuePair<string, string> kvp)
        {
            return new KeyValuePair<string, string>(Decrypt(kvp.Key), Decrypt(kvp.Value));
        }
        public static KeyValuePair<string, string> EncryptKVP(KeyValuePair<string, string> kvp)
        {
            return new KeyValuePair<string, string>(Encrypt(kvp.Key), Encrypt(kvp.Value));
        }

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
        private static string key = "xa;lsdkghklqwegbasklqyn78]";
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
