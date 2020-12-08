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
    class Day8
    {
        public static void demo()
        {
            Console.WriteLine("Day 8" );
            new Take1().part1();

            //new Take1().part2(); //requires manual intervention


        }

        class Take1
        {
            string filename = @"c:\temp\Day8input.txt";
            string testfilename = @"c:\temp\Day8test1input.txt";

            int jmpif = -1;
            int nopif=-1;
            public void part2()
            {
                for(jmpif=0;jmpif<=73; jmpif++)
                {
                    part1();
                }
                for (nopif = 0; nopif <= 22; nopif++)
                {
                    part1();
                }
            }

            public void part1()
            {               
                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                var codes = new List<Tuple<string, int,bool>>();
                foreach (var line in lines)
                {

                   // Console.WriteLine(line);
                    var s = line.Split(' ');
                    codes.Add(new Tuple<string, int,bool>(s[0], int.Parse(s[1]),false));

                }

                int ptr = 0;
                int acc = 0;

                string cmd;
                int param;
                bool halt;
                long jumps = 0;
                long nops = 0;

                while (true)  //an "infinite" loop seems fitting here.
                {
                    (cmd, param, halt) = codes[ptr];

                    if(halt)
                    {                        
                        Console.WriteLine(acc +" Acc");
                        Console.WriteLine(jumps + " jumps");
                        Console.WriteLine(nops + " nops");
                        break;
                    }

                    codes[ptr] = new Tuple<string, int, bool>(cmd, param, true);
                    Console.WriteLine($"{ptr}: {lines[ptr]} Acc={acc} ");
                    switch (cmd)
                    {
                        case "acc":
                            
                            acc += param;

                            break;
                        case "jmp":
                            if (jmpif != jumps++)
                            {
                                ptr += param;
                                continue;
                            }
                            break;
                        case "nop":
                            
                            if(nopif==nops++)
                            {
                                ptr += param;
                                continue;
                            }
                            

                            if (ptr+param>=codes.Count-6)
                                Console.WriteLine("You win!");
                            break;

                        case "win": //added to the last line of the file.  Letting it error out as ptr exceeds the list would work too.
                            Console.WriteLine("You win!");//now read the ACC and enter it for p2.
                            break;

                            
                    }
                    ptr++;
                }


                
            }
        }
    }
}
