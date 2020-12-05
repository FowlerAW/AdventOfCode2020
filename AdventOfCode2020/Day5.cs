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

            Console.WriteLine("Day 5.  The first and second rows represent row number, read vertically.  Other characters are column number.  The blank spot is your seat.");
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
                
                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                int[] b = new int[10];
                int[] f = new int[10];
                int[] l = new int[10];
                int[] r = new int[10];

                for(var i = 0; i < 10; i++)
                {
                    b[i] = 0;
                    f[i] = 0;
                    l[i] = 0;
                    r[i] = 0;
                }
                double row,seat,max;
                max = 0;
                foreach (var linex in lines)
                {
                    var line = linex;
                       
                    print(line);

                    

                }
                //not 464 or 468 or 492 or 285
                //print("FBBBBFBRLL", '@');

                Console.SetCursorPosition(0, 10);

                //Console.ReadKey();
            }

            void print(string line, char c = 'X' )
            {
                double row = 0;
                double seat = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (line[i] == 'B')
                        row += Math.Pow(2, (6 - i));

                }
                for (int i = 7; i < 10; i++)
                {
                    if (line[i] == 'R')
                        seat += Math.Pow(2, (9 - i));

                }



                Console.SetCursorPosition((int)row, (int)seat);
                if (c == 'X')
                {
                    switch (seat)
                    {
                        case 0:
                            Console.Write((int)row / 10);
                            break;
                        case 1:
                            Console.Write(row % 10);
                            break;
                        default:
                            Console.Write(seat);
                            break;
                    }
                }
                else
                    Console.Write(c);
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
