using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _usedPrompts = new List<string>();
    private List<string> _items = new List<string>();

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetUnusedRandom(_prompts, _usedPrompts)} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Keep listing items (press enter after each one):");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = ReadLineUntil(endTime);
            if (!string.IsNullOrWhiteSpace(entry))
            {
                _items.Add(entry);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_items.Count} items!");
        DisplayEndingMessage();
    }

    // Reads input one key at a time so the activity ends the moment the
    // chosen duration expires, even if the user is mid-entry.
    private string ReadLineUntil(DateTime endTime)
    {
        string input = "";
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input;
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            Thread.Sleep(50);
        }
        return null;
    }
}