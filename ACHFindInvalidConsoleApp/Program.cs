using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACHFindInvalidConsoleApp
{
    class Program
    {
        static void FindInvalidChar(string FilePath)
        {

            try
            {
                StreamReader reader = new StreamReader(FilePath);
                string line;
                int lineNumber = 1,
                    invalidCharNumber = 0;
                Match match;
                Regex regex = new Regex(@"[a-z]|[\d]|\s|[_]|[-]|[@]|[:]|[.]|[$]|[=]|[/]");


                //we read the file line by line till the end
                while ((line = reader.ReadLine()) != null)
                {
                    //we loop through out the line character and verify if it matches the pattern of the regex expression
                    for (int i = 0; i < line.Length; i++)
                    {
                        match = regex.Match(line[i].ToString().ToLower());
                        //if there is not match with any normal character then we print out the line number, the column and the character itself
                        if (!(match.Success))
                        {
                            invalidCharNumber++;
                            Console.WriteLine("Line {0} - Col {1} - Character {2}", lineNumber, i + 1, line[i]);
                        }

                    }
                    lineNumber++;

                }

                //we close the file
                reader.Close();

               
                //print out a summary of the file: number of line and invalid char found in the file
                Console.WriteLine("----------Summary--------------------");
                Console.WriteLine(" {1} lines in the file \n {0} invalid characters found", invalidCharNumber, lineNumber);
                Console.WriteLine("------------------------------------");


            }
            //we catch Input/output exeception here and inform the user about it
            catch (IOException ex)
            {

                Console.WriteLine("Error when reading the file");

            }
            //we catch general exception and print out to the console 
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());


            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("MWI Homework Exercises");
            Console.WriteLine("ACH Find Invalid Characters");

            string FileName = @"C:\Users\nas\Documents\MagicWrighterHomeWork\homework-exercises\ach-find-invalid-chars\invalid-chars.ach";

            Console.WriteLine();
            Console.Write("Enter the full path of the file to check : ");
            FileName = Console.ReadLine();

            Console.WriteLine();

            //if the file exist else we print out that the file does't exist
            if (File.Exists(FileName))
            {
                FileInfo info = new FileInfo(FileName);
                //if the file exist then we check if the file is not empty
                if (info.Length == 0)
                    Console.WriteLine("File is empty");
                else
                    FindInvalidChar(FileName);


            }
            else
                Console.WriteLine("File doesn't exist");


            Console.WriteLine("Thank You \nPress any key to quit the program");
            Console.ReadKey();

        }
    }
}
