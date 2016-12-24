using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //to stream file

//Help from https://www.tutorialspoint.com/csharp/csharp_file_io.htm
//This file will contain functions to load files 
//in program to compare them against each other
//So far only .txt files would be operated

namespace Plagiarism_Detector
{
    class Document
    {
        string file_name;
        String file_text; //it will store all the text in the file
        public void streamfile()  //streaming text file 
        {
            using (StreamReader sr = new StreamReader(file_name))
            {
                file_text = sr.ReadToEnd();
            }
            //open_file dialog would also be implemented later
            // to browse any file from PC
        }
    }
}
