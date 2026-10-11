using System;

// Creative addition: a goal for bad habits. Recording it LOSES points.
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -GetPoints(); // Subtract points instead of adding them
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {GetShortName()} ({GetDescription()}) -- Loses {GetPoints()} points each time recorded";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
    }
}