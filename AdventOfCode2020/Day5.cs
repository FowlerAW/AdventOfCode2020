using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Day5
    {
        public static void demo()
        {
            new Day5P1().part1();
            //new Day5P2().part1();
        }

        class Day5P1
        {
            string filename = @"c:\temp\Day5input.txt";
            string testfilename = @"c:\temp\Day5test1input.txt";
            public Day5P1()
            {

            }

            public void part1()
            {
                var lines = File.ReadAllText(testfilename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                string result = "foo";

                Console.WriteLine(result);
                //Console.ReadKey();
            }


            public void part2()
            {
                var lines = File.ReadAllText(testfilename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                string result = "bar";

                Console.WriteLine(result);
                //Console.ReadKey();
            }

        }

        class Day5take2
        {

        }
    }
}
