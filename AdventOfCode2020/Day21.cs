using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Day21
    {
        public static void demo()
        {
            new Take1().part1();
        }

        class Take1
        {
            string filename = @"c:\temp\Day21input.txt";
            string testfilename = @"c:\temp\Day21test1input.txt";


            public void part1()
            {
                long result = 0;
                var dd= new Dictionary<char, int>();

                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (var line in lines)
                {

                    if (string.IsNullOrEmpty(line))
                    { }

                    Console.WriteLine(line);

                    foreach (char c in line)
                    {

                    }

                }

                Console.WriteLine(result);
            }
        }
    }
}
