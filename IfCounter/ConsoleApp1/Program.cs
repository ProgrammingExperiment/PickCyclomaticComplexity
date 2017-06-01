using StatsdClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program

    { 


        static void Main(string[] args)

        {
            var metricsConfig = new MetricsConfig
            {
                StatsdServerName = "35.185.254.120",
                StatsdServerPort = 8125,
                Prefix = "grafana",
            };
            Metrics.Configure(metricsConfig);
            
            Metrics.GaugeDelta("shawnGauge", 2);
            


            string inFileName = null;

            Console.WriteLine("Enter directory path: ");
            inFileName = Console.ReadLine();

            try
            {
                foreach (var file in Directory.EnumerateFiles(inFileName))
                {
                    int ifCounter = 0;
                    int caseCounter = 0;
                    int starCounter = 0;

                    Console.Write("File: " + file + "\t");

                    IEnumerable<string> lines = File.ReadLines(file);
                    foreach (var l in lines)

                    {
                        Metrics.Counter("lines");
                        if (l.Contains("*"))
                        {
                            starCounter++;
                        }

                        var words = l.Split(' ');
                        foreach (var word in words)
                        {
                            if (word.ToLower().Equals("if"))
                            {
                                ifCounter++;
                            }

                            if (word.ToLower().Equals("case"))
                            {
                                caseCounter++;
                            }

                        }
                        Metrics.Timer("timer",2);


                    }

                    Console.WriteLine("contains {0} If's, {1} Case's and {2} Comments ", ifCounter, caseCounter, starCounter);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


        }

       
    }



}
