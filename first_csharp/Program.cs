using System;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 10;
            string word = "Hello";
            bool flag = true;
            int[] numArray = new int[5];
            fizzbuzz(10);
            Random rand = new Random();
            for(int val = 0; val < 10; val++)
            {
                Console.WriteLine(rand.Next(2,8));
            }
        }

        public static void fizzbuzz(int limit)
        {
            for (int i = 1; i < limit; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
