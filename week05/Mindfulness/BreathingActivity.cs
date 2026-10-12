using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            int inSeconds = Math.Min(4, remaining);
            Console.Write("Breathe in... ");
            ShowBreathBar(inSeconds, true);
            Console.WriteLine();

            remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            if (remaining <= 0) break;

            int outSeconds = Math.Min(6, remaining);
            Console.Write("Breathe out... ");
            ShowBreathBar(outSeconds, false);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    // Creative animation: the bar grows while inhaling and shrinks while
    // exhaling, with countdown digits to pace the breath
    private void ShowBreathBar(int seconds, bool inhale)
    {
        int width = 10;
        int startLeft = Console.CursorLeft;
        for (int step = 0; step < seconds; step++)
        {
            Console.SetCursorPosition(startLeft, Console.CursorTop);
            int filled = inhale ? step + 1 : seconds - step;
            int number = seconds - step;
            Console.Write(new string('#', filled).PadRight(width) + " " + number);
            Thread.Sleep(1000);
        }
        Console.SetCursorPosition(startLeft, Console.CursorTop);
        Console.Write(new string(' ', width + 3));
        Console.SetCursorPosition(startLeft, Console.CursorTop);
    }
}