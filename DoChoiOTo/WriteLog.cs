using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DoChoiOTo
{
    public class WriteLog
    {
        public const string LogFolder = "Logs";
        /// <summary>
        /// This is method write log when run error
        /// </summary>
        /// <param name="strTitle">
        /// Logger title
        /// </param>
        /// <param name="strMessage">
        /// Logger message
        /// </param>
        public static void WriteLogEntry(string strTitle, string strMessage, string path)
        {
            string folderRoot = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path))
            {
                folderRoot = path;
            }
            string folderLogPath = string.Format("{0}\\{1}", folderRoot, LogFolder);

            try
            {
                string fileLogPath = string.Format("{0}\\LogFile_{1}.log", folderLogPath, DateTime.Now.ToString("dd-MM-yyyy"));
                if (!File.Exists(fileLogPath))
                {
                    if (!Directory.Exists(folderLogPath))
                    {
                        Directory.CreateDirectory(folderLogPath);
                    }
                    File.WriteAllText(fileLogPath, string.Empty);
                }
                var writer = new StreamWriter(fileLogPath, true);
                writer.WriteLine(string.Format("{0}:-{1}{2}{3}", DateTime.Now, strTitle, Environment.NewLine, strMessage));
                writer.Close();
            }
            catch
            {
                // No need to catch this exception
            }

        }

        /// <summary>
        /// This is method write log when run error
        /// </summary>
        /// <param name="strTitle">
        /// Logger title
        /// </param>
        /// <param name="strMessage">
        /// Logger message
        /// </param>
        public static void WriteLogEntry(string strTitle, string strMessage)
        {
            WriteLogEntry(strTitle, strMessage, string.Empty);
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="ex"></param>
        public static void WriteLogEntry(string strTitle, Exception ex)
        {
            WriteLogEntry(strTitle, ex.Message + " - " + ex.StackTrace, string.Empty);
        }
    }
}