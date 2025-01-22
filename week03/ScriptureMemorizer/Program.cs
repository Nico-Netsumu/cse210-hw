using System;

namespace ScriptureHider
{
    // Main Function
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            var reference = new Reference("Proverbs", 3, 5, 6);
            var scripture = new Scripture(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding.");
           
            while (true)
            {
                Console.WriteLine("Welcome to the Scripture Memo!\n");
                
                Console.Clear();
                Console.WriteLine(scripture);
                
                if (scripture.AreAllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Program will now end.");
                    break;
                }

                Console.WriteLine("\nPress enter and try harder by memorising the following scripture line. Write 'quit' to finish it immediately.");
                var input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords();
            }
        }
    }
}
