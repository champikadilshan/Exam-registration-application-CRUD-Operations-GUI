using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRegistration  
{
    public class Methods
    {
        // Create log file
        public static void LogFile(string action = "INFO", string message = "")
        {
            string txtFile = @"C:\Users\dilshan\OneDrive - University of Sri Jayewardenepura Faculty of Technology\Learning Materials\Semester 3\Visual Application Programming\Assignment 2\log.txt";

            StreamWriter log;
            if (!File.Exists(txtFile)) log = new StreamWriter(txtFile);
            else log = File.AppendText(txtFile);

            log.Write(DateTime.Now);
            if (action == "") log.WriteLine("\t" + "\t:\t" + message);
            else log.WriteLine("\t[" + action + "]\t:\t" + message);
            log.Close();
        }
    }
}
