using System;

class Program
{
    static void Main(string[] args)
    {
        Assigment assigment = new Assigment("Samuel Bennet", "Multiplication");

        Console.WriteLine(assigment.GetSummary());
    }
}