using System;
using System.Collections.Generic;
//Well done Claire.  You're showing a strong understanding of the language already.
namespace basic13
{
    class Program
    {
       public static void Count()
       {
           for (int i = 1; i <= 255; i++)
           {
               Console.WriteLine(i);
           }
       } 
       public static void Count2()
       {
           for (int i = 1; i <= 255; i++)
           {
               if (i % 2 != 0)
               {
                   Console.WriteLine(i);
               }
           }
       }
       public static void PrintSum()
       {
           int sum = 0;
           for (int i = 1; i <= 255; i++)
           {
               sum = sum + i;
               Console.WriteLine("New Number: {0} Sum: {1}", i, sum);
           }
       } 
       public static void Iter()
       {
           int[] array = {1,3,5,7,9,13};
            foreach (var num in array)
            {
                Console.WriteLine(num);
            }
       }
       public static void Max(int[] array)
       {
           int max = array[0];
           foreach (var num in array)
           {
               if (num > max)
               {
                   max = num;
               }
           }
           Console.WriteLine("The max value in the array is {0}", max);
       }
       public static void Average(int[] array)
       {
           int sum = 0;
           foreach (var num in array)
           {
               sum = sum + num;
           }
            int average = sum/(array.Length); // Interesting isn't it that we can say int sum and divide by another int, 
                                              // and say the average will be int as well despite that not always working out that way! 
                                              // like 9(sum)/2(array.Length) = 4.5 This works either way but do you think it's accurate?
            Console.WriteLine("The average of the array is {0}", average);
       }
       public static int[] OddArray()
       {
           List<int> oddList = new List<int>();
           for (int i = 1; i <= 255; i++)
           {
               if (i % 2 == 1)
               {
                   oddList.Add(i);
               }
           }
           return oddList.ToArray(); //clever
       }
       public static void GreaterThan(int[] array, int y)
       {
           int count = 0;
           foreach (int num in array)
           {
               if (num > y)
               {
                   count++;
               }
           }
           Console.WriteLine("There are {0} values greater than Y", count);
       }
       public static void Square(int[] array)
       {
           for (int i = 0; i < array.Length; i++)
           {
               int square = array[i] * array[i];
               array[i] = square;
           }
       }
       public static void Eliminate(int[] array)
       {
           for (int i = 0; i < array.Length; i++)
           {
               if (array[i] < 0)
               {
                   array[i] = 0;
               }
           }
       }
       public static void MinMaxAvg(int[] array)
       {
           int min = array[0];
            int max = array[0];
            int sum = 0;
            foreach (var num in array)
            {
                if(num < min)
                {
                    min = num;
                }
               if (num > max)
               {
                   max = num;
               }
               sum = sum + num;
            }
            int average = sum/(array.Length);
            Console.WriteLine("The min value in the array is {0}", min);
            Console.WriteLine("The max value in the array is {0}", max);
            Console.WriteLine("The average of the array is {0}", average);
       }
       public static void Shift(int[] array)
       {
           for (int i = 0; i < array.Length-1; i++)
           {
               array[i] = array[i+1];
           }
           array[array.Length-1] = 0;
           foreach (int num in array)
           {
               Console.WriteLine(num);
           }
       }
       public static object[] NumberToString(object[] array) // Brilliant to return generic object[], but does a generic object[] come in? Or is it int[]?
       {
           for (int i = 0; i < array.Length; i++)
           {
               if((int)array[i] < 0)
               {
                   array[i] = "Dojo";
               }
           }
           return array;
       }
       public static void Main(string[] args)
        {
            object[] array = {-1,-3,2};
            NumberToString(array);
        }
    }
}
