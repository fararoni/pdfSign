using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nekdu.FirmaPDF.Util.Extents
{
    public static class StringExtension
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Elipsis(this string text, int lenght)
        {
            string text2 = null;
            if (text.Length > lenght)
            {
                text2 = text.Substring(0, Math.Min(lenght - "...".Length, text.Length)).TrimEnd();
                int num = text2.LastIndexOf(' ');
                if (num > -1)
                {
                    if (num + 2 + "...".Length < lenght)
                    {
                        return text2.Substring(0, num + 2) + "...";
                    }

                    while (num > 2 && text2.Substring(num - 1, 1).StartsWith(" "))
                    {
                        num--;
                    }

                    return text2.Substring(0, num) + "...";
                }

                return text2 + "...";
            }

            return text;
        }

        public static string GetFileDirectory(this string fullPath) {
            FileInfo fi = new FileInfo(fullPath);
            return fi.DirectoryName;
        }

        public static string GetFileName(this string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            return fi.Name;
        }
        public static string GetExtension(this string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            return fi.Extension;
        }
        public static bool GetFileExist(this string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            return fi.Exists;
        }
        public static bool GetIsDirectory(this string fullPath)
        {
            FileAttributes attr = File.GetAttributes(fullPath);
            if (attr.HasFlag(FileAttributes.Directory)) { 
                return true;
            } else {
                return false;
            }

        }

    }
}
