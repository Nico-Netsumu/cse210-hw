using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        int x = 7;
        int y = 3;
        
        if (x > y)
            {
                Console.WriteLine($"{x} is more than {y}");
            }
        else
            {
                Console.WriteLine($"{x} is less than {y}");
            }
    }
}