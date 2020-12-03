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
            Console.WriteLine("\nDay3");
            new Day3P1().part1();
        }

        class Day3P1
        {
            string filename = @"c:\temp\day3input.txt";
            string testfilename = @"c:\temp\day3test1input.txt";
            public void part1()
            {
                var lines = Helpers.getFileAsStrings(filename);

                int p = 0;
                int width = lines[0].Length;
                int trees = 0;
                int right = 1;//1,1=77
                //int right = 3; //3,1=218
                right = 5;//5,1=65
                right = 7;//7,1=82
                right = 1;//1,2=43
                int down = 1;
                down = 2;
                int skip = 1;
                //77*218*65*82*43  //ran it different times
                foreach(var line in lines)
                {
                    if (--skip == 0)
                    {
                        StringBuilder s = new StringBuilder(line);
                        if (line[p] == '#')
                        {
                            trees++;
                            s[p] = 'X';
                        }
                        else
                        {
                            s[p] = 'O';
                        }

                        Console.WriteLine(s);

                        skip = down;
                        p += right;
                        if (p >= width)
                            p -= width;
                    }
                    else
                    { Console.WriteLine(line); }
                }

                Console.WriteLine(trees);
                //Console.ReadKey();
            }

        }
    }
}
