using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Day6
    {
        public static void demo()
        {
            Console.WriteLine("Day 6\n" +
                "Keeping track of the number of questions answered." +
                "\n\nI started by adding each char to a hashset and adding its count to \n" +
                "a running total in between groups, then clearing the set for the next group.\n" +
                "\n" +
                "Part 2 required updating the set to a dictionary and keeping a count of the\n" +
                "number in the group and the number of times the question was answered.\n" +
                "Then only incrementing the total if those numbers matched.\n" +
                "\n" +
                "The group pattern in the input was similar to Day 5 but it was faster to\n" +
                "rewrite the code instead of extracting it from the previous solution.\n" +
                "I ran into an issue in the previous day where the last group was not added\n" +
                "to the total so I added outputs that would allow me to debug immediately\n" +
                "and confirm if groups were counted correctly, I ended up doign the last\n" +
                "groups manually to enter my answer.\n" +
                "\n" +
                "Part 1: 08:35  rank 3000\n" +
                "Part 2: 14:25  rank 2357\n" +
                "\n" +
                "(press any key to continue)");
            Console.ReadKey();
            



            new Take1().part1();

            Console.WriteLine("\n\nDay 6");
            Console.WriteLine("(press any key to continue)");
            Console.ReadKey();
            Console.Clear();

        }

        class Take1
        {
            string filename = @"c:\temp\Day6input.txt";
            string testfilename = @"c:\temp\Day6test1input.txt";


            public void part1()
            {

                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                var alpha = new Dictionary<char, int>();
                long p1sum = 0;
                long sum = 0;
                int groupcount = 0;
                foreach (var line in lines)
                {

                    if (string.IsNullOrEmpty(line))
                    {
                        p1sum += alpha.Count();
                        Console.WriteLine($"Part 1 +{alpha.Count()} total {p1sum}\n");

                        foreach (var kvp in alpha)
                        {
                            Console.Write($"{kvp.Key}: {kvp.Value} / {groupcount} ");
                            if (kvp.Value == groupcount)
                            {
                                sum++;
                                Console.WriteLine("+1");
                            }
                            else { Console.WriteLine(); }
                        }

                        Console.WriteLine($"Part 2 total {sum}\n");
                        alpha.Clear();
                        groupcount = 0;
                    }
                    else
                    {
                        groupcount++;
                    }

                    foreach(char c in line)
                    {
                        if (alpha.ContainsKey(c))
                        {
                            alpha[c]++;
                        }
                        else { alpha.Add(c, 1); }
                    }
                        Console.WriteLine(line);

                }

                //add totals again, for last group
                p1sum += alpha.Count();
                Console.WriteLine($"Part 1 +{alpha.Count()} total {p1sum}\n");
                foreach (var kvp in alpha)
                {

                    Console.WriteLine($"{kvp.Key}: {kvp.Value} / {groupcount} ");
                    if (kvp.Value == groupcount)
                    {
                        sum++;
                        Console.Write("+1");
                    }
                }

                Console.WriteLine($"total {sum}\n");
                Console.WriteLine($"Part 1 total {p1sum}\n");
            }
        }
    }
}