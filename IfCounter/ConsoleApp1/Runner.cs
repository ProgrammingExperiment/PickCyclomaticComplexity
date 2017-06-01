using StatsdClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Runner
    {
        static void Main(string[] args)
        {

            var MetricsConfig = new MetricsConfig
            {
                StatsdServerName = "35.185.254.120",
                StatsdServerPort = 8125,
                Prefix = "Assignment2"
            };

            Metrics.Configure(MetricsConfig);

            Console.WriteLine("Enter directory path: ");
            var DirPath = Console.ReadLine();

            var myProg = new Counter(DirPath); //

            var Ifs = 0;
            var Cases = 0;
            var Comments = 0;
            var lines = 0;

            using (Metrics.StartTimer("processingFiles", 1))
            {
                var files = 0;
                foreach (var file in myProg.getFiles())
                {
                    Ifs += myProg.countIfs(file);
                    //Thread.Sleep(1);

                    Cases += myProg.countCases(file);
                    Comments += myProg.countComments(file);
                    lines += myProg.countLines(file);

                    Metrics.Counter("numberOfLines");
                    Metrics.GaugeAbsoluteValue("GaugeFiles", files++);
                }
            }


            Console.WriteLine("contains {0} If's, {1} Case's and {2} Comments ", Ifs, Cases, Comments);
            Console.ReadKey();
        }
    }
}
