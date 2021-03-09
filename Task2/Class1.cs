using System;
using System.IO;

namespace Task2
{
    //2. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив заданной размерности 
    //и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которые возвращают сумму 
    //элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, умножающий каждый элемент массива 
    //на определенное число, свойство MaxCount, возвращающее количество максимальных элементов. В Main продемонстрировать работу класса.
    //б)* Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

    public class MyArray
    {
        private int[] _array;
        private int _size;
        private int _starValue;
        private int _step;

        public int MaxCount { get { return GetMaxCount(); } }

        public int Sum{ get { return GetSum(); } }
        public MyArray(int size, int startValue, int step)
        {
            Initialize(size, startValue, step);
        }

        public MyArray(string pathToFile)
        {
            string[] data = File.ReadAllLines(pathToFile);
            int size = Convert.ToInt32(data[0]);
            int startValue = Convert.ToInt32(data[1]);
            int step = Convert.ToInt32(data[2]);

            Initialize(size, startValue, step);
        }
        

        public int[] Inverse()
        {
            return Multi(-1);

        }
        public int[] Multi(int multiplicator)
        {
            int[] resultarray = new int[_array.Length];
            for (int i = 0; i < _array.Length - 1; i++)
            {
                resultarray[i] = _array[i] * multiplicator;
            }
            return resultarray;
        }

        public void SaveToFile(string pathToFile)
        {
            File.WriteAllText(pathToFile, $"{_size}\n{_starValue}\n{_step}");
        }

        private void Initialize(int size, int startValue, int step)
        {
            _size = size;
            _starValue = startValue;
            _step = step;

            _array = new int[size];
            for (int i = 0; i < _array.Length - 1; i++)
            {
                _array[i] = startValue + step * i;
            }
        }

        private int GetMaxCount()
        {
            int max = 0;
            foreach (int item in _array)
            {
                if (max < item)
                    max = item;
            }
            int maxcount = 0;
            foreach (int item in _array)
            {
                if (item == max)
                    maxcount++;
            }
            return maxcount;
        }
        private int GetSum()
        {
            int sum = 0;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                sum = sum + _array[i];
            }
            return sum;
        }
    }

    public static class Task2
    {
        public static void Execute()
        {
            MyArray myArray = new MyArray(30, 5, 7);
            myArray.SaveToFile(@"C:\myArray1.txt");


            MyArray arrayFromFile = new MyArray(@"C:\myArray1.txt");
            Console.WriteLine($"Max count {arrayFromFile.MaxCount}");
        }
    }
}
