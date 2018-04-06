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
          static void FindInvalidChar( string FilePath)
        {

            try
            {
                StreamReader reader = new StreamReader(FilePath);
                //for each line of the file
                string line;
                int LineNumber = 1, counter = 0;

            

                //we read the file line by line till the end
                while ((line = reader.ReadLine()) != null)
                {
                    Regex regex = new Regex(@"[a-z]|[\d]|\s|[_]|[-]|[@]|[:]|[.]|[$]|[=]|[/]");

                    for (int i = 0; i < line.Length; i++)
                    {
                        Match match = regex.Match(line[i].ToString().ToLower());
                        //if there is not match with any normal charactere then we print the line and the position
                        if (!(match.Success))
                        {
                            counter++;
                            Console.WriteLine("Line {0} - Position {1} - Character {2}", LineNumber, i + 1, line[i]);
                        }

                    }
                    LineNumber++;

                }
                Console.WriteLine(" {1} lines in the file \n {0} invalid characters found", counter, LineNumber);
                //we close the file
                reader.Close();

            }
            catch (IOException ex)
            {

                Console.WriteLine("Error when reading the file");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        static void Main(string[] args)
        {
            

            string FileName = @"C:\Users\nas\Documents\MagicWrighterHomeWork\homework-exercises\ach-find-invalid-chars\invalid-chars.ach";

            Console.Write ("Enter the path of the file : ");
              FileName =Console.ReadLine();

            Console.WriteLine();

            if (File.Exists(FileName))
            {
                FileInfo info = new FileInfo(FileName);

                if ( info.Length == 0)
                    Console.WriteLine("File is empty");
                else
                    FindInvalidChar(FileName);
              
              
            }
            else
                Console.WriteLine("File doesn't exist");


            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
