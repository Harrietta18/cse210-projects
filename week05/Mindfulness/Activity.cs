using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private Random _random = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    // Each child class provides its own version of Run()
    public abstract void Run();

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = ReadPositiveNumber();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(4);
        Console.WriteLine();
    }

    private int ReadPositiveNumber()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.Write("Please enter a positive whole number: ");
        }
        return number;
    }

    protected void ShowSpinner(int seconds)
    {
        ShowSpinner(seconds, DateTime.Now.AddSeconds(seconds));
    }

    // Stops early if the activity's total time runs out mid-spin.
    protected void ShowSpinner(int seconds, DateTime stopTime)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        int index = 0;
        while (DateTime.Now < stopTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Count;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string digits = i.ToString();
            Console.Write(digits);
            Thread.Sleep(1000);
            Console.Write(new string('\b', digits.Length)
                        + new string(' ', digits.Length)
                        + new string('\b', digits.Length));
        }
    }

    // Returns a random item without repeating until all have been used once
    protected string GetUnusedRandom(List<string> fullList, List<string> usedList)
    {
        List<string> available = new List<string>();
        foreach (string item in fullList)
        {
            if (!usedList.Contains(item))
            {
                available.Add(item);
            }
        }
        if (available.Count == 0)
        {
            usedList.Clear();
            available = new List<string>(fullList);
        }
        string choice = available[_random.Next(available.Count)];
        usedList.Add(choice);
        return choice;
    }
}