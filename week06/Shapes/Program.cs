using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(
            new Square(
                "Pink",
                5));

        shapes.Add(
            new Rectangle(
                "Purple",
                4,
                6));

        shapes.Add(
            new Circle(
                "Lavender",
                3));

        Console.WriteLine("Shapes and Areas");
        Console.WriteLine("----------------");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(
                $"Color: {shape.GetColor()}");

            Console.WriteLine(
                $"Area: {shape.GetArea():F2}");

            Console.WriteLine();
        }
    }
}