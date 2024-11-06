using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Asmet1.Dictionary;
using static System.Net.Mime.MediaTypeNames;
namespace Asmet1
{
    internal class Program
    {
        private static MyDictionary dictionaryDs = new MyDictionary();
        static void Main(string[] args)
        {
            string loadedFile = "No";
            MainMenu(loadedFile);


            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        static void MainMenu(string loadedFile)
        {
            int userInput = 10;
            while (true)
            {
                var entries = dictionaryDs.GetAllEntries();

                Console.Clear();
                Console.WriteLine("---Main Menu---");
                Console.WriteLine();
                Console.WriteLine("0- Loading Operations");
                Console.WriteLine("1- Insert Operations");
                Console.WriteLine("2- Find Operations");
                Console.WriteLine("3- Delete Operations");
                Console.WriteLine("4- Delete All From Dic");
                Console.WriteLine("5- Print Operations");
                Console.WriteLine("6- Test Operation");
                Console.WriteLine("7- Exit");
                Console.WriteLine("\n");
                if (entries.Any())
                {
                    Console.WriteLine("There is a Word or Words Loaded ^^");
                }
                else
                {
                    Console.WriteLine("There are no Words in the dictionary :c");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Enter 0/7 from the list above");
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine(userInput);
                    if (userInput >= 0 && userInput <= 7)
                    {
                        switch (userInput)
                        {
                            case 0:
                                LoadOp();
                                break;
                            case 1:
                                InsertOp();
                                break;
                            case 2:
                                FindOp();
                                break;
                            case 3:
                                DeleteOp();
                                break;
                            case 4:
                                DeleteAllOp();
                                break;
                            case 5:
                                PrintOp();
                                break;
                            case 6:
                                TestOp();
                                break;
                            case 7:
                                Console.WriteLine("Bye Bye");
                                Environment.Exit(0);
                                break;
                            //default:
                            //    Console.WriteLine();
                            //    Console.WriteLine("Please Enter a Vaild Number");
                            //    Console.WriteLine();
                            //    Console.WriteLine("Press any key to Retry");
                            //    Console.ReadKey();
                            //    break;
                        }//end of switch
                    }//end of int 0/7
                }//end of 
                else
                {
                    Console.WriteLine("im a stinky program");
                }
            }
        }//end of MainMenu 
        static void TestOp()
        {
            LoadOp();
            InsertOp();
            FindOp();
            DeleteOp();
            PrintOp();
            DeleteAllOp();
            PrintOp();
        }
        static void LoadOp()
        {
            Console.Clear();
            int userInputLoad = 0;
            int passed = 0;
            int failed = 0;
            string folderPathOrdered = @"ordered";
            string folderPathRandom = @"random";
            int Curser = 0;
            List<string> list = new List<string>();
            string[] filesOrdered = Directory.GetFiles(folderPathOrdered, "*.txt");
            string[] filesRandom = Directory.GetFiles(folderPathRandom, "*.txt");
            while (true)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Console.Clear();
                Console.WriteLine("---File Selector---");
                Console.WriteLine();
                Curser = 0;
                foreach (string file in filesOrdered)
                {
                    Console.WriteLine(Curser + "- " + file); 
                    list.Insert(Curser, file);
                    Curser++;
                }
                foreach (string file in filesRandom)
                {
                    Console.WriteLine(Curser + "- " + file);
                    list.Insert(Curser, file);
                    Curser++;
                }
                Console.WriteLine(Curser + "- Go back");
                Console.WriteLine();
                Console.WriteLine("Enter 0/{0} from the list above", Curser);
                if (int.TryParse(Console.ReadLine(), out userInputLoad))
                {
                    if (userInputLoad >= 0 && userInputLoad <= Curser)
                    {
                        if (userInputLoad == Curser)
                        {
                            break;
                        }
                        string fileDes = list.ToArray()[userInputLoad];
                        Console.WriteLine(fileDes);

                        string[] lines = File.ReadAllLines(fileDes);

                        Curser = 0;

                        sw.Start();
                        foreach (string line in lines)
                        {
                            Curser++;
                            if (line.All(char.IsLetterOrDigit))
                            {
                                Console.WriteLine(line);
                                dictionaryDs.AddOp(line);
                                passed++;
                            }
                            else
                            {
                                failed++;
                            }
                        }
                        sw.Stop();
                        TimeSpan timespan = sw.Elapsed;
                        Console.WriteLine("\n");
                        Console.WriteLine("File ID Number Selected: " + userInputLoad);
                        Console.WriteLine("Total Number of Successful Addtion: " + passed);
                        Console.WriteLine("Total Number of Failed Addtion: " + failed);
                        Console.WriteLine("Total Number of Itteration: " + Curser);
                        Console.WriteLine("Time Taken: " + timespan + " seconds");
                        Console.WriteLine("\n");
                        Console.WriteLine("Press any key to go Back...");
                        Console.ReadKey();
                    }
                }
            }
        }//end file load
        static void InsertOp()
        {
            Console.Clear();
            Console.WriteLine("---Insert Operation---");
            Console.WriteLine();
            Console.WriteLine("Enter your word to be instered into the Dictionary");
            Console.WriteLine();
            string userInputInsert = Console.ReadLine();
            dictionaryDs.AddOp(userInputInsert);
            Console.Clear();
            Console.WriteLine("---File Selector---");
            Console.WriteLine();
            Console.WriteLine("Enter your word to be instered into the Dictionary");
            Console.WriteLine();
            Console.WriteLine(userInputInsert + " Was Added to the Dictionary");
            Console.WriteLine(userInputInsert + " Is " + userInputInsert.Length + " long");
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to go Back...");
            Console.ReadKey();
        }
        static void FindOp()
        {
            Console.Clear();
            Console.WriteLine("---Find Operation---");
            Console.WriteLine();
            Console.WriteLine("Enter your word to be instered into the Dictionary");
            Console.WriteLine();
            string userInputFind = Console.ReadLine();
            Node result = dictionaryDs.Find(userInputFind);
            if (userInputFind != null)
            {
                if (result != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The word was found.");
                    Console.WriteLine("");
                    Console.WriteLine($"Word: {result.Word}, Length: {result.Length}");
                }
                else
                {
                    Console.WriteLine("The word was not found.");
                }
               // Console.WriteLine($"Word: {result.Word}, Length: {result.Length}");
            }
            else
            {
                Console.WriteLine("The Word was not found.");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to go Back...");
            Console.ReadKey();
        }//end find
        static void DeleteOp()
        {
            Console.Clear();
            Console.WriteLine("---Delete Operation---");
            Console.WriteLine();
            Console.WriteLine("Enter your word to be Removed from the Dictionary");
            Console.WriteLine();
            string userInputDelete = Console.ReadLine();
            Node result = dictionaryDs.Find(userInputDelete);

            if (userInputDelete != null)
            {
                if (result != null)
                {
                    Console.WriteLine("");
                    dictionaryDs.DelOp(userInputDelete);
                    if (userInputDelete != null)
                    {
                        if (result != null)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Succussfully Deleted");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Failed to Delete");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Failed to Delete, As No Key with the name ({0}) was found", userInputDelete);
                }
            }
                //dictionaryDs.DelOp(userInputDelete);
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to go Back...");
            Console.ReadKey();
        }//end of deleteat all#
        static void DeleteAllOp()
        {
            int userInput = 8;
            var entries = dictionaryDs.GetAllEntries();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("---Delete All Operation---");
                Console.WriteLine();
                Console.WriteLine("Would you like to Remove all Entries From dictionary?");
                Console.WriteLine();
                Console.WriteLine("0- Remove all Entries From dictionary");
                Console.WriteLine("1- Press any key to go Back...");
                Console.WriteLine();
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine();
                    if (userInput >= 0 && userInput <= 1)
                    {
                        switch (userInput)
                        {
                            case 0:
                                dictionaryDs.ClearAllEntries();
                                break;
                            case 1:
                                return;
                        }
                    }
                    if (entries.Any() && userInput >= 0 && userInput <= 1)
                    {
                        Console.WriteLine("No entries have been deleted from the dictionary.");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to go Back...");
                        Console.ReadKey();
                        return;
                    }
                    else if(userInput >= 0 && userInput <= 1)
                    {
                        Console.WriteLine("There are no more entries in the dictionary.");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to go Back...");
                        Console.ReadKey();
                        return;
                    }

                }
            }
        }
        static void PrintOp()
        {
            Console.Clear();
            Console.WriteLine("---Print Operation---");
            Console.WriteLine();

            var entries = dictionaryDs.GetAllEntries();

            if (entries.Any())
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("The dictionary is empty.");
            }
            Console.WriteLine("\n");
            Console.WriteLine("---Print Operation---");
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to go Back...");
            Console.ReadKey();
        }
    }
}
        