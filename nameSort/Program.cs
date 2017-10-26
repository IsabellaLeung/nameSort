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
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("You haven't given me anything to sort!");
                return;
            } 

            //Read each line of the file into a string array
            string[] lines = System.IO.File.ReadAllLines(args[0]);

            //List to store each line/name in 
            List <string> namesList = new List<string>();
            string path = Directory.GetCurrentDirectory() + @"\" + "sorted-names-list.txt";

            //Add each line of the file to the name list then sort by last name
            foreach (string line in lines)
            {
                //Make sure the name has at least 2 names (first/last) but does not exceed 4 (3first/1last max)
                if (line.Count(Char.IsWhiteSpace) <= 3 && line.Count(Char.IsWhiteSpace) >= 1)
                {
                    namesList.Add(line); 
                }
                else
                {
                    Console.WriteLine("Invalid name inserted");
                }
            }

            //Order the names list first by surname, then by first name if surnames are the same
            namesList = namesList.OrderBy(x => x.Split(' ').Last()).ThenBy(x => x).ToList();

            //Create a new file to store ordered names in
            using (StreamWriter newNamesList = File.CreateText(path))
            {
                foreach (string orderedName in namesList)
                {
                    newNamesList.WriteLine(orderedName);
                } 
            }

            //Write ordered names to console
            namesList.ForEach(i => Console.WriteLine("{0}\n", i));

            //Keep the console window open
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
