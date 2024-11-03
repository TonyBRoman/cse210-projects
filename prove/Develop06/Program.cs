using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYou have {totalPoints} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    Console.Write("Enter the filename to save goals to: ");
                    string saveFilename = Console.ReadLine();
                    SaveGoals(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load goals from: ");
                    string loadFilename = Console.ReadLine();
                    LoadGoals(loadFilename);
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("Select a goal type: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("What is the short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int point = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                goals.Add(new SimpleGoal(name, point, description));
                break;

            case "2":
                goals.Add(new EternalGoal(name, point, description));
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, point, targetCount, bonusPoints, description));
                break;

            default:
                Console.WriteLine("Invalid goal type selected");
                break;
        }
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The Goals are: ");
        for (int i = 0; i < goals.Count; i++)
        {
            string status = goals[i].IsCompleted ? "[X]" : "[ ]";
            string output = $"{i + 1}. {status} {goals[i].Name} ({goals[i].Description})";

            if (goals[i] is ChecklistGoal checklistGoal)
            {
                output += $" --- Currently completed: {checklistGoal.CurrentCount} of {checklistGoal.TargetCount}";
            }

            Console.WriteLine(output);
        }
    }

    static void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Points until now: {totalPoints}");
            foreach (Goal goal in goals)
            {
                string line = goal.GetType().Name + ": " +
                              goal.Name + "," +
                              goal.Description + "," +
                              "Points: " + goal.Points + "," +
                              (goal is ChecklistGoal checklistGoal ? $"Bonus: {checklistGoal.BonusPoints}" : 
                              $"Completed: {goal.IsCompleted}");
                writer.WriteLine(line);
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;

            
            if ((line = reader.ReadLine()) != null && line.StartsWith("Points until now:"))
            {
                string pointsStr = line.Substring("Points until now: ".Length);
                if (int.TryParse(pointsStr, out int parsedPoints))
                {
                    totalPoints = parsedPoints;
                }
                else
                {
                    Console.WriteLine("Error parsing total points.");
                    return;
                }
            }

            
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length < 3)  
                {
                    Console.WriteLine("Skipping invalid line: " + line);
                    continue;
                }

                string type = parts[0].Split(':')[0].Trim();
                string name = parts[0].Split(':')[1].Trim();
                string description = parts[1].Trim();

                if (!int.TryParse(parts[2].Split(':')[1].Trim(), out int points))
                {
                    Console.WriteLine("Error parsing points from line: " + line);
                    continue;
                }

                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(name, points, description));
                        break;

                    case "EternalGoal":
                        goals.Add(new EternalGoal(name, points, description));
                        break;

                    case "ChecklistGoal":
                        if (parts.Length >= 4)
                        {
                            if (!int.TryParse(parts[3].Split(':')[1].Trim(), out int bonusPoints))
                            {
                                Console.WriteLine("Error parsing bonus points from line: " + line);
                                continue;
                            }

                            ChecklistGoal checklistGoal = new ChecklistGoal(name, points, 0, bonusPoints, description);
                            goals.Add(checklistGoal);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ChecklistGoal format, skipping: " + line);
                        }
                        break;

                    default:
                        Console.WriteLine($"Unknown goal type: {type}");
                        break;
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < goals.Count; i++)
        {
            string status = goals[i].IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {goals[i].Name}");
        }

        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal selectedGoal = goals[goalNumber - 1];
        int earnedPoints = selectedGoal.RecordEvent();

        if (earnedPoints > 0)
        {
            totalPoints += earnedPoints;
            Console.WriteLine($"Congratulations! you have earned {earnedPoints} points!");
            Console.WriteLine($"You now have {totalPoints} points.");
        }
        else
        {
            Console.WriteLine($"The goal '{selectedGoal.Name}' is already completed. No points awarded.");
        }
    }
}

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }
    public string Description { get; set; }

    public Goal(string name, int points, string description)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
        Description = description;
    }

    public abstract int RecordEvent();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points, string description) : base(name, points, description) { }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Points;
        }
        return 0; 
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points, string description) : base(name, points, description) { }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Points;
        }
        return 0; 
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int BonusPoints { get; set; }
    public int CurrentCount { get; set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints, string description) : base(name, points, description)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override int RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }
}

