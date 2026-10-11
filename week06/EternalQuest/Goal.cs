using System;

// The abstract base class that holds all shared state and behavior for goals.
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Records an accomplishment and returns the points awarded.
    // Returns an int so the manager never needs to know the goal type
    // (a NegativeGoal simply returns a negative number).
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "X" : " ";
        return $"[{checkbox}] {GetShortName()} ({GetDescription()})";
    }

    // Serializes the goal so it can be saved to a file.
    public abstract string GetStringRepresentation();
}