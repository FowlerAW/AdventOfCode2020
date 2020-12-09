using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Day9
    {
        public static void demo()
        {
            new Take1().part2();
        }

        class Take1
        {
            string filename = @"c:\temp\Day9input.txt";
            string testfilename = @"c:\temp\Day9test1input.txt";

            List<ulong> nums;

            public Take1()
            {
                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                nums = lines.Select(x => UInt64.Parse(x)).ToList();
            }

            public UInt64 part1()
            {
                int oldest = 0;

                var hs = new HashSet<UInt64>();
                for (int n = 0; n < 25; n++)
                {
                    hs.Add(nums[n]);
                }

                for (int n = 25;n<=1001;n++)
                {
                    var target = nums[n];
                    bool valid = false;
                    for(int i = n - 1; i >= oldest; i--)
                    {
                        if(hs.Contains(target-nums[i]))
                        {
                            valid = true;
                            continue;
                        }
                    }
                    if (!valid)
                    {
                        //Console.WriteLine("Invalid: " + nums[n]);
                        return nums[n];
                    }

                    hs.Remove(nums[oldest]);
                    oldest++;
                    hs.Add(nums[n]);
                }

                return 0;
            }

            public void part2()
            {
                UInt64 target = part1();
                Console.WriteLine("Part 1: " +target);

                
                int oldest = 0;
                int newest = 1;
                UInt64 sum = nums[oldest] + nums[newest];

                while (sum != target)
                {
                    if (sum > target)
                    {
                        sum -= nums[oldest++];
                    }
                    else
                    {
                        sum += nums[++newest];
                    }
                }

                UInt64 max = UInt64.MinValue;
                UInt64 min = UInt64.MaxValue;
                for (int i = oldest; i <= newest; i++)
                {
                    if (nums[i] < min)
                        min = nums[i];

                    if (nums[i] > max)
                        max = nums[i];
                }

                Console.WriteLine("Part 2: " + (min+max));

            return;
            }
        }
    }
}
