using System;

// =====================================================================
// EXCEEDING REQUIREMENTS — What I added beyond the core requirements:
//
// 1. Scripture library loaded from a file (scriptures.txt).
//    The program looks for "scriptures.txt" in the program folder.
//    Each line has the format:  Reference | Text
//    You can add any number of scriptures, including multi-verse ones.
//    If the file is missing or empty, a built-in library of five
//    scriptures is used so the program always works.
//
// 2. Random scripture selection: each time the program starts, it
//    picks a random scripture from the library to practice.
//
// 3. Stretch challenge completed: random selection only chooses from
//    words that are still visible, so hidden words are never "re-hidden"
//    and progress is always steady.
//
// 4. Hint system: typing "hint" reveals the FIRST LETTER of three
//    hidden words (e.g., "F___ ___ L_____"). First-letter cues are a
//    real memorization technique. Hinted words still count as hidden.
//
// 5. Progress tracker: shows how many words are hidden, the percentage
//    memorized, and how many hints were used at the end.
// =====================================================================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Scripture Memorizer ===");
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Console.WriteLine($"Loaded {library.GetScriptureCount()} scripture(s) from the library.");

        Scripture scripture = library.GetRandomScripture();
        Console.WriteLine($"Today's scripture: {scripture.GetReferenceText()}");
        Console.WriteLine("Press Enter to begin...");
        Console.ReadLine();

        int hintsUsed = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine($"All words are hidden — nice work! ({hintsUsed} hint(s) used)");
                break;
            }

            int hidden = scripture.GetHiddenWordCount();
            int total = scripture.GetTotalWordCount();
            int percent = (int)Math.Round(100.0 * hidden / total);
            Console.WriteLine($"Progress: {hidden}/{total} words hidden ({percent}% memorized)");
            Console.WriteLine();
            Console.Write("Press Enter to hide words, type 'hint' for a clue, or 'quit' to end: ");

            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "quit")
            {
                Console.WriteLine("Goodbye! Come back soon to keep practicing.");
                break;
            }
            else if (input == "hint")
            {
                int hinted = scripture.HintRandomWords(3);
                if (hinted > 0)
                {
                    hintsUsed++;
                }
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}