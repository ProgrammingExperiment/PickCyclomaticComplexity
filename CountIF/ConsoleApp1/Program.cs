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


            foreach (var file in Directory.EnumerateFiles(inFileName))
            {
                int ifCounter = 0;
                Console.Write("File: " + file + "\t" );
            
                IEnumerable<string> lines = File.ReadLines(file);
                foreach (var l in lines)
                {
                    if (l.ToLower().Contains("if") )
                    {
                        ifCounter++; 
                    }

                }

                Console.Write(" has " + ifCounter + " IF statements \n");
               
            }
            
            //int counter = 0;
            //string delim = " ,.";
            //string[] fields = null;
            //string line = null;

            //while (!sr.EndOfStream)
            //{
            //    line = sr.ReadLine();
            //}



            //fields = line.Split(delim.ToCharArray());
            //for (int i = 0; i < fields.Length; i++)
            //{
            //    counter++;
            //}
            //sr.Close();
            //Console.WriteLine("The word count is {0}", counter);
    
        }
    }
}