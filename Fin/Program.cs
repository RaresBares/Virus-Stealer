using System;
using System.IO;


namespace Fin
{
    internal class Program
    {
        public static void Main(string[] args)
        {
      
            Console.Out.WriteLine(Path.GetTempPath().getP);
            Console.Out.WriteLine(Path.GetFullPath(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/").ToString()));
        }
    }
}