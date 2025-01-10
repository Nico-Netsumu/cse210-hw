using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the class grade dataminer!");
        Console.Write("What is your percentage on this class? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"The grade letter you got is: {letter}");
        
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You Successfully passed to the next class!");
        }
        else
        {
            Console.WriteLine("Better luck next time! ");
        }

    }
}