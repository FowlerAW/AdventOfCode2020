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
    class Day17
    {
        public static void demo()
        {
            new Take1().part2();
        }

        class Take1
        {
            string filename = @"c:\temp\Day17input.txt";
            string testfilename = @"c:\temp\Day17test1input.txt";


            public void part1()
            {
                //init
                int size = 30;
                bool db = false;
                bool db1 = false;
                bool db2 = false;
                int cycles = 6;

                bool[,,] sp = new bool[size, size, size];
                //bool[,,] nextSp = new bool[size, size, size];

                //setup
                { 
                var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                     int y = size/3; int z = size/3;
                    foreach (var line in lines)
                    {
                        int x = size / 3;
                        foreach (char c in line)
                        {
                            sp[x, y, z] = c == '#';
                            x++;
                        }
                        y++;
                    } 
                }

                //process
                for(int i = 0; i < cycles; i++)
                {
                    Console.WriteLine("Begin Cycle " + i);

                    byte[,,] counts = new byte[size, size, size];
                    for (int z = 0; z < size; z++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            for (int x = 0; x < size; x++)
                            {
                                if (sp[x, y, z])
                                {
                                    //counts[x, y, z]++;
                                    counts[x, y, z + 1]++;
                                    counts[x, y, z - 1]++;
                                    counts[x, y + 1, z]++;
                                    counts[x, y + 1, z + 1]++;
                                    counts[x, y + 1, z - 1]++;
                                    counts[x, y - 1, z]++;
                                    counts[x, y - 1, z + 1]++;
                                    counts[x, y - 1, z - 1]++;

                                    counts[x + 1, y, z]++;
                                    counts[x + 1, y, z + 1]++;
                                    counts[x + 1, y, z - 1]++;
                                    counts[x + 1, y + 1, z]++;
                                    counts[x + 1, y + 1, z + 1]++;
                                    counts[x + 1, y + 1, z - 1]++;
                                    counts[x + 1, y - 1, z]++;
                                    counts[x + 1, y - 1, z + 1]++;
                                    counts[x + 1, y - 1, z - 1]++;

                                    counts[x - 1, y, z]++;
                                    counts[x - 1, y, z + 1]++;
                                    counts[x - 1, y, z - 1]++;
                                    counts[x - 1, y + 1, z]++;
                                    counts[x - 1, y + 1, z + 1]++;
                                    counts[x - 1, y + 1, z - 1]++;
                                    counts[x - 1, y - 1, z]++;
                                    counts[x - 1, y - 1, z + 1]++;
                                    counts[x - 1, y - 1, z - 1]++;
                                }
                            }
                        }
                    }

                    int activecount = 0;
                    
                    for (int z = 0; z < size; z++)
                    {
                        
                        if (db )
                            Console.WriteLine("\nz=" + z);
                        for (int y = 0; y < size; y++)
                        {
                            for (int x = 0; x < size; x++)
                            {
                                if (sp[x, y, z])
                                {

                                    //If a cube is active and exactly 2 or 3 of its neighbors are also active, 
                                    //    the cube remains active.Otherwise, the cube becomes inactive.
                                    sp[x,y,z] = counts[x,y,z]== 2 || counts[x, y, z] == 3;

                                }
                                else
                                {
                                    //If a cube is inactive but exactly 3 of its neighbors are active, 
                                    //  the cube becomes active. Otherwise, the cube remains inactive.
                                    sp[x, y, z] = counts[x, y, z] == 3;
                                }
                                if (sp[x, y, z])
                                {
                                    activecount++;
                                    if (db1 )
                                        Console.Write('#');
                                    if (db2 )
                                        Console.Write(counts[x, y, z]);
                                }
                                else
                                {
                                    if (db1 )
                                        Console.Write('.');
                                    if (db2 )
                                        Console.Write(counts[x, y, z]);
                                }

                            }
                            if (db)
                                Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Cycle " + i +": " +activecount);
                }
            }
            public void part2()
            {
                //init
                int size = 30;
                bool db = false;
                bool db1 = false;
                bool db2 = false;
                int cycles = 6;

                bool[,,,] sp = new bool[size, size, size, size];

                //setup
                {
                    var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    int y = size / 3;
                    foreach (var line in lines)
                    {
                        int x = size / 3;
                        foreach (char c in line)
                        {
                            sp[size / 3, x, y, size / 3] = c == '#';
                            x++;
                        }
                        y++;
                    }
                }

                //process
                for (int i = 0; i < cycles; i++)
                {
                    Console.WriteLine("Begin Cycle " + i);

                    byte[,,,] counts = new byte[size, size, size, size];
                    for (int w = 0; w < size; w++)
                    {
                        for (int z = 0; z < size; z++)
                        {
                            for (int y = 0; y < size; y++)
                            {
                                for (int x = 0; x < size; x++)
                                {
                                    if (sp[w, x, y, z])
                                    {
                                        addcountswithW(counts,w,x,y,z,0);
                                        addcountswithW(counts, w, x, y, z, -1);
                                        addcountswithW(counts, w, x, y, z, +1);
                                        counts[w, x, y, z]--;
                                    }
                                }
                            }
                        }
                    }

                    int activecount = 0;

                    for (int w = 0; w < size; w++)
                    {
                        for (int z = 0; z < size; z++)
                        {

                            if (db)
                                Console.WriteLine("\nz=" + z);
                            for (int y = 0; y < size; y++)
                            {
                                for (int x = 0; x < size; x++)
                                {
                                    if (sp[w, x, y, z])
                                    {

                                        //If a cube is active and exactly 2 or 3 of its neighbors are also active, 
                                        //    the cube remains active.Otherwise, the cube becomes inactive.
                                        sp[w, x, y, z] = counts[w, x, y, z] == 2 || counts[w, x, y, z] == 3;

                                    }
                                    else
                                    {
                                        //If a cube is inactive but exactly 3 of its neighbors are active, 
                                        //  the cube becomes active. Otherwise, the cube remains inactive.
                                        sp[w, x, y, z] = counts[w, x, y, z] == 3;
                                    }
                                    if (sp[w, x, y, z])
                                    {
                                        activecount++;
                                        if (db1)
                                            Console.Write('#');
                                        if (db2)
                                            Console.Write(counts[w, x, y, z]);
                                    }
                                    else
                                    {
                                        if (db1)
                                            Console.Write('.');
                                        if (db2)
                                            Console.Write(counts[w, x, y, z]);
                                    }

                                }
                                if (db)
                                    Console.WriteLine();
                            }
                        }
                        }
                        Console.WriteLine("Cycle " + i + ": " + activecount);
                    }
                }

            private void addcountswithW(byte[,,,] counts, int w, int x, int y, int z, int v)
            {
                counts[w+v, x, y, z]++;
                counts[w+v, x, y, z + 1]++;
                counts[w+v, x, y, z - 1]++;
                counts[w+v, x, y + 1, z]++;
                counts[w+v, x, y + 1, z + 1]++;
                counts[w+v, x, y + 1, z - 1]++;
                counts[w+v, x, y - 1, z]++;
                counts[w+v, x, y - 1, z + 1]++;
                counts[w+v, x, y - 1, z - 1]++;
                counts[w+v, x + 1, y, z]++;
                counts[w+v, x + 1, y, z + 1]++;
                counts[w+v, x + 1, y, z - 1]++;
                counts[w+v, x + 1, y + 1, z]++;
                counts[w+v, x + 1, y + 1, z + 1]++;
                counts[w+v, x + 1, y + 1, z - 1]++;
                counts[w+v, x + 1, y - 1, z]++;
                counts[w+v, x + 1, y - 1, z + 1]++;
                counts[w+v, x + 1, y - 1, z - 1]++;
                counts[w+v, x - 1, y, z]++;
                counts[w+v, x - 1, y, z + 1]++;
                counts[w+v, x - 1, y, z - 1]++;
                counts[w+v, x - 1, y + 1, z]++;
                counts[w+v, x - 1, y + 1, z + 1]++;
                counts[w+v, x - 1, y + 1, z - 1]++;
                counts[w+v, x - 1, y - 1, z]++;
                counts[w+v, x - 1, y - 1, z + 1]++;
                counts[w+v, x - 1, y - 1, z - 1]++;
            }
        }
    }
}
