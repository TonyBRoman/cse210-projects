using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1,101);

        int guess = 0;
        int attempts = 0;

        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess?: ");
            guess = int.Parse(Console.ReadLine());

            attempts++;

            if (guess == magicNumber)
            {
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {attempts} guesses.");
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