using System;

class Program
{
    static void Main(string[] args)
    // Temporary code to verify if we can create the functions
    {
        Fraction frac = new Fraction(3, 4);

        Console.WriteLine($"Numerator: {frac.GetTop()}, Denominator: {frac.GetBottom()}");

        frac.SetTop(5);
        frac.SetBottom(8);

        Console.WriteLine($"New Numerator: {frac.GetTop()}, New Denominator: {frac.GetBottom()}");      

    }
}