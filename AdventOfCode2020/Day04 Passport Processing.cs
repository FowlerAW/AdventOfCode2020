using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day4
    {
        public static void demo()
        {
            Console.WriteLine("\nDay4");
            new Day4P1().part1();
            //new Day4P2().part1();

            Console.WriteLine("\n\nDay 4");
            Console.WriteLine("(press any key to continue)");
            Console.ReadKey();
            Console.Clear();
        }

        class Day4P1
        {
            string filename = @"c:\temp\Day4input.txt";
            string testfilename = @"c:\temp\Day4test1input.txt";
            string test2filename = @"c:\temp\Day4test2input.txt";
            string test3filename = @"c:\temp\Day4test3input.txt";
            public Day4P1()
            {

            }

            public void part1()
            {
                 var lines = File.ReadAllText(filename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                bool byr=false;//(Birth Year)
                bool iyr=false;//(Issue Year)
                bool eyr=false;//(Expiration Year)
                bool hgt=false;//(Height)
                bool hcl=false;//(Hair Color)
                bool ecl=false;//(Eye Color)
                bool pid=false;//(Passport ID)
                bool cid=false;//(Country ID)

                int count = 0;
                bool p1 = false;
                int total = 0;
                foreach(string line in lines)
                {
                    if (line.Trim() == "")
                    {
                        total++;
                        //process
                        if (byr &&
                           iyr &&
                           eyr &&
                           hgt &&
                           hcl &&
                           ecl &&
                           pid

                            )
                        {
                            count++;
                            Console.WriteLine($"Good {count}/{total}");
                        }
                        else
                        {
                            Console.WriteLine($"bad {count}/{total}");
                        }

                        byr = false;
                        iyr = false;
                        eyr = false;
                        hgt = false;
                        hcl = false;
                        ecl = false;
                        pid = false;
                        Console.WriteLine();
                    }
                    else
                    {

//byr(Birth Year) - four digits; at least 1920 and at most 2002.
//iyr(Issue Year) - four digits; at least 2010 and at most 2020.
//eyr(Expiration Year) - four digits; at least 2020 and at most 2030.

                       byr = byr || hasyear(line,"byr:",1920,2002) || p1 && line.Contains("byr:");
                        iyr = iyr || hasyear(line,"iyr:",2010,2020) || p1 && line.Contains("iyr:");
                        eyr = eyr || hasyear(line, "eyr:", 2020, 2030) || p1 && line.Contains("eyr:");
                        //hgt(Height) - a number followed by either cm or in:
                        //    If cm, the number must be at least 150 and at most 193.
                        //    If in, the number must be at least 59 and at most 76.
                        hgt = hgt || validatehgt(line) || p1 && line.Contains("hgt:");

                        //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                        hcl = hcl || (new Regex("hcl:#[a-f0-9]{6}").IsMatch(line) 
                            && !new Regex("hcl:#[a-f0-9]{7}").IsMatch(line)) || p1 && line.Contains("hcl:");
                        //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                        ecl = ecl || new Regex("ecl:(amb|blu|brn|gry|grn|hzl|oth)").IsMatch(line) || p1 && line.Contains("ecl:");
                        //pid(Passport ID) - a nine - digit number, including leading zeroes.
                        pid = pid || (new Regex("pid:\\d{9}").IsMatch(line)) || p1 && line.Contains("pid:");
                        if (!p1 && new Regex("pid:\\d{10}").IsMatch(line))
                        {
                            pid = false;
                        }


                        Console.WriteLine($"{line} - byr:{byr} iyr:{iyr} eyr:{eyr} hgt:{hgt} hcl:{hcl} ecl:{ecl} pid:{pid}");
                    }

                }
                Console.WriteLine();
                Console.WriteLine($"grand total {count} / {total}");
                //Console.ReadKey();
                //pt 2 not 189
                //111
            }
            bool validatehgt(string s)
            {
                //hgt(Height) - a number followed by either cm or in:
                //    If cm, the number must be at least 150 and at most 193.
                //    If in, the number must be at least 59 and at most 76.
                var rx =new Regex("hgt:(\\d+)(cm|in)");
                var m=rx.Match(s);

                if (!m.Success)
                    return false;

                if (!int.TryParse(m.Groups[1].Value, out int year))
                    return false;

                switch (m.Groups[2].Value)
                {
                    case "in":
                        return year >= 59 && year <= 76;
                        
                    case "cm":
                        return year >= 150 && year <= 193;
                        
     
                }

                return false;
            }

            bool hasyear(string b, string find, int min, int max)
            {
                var rx = new Regex(find+"(\\d{4})");
                var m = rx.Match(b);
                if (!m.Success)
                    return false;

                if (new Regex(find + "(\\d{5})").IsMatch(b))
                    return false;

                if (!int.TryParse(m.Groups[1].Value, out int year))
                    return false;

                return year >= min && year <= max;
                
            }

            public void part2()
            {
                var lines = File.ReadAllText(testfilename).Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                string result = "bar";

                Console.WriteLine(result);
                //Console.ReadKey();
            }

        }

        class Day4take2
        {
            static void part1()
            {
                Console.WriteLine( countValidCredentials(@"c:\temp\Day4input.txt", new part1Validator()));
            }
            static int countValidCredentials(string filename, iCredentialValidator v)
            {
                return parseCredentials(filename).Count(v.Validate);
            }


            static List<Credential> parseCredentials(string filename) {
                var f=File.ReadAllText(filename);


                var records = f.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

                return null;
            }

            class Credential { 
                string byr;//(Birth Year)
                string iyr;//(Issue Year)
                string eyr;//(Expiration Year)
                string hgt;//(Height)
                string hcl;//(Hair Color)
                string ecl;//(Eye Color)
                string pid;//(Passport ID)
                string cid;//(Country ID)
            }
            interface iCredentialValidator
            {
                bool Validate(Credential credential);
            }
            class part1Validator : iCredentialValidator
            {
                public bool Validate(Credential c)
                {
                    return false;
                }
            }

        }
    }
}
