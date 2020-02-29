using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG_Installer
{
    public static class Logger
    {
        public const string LOGFILE = "STG-Installer.log";

        public static void PrepareLog()
        {
            if (File.Exists(LOGFILE))
                File.Delete(LOGFILE);
        }

        public static void AppendLog(string Text)
        {
            File.AppendAllText(LOGFILE, string.Format("{0} - {1}\n", DateTime.UtcNow.ToShortTimeString(), Text));
        }
    }
}
