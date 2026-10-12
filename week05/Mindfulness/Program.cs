using System;
using System.Collections.Generic;

/*
 * EXCEEDING REQUIREMENTS:
 * 1. No repeats: Random prompts and questions never repeat until every item
 *    in the list has been used at least once in the session
 *    (see Activity.GetUnusedRandom).
 * 2. Breathing animation: Instead of plain digits, breathing shows a bar that
 *    grows while inhaling and shrinks while exhaling, with countdown digits
 *    (see BreathingActivity.ShowBreathBar).
 * 3. Session log: The program tracks how many times each activity was
 *    completed. It can be viewed from menu option 4 and is shown on quit.
 * 4. Input validation: The duration prompt re-asks until the user enters a
 *    positive whole number.
 * 5. Exact timing: The listing activity ends the moment the duration expires
 *    (even mid-typing), and all pauses are clamped so activities never run
 *    over the chosen duration.
 */
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityLog = new Dictionary<string, int>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View session log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            if (choice == "1")
            {
                activity = new BreathingActivity();
            }
            else if (choice == "2")
            {
                activity = new ReflectingActivity();
            }
            else if (choice == "3")
            {
                activity = new ListingActivity();
            }
            else if (choice == "4")
            {
                ShowLog(activityLog);
                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
            else if (choice == "5")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for taking time to be mindful today!");
                ShowLog(activityLog);
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press enter to try again.");
                Console.ReadLine();
            }

            if (activity != null)
            {
                Console.Clear();
                activity.Run(); // Polymorphism: base-type variable, child behavior

                string name = activity.GetName();
                if (!activityLog.ContainsKey(name))
                {
                    activityLog[name] = 0;
                }
                activityLog[name] = activityLog[name] + 1;
            }
        }
    }

    static void ShowLog(Dictionary<string, int> activityLog)
    {
        Console.WriteLine();
        Console.WriteLine("Session Log (times completed):");
        if (activityLog.Count == 0)
        {
            Console.WriteLine("  No activities completed yet.");
        }
        foreach (KeyValuePair<string, int> entry in activityLog)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value}");
        }
    }
}