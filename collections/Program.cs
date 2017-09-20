using System;
using System.Collections.Generic;
//The code looks good Claire.  Well done. Looks like you're understanding collections and randoms quite well. 
namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            string[] array2 = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            bool[] array3 = new bool[10];  
            for(int a = 0; a < 10; a += 2)
            {
                array3[a] = true;
            }

            int[,] multiTable = new int[10,10];
            for(int b = 0; b < 10; b++)
            {
                for(int c = 0; c < 10; c++)
                {
                    multiTable[b, c] = (b + 1) * (c + 1);
                }
            }
            for(int x = 0; x < 10; x++)
            {
                string display = "[";
                for(int y = 0; y < 10; y++)
                {
                    display += multiTable[x, y] + ",";
                }
                display += "]";
                Console.WriteLine(display);
            }

            List<string> iceCream = new List<string>();
            iceCream.Add("Rainbow Sherbet");
            iceCream.Add("Daiquiri Ice");
            iceCream.Add("Raspberry Sorbet");
            iceCream.Add("Peanut Butter Pretzel Gelato");
            iceCream.Add("Americone Dream");
            Console.WriteLine(iceCream.Count);
            Console.WriteLine(iceCream[2]);
            iceCream.RemoveAt(2);
            Console.WriteLine(iceCream.Count);

            Dictionary<string,string> userInfo = new Dictionary<string,string>();
            Random rand = new Random();
            foreach (var item in array2)
            {
                userInfo.Add(item, iceCream[rand.Next(iceCream.Count)]);
            }
            foreach(KeyValuePair<string,string> info in userInfo)
            {
                Console.WriteLine(info.Key + " - " + info.Value);
            }
        }
    }
}
