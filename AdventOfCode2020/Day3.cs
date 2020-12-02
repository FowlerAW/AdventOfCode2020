using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Day3
    {
        public static void demo()
        {
            new Day3P1().part1();
            //new Day3P2().part1();
        }

        class Day3P1
        {
            string filename = @"c:\temp\day3input.txt";
            string testfilename = @"c:\temp\day3test1input.txt";
            public Day3P1()
            {

            }

            public void part1()
            {
                var lines = File.ReadAllText(testfilename).Trim().Split('\n');

                string result="foo";

                Console.WriteLine(result);
                //Console.ReadKey();
            }


            public void part2()
            {
                var lines = File.ReadAllText(testfilename).Trim().Split('\n');

                string result="bar";

                Console.WriteLine(result);
                //Console.ReadKey();
            }

        }

        class day3take2
        {
            
        }
    }
}
