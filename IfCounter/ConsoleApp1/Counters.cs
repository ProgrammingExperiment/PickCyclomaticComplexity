using StatsdClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Counter

    {

       //constructor 
        public Counter(String DirectoryPath)
        {
            _DirectoryPath = DirectoryPath;
        }
        String _DirectoryPath;

        public IEnumerable<String> getFiles()
        {
            try {
                return Directory.EnumerateFiles(_DirectoryPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public int countIfs(String file)
        {
            try
            {
                IEnumerable<string> lines = File.ReadLines(file);
                var ifCounter = 0;
                foreach (var l in lines)
                {
                    var words = l.Split(' ');
                    foreach (var word in words)
                    {
                        if (word.ToLower().Equals("if"))
                        {
                            ifCounter++;
                        }
                    }
                }
                return ifCounter;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public int countCases(String file)
        {
            try
            {
                IEnumerable<string> lines = File.ReadLines(file);
                var CaseCounter = 0;
                foreach (var l in lines)
                {
                    var words = l.Split(' ');
                    foreach (var word in words)
                    {
                        if (word.ToLower().Equals("case"))
                        {
                            CaseCounter++;
                        }
                    }
                }
                return CaseCounter;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }

        public int countComments(string file)
        {
            try
            {
                IEnumerable<string> lines = File.ReadLines(file);
                var CommentCounter = 0;
                foreach (var l in lines)
                {
                    if (l.Contains("*"))
                    {
                        CommentCounter++;
                    }
                }
                return CommentCounter;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }

        public int countLines(String file)
        {
            try
            {
                IEnumerable<string> lines = File.ReadLines(file);
                var lineCounter = 0;
                foreach (var l in lines)
                {
                    lineCounter++;

                }
                return lineCounter;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
 
   
}
}
