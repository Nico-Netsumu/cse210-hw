using System.Security.Cryptography.X509Certificates;

class GameManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;
    private string saveFolder = "documents/EQSaves";
    
    public string X = "∞";


    public void Run()
    {
        if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);
        
        while (true)
        {
            Console.WriteLine("\nWelcome to Eternal Quest! Select your action!\n\n1. Create Goal\n2. Record Progress\n3. Show Goals\n4. Save\n5. Load\n6. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": RecordGoalProgress(); break;
                case "3": ShowGoals(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": return;
                default: Console.WriteLine("Fatal error! Make sure you wrote the correct number!"); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\n\n\n\n\nSelect goal type:\n1. Simple\n2. Eternal\n3. Checklist");
        string type = Console.ReadLine();
        Console.Write($"\n\n\n\n\n\n\n\nHow is the Goal called? : ");
        string name = Console.ReadLine();
        Console.Write("Write a brief description about the goal: ");
        string description = Console.ReadLine();
        Console.Write("How many points you earn per completion? : ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal { Name = name, Description = description, Points = points, IsCompleted = false });
                break;
            case "2":
                goals.Add(new EternalGoal { Name = name, Description = description, Points = points });
                break;
            case "3":
                Console.Write("What's are the most desearible times you want to accomplish the goal? For Bonus points: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("How many Bonus points if reached that many times the goal?: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal { Name = name, Description = description, Points = points, TargetCount = targetCount, BonusPoints = bonusPoints, CurrentCount = 0 });
                break;
            default:
                Console.WriteLine("Fatal error! You should not write words, only awnser with numbers!");
                Console.ReadLine();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                break;
        }
    }

    private void RecordGoalProgress()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            string check = " "; // Default: Not completed
            string infonum = " ";

            if (goals[i] is SimpleGoal simpleGoal)
            {
                check = simpleGoal.IsCompleted ? "X" : " ";
            }
            else if (goals[i] is EternalGoal eternalGoal)
            {
                check = X;
            }
            else if (goals[i] is ChecklistGoal checklistGoal)
            {
                check = (checklistGoal.CurrentCount >= checklistGoal.TargetCount) ? "X" : " ";
                infonum = $" -- Completed {checklistGoal.CurrentCount} / {checklistGoal.TargetCount} times";
            }

            Console.WriteLine($"[{check}] {i + 1}. {goals[i].Name} : {goals[i].Description}{infonum}.");
        }

        Console.Write("Write the goal's name you achieved! : ");
        string name = Console.ReadLine();
        Goal goal = goals.Find(g => g.Name == name);
        if (goal != null)
        {
            goal.RecordProgress();
            score += goal.Points;
        }
        else
        {
            Console.WriteLine("Fatal error! Goal's name not found, make sure you wrote it properly,\nor in case you didn't load your previous save data, do it right now!");
            Console.ReadLine();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
        }
    }

    private void ShowGoals()
    {
        Console.WriteLine($"\n\n\n\n\n\n\n\n\n\nCurrent Score: {score}");
        for (int i = 0; i < goals.Count; i++)
        {
            string check = " "; // Default: Not completed
            string infonum = " ";

            if (goals[i] is SimpleGoal simpleGoal)
            {
                check = simpleGoal.IsCompleted ? "X" : " ";
            }
            else if (goals[i] is EternalGoal)
            {
                check = X;
            }
            else if (goals[i] is ChecklistGoal checklistGoal)
            {
                check = (checklistGoal.CurrentCount >= checklistGoal.TargetCount) ? "X" : " ";
                infonum = $" -- Completed {checklistGoal.CurrentCount} / {checklistGoal.TargetCount} times";
            }

            Console.WriteLine($"[{check}] {i + 1}. {goals[i].Name} : {goals[i].Description}{infonum}.");
        }
        Console.ReadLine();
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
    }


    private void SaveGoals()
    {
        Console.Write("Enter a name for your new save data: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter($"{saveFolder}/{filename}.txt"))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }
        Console.ReadLine();
        Console.WriteLine("\n\n\n\n\n\n\n\n\n");
    }

    private void LoadGoals()
    {
        Console.Write("Enter the name of the saved data you want to load: ");
        string filename = Console.ReadLine();
        string path = $"{saveFolder}/{filename}.txt";
        if (!File.Exists(path))
        {
            Console.WriteLine("Fatal Error! File not found, make sure you wrote it correctly");
            Console.ReadLine();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            return;
        }
        
        string[] lines = File.ReadAllLines(path);
        score = int.Parse(lines[0]);
        goals.Clear();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            string type = parts[0].Split(':')[0];
            string name = parts[0].Split(':')[1];
            string description = parts[1];
            int points = int.Parse(parts[2]);
            
            if (type == "SimpleGoal")
                goals.Add(new SimpleGoal { Name = name, Description = description, Points = points, IsCompleted = bool.Parse(parts[3]) });
            else if (type == "EternalGoal")
                goals.Add(new EternalGoal { Name = name, Description = description, Points = points });
            else if (type == "ChecklistGoal")
                goals.Add(new ChecklistGoal { Name = name, Description = description, Points = points, BonusPoints = int.Parse(parts[3]), TargetCount = int.Parse(parts[4]), CurrentCount = int.Parse(parts[5]) });
        }
    }
}