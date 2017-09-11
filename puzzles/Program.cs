using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static int[] RandomArray()
        {
            Random rand = new Random();
            List<int> randomNums = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                randomNums.Add(rand.Next(5,25));
            }
            int[] array = randomNums.ToArray();
            int min = array[0];
            int max = array[0];
            int sum = 0;
            foreach (int num in array)
            {
                if(num < min)
                {
                    min = num;
                }
                if(num > max)
                {
                    max = num;
                }
                sum += num;
            }
            Console.WriteLine("The Max of the Random Array is {0}", max);
            Console.WriteLine("The Min of the Random Array is {0}", min);
            return array;

        }
        public static string CoinFlip()
        {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int chance = rand.Next(0,2);
            string result = "Tails";
            if (chance == 0)
            {
                result = "Heads";
            }
            Console.WriteLine(result);
            return result;
        }
        public static double TossMultipleCoins(int num)
        {
            int heads = 0;
            for (int reps = 0; reps < num; reps++)
            {
                if(CoinFlip(result == "Heads"))
                {
                    heads++;
                }
            }
            double ratio = (double)heads/(double)num;
            return ratio;
        }
        public static string[] Names()
        {
            string[] names = new string[5] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            for (int i = 0; i < names.Length - 1; i++)
            {
                int randIdx = rand.Next(idx + 1, names.Length - 1)
                string temp = names[i];
                names[i] = names[randIdx];
                names[randIdx] = temp;
                Console.WriteLine(names[i]);
            }
            Console.WriteLine(names[names.Length-1]);
            List<string> nameList = new List<string>();
            foreach (var name in names)
            {
                if (name.Length > 5)
                {
                    nameList.Add(name);
                }
            }
            return nameList.ToArray();
        }
        static void Main(string[] args)
        {
            RandomArray();
            CoinFlip();
            TossMultipleCoins(4);
            Names();
        }
    }
}
