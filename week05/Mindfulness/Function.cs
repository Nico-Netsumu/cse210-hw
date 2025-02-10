using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Name}!");
        Console.WriteLine(Description);
        Console.Write("Enter the duration of the activity (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        ShowSpinner(3);
        Console.WriteLine($"You completed the {Name} for {Duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public override void Run()
    {
        Start();
        int timeLeft = Duration;

        while (timeLeft > 0)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            timeLeft -= 3;

            if (timeLeft <= 0) break;

            Console.WriteLine("Breathe out...");
            Countdown(3);
            timeLeft -= 3;
        }

        End();
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

    public override void Run()
    {
        Start();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        ShowSpinner(5);

        int timeLeft = Duration;
        while (timeLeft > 0)
        {
            Console.WriteLine(questions[rand.Next(questions.Count)]);
            ShowSpinner(5);
            timeLeft -= 5;
        }

        End();
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt grateful this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by listing as many things as you can.") { }

    public override void Run()
    {
        Start();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Console.WriteLine("You have a few seconds to think...");
        ShowSpinner(5);

        List<string> responses = new List<string>();
        Console.WriteLine("Start listing items:");
        int timeLeft = Duration;
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
                responses.Add(input);
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        End();
    }
}
