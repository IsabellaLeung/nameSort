using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace nameSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Check input is not nothing
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("You haven't given me anything to sort!");
                return;
            } 

            //Input file
            string[] fileToOpen = File.ReadAllLines(args[0]);

            //Read file
            var unsortedList = ListOfNames.NamesList(fileToOpen);
            //Sort file
            var sortedList = SortingNames.SortNames(unsortedList);

            //Save file
            SaveToFile.SaveSortedList(sortedList);

            //Keep the console window open
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }

    public class ListOfNames
    {
        public static List<string> NamesList(string[] textInFile)
        {
            List<string> nameList = new List<string>();

            //Add each line of the file to the name list then sort by last name
            foreach (string line in textInFile) {
                //Make sure the name has at least 2 names (first/last) but does not exceed 4 (3first/1last max) 
                if (line.Count(Char.IsWhiteSpace) <= 3 && line.Count(Char.IsWhiteSpace) >= 1)
                {
                    nameList.Add(line);
                }
                else
                {
                    Console.WriteLine("Invalid name inserted");
                }
            }
            return nameList;
        }
    }

    public class SortingNames
    {
        public static List<string> SortNames(List<string> listToSort)
        {
            //Order the names list first by surname, then by first name if surnames are the same
            listToSort = listToSort.OrderBy(x => x.Split(' ').Last()).ThenBy(x => x).ToList();
            //Print to Console
            listToSort.ForEach(i => Console.WriteLine("{0}\n", i));
            return listToSort;
        }
    }

    public class SaveToFile 
    {
        public static List<string> SaveSortedList(List<string> fileToSave)
        {
            //Save file in same dir as unsorted list
            string path = Directory.GetCurrentDirectory() + @"\" + "sorted-names-list.txt";
            using (StreamWriter newNamesList = File.CreateText(path))
            {
                foreach (string orderedName in fileToSave)
                {
                    newNamesList.WriteLine(orderedName); 
                }
            }
            return fileToSave;
        }
    }
}
