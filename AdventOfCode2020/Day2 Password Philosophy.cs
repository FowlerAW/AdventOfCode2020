using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Day2
    {
        public static void demo()
        {
            new Day2P1().part1();
            new Day2P1().part2();
            new day2take2().part1();
        }

        class Day2P1
        {
            string filename = @"c:\temp\day2input.txt";
            string testfilename = @"c:\temp\day2test1input.txt";
            public Day2P1()
            {

            }
            
            public void part1()
            {
                var lines = File.ReadAllText(filename).Trim().Split('\n');

                long validcount = 0;

                foreach(var line in lines)
                {
                    var pass = line.Split(':')[1];
                    var format = line.Split(':')[0];
                    var letter = char.Parse(format.Split(' ')[1]);
                    var range = format.Split(' ')[0];
                    var min = range.Split('-')[0];
                    var max = range.Split('-')[1];

                    int imin = int.Parse(min);
                    int imax = int.Parse(max);

                    int charcount = pass.Count(c => c == letter);

                    if (charcount <= imax && charcount >= imin)
                        validcount++;

                }


                Console.WriteLine(validcount);
                //Console.ReadKey();
            }


            public void part2()
            {
                var lines = File.ReadAllText(filename).Trim().Split('\n');

                long validcount = 0;

                foreach (var line in lines)
                {
                    var pass = line.Split(':')[1];
                    var format = line.Split(':')[0];
                    var letter = char.Parse(format.Split(' ')[1]);
                    var range = format.Split(' ')[0];
                    var min = range.Split('-')[0];
                    var max = range.Split('-')[1];

                    int imin = int.Parse(min);
                    int imax = int.Parse(max);

                    int charcount = 0;

                    if (pass[imin]==letter)
                        charcount++;

                    if (pass[imax]==letter)
                        charcount++;

                    if (charcount == 1)
                        validcount++;
                }


                Console.WriteLine(validcount);
                //Console.ReadKey();
            }

        }

        class day2take2
        {
            string filename = @"c:\temp\day2input.txt";
            public void part1() {
                var lines = File.ReadAllText(filename).Trim().Split('\n');

                long p1count = 0;
                long p2count = 0;
                foreach (var line in lines) {
                    var tokens= line.Split(new char[]{'-',' ',':','\r'});
                    int min = int.Parse(tokens[0]);
                    int max = int.Parse(tokens[1]);
                    char letter = char.Parse(tokens[2]);
                    string pass = tokens[4];

                    int p1c = pass.Count(c => c == letter);
                    if (p1c >= min && p1c <= max)
                        p1count++;

                    if ((pass[min - 1] == letter) ^ (pass[max - 1] == letter))
                        p2count++;

                    }

                Console.WriteLine($"Part1: {p1count} valid Passwords\nPart2: {p2count} valid passwords.");
            }

        }
    }
}
