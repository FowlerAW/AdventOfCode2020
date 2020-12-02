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
            Console.WriteLine("Day1");
            Console.WriteLine($"Part 1 - simple*: {Day1Take1.Part1()}");
            Console.WriteLine($"Part 1 - retry: {new Take2(f).Part1()}");
            Console.WriteLine($"Part 2 - simple*: {Day1Take1.Part2()}");
            Console.WriteLine($"Part 2 - retry: {new Take2(f).Part2()}");
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
                            Console.WriteLine($"{i}: {nums[i]}");
                            Console.WriteLine($"{j}: {nums[j]}");
                            Console.WriteLine(nums[i] + nums[j]);
                            Console.WriteLine(nums[i] * nums[j]);
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
                                Console.WriteLine($"{i}: {nums[i]}");
                                Console.WriteLine($"{j}: {nums[j]}");
                                Console.WriteLine($"{k}: {nums[k]}");
                                Console.WriteLine(nums[i] + nums[j] + nums[k]);
                                Console.WriteLine(nums[i] * nums[j] * nums[k]);
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

                return productWithSum(_target);
            }

        }

    }

}
