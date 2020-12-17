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
    class Day11
    {
        public static void demo()
        {
            new Take1().part2();
        }

        class Take1
        {
            string filename = @"c:\temp\Day11input.txt";
            string testfilename = @"c:\temp\Day11test1input.txt";


            public void part1()
            {
                long result = 0;
                

                var nextLines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None)
                    .Select(x=>x.ToCharArray()).ToArray();



                char[][] lines;
                int len = nextLines[0].Length-1;


                int changes = 1;
                int occupied =-1;

                while (changes > 0)
                {
                    lines = nextLines.Select(a => a.ToArray()).ToArray();
                    changes = 0;
                    occupied = 0;

                    Console.WriteLine();
                    for (int r = 0; r < lines.Length; r++)
                    {
                        Console.WriteLine(lines[r]);
                        for (int c = 0; c <= len; c++)
                        {
                            if (lines[r][c] != '.')
                            {
                                int seatcount = 0;
                                if (r > 0)
                                {
                                    seatcount += (c > 0) && lines[r - 1][c - 1] == '#' ? 1 : 0;
                                    seatcount += lines[r - 1][c] == '#' ? 1 : 0;
                                    seatcount += (c < len) && lines[r - 1][c + 1] == '#' ? 1 : 0;
                                }

                                seatcount += (c > 0) && lines[r][c - 1] == '#' ? 1 : 0;
                                seatcount += (c < len) && lines[r][c + 1] == '#' ? 1 : 0;

                                if (r < lines.Length - 1)
                                {
                                    seatcount += (c > 0) && lines[r + 1][c - 1] == '#' ? 1 : 0;
                                    seatcount += lines[r + 1][c] == '#' ? 1 : 0;
                                    seatcount += (c < len) && lines[r + 1][c + 1] == '#' ? 1 : 0;
                                }

                                if (lines[r][c] == 'L' && (seatcount == 0)
                                    || lines[r][c] == '#' && (seatcount < 4))
                                {
                                    nextLines[r][c] = '#';
                                    occupied++;
                                    changes += (lines[r][c] == 'L') ? 1 : 0;
                                }
                                else
                                {
                                    nextLines[r][c] = 'L';
                                    changes += (lines[r][c] == '#') ? 1 : 0;
                                }
                            }

                        }

                    }
                  //  Console.ReadKey();
                    

                }


                Console.WriteLine();
                Console.WriteLine(occupied);
            }

            public void part2()
            {
                long result = 0;


                var nextLines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None)
                    .Select(x => x.ToCharArray()).ToArray();



                char[][] lines;
                int len = nextLines[0].Length - 1;


                int changes = 1;
                int occupied = -1;

                while (changes > 0)
                {
                    lines = nextLines.Select(a => a.ToArray()).ToArray();
                    changes = 0;
                    occupied = 0;

                    //Console.WriteLine();
                    for (int r = 0; r < lines.Length; r++)
                    {
                      //  Console.WriteLine(lines[r]);
                        for (int c = 0; c <= len; c++)
                        {
                            if (lines[r][c] != '.')
                            {
                                int seatcount = 0;
                                seatcount += look(lines,r,c,len,-1, -1);
                                seatcount += look(lines,r,c,len,-1,  0);
                                seatcount += look(lines,r,c,len,-1,  1);
                                seatcount += look(lines,r,c,len,0, -1);
                                seatcount += look(lines,r,c,len,0, 1);
                                seatcount += look(lines,r,c,len,1, -1);
                                seatcount += look(lines,r,c,len,1,  0);
                                seatcount += look(lines,r,c,len,1, 1);


                                if (lines[r][c] == 'L' && (seatcount == 0)
                                    || lines[r][c] == '#' && (seatcount < 5))
                                {
                                    nextLines[r][c] = '#';
                                    occupied++;
                                    changes += (lines[r][c] == 'L') ? 1 : 0;
                                }
                                else
                                {
                                    nextLines[r][c] = 'L';
                                    changes += (lines[r][c] == '#') ? 1 : 0;
                                }
                            }

                        }

                    }
                     // Console.ReadKey();


                }


                Console.WriteLine();
                Console.WriteLine(occupied);
            }

            private int look(char[][] lines, int r, int c, int len, int v1, int v2)
            {
                while (true)
                {
                    r += v1;
                    c += v2;
                    if (r < 0 || r > lines.Length-1 || c < 0 || c > len || lines[r][c] == 'L')
                        return 0;

                    if (lines[r][c] == '#')
                        return 1;
                }
            }
        }
    }
}

