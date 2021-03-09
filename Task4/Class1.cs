using System;
using System.IO;
using System.Text;

namespace Task4
{
    //*а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. 
    //Создать методы, которые возвращают 
    //сумму всех элементов массива, 
    //сумму всех элементов массива больше заданного,
    //свойство, возвращающее минимальный элемент массива,
    //свойство, возвращающее максимальный элемент массива,
    //метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
    //* б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    //Дополнительные задачи
    //в) Обработать возможные исключительные ситуации при работе с файлами.
    public class MyMultiArray
    {
        private int[,] _array;
        private int _size1;
        private int _size2;
        public int MinElement { get { return GetMinElement(); } }
        public int MaxElement { get { return GetMaxElement(); } }


        public MyMultiArray(int size1, int size2)
        {
            _array = new int[size1, size2];
            _size1 = size1;
            _size2 = size2;
            Random random = new Random();

            for (int i = 0; i <= size1 - 1; i++)
            {
                for (int j = 0; j <= size2 - 1; j++)
                {
                    _array[i, j] = random.Next(-10000, 10000);
                    Console.Write($"[{i},{j}]: {_array[i, j]}, ");
                }
            }

        }

        public MyMultiArray(string pathToFile)
        {
            ReadFromFile(pathToFile);
        }

        public int Sum()
        {
            int sum = 0;

            for (int i = 0; i <= _size1 - 1; i++)
            {
                for (int j = 0; j <= _size2 - 1; j++)
                {
                    sum += _array[i,j];
                }
            }

            return sum;
        }

        public int SumGreaterThen(int number)
        {
            int sum = 0;

            for (int i = 0; i <= _size1 - 1; i++)
            {
                for (int j = 0; j <= _size2 - 1; j++)
                {
                    if (_array[i,j] > number)
                    sum += _array[i, j];
                }
            }

            return sum;
        }

        public int GetMinElement()
        {
            int min = 0;

            for (int i = 0; i <= _size1 - 1; i++)
            {
                for (int j = 0; j <= _size2 - 1; j++)
                {
                    if (_array[i, j] < min)
                        min = _array[i, j];
                }
            }

            return min;
        }

        public int GetMaxElement()
        {
            int max = 0;

            for (int i = 0; i <= _size1 - 1; i++)
            {
                for (int j = 0; j <= _size2 - 1; j++)
                {
                    if (_array[i, j] > max)
                        max = _array[i, j];
                }
            }

            return max;
        }

        private void ReadFromFile(string pathToFile)
        {
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                int size1 = Convert.ToInt32(sr.ReadLine()); // 3
                int size2 = Convert.ToInt32(sr.ReadLine()); // 4

                _size1 = size1;
                _size2 = size2;
                _array = new int[size1, size2];

                int i = 0;

                while (!sr.EndOfStream && i != size1)
                {
                    string arrayLine = sr.ReadLine(); // 1,2,3,4
                    string[] lineElements = arrayLine.Split(',');

                    for (int j = 0; j <= size2 - 1; j ++)
                    {
                        _array[i, j] = Convert.ToInt32(lineElements[j]);
                    }

                    i++;
                }
            }
        }

        public void WriteToFile(string pathToFile)
        {
            using (StreamWriter sw = new StreamWriter(pathToFile))
            {
                sw.WriteLine(_size1);
                sw.WriteLine(_size2);

                for (int i = 0; i <= _size1 - 1; i++)
                {
                    StringBuilder arrayLineBilder = new StringBuilder();

                    for (int j = 0; j <= _size2 - 1; j++)
                    {
                        if (j == 0)
                        {
                            arrayLineBilder.Append(_array[i, j]);
                        }
                        else
                        {
                            arrayLineBilder.Append($",{_array[i, j]}");
                        }
                    }

                    sw.WriteLine(arrayLineBilder);
                }
            }
        }

        public void MaxElementIndex(ref int index)
        {
            int max = MaxElement;

            for (int i = 0; i <= _size1 - 1; i++)
            {
                for (int j = 0; j <= _size2 - 1; j++)
                {
                    if (_array[i, j] == max)
                        index = i * _size1 + j;
                }
            }
        }


    }

    public static class Task4
    {
        public static void Execute()
        {
            try
            {
                MyMultiArray multiArray = new MyMultiArray(20, 20);

                int sum = multiArray.Sum();
                Console.WriteLine($"Summa = {sum}");

                int sumnum = multiArray.SumGreaterThen(777);
                Console.WriteLine($"The sum of the elements is greater than the given {sumnum}");

                int min = multiArray.MinElement;
                Console.WriteLine($"Min element {min}");

                int max = multiArray.MaxElement;
                Console.WriteLine($"Max element {max}");

                int maxIndex = 0;

                multiArray.MaxElementIndex(ref maxIndex);

                Console.WriteLine($"Max index is {maxIndex}");

                multiArray.WriteToFile(@"C:\multiArrayData1.txt");

                MyMultiArray multiArray1 = new MyMultiArray(@"C:\multiArrayData1.txt");
                Console.WriteLine("Array loaded");
            }
            catch(IOException ex)
            {
                Console.WriteLine($"Error working with file {ex}");
            }
        }
    }
}
