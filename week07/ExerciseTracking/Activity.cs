using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;


    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }


    public DateTime GetDate()
    {
        return _date;
    }


    public int GetMinutes()
    {
        return _minutes;
    }


    // These methods are abstract because each activity
    // calculates distance, speed, and pace differently.
    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();



    // This method is shared by all activities.
    // It uses the overridden methods from each child class.
    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_minutes} min): " +
               $"Distance: {GetDistance():0.0} km, " +
               $"Speed: {GetSpeed():0.0} kph, " +
               $"Pace: {GetPace():0.0} min per km";
    }


    private string GetActivityName()
    {
        return GetType().Name;
    }
}