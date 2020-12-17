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
    class Day13
    {
        public static void demo()
        {
            new Take1().part2take2();
        }

        class Take1
        {
            string filename = @"c:\temp\Day13input.txt";
            string testfilename = @"c:\temp\Day13test1input.txt";


            public void part1()
            {
                long result = 0;
                var dd = new Dictionary<char, int>();

                string[] lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                int timestamp = int.Parse(lines[0]);

                List<Tuple<int, int>> busses = new List<Tuple<int, int>>();
                var rawbusses= lines[1].Split(',');
                for (int i=0;i<rawbusses.Length;i++)
                {
                    int newbus;
                    if(int.TryParse(rawbusses[i], out newbus))
                    {
                        busses.Add(new Tuple<int,int>(newbus,i));
                        Console.Write(" " + newbus);
                    }
                }

                Console.WriteLine();
                for(int i = 0; i < 1000; i++)
                {
                    foreach(var bus in busses)
                    {
                        if((timestamp+i)%bus.Item1==0)
                        {
                            Console.WriteLine(i * bus.Item1);
                            return;
                        }
                    }
                }

                Console.WriteLine(result);
            }
            public void part2()
            {
                var busses = new SortedDictionary<int, int>();
                {
                    string[] lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    


                    var rawbusses = lines[1].Split(',');
                    for (int i = 0; i < rawbusses.Length; i++)
                    {
                        int newbus;
                        if (int.TryParse(rawbusses[i], out newbus))
                        {
                            busses.Add(newbus, i);
                            Console.WriteLine(newbus + " " + i);
                        }
                    }
                }

                var keys = busses.Keys.ToArray();
                int len = keys.Length - 1;
                long timestamp = 0;
                  timestamp = 100000000000000;
                //timestamp = 102493008563371
                bool keepGoing = true;
                while (keepGoing)
                {
                    keepGoing = false;
                    timestamp += keys[len];
                    long offset = timestamp - busses[keys[len]];
                    for(int i = len - 1; i >= 0; i--)
                    {

                        long target = offset + busses[keys[i]];
                        if (target % keys[i] != 0)
                        {
                            keepGoing = true;
                            break;
                        }

                    }

                }
                Console.WriteLine(timestamp - busses[keys[len]]);
                //not 300734823787057

            }
            public void part2take2()
            {
                var busses = new SortedDictionary<int, int>();
                {
                    string[] lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);




                    var rawbusses = lines[1].Split(',');
                    for (int i = 0; i < rawbusses.Length; i++)
                    {
                        int newbus;
                        if (int.TryParse(rawbusses[i], out newbus))
                        {
                            busses.Add(newbus, i);
                            Console.WriteLine(newbus + " " + i);
                        }
                    }
                }

                var keys = busses.Keys.ToArray();
                int len = keys.Length - 1;
                long timestamp = 0;
                timestamp = 100000000000000;
                //timestamp = 102493008563371
                bool keepGoing = true;
                while (keepGoing)
                {
                    keepGoing = false;
                    timestamp += keys[len];
                    long offset = timestamp - busses[keys[len]];
                    for (int i = len - 1; i >= 0; i--)
                    {

                        long target = offset + busses[keys[i]];
                        if (target % keys[i] != 0)
                        {
                            keepGoing = true;
                            break;
                        }

                    }

                }
                Console.WriteLine(timestamp - busses[keys[len]]);
                //not 300734823787057

            }

        }
    }
}
