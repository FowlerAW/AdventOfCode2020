using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Day8.demo();

            //bigDemo();
        }

        static void bigDemo()
        {
            Day1.Demo();
            Day2.demo();
            Day3.demo();
            Day4.demo();
            Console.WriteLine("\nPress any key to continue with day 5 (The quick implementation relies on starting with a blank screen.)");
            Console.ReadKey();
            Console.Clear();
            Day5.demo();
            Day6.demo();
            Console.ReadKey();
            Day7.demo();
            
        }
    }
}
