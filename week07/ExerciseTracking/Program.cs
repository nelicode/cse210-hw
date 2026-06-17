using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // I created a list of Activity to store different types
        // of exercises. This demonstrates polymorphism because
        // the list can contain Running, Cycling, and Swimming objects.
        List<Activity> activities = new List<Activity>();


        // I created a Running activity.
        // Running inherits the common information from Activity
        // and uses distance to calculate speed and pace.
        Running running = new Running(
            new DateTime(2022, 11, 3),
            30,
            4.8);


        // I created a Cycling activity.
        // Cycling inherits from Activity and uses speed
        // to calculate distance and pace.
        Cycling cycling = new Cycling(
            new DateTime(2022, 11, 3),
            30,
            20);


        // I created a Swimming activity.
        // Swimming inherits from Activity and uses laps
        // to calculate distance, speed, and pace.
        Swimming swimming = new Swimming(
            new DateTime(2022, 11, 3),
            30,
            40);


        // I added all activities to the same Activity list.
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);



        // I loop through the list and call GetSummary().
        // Each object uses its own overridden methods
        // because of polymorphism.
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}