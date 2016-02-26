using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DoChoiOTo
{
    public class Utilities
    {
        public const string AlertJs = "<script> alert('{0}'); </script>";
        public static StringCollection ImageFileExtension = new StringCollection()
        {
            ".jpg",
            ".png",
            ".gif"
        };

        public static string CreateFileURL(string fileName)
        {
            var filePath = string.Format("{0}{1}\\{2}{3}", AppDomain.CurrentDomain.BaseDirectory, "imagesUpload",DateTime.Now.ToString("yyyyMMddhhmmss"), fileName);
            return filePath;
        }
    }
}