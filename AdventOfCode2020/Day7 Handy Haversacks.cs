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
    class Day7
    {
        public static void demo()
        {

            Console.WriteLine("Day 7");
            Console.WriteLine("Part 1 00:22:26  rank 1444");
            Console.WriteLine("Part 2 00:48:47  rank 2425");
            Console.WriteLine("(press any key to continue)");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Day 7 Part 1");
            new Take1().part1();

            Console.WriteLine("\nDay 7 Part 1");
            
            Console.WriteLine("\n(press any key to continue)");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Day 7 Part 2\n");

            new Take1().part2();

            Console.WriteLine("Day 7 Part 2");
            Console.WriteLine("(press any key to continue)");
            Console.ReadKey();
            Console.Clear();


        }

        class Take1
        {
            string filename = @"c:\temp\Day7input.txt";
            string testfilename = @"c:\temp\Day7test1input.txt";


            public void part1()
            {
                long result = 0;
                var dd = new Dictionary<string, List<string>>();

                var rules = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (var rulex in rules)
                {
                    var rule = rulex.Replace(".", "");
                    var split1 = rule.Split(new string[] { "contain" }, StringSplitOptions.None);
                    var parent = split1[0].Trim();

                    Console.WriteLine();
                    Console.WriteLine(rule);
                    var children = split1[1].Split(new char[] { ',' });
                    foreach (var xchild in children)
                    {
                        var child = xchild.Substring(3);
                        if(child[child.Length-1] != 's')
                                child = child + 's';

                        if (!dd.ContainsKey(child))
                        {
                            dd.Add(child, new List<string>());
                        }
                        dd[child].Add(parent);
                        Console.WriteLine($"{child} can be in  {parent}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();

                var xx = new Dictionary<string, int>();
                recurse("shiny gold bags",dd,xx);

                Console.WriteLine(xx.Count());

            }

            private void recurse(string v, Dictionary<string, List<string>> dd, Dictionary<string, int> xx)
            {
                if (!dd.ContainsKey(v))
                {
                    return;
                }

                foreach(var parent in dd[v])
                {
                    if (!xx.ContainsKey(parent))
                    {
                        xx.Add(parent, 1);
                        Console.WriteLine(parent);
                    }
                    recurse(parent, dd, xx);
                }
                return;
            }

            public void part2()
            {
                
                var dd = new List<Tuple<string,string,int>>();
                //filename = testfilename;
                var rules = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (var rulex in rules)
                {
                    var rule = rulex.Replace(".", "");
                    var split1 = rule.Split(new string[] { "contain" }, StringSplitOptions.None);
                    var parent = split1[0].Trim();

                    Console.WriteLine();
                    Console.WriteLine(rule);
                    var children = split1[1].Split(new char[] { ',' });
                    foreach (var xchild in children)
                    {
                        if (xchild != " no other bags")
                        {
                            var child = xchild.Substring(3);
                            if (child[child.Length - 1] != 's')
                                child = child + 's';

                            int qty = int.Parse(xchild.Substring(1, 1));

                            dd.Add(new Tuple<string, string, int>(parent, child, qty));
                            Console.WriteLine($"{parent} contain {qty} of {child}");
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine();

                var xx = new Dictionary<string, int>();

                

                Console.WriteLine(recurse2("shiny gold bags", dd)-1);

            }

            static long recurse2(string parent, List<Tuple<string , string , int >> xx)
            {
                Console.WriteLine($"{parent} contains:");
                if (!xx.Any(z => z.Item1 == parent))
                {
                    Console.WriteLine("(1) No other bags.");
                    return 1;
                }

                long count = 1;
                foreach (var q in xx.Where(z => z.Item1 == parent))
                {
                    Console.WriteLine($"{parent} contains {q.Item3} of { q.Item2}");
                    count += q.Item3 * recurse2(q.Item2, xx);
                    Console.WriteLine($"({parent} contains {q.Item3} of { q.Item2} -> total {count})");
                     
                }
                return count;
            }
        }
    }
}
