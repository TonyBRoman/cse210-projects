using System;

class Program
{
    static void Main(string[] args)
    // Temporary code to verify if we can create the functions
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(6);
        Fraction frac3 = new Fraction(6, 7);
        
        frac1.DisplayFraction();
        frac2.DisplayFraction();
        frac3.DisplayFraction();
    }
}