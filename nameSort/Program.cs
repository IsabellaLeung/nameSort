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
            //if (args == null || args.Length == 0)
            //{
            //    Console.WriteLine("You haven't given me anything to sort!");
            //    return;
            //} 

            //Input file
            string[] fileToOpen = File.ReadAllLines("unsorted-names-list.txt");

            //Read file
            ListOfNames takeUnsortedList = new ListOfNames();
            var unsortedList = takeUnsortedList.NamesList(fileToOpen);
            var randomvarthing = new List<String> { "a", "c", "s", "w", "a" };
            var randomvarthing2 = "asdasd!";

            //Sort file
            SortingNames sort = new SortingNames();
            ISortingNames sortAnyName = sort;
            sort.SortNamesAsc(unsortedList);
            sort.SortNamesDesc(unsortedList);
            sort.SortNamesAsc(randomvarthing);
            //sort.SortNamesAsc(randomvarthing2);

            //Save file
            //SaveToFile.SaveSortedList(sortedList);

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
    
    public interface ISortingNames
    {
        List<string> SortNamesAsc(List<string> listToSort);
        List<string> SortNamesDesc(List<string> listToSort);
    }

    public class SortingNames : ISortingNames
    {
        public List<string> SortNamesAsc(List<string> listToSort)
        {
            //Order the names list first by surname, then by first name if surnames are the same
            listToSort = listToSort.OrderBy(x => x.Split(' ').Last()).ThenBy(x => x).ToList();
            //Print to Console
            Console.WriteLine("Names in ascending order:");
            listToSort.ForEach(i => Console.WriteLine("{0}\n", i));
            return listToSort;
        }

        public List<string> SortNamesDesc(List<string> listToSort)
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
