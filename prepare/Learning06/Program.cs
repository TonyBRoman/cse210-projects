using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Blue", 5);
        Console.WriteLine("Color: " + square.GetColor());
        Console.WriteLine("Area: " + square.GetArea());
    }
}