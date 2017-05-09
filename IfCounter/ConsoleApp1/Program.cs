using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inFileName = null;

            Console.WriteLine("Enter directory path: ");
            inFileName = Console.ReadLine();

            try
            {
                foreach (var file in Directory.EnumerateFiles(inFileName))
                {
                    int ifCounter = 0;
                    int caseCounter = 0;
                    Console.Write("File: " + file + "\t");

                    IEnumerable<string> lines = File.ReadLines(file);
                    foreach (var l in lines)

                    {
                        var words = l.Split(' ');
                        foreach (var word in words)
                        {
                            if (word.ToLower().Equals("if"))

                                ifCounter++;


                            if (word.ToLower().Equals("case")) 
                            {
                                caseCounter++;
                            }
                        }

                

                   }
                    Console.WriteLine("contains {0} If's and {1} Case's ", ifCounter, caseCounter);
                    

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to find path");
            }
            
        }
    }
}