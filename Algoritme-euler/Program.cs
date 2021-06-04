using System;

namespace Algoritme
{
    class Program
    {
        static void Main(string[] args)
        {
            //Euler algorithm practice

            /*int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine($"Answer 1 = {sum}");*/

            int PreviousNum = 1;
            int currentNum = 2;
            int sum = currentNum;
            while (currentNum <= 4000000)
            {
                int tempNum = PreviousNum;
                PreviousNum = currentNum;
                currentNum = tempNum + currentNum;
                if (currentNum % 2 == 0)
                {
                    sum += currentNum;
                }
            }
            Console.WriteLine($"Answer 2 = {sum}");
        }
    }
}
