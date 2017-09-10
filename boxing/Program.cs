using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> box = new List<object>();
            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");
            int sum = 0;
            foreach (var item in box)
            {
                Console.WriteLine(item);
                if (item is int) {
                    sum += (int)item;
                }
            }
            Console.WriteLine("The sum of the integers is {0}", sum);
        }
    }
}
