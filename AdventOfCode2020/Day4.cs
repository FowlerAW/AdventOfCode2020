using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Day4
    {
        public static void demo()
        {
            new Day4P1().part1();
            //new Day4P2().part1();
        }

        class Day4P1
        {
            string filename = @"c:\temp\Day4input.txt";
            string testfilename = @"c:\temp\Day4test1input.txt";
            public Day4P1()
            {

            }

            public void part1()
            {
                var lines = File.ReadAllText(testfilename).Trim().Split('\n');

                string result = "foo";

                Console.WriteLine(result);
                //Console.ReadKey();
            }


            public void part2()
            {
                var lines = File.ReadAllText(testfilename).Trim().Split('\n');

                string result = "bar";

                Console.WriteLine(result);
                //Console.ReadKey();
            }

        }

        class Day4take2
        {

        }
    }
}
