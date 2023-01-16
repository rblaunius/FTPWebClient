using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager
{
    public class Cache
    {
        public Cache()
        {
            this.FilesByServer = new Hashtable();
        }
        /// <summary>
        /// The hash key is the server nickname, value is List<Models.FTPDirectory>
        /// </summary>
        public Hashtable FilesByServer { get; set; }

        public void Clear()
        {
            this.FilesByServer = new Hashtable();
        }
        public void Clear(string server)
        {
            if (this.FilesByServer != null)
                if (this.FilesByServer.ContainsKey(server)) 
                    this.FilesByServer.Remove(server);
        }
    }
}
