using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?: ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess = 0;

        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess?: ");
            guess = int.Parse(Console.ReadLine());

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
}