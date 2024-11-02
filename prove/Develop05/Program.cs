using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartBreathing();
                    break;
                    // Console.WriteLine("Starting Breathing Activity...");
                    // break;

                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartReflection();
                    // Console.WriteLine("Starting Reflection Activity...");
                    break;

                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartListing();
                    // Console.WriteLine("Starting Listing Activity...");
                    break;

                case "4":
                    quit = true;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }
}

class Activity
{
    protected int duration;

    public void StartActivity(string activityName, string description)
    {
        Console.WriteLine($"\nWelcome to the {activityName} Activity");
        Console.WriteLine(description);
        Console.Write("\nHow long, in seconds would you like for your session? ");
        duration = int.Parse(Console.ReadLine());

        Console.Write("\nGet ready...");
        PauseWithCountdown(5," ");
    }

    public void EndActivity(string activityName)
    {
        Console.WriteLine("\nWell done!!");
        Console.WriteLine($"\nYou have completed another {duration} seconds of the {activityName} Activity.");
        PauseWithAnimation();
    }

    protected void PauseWithAnimation()
    {
        for (int i = 0; i<3; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void PauseWithCountdown(int seconds, string message)
    {
        Console.Write(message);
        for (int i = 4; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void PauseWithSpiner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
           Console.Write(s);
           Thread.Sleep(1000);
           Console.Write("\b \b"); 
        }

        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    public void StartBreathing()
    {
        StartActivity("Breathing","\nThis activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        int elapsedTime = 0;

        while (elapsedTime < duration)
        {
            PauseWithCountdown(3, "\nBreathe in...");
            elapsedTime +=3;

            if (elapsedTime >= duration) break;

            PauseWithCountdown(3, "Breathe out...");
            elapsedTime +=3;
        }
        EndActivity("Breathig");
    }    
}

class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.", 
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.", 
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "How did you feel when it was complete?",
        "What was your favorite thing about this experience?",
        "What made this time different than other times when tou were not as successful?",
        "What could you learn from this experience that applies to other situations?"
    };

    public void StartReflection()
    {
        StartActivity("Reflection", "\nThis activity will help you felect on times in your life when you have shown strength and resilience.");

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        PauseWithCountdown(5, "");

        var randomQuestions = questions.OrderBy(q => random.Next()).Take(2).ToList();

        foreach (string question in randomQuestions)
        {
            Console.Write($"{question}  ");
            PauseWithSpiner(duration);
        }

        EndActivity("Reflection");
    }
}

class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are the people that you appreciate?",
        "What are personal strenghts of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public void StartListing()
    {
        StartActivity("Listing", "\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"\nList as many responses you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.Write("\nYou may begin in: ");
        PauseWithCountdown(5, " ");

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items!");
        EndActivity("Listing");
    
    }
}