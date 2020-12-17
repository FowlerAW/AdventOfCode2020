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
    class Day14
    {
        public static void demo()
        {
            //{ new Take1().solve(false); }
            new Take1().solve(false);
            //not 4886706177792
        }

        class Take1
        {
            string filename = @"c:\temp\Day14input.txt";
            string testfilename = @"c:\temp\Day14test1input.txt";



            Dictionary<long, long>dd;
            string mask;
            public void solve(bool isP1=true)
            {
                dd= new Dictionary<long,long>();

                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    switch (line.Substring(0, 3))
                    {
                        case "mem":
                            var parts = line.Split(']');
                            var address = parts[0].Substring(4);
                            var val = long.Parse(parts[1].Substring(3));
                            if (isP1)
                            {
                                store(val, address);
                           // Console.WriteLine($"{val} => {address}; stored {dd[address]}");
                            }
                            else
                            {
                                decoderStore(val, address);
                            }
                            break;

                        case "mas":
                            mask = line.Substring("mask = ".Length);
                            Console.WriteLine("Mask = " + mask);
                            break;
                    }


                }

                ulong sum = 0;
                foreach(var num in dd.Values)
                {
                    Console.WriteLine(sum);
                    sum = sum + (ulong)num;
                    Console.WriteLine("+" + num);

                }
                Console.WriteLine(sum);
                //not 3065640044288
            }

            private void store(long val, string address)
            {
                dd[long.Parse(address)] = applyMask(val);
            }

            private void decoderStore(long val, string address)
            {
                storeFloating(applyAddressMask(long.Parse(address)),val);
            }

            private string applyAddressMask(long address) {
                var bval = new StringBuilder(Convert.ToString(address,2).PadLeft(36, '0'));
                int x = 0;
                Console.WriteLine("\n" + bval.ToString() + 'x');
                Console.WriteLine(mask + 'x');
                for (int i = 1; i <= bval.Length; i++)
                {
                    if (mask[mask.Length - i] == '1')
                        bval[bval.Length - i] = '1';
                    else if (mask[mask.Length - i] == 'X')
                    {
                        x++;
                        bval[bval.Length - i] = 'X';
                    }
                }

                return bval.ToString();

            }
            private long applyMask(long val)
            {
                var bval= new StringBuilder(Convert.ToString(val,2).PadLeft(36,'0'));
                
                Console.WriteLine("\n"+bval.ToString()+'x');
                Console.WriteLine(mask + 'x');

                for(int i=1;i<= bval.Length;i++)
                {
                    if (mask[mask.Length-i] == '0')
                        bval[bval.Length-i] = '0';
                    else if (mask[mask.Length - i] == '1')
                        bval[bval.Length - i] = '1';
                }

                Console.WriteLine(bval.ToString() + 'x' + "\n");

                return Convert.ToInt64(bval.ToString(), 2);
                //not 8375882684
            }

            void storeFloating(string floatingAddress, long val)
            {
                if (!floatingAddress.Contains('X'))
                {
                    dd[Convert.ToInt64(floatingAddress, 2)] = val;
                }
                else
                {
                    //split one pair of x's
                    int xpos = floatingAddress.IndexOf('X');

                    var newaddy = floatingAddress.Substring(0,xpos)+"1"+floatingAddress.Substring(xpos+1);
                    storeFloating(newaddy, val);
                    newaddy = floatingAddress.Substring(0, xpos) + "0" + floatingAddress.Substring(xpos + 1);
                    storeFloating(newaddy, val);

                }
            }
        }
    }
}
