using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        SortedArray arr = new SortedArray();
        int action = 0;
        while (action != 5)
        {
            Console.WriteLine("\n1. Вивести масив\n" +
                "2. Додати елемент\n" +
                "3. Видалити елемент\n" +
                "4. Знайти елемент\n" +
                "5. Завершити програму\n\n"+
                "Оберiть дiю: ");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    arr.ShowArray(arr.array);
                    break;
                case 2:
                    arr.AddElement(arr.array, arr.arraySize);
                    break;
                case 3:
                    arr.RemoveElement(arr.array, arr.arraySize);
                    break;
                case 4:
                    arr.SearchElement(arr.array);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("\nТакої дiї не iснує, спробуйте ще раз\n");
                    break;

            }
        }
    }
    public class SortedArray
    {
        public int arraySize = 0;
        public List<int> array = new List<int>();
        public void ShowArray(List<int> array)
        {
            if (array.Count > 0)
            {
                Console.WriteLine("\nМасив: ");
                array.ForEach(Console.WriteLine);
            }
            else Console.WriteLine("\nВ масивi зараз немає елементiв");
        }
        public void AddElement(List<int> array, int arraySize)
        {
            Console.WriteLine("\nВведiть елемент, який бажаєте додати: ");
            int newElement = Convert.ToInt32(Console.ReadLine());
            array.Add(newElement);
            array.Sort();
            arraySize = array.Count();
        }
        public void RemoveElement(List<int> array, int arraySize)
        {
            Console.WriteLine("\nВведiть елемент, який бажаєте видалити: ");
            int removingElement = Convert.ToInt32(Console.ReadLine());
            if (array.BinarySearch(removingElement) >= 0)
            {
                array.Remove(removingElement);
                arraySize = array.Count();
            }
            else Console.WriteLine("Такого елементу в масивi не iснує");
        }
        public void SearchElement(List<int> array)
        {
            Console.WriteLine("\nВведiть елемент, який бажаєте знайти: ");
            int searchingElement = Convert.ToInt32(Console.ReadLine());
            if (array.BinarySearch(searchingElement) >= 0)
                Console.WriteLine("Iндекс елементу " + searchingElement + " наступний: " + array.BinarySearch(searchingElement));
            else Console.WriteLine("Такого елементу в масивi не iснує");
        }
    }
}