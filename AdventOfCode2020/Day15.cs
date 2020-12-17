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
    class Day15
    {
        public static void demo()
        {
            new Take1().part1();
        }

        class Take1
        {
            string filename = @"c:\temp\Day15input.txt";
            string testfilename = @"c:\temp\Day15test1input.txt";


            public void part1()
            {
                
                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    solveP1(line.Split(',').Select(x=>int.Parse(x)).ToList(), 2020);
                    solveP1(line.Split(',').Select(x => int.Parse(x)).ToList(), 30000000);
                }

                
            }


            
            
            private void solveP1(List<int> nums, int target)
            {
                var theLastTurnThisNumberWasSaid = new Dictionary<int, int>();
                
                for(int i=1;i<nums.Count;i++)
                {
                    theLastTurnThisNumberWasSaid[nums[i-1]] = i;
                    Console.WriteLine(i + ": " + nums[i-1]);
                }

                int saidLast = nums[nums.Count - 1];
                Console.WriteLine(nums.Count + ": " + saidLast);
                int currentTurn = nums.Count+1;

                while (currentTurn <= target)
                {
                    if (!theLastTurnThisNumberWasSaid.ContainsKey(saidLast))
                    {                      
                        theLastTurnThisNumberWasSaid[saidLast] = currentTurn-1;
                        saidLast = 0;
                        //Console.WriteLine(currentTurn + ": " + saidLast);
                        currentTurn++;
                    }
                    else
                    {
                        int sayNext = currentTurn - theLastTurnThisNumberWasSaid[saidLast]-1;
                        theLastTurnThisNumberWasSaid[saidLast]=currentTurn-1;
                        saidLast = sayNext;
                       // Console.WriteLine(currentTurn + ": " + saidLast);
                        currentTurn++;
                    }
                }
            Console.WriteLine(currentTurn + ": " + saidLast);
            }
        }
    }
}
