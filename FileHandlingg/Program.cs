using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using COMP123_S2016_Lesson8;

namespace FileHandlingg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Employee employee = new Employee();
                const string FILENAME = "..\\..\\employee.txt";
                const char DELIM = ',';
                //opened streams and creted new filestream object called "inFile"
                FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                //setup var's to temp hold my data
                string recordString;
                string[] fields;

                //read from the file
                recordString = reader.ReadLine();

                while (recordString != null)
                {
                    fields = recordString.Split(DELIM);

                    employee.EmployeeID = Convert.ToInt32(fields[0]);
                    employee.FirstName = fields[1];
                    employee.LastName = fields[2];
                    employee.Salary = Convert.ToDouble(fields[3]);

                    Console.WriteLine("{0} {1} {2} {3}", employee.EmployeeID, employee.FirstName, employee.LastName, employee.Salary.ToString("C"));

                    recordString = reader.ReadLine();
                }
                //close the streams
                reader.Close();
                inFile.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            #region FileStream and StreamWriter
            /*  string myfile = "myfile.txt";
            if (File.Exists(myfile))
            {
                Console.WriteLine("Created: " + File.GetCreationTime(myfile));
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            FileStream outFile = new FileStream("..\\..\\somefile.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            writer.WriteLine("Hello World!");
            writer.Close();
            outFile.Close();*/
            #endregion
        }
    }
}
