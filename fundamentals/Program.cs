using System;

namespace fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
             for (int i = 1; i <= 256; i++)
            {
                Console.WriteLine(i);
            }
            int x = 1;
            while (x < 101)
            {
                if (x % 5 == 0 && x % 3 == 0)
                {
                    x = x + 1;
                }
                else if (x % 5 == 0) {
                    Console.WriteLine(x);
                    x = x + 1;
                }
                else if (x % 3 == 0) {
                    Console.WriteLine(x);
                    x = x + 1;
                }
                else
                {
                    x = x + 1;
                }
            }
            int y = 1;
            while (y < 101)
            {
                if (y % 5 == 0 && y % 3 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                    y = y + 1;
                }
                else if (y % 5 == 0) {
                    Console.WriteLine("Buzz");
                    y = y + 1;
                }
                else if (y % 3 == 0) {
                    Console.WriteLine("Fizz");
                    y = y + 1;
                }
                else
                {
                    y = y + 1; // random comment
                }
            }
            Random rand = new Random();
            for (int z = 0; z < 10; z++)
            {
                int num = rand.Next();
                if (num % 5 == 0 && num % 3 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (num % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (num % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
