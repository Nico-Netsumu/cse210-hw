using System;

class Program
{

    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string usern = promptUserName();
        int userNumb = promptUserNumber();

        int squaredNumber = squareNumber(userNumb);

        DisplayResult(usern, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to my program!");
    }

    static string promptUserName()
    {
        Console.Write("Please enter your full name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int promptUserNumber()
    {
        Console.Write("Enter your favorite number! ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int squareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"So you are '{name}', did you know that");
        Console.WriteLine($"your favoritenumber times itself is {square}?");
    }

}