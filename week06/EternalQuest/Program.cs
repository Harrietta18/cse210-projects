using System;

class Program
{
    /*
        EXCEEDING REQUIREMENTS:
        1. Leveling System - The player levels up every 1000 points and earns a new
           rank title (Novice -> Apprentice -> Adventurer -> Hero -> Champion ->
           Legend -> Ninja Unicorn). A "LEVEL UP!" celebration is displayed.
        2. Negative Goals - A fourth goal type for "bad habits" (e.g., biting nails).
           Recording one of these SUBTRACTS points from the score, encouraging
           the player to avoid them.
        3. Completion Celebrations - When a Simple Goal or Checklist Goal is fully
           finished for the first time, a special congratulations message appears.
    */

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}