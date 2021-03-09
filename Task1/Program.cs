using System;

namespace Task1
{
    //Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 
    //до 10 000 включительно. Заполнить случайными числами. Написать программу, позволяющую найти и вывести 
    //количество пар элементов массива, в которых только одно число делится на 3. В данной задаче под парой 
    //подразумевается два подряд идущих элемента массива.
//Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
    public class Massive
    {
        public static bool IsPair(int a, int b)
        {
            return (a % 3 == 0 && b % 2 != 0) || (a % 3 != 0 && b % 2 == 0);
        }
        public static void Main()
        {
            int[] array = new int[20];
            Random random = new Random();
            for (int i=0; i < array.Length-1; i++)
            {
                array[i] = random.Next(-10000, 10000);
                Console.Write($"{array[i]}, ");
            }

            int count = 0;
            for (int i = 0; i < array.Length - 2; i++)
            {
                if (IsPair(array[i], array[i + 1]))
                    count++;
            }
            Console.WriteLine();
            Console.WriteLine($"Pair count {count}");
        }
    }
}
