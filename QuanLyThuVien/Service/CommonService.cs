using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyThuVien.Service
{
    public class CommonService
    {
        public static string ValidateString(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            string result = "";
            string[] words = s.Split(' ');

            foreach (string word in words)
            { 
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }
            }
            return result.Trim();
        }
    }
}
