
using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: Hides only words that are still visible, so every
        // round makes progress. The program also supports verse ranges
        // through the Reference class and exits when the user types quit.

        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text =
            "Trust in the Lord with all thine heart; and lean not unto " +
            "thine own understanding. In all thy ways acknowledge him, " +
            "and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");

            string input = Console.ReadLine() ?? "";

            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (input.Length == 0)
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Good job practicing your scripture!");
    }
}
