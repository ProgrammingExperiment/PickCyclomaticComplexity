using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Record
    {
        String fileName { get; set; }
        int numberOfIfs { get; set; }
        int numberOfCases { get; set; }
        int numberOfComments { get; set; }
        int numberOfLines { get; set; }

        //constructor
        public Record(String fileName, int Ifs,int Cases, int Comments, int Lines)
        {
            this.fileName = fileName;
            numberOfIfs = Ifs;
            numberOfCases = Cases;
            numberOfComments = Comments;
            numberOfLines = Lines;
       
        }

        public String print()
        {
            var outPut = string.Format("File Name:{0}\t Number of lines: {1}\t Number of if's: {2}\t Number of Case's: {3}\t Number of Comments;{4}",fileName,numberOfLines,numberOfIfs,numberOfCases,numberOfComments);
            return outPut;

        }
        
    }
}
