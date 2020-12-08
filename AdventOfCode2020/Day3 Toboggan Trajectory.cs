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
            //new Day3P1().part1();

            Take2.solve(@"c:\temp\day3input.txt");

            Console.WriteLine("\n\nDay 3");
            Console.WriteLine("(press any key to continue)");
            Console.ReadKey();
            Console.Clear();
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
                int down = 1;
                right = 3; //3,1=218
                right = 5;//5,1=65
                right = 7;//7,1=82
                right = 1;//1,2=43
                //down = 2;
                right = 3;
                //77*218*65*82*43  //ran it different times
                //70*29*76*63*220**
                //70*220*63*76*29
                int skip = 1;
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

                Console.WriteLine($"\nRight: {right} Down: {down}  Trees: {trees}");
                //Console.ReadKey();
            }

        }

        class Take2
        {
            public static void solve(string filename)
            {
                var bytes = File.ReadAllBytes(filename);
                int width = -1;
                for (int i = 0; i < bytes.Length; i++) {
                    if (bytes[i] == '\n')
                    {
                        width = i;
                        break;
                    }
                }

                Console.WriteLine(countTrees(bytes,width,3,1));
            }
            static long countTrees(byte[] field, int width, int right, int down)
            {
                int treecount = 0;
                for(long pos = 0;   pos < field.Length; pos += right + down * width)
                {
                    switch(field[pos])
                    {
                        case (byte)'\n':
                            pos++;
                            break;
                        case (byte)'\r':
                            pos+=2;
                            break;
                    }

                    Console.WriteLine($"{(char)field[pos]} {pos} {pos % width}");
                    if (field[pos] == '#')
                        treecount++;
                }
                return treecount;
            }

        }
    }
}
