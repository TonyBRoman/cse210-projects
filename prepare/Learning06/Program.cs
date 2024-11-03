using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 4),
            new Rectangle("Green", 3, 7),
            new Circle("Yellow", 5)
        };

        foreach(Shape shape in shapes)
        {
            Console.WriteLine("Color" + shape.GetColor());
            Console.WriteLine("Area: ", + shape.GetArea());
            Console.WriteLine();
        }
    }
}