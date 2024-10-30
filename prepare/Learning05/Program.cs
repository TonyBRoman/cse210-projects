using System;

class Program
{
    static void Main(string[] args)
    {
        Assigment assigment = new Assigment("Samuel Bennet", "Multiplication");

        Console.WriteLine(assigment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
    }
}

