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
    class Day10
    {
        public static void demo()
        {
            Take2.part2();
        }

        class Take1
        {
            string filename = @"c:\temp\Day10input.txt";
            string testfilename = @"c:\temp\Day10test1input.txt";


            public void part1()
            {
                var dd = new Dictionary<char, int>();

                var nums = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None)
                    .Select(x => int.Parse(x)).ToList();
                nums.Sort();

                int[] diffs = new int[4];

                int last = 0;
                foreach (var num in nums)
                {
                    var diff = num - last;
                    diffs[diff]++;
                    last = num;
                }
                diffs[3]++;


                Console.WriteLine(diffs[1]*diffs[3]);
            }

            public void part2()
            {
                var inputValues = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None)
                    .Select(x => int.Parse(x)).ToList();
                inputValues.Sort();  //don't actually need to sort it....
                inputValues.Insert(0, 0);
                inputValues.Append(inputValues.Last()+3);

                var pathsToNode = inputValues.ToDictionary(key => key, value => 0L);
                pathsToNode[0] = 1;

                foreach(var value in inputValues)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (pathsToNode.ContainsKey(value + i))
                        {
                            pathsToNode[value + i] += pathsToNode[value];
                        }
                    }
                }

                Console.WriteLine(pathsToNode[inputValues.Last()]);
            }
        }

        class Take2
        {
            public static void part2()
            {
                Dictionary<int, long> pathsToNode = File.ReadAllText(@"c:\temp\Day10input.txt").Trim()
                    .Split(new string[] { "\r\n" }, StringSplitOptions.None)
                    .ToDictionary(key => int.Parse(key), value => 0L);
                pathsToNode.Add(0, 1);
                int[] diffcounts = new int[3];
                int value = -3;//hack
                int lowestNextValue=0;
                do
                {
                    diffcounts[lowestNextValue - value-1]++;
                    value = lowestNextValue;
                    lowestNextValue = -1;
                    for (int i= 3; i > 0; i--)
                    {
                        int nextValue = value + i;
                        if (pathsToNode.ContainsKey(nextValue))
                        {
                            lowestNextValue = nextValue;   
                            pathsToNode[nextValue] += pathsToNode[value];
                        }
                    }
                } while (lowestNextValue > -1);
                Console.WriteLine("Diff 1 count: " + diffcounts[0]);
                Console.WriteLine("Diff 2 count: " + diffcounts[1]);
                Console.WriteLine("Diff 3 count: " + diffcounts[2]);
                Console.WriteLine("Part 1: " + diffcounts[0]* diffcounts[2]);
                Console.WriteLine("Part 2: " + pathsToNode[value]);
            }
        }
    }
}
