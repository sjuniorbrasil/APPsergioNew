using System;
using System.IO;

namespace Produsys
{
    public class DllProdusys
    {
        public void ExcluiIbexpert()
        {
            string getuser = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "AppData";
            string completa = getuser + @"\Roaming\HK-Software\IBExpert\ibexpert.dir";            
            File.Delete(completa);
        }

    }
}
