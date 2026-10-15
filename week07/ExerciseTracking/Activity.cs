using System;

public abstract class Activity
{
    // Protected (not private) because derived classes need _minutes
    // for their speed/pace calculations — allowed per the rubric
    protected DateTime _date;
    protected double _minutes;

    public Activity(DateTime date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Abstract methods: declared here, implemented (overridden) in each
    // derived class, because each activity calculates them differently
    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    // Defined ONCE here — never needs overriding, because it calls the
    // abstract methods above and polymorphism picks the right version
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.00} min per mile";
    }
}