using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode2020
{
    class Helpers
    {
        public static string[] getFileAsStrings(string filename)
        {
            var delimiters = new string[] { "\r\n","\n" };
            return File.ReadAllText(filename).Trim().Split(delimiters, StringSplitOptions.None);
        }

        public static void downloadFileByDay(int day)
        {


        }
    }
}
