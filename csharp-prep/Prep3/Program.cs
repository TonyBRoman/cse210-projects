using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?: ");
        int magicNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("What is your guess?: ");
        int guess = int.Parse(Console.ReadLine());

        if (guess == magicNumber)
        {
            Console.WriteLine("You guessed it!");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else 
        {
            Console.WriteLine("Higher");
        }
    }
}