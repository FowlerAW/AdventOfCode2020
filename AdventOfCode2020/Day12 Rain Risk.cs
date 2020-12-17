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
    class Day12
    {
        public static void demo()
        {
            new Take1().part2();
        }

        class Take1
        {
            string filename = @"c:\temp\Day12input.txt";
            string testfilename = @"c:\temp\Day12test1input.txt";


            public void part1()
            {
                long result = 0;
                
                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                int North = 0;
                int East = 0;
                int Degrees = 0;

                var cardinals = new Dictionary<int, char>();
                cardinals[0] = 'E';
                cardinals[90] = 'S';
                cardinals[180] = 'W';
                cardinals[270] = 'N';

                foreach (var line in lines)
                {
                    

                    int num = int.Parse(line.Substring(1));
                    char cmd = line[0];
                    if (cmd == 'F')
                        cmd = cardinals[Degrees];

                    if (cmd == 'N')
                        North += num;
                    else if (cmd == 'S')
                        North -= num;
                    else if (cmd == 'E')
                        East += num;
                    else if (cmd == 'W')
                        East -= num;
                    else if (cmd == 'R')
                        Degrees = (Degrees + num) % 360;
                        else if (cmd == 'L')
                    {
                        Degrees = (Degrees + 360 - num) % 360;
                    }

                    Console.WriteLine($"{line}: N{North} E{East} Facing {cardinals[Degrees]}");
                }

                Console.WriteLine(Math.Abs(North) + Math.Abs(East));
            }

            public void part2()
            {
                long result = 0;

                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                int sn = 0;
                int se = 0;

                int North = 1;
                int East = 10;
                int Degrees = 0;

                var cardinals = new Dictionary<int, char>();
                cardinals[0] = 'E';
                cardinals[90] = 'S';
                cardinals[180] = 'W';
                cardinals[270] = 'N';

                foreach (var line in lines)
                {


                    int num = int.Parse(line.Substring(1));
                    char cmd = line[0];
                    if (cmd == 'F')
                    {
                        sn += North * num;
                        se += East * num;
                    }else if (cmd == 'N')
                        North += num;
                    else if (cmd == 'S')
                        North -= num;
                    else if (cmd == 'E')
                        East += num;
                    else if (cmd == 'W')
                        East -= num;
                    else if (cmd == 'R')
                    {
                        for (int i = 0; i < num; i+=90)
                        {
                            int temp = North;
                            North = -East;
                            East = temp;
                        }
                    }
                    else if (cmd == 'L')
                    {
                        for (int i = 0; i < num; i+=90)
                        {
                            int temp = East;
                            East = -North;
                            North = temp;
                        }
                    }

                    Console.WriteLine($"{line}: N{North} E{East} SN{sn} SE{se}");
                    //21293 wrong
                    //6575
                }

                Console.WriteLine(Math.Abs(sn) + Math.Abs(se));
            }
        }
    }
}
