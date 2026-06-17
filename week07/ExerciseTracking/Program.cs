using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // I created a list of type Activity to store all the activities.
        // I used the base class Activity to demonstrate polymorphism because
        // this list can store objects from Running, Cycling, and Swimming.
        List<Activity> activities = new List<Activity>();


        // I created a Running object that inherits from the Activity class.
        // This class uses the distance to calculate the speed and pace.
        activities.Add(
            new Running(
                new DateTime(2022, 11, 3),
                30,
                4.8));


        // I created a Cycling object that inherits from the Activity class.
        // This class uses the speed to calculate the distance and pace.
        activities.Add(
            new Cycling(
                new DateTime(2022, 11, 3),
                30,
                20));


        // I created a Swimming object that inherits from the Activity class.
        // This class uses the number of laps to calculate the distance,
        // speed, and pace of the activity.
        activities.Add(
            new Swimming(
                new DateTime(2022, 11, 3),
                30,
                40));


        // I loop through the list of activities to display the information
        // for each one. Although all objects are stored as Activity,
        // each class uses its own overridden methods through polymorphism.
        foreach (Activity activity in activities)
        {
            // GetSummary() uses the calculations from each derived class
            // to display the correct distance, speed, and pace.
            Console.WriteLine(activity.GetSummary());
        }
    }
}