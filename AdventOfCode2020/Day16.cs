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
    class Day16
    {
        public static void demo()
        {
            new Take1().part1();
        }

        class Take1
        {
            string filename = @"c:\temp\Day16input.txt";
            string testfilename = @"c:\temp\Day16test1input.txt";

            public void part1()
            {
                bool[,] ruleswork = new bool[19, 19];

                for (int k = 0; k < 19; k++)
                {
                    for (int j = 0; j < 19; j++)
                    {
                        ruleswork[k, j] = true;
                    }
                }

                bool p1 = false;
                long result = 0;
                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                var rules = new List<Tuple<string, int, int, int, int>>();
                int i = 0;
                foreach (var line in lines)
                {
                    i++;
                    if (i < 20)
                    {
                        var parts = line.Split(':')[1].Split('o');
                        var a = int.Parse(parts[0].Split('-')[0].Trim());
                        var b = int.Parse(parts[0].Split('-')[1].Trim());
                        var c = int.Parse(parts[1].Split('-')[0].Substring(2).Trim());
                        var d = int.Parse(parts[1].Split('-')[1].Trim());
                        rules.Add(new(parts[0], a, b, c, d));
                        Console.WriteLine($"Rule {i} {parts[0]}: {a}-{b} or {c}-{d}");
                        continue;
                    }
                    else if (i < 26)
                    {
                        continue;
                    }

                    var nums = line.Split(',').Select(x => int.Parse(x));

                    if (p1)
                        result += nums.Where(num => !rules.Any(rule => matchRule(num, rule))).Sum();

                    if (!p1)
                    {
                        if (nums.Any(num => !rules.Any(rule => matchRule(num, rule))))
                            break;
                        var numarr = nums.ToArray();
                        for (int krule = 0; krule < 19; krule++)
                        {
                            for (int jnum = 0; jnum < 19; jnum++)
                            {
                                if (!ruleswork[krule, jnum] || !matchRule(numarr[krule], rules[jnum]))
                                {
                                    ruleswork[krule, jnum] = false;
                                }
                            }
                        }


                    }

                }
                if (p1)
                {
                    Console.WriteLine(result);
                    //not 17886,

                }
                else
                {
                    for (int krule = 0; krule < 19; krule++)
                    {
                        Console.Write((krule + ": ").PadLeft(4,'0'));
                        for (int jnum = 0; jnum < 19; jnum++)
                        {
                            Console.Write(ruleswork[krule, jnum] ? 'X' : '.');
                            //if (ruleswork[k, j])
                            //{
                            //    Console.WriteLine($"Field {k} = rule {j}: {rules[j].Item1}");
                            //  //  break;
                            //}

                        }
                        Console.WriteLine();
                    }
                }

                bool matchRule(int num, Tuple<string, int, int, int, int> rule)
                {
                    (_, int a, int b, int c, int d) = rule;
                    return (num >= a && num <= b) || (num >= c && num <= d);
                }
            }
        }
    }
}
