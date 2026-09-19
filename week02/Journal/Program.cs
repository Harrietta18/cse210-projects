/*
Exceeding Requirements Report:
1. Implemented proper CSV formatting and parsing in saving and loading operations (Entry.ToCsv() and Journal.ParseCsvLine()).
   This allows entries containing commas, quotes, and special characters to save cleanly without breaking the file structure,
   ensuring full compatibility when opened directly in Microsoft Excel.
2. Expanded the prompt list to include additional prompts beyond the baseline required five.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a number from 1 to 5.\n");
                    break;
            }
        }
    }
}