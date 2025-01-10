using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;


        while (guess != magicNumber)
        {
            Console.Write("Guess the Number!");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("It's not this number, it's higher than that.");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("It's not this number, it's lower than that.");
            }
            else
            {
                Console.WriteLine("You guessed it! Congrats!");
            }

        }                    
    }
}