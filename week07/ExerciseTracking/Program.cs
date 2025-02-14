using System;
using System.Collections.Generic;

abstract class Activity
{
    private string _date;
    protected int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{GetType().Name} on {_date}: Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} km/h, Pace: {GetPace():F2} min/km";
    }
}

class Running : Activity
{
    private double _distance; // km

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / _minutes) * 60; // km/h
    public override double GetPace() => _minutes / _distance; // min/km
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0; // km
    public override double GetSpeed() => (GetDistance() / _minutes) * 60; // km/h
    public override double GetPace() => _minutes / GetDistance(); // min/km
}

class Cycling : Activity
{
    private double _distance; // km

    public Cycling(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / _minutes) * 60; // km/h
    public override double GetPace() => _minutes / _distance; // min/km
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        List<Activity> activities = new List<Activity>
        {
            new Running("2023-02-14", 30, 5.0),
            new Swimming("2023-02-14", 25, 20),
            new Cycling("2023-02-14", 45, 15.0)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}