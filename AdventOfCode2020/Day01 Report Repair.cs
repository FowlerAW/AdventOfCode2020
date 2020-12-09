using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day1
    {
        public static void Demo()
        {
            var f = @"c:\temp\day1input.txt";
            Console.WriteLine("Day1 Report Repair");
            Console.WriteLine("Trying to be quick, I wrote a nested loop brute forcer, \n" +
                "but at least I started the inner loop at the outer loop value since the combinations\n" +
                "before that had been checked already, an O(n*log(n)) algorithm.\n");
            Console.WriteLine("Part 1 - simple");
            Day1Take1.Part1();

            Console.WriteLine("\nThen doubled down and added another loop O(n*log(n)*log(n))\n");
            Console.WriteLine($"Part 2 - simple*:");
            Day1Take1.Part2();

            Console.WriteLine("\nSTATS for Day 1:\nPart 1 17:06  Rank 2989\nPart 2 20:34  Rank 2812\n");

            Console.WriteLine("\n(press any key to continue)");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Day 1, take 2\n\nLater I refactored it to run in one pass, adding each value to a hashset\n" +
                "so I could check if the needed value (2020-the current number) has already been seen.\n" +
                "And then I changed the hashset to a bool array with 2020 elements, one for each possible\n" +
                "value.  A much simpler (and faster) hash algorithm.  O(n).\n");

            Console.WriteLine($"Part 1 - retry");
            new Take2(f).Part1();


            Console.WriteLine("\n The part 2 refactor just added a loop to check each third value for the\n" +
                "matching pair in the rest of the data.  This could be done with an extra log(n) time since only \n" +
                "elements after the third number had to be checked.  O(n log(n)).\n\n" +
                "Sorting the list ascending would be an O(n log(n)) operation also, and would make it more likely\n" +
                "to find the correct triplet earlier.  Filtering out values that are too high could help too.\n" +
                "(>2017, or > 2020-smallest value.  Lots of tricks to use here.)\n");
            Console.WriteLine($"\nPart 2 - retry:");
            Console.WriteLine(  new Take2(f).Part2());

            Console.WriteLine("\n(press any key to continue)");
            Console.ReadKey();
            Console.Clear();
        }

        class Day1Take1
        {
            static public int Part1()
            {
                var lines = File.ReadAllText(@"c:\temp\day1input.txt").Trim().Split('\n');
                var nums = lines.Select(x => int.Parse(x)).ToList();

                for (int i = 0; i < nums.Count; i++)
                {
                    for (int j = i + 1; j < nums.Count; j++)
                    {
                        if (nums[i] + nums[j] == 2020)
                        {
                            Console.WriteLine($"index# {i}: {nums[i]}");
                            Console.WriteLine($"index# {j}: {nums[j]}");
                            Console.WriteLine($"Sum: {nums[i] + nums[j]}");
                            Console.WriteLine($"Product: {nums[i] * nums[j]}");
                            return (nums[i] * nums[j]);
                        }
                    }
                }
                return -1;
            }

            static public int Part2()
            {
                var lines = File.ReadAllText(@"c:\temp\day1input.txt").Trim().Split('\n');
                var nums = lines.Select(x => int.Parse(x)).ToList();

                for (int i = 0; i < nums.Count; i++)
                {
                    for (int j = i + 1; j < nums.Count; j++)
                    {
                        for (int k = j + 1; k < nums.Count; k++)
                        {
                            if (nums[i] + nums[j] + nums[k] == 2020)
                            {
                                Console.WriteLine($"index# {i}: {nums[i]}");
                                Console.WriteLine($"index# {j}: {nums[j]}");
                                Console.WriteLine($"index# {k}: {nums[k]}");
                                Console.WriteLine("Sum: " +nums[i] + nums[j] + nums[k]);
                                Console.WriteLine("Product: " + nums[i] * nums[j] * nums[k]);
                                return (nums[i] * nums[j] * nums[k]);
                            }
                        }
                    }
                }
                return -1;
            }
        }

        class Take2
        {
            const int _target = 2020;
            bool[] _exists;
            List<int> _values;
            string _filename;

            public Take2(string filename)
            {
                _exists = new bool[_target];
                _values = new List<int>();
                _filename = filename;
            }
            public int Part2()
            {
                foreach (var s in File.ReadAllText(_filename).Trim().Split('\n'))
                {
                    int num = int.Parse(s);
                    if (num <= 0 || num >= _target)
                    {
                        Console.WriteLine($"Warning: Has out of range {num}");
                        continue;
                    }

                    if (_exists[num])
                    {
                        Console.WriteLine($"Warning: Has duplicates {num}");
                    }

                    var foundIt = productWithSum(_target - num);
                    if (foundIt > 0)
                    {
                        return foundIt * num;
                    }

                    _values.Add(num);
                    _exists[num] = true;
                }

                return -1;
            }

            int productWithSum(int target)
            {
                foreach (var num in _values)
                {
                    if (num >= target)
                        continue;

                    int complement = target - num;
                    if (_exists[complement])
                        return complement * num;
                }
                return -1;
            }

            public int Part1()
            {
                _values = File.ReadAllText(_filename).Trim().Split('\n').Select(x => int.Parse(x)).ToList();

                foreach (var num in _values)
                    _exists[num] = true;

                int result = productWithSum(_target);
                Console.WriteLine(result);
                return result;
            }

        }

    }

}
