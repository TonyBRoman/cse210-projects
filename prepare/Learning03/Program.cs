using System;

class Program
{
    static void Main(string[] args)
    // Temporary code to verify if we can create the functions
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(5);
        Fraction frac3 = new Fraction(3, 4);
        Fraction frac4 = new Fraction(1, 3);

        Console.WriteLine($"{frac1.GetFractionString()}");
        Console.WriteLine($"{frac1.GetDecimalValue()}");
        Console.WriteLine($"{frac2.GetFractionString()}");
        Console.WriteLine($"{frac2.GetDecimalValue()}");
        Console.WriteLine($"{frac3.GetFractionString()}");
        Console.WriteLine($"{frac3.GetDecimalValue()}");
        Console.WriteLine($"{frac4.GetFractionString()}");
        Console.WriteLine($"{frac4.GetDecimalValue()}");

    }
}