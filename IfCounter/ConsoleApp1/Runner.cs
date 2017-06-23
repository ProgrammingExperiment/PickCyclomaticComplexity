using StatsdClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Runner
    {

        static void Main(string[] args)
        {

            var MetricsConfig = new MetricsConfig
            {
                StatsdServerName = "35.185.229.116", // My VM machine 35.185.229.116
                StatsdServerPort = 8125,
                Prefix = "Assignment 3 & 4"
            };

            Metrics.Configure(MetricsConfig);

            Console.WriteLine("Please enter directory path: ");
            var DirPath = Console.ReadLine();

            var myProg = new Counter(DirPath);

            var totalIfs = 0;
            var totalCases = 0;
            var totalComments = 0;
            var totalLines = 0;
            var totalFiles = 0;

            //dictionary to assign and store keys,values(list of records) , i could have used SortedList<TKey, Tvalue>
            Dictionary<int, List<Record>> recordsDict = new Dictionary<int, List<Record>>();
            
            try
            {
                String assignment3Path = @"C:\dev\Assignment3Output.txt";
                StreamWriter sw3 = File.CreateText(assignment3Path);

                foreach (var file in myProg.getFiles())
                {
                    Metrics.Counter("Number of Files");
                    using (Metrics.StartTimer("FilesProcessingTimer"))
                    {

                        var localIfs = 0;
                        localIfs = myProg.countIfs(file);                       
                        //sends metris on individule file
                        Metrics.Counter("Number Of Ifs", localIfs, 1);
                        //keeps running count
                        totalIfs = localIfs + totalIfs;

                        var localCases = 0;
                        localCases = myProg.countCases(file);                        
                        Metrics.Counter("Number of Cases", localCases, 1);
                        totalCases = totalCases + localCases;

                        var localComments = 0;
                        localComments = myProg.countComments(file);                       
                        Metrics.Counter("Number of Comments", localComments, 1);
                        totalComments = totalComments + localComments;

                        var localLines = 0;
                        localLines = myProg.countLines(file);
                        
                        Metrics.Counter("Number of Lines", localLines, 1);
                        totalLines = totalLines + localLines;

                        //var localFiles = 0;
                        totalFiles++;

                        // key for my dictionary  **Assignment 4***
                        if (recordsDict.ContainsKey(localLines))
                        {
                            // capturing collecion records, retunes the values
                            List<Record> values = recordsDict[localLines];
                            //refreshing the values in 
                            Record record = new Record(file, localIfs, localCases, localComments, localLines);
                            //adding record into the value list
                            values.Add(record);
                              // assigns updated list of records into the value of key in my dict.                          
                            recordsDict[localLines] = values;

                        }
                        else
                        {
                            // creates new entery on dict.
                            List<Record> values = new List<Record>();
                            Record record = new Record(file, localIfs, localCases, localComments, localLines);
                            values.Add(record);
                            //new entery in my dictionary
                            recordsDict.Add(localLines, values);
                                                       
                        }

                        //print to counts to console per processed file
                        Console.WriteLine("File Name:{0}\t Number of lines: {1}\t Number of if's: {2}\t Number of Case's: {3}\t Number of Comments;{4}", file, localLines, localIfs, localCases, localComments);
                        //print to counts to file per processed file
                        sw3.WriteLine("File Name:{0}\t Number of lines: {1}\t Number of if's: {2}\t Number of Case's: {3}\t Number of Comments;{4}", file, localLines, localIfs, localCases, localComments);
                    }
                }
                sw3.Flush(); //finish writing to file
                sw3.Dispose(); // closes file
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

           //break into assignment 4 output
            Console.WriteLine("Enter to view output for Assignment 4");
            Console.ReadLine();
            Console.Clear();


            // keys in list to do the sorting then reverse 
            List<int> keysOfMyDict = recordsDict.Keys.ToList();
            //ascending
            keysOfMyDict.Sort();
            //descending
            keysOfMyDict.Reverse();

            //create txt file with output for Assignment 4 * *
            String path = @"C:\dev\Assignment4Output.txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Directory contains: {0} If's, {1} Case's and {2} Comments, for a total of {3} lines", totalIfs, totalCases, totalComments, totalLines);

                foreach (var key in keysOfMyDict)
                {
                    List<Record> listOfRecords = recordsDict[key];
                    foreach (var rec in listOfRecords)
                    {
                        sw.WriteLine("{0}", rec.print());
                    }

                }
            }
            
            //to print on Console
            foreach (var key in keysOfMyDict)
            {
                var listOfRecords = recordsDict[key];
                foreach (var rec in listOfRecords)
                {
                    Console.WriteLine("{0}", rec.print());
                }

            }
            //grand totals
            Console.WriteLine("contains {0} If's, {1} Case's and {2} Comments, for a total of {3} lines", totalIfs, totalCases, totalComments, totalLines);
            Console.ReadKey();

        }
    }
}
