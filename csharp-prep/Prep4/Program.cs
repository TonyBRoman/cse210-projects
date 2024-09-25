using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;
        while(userNumber !=0)

        {
            Console.Write("Enter a number: ");

            string userReposonse = Console.ReadLine();
            userNumber = int.Parse(userReposonse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        
        int sum = 0;
        foreach(int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The avarage is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");

        int? smallestPositive = null;

        foreach (int number in numbers)
        {
            if (number > 0)
            {
                if (smallestPositive == null || number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }

        if (smallestPositive.HasValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine($"No positive numbers were entered.");
        }
        
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach(int number in numbers)
        {
            Console.WriteLine($" {number}");
        }
    }
}