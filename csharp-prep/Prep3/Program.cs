using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1,101);

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