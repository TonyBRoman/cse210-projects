using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes") 
        {
            Random random = new Random();
            int magicNumber = random.Next(1,101);

            int guess = 0;
            int attempts = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess?: ");
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

            
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine(); 
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}
