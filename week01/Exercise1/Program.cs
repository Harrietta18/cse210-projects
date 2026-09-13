using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first Name?");
        string first =Console.ReadLine();

        Console.Write("What is your last Name?");
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}.");

    }
}