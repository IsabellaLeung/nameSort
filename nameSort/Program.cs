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
            Console.WriteLine("Welcome to The Sorter! Please either enter a .txt file on its own or a list of words separated by a comma and space e.g 'a, b, c' NOT 'a,b,c,'.  If you would like to enter names please enclose them each in double quotes before using a comma in between.");

            List<string> unsortedList = new List<String>();
            
            //Check input is not nothing
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("You haven't given me anything to sort!");
                return;
            }
            //If inputing a .txt file
            else if (args != null && args.Length == 1)
            {
                string[] fileToOpen = File.ReadAllLines(args[0]);
                ListOfNames takeUnsortedList = new ListOfNames();
                unsortedList = takeUnsortedList.NamesList(fileToOpen);
            }
            //If writing list in to args
            else if (args!= null && args.Length > 1)
            {
                List<string> wordList = new List<string>();
                foreach (string word in args)
                {
                    wordList.Add(word.TrimEnd(','));
                }
                unsortedList = wordList;
            }

            //Sort list whichever way it is given
            ISortingNames theSorter = new AscendingSorter();
            ISortingNames theSorter2 = new DescendingSorter();

            var sortedListAsc = theSorter.Sort(unsortedList);
            var sortedListDesc = theSorter2.Sort(unsortedList);

            //ISortingNames theSorter;
            //var sortedList = theSorter.Sort(unsortedList);

            //Save file
            SaveToFile finalList = new SaveToFile();
            //var saveFinalList = finalList.SaveSortedList();

            //Keep the console window open
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }

    public class ListOfNames
    {
        public List<string> NamesList(string[] textInFile)
        {
            List<string> nameList = new List<string>();

            //Add each line of the file to the name list
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
    
    public interface ISortingNames
    {
        List<string> Sort(List<string> listToSort);
    }

    public class AscendingSorter : ISortingNames
    {
        public List<string> Sort(List<string> listToSort)
        {
            //Order the names list first by surname, then by first name if surnames are the same
            listToSort = listToSort.OrderBy(x => x.Split(' ').Last()).ThenBy(x => x).ToList();
            //Print to Console
            Console.WriteLine("Names in ascending order:");
            listToSort.ForEach(i => Console.WriteLine("{0}\n", i));
            return listToSort;
        }
    }

    public class DescendingSorter : ISortingNames
    {
        public List<string> Sort(List<string> listToSort)
        {
            //Order the names list first by surname, then by first name if surnames are the same
            listToSort = listToSort.OrderByDescending(x => x.Split(' ').Last()).ThenBy(x => x).ToList();
            //Print to Console
            Console.WriteLine("Names in descending order:");
            listToSort.ForEach(i => Console.WriteLine("{0}\n", i));
            return listToSort;
        }
    }

    public class SaveToFile 
    {
        public List<string> SaveSortedList(List<string> fileToSave)
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
