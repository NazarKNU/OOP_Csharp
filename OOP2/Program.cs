using System;
using System.Numerics;

class Program
{
    public static void Main()
    {
        float[] array = CreateArray();
        int action = 0;
        ArrayMenu(action, array);
        float[,] matrix = CreateMatrix();
        MatrixMenu(action, matrix);
    }
    public static float[] CreateArray()
    {
        int arraySize = 1;
        Console.WriteLine("Введiть розмiр масиву: ");
        arraySize = Convert.ToInt32(Console.ReadLine());
        float[] array = new float[arraySize];
        Console.WriteLine("Оберiть спосiб створення масиву\n" +
            "1. Випадково\n" +
            "2. Вручну");
        int creation1 = Convert.ToInt32(Console.ReadLine());
        Random random = new Random();
        if (creation1 == 2) Console.WriteLine("Введiть елементи масиву: ");
        for (int i = 0; i < arraySize; i++)
        {
            if (creation1 == 2) array[i] = Convert.ToSingle(Console.ReadLine());
            else array[i] = random.Next(-10, 10);
        }
        return array;
    }

    public static float[,] CreateMatrix()
    {
        int arraySize = 1;
        Console.WriteLine("Введiть розмiр масиву: ");
        arraySize = Convert.ToInt32(Console.ReadLine());
        float[,] matrix = new float[arraySize, arraySize];
        Console.WriteLine("Оберiть спосiб створення масиву\n" +
            "1. Випадково\n" +
            "2. Вручну");
        int creation1 = Convert.ToInt32(Console.ReadLine());
        if (creation1 == 2) Console.WriteLine("Введiть елементи масиву: ");
        Random random = new Random();
        for (int i = 0; i < arraySize; i++)
        {
            for (int j = 0; j < arraySize; j++)
            {
                if (creation1 == 2) matrix[j, i] = Convert.ToSingle(Console.ReadLine());
                else matrix[i, j] = random.Next(-10, 10);
            }
        }
        return matrix;
    }

    public static void ArrayMenu(int action, float[] array)
    {

        while (action != 6)
        {
            Console.WriteLine("\n1. Вiдобразити масив\n" +
                "2. Вiддзеркалити масив\n" +
                "3. Вирiшити вираз\n" +
                "4. Вiдсортувати за модулем\n" +
                "5. Ввести iншi данi\n" +
                "6. Перейти до квадратної матрицi\n" +
                "Оберiть дiю: ");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    ShowArray(array);
                    break;
                case 2:
                    array = MirrorArray(array);
                    break;
                case 3:
                    float[] array2 = CreateArray();
                    ShowArray(array);
                    ShowArray(array2);
                    SolveExpression(array, array2);
                    break;
                case 4:
                    array = SortByModule(array);
                    break;
                case 5:
                    array = CreateArray();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("\nТакої дiї не iснує, спробуйте ще раз\n");
                    break;
            }
        }
    }

    public static void MatrixMenu(int action, float[,] matrix)
    {
        while (action != 6)
        {
            Console.WriteLine("\n1. Вiдобразити матрицю\n" +
               "2. Перемiстити негативнi елементи вгору\n" +
               "3. Ущiльнити матрицю\n" +
               "4. Кiлькiсть рядкiв, що складають арифметисну прогресiю\n" +
               "5. Ввести iншi данi\n" +
               "6. Завершити програму\n" +
               "Оберiть дiю: ");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    ShowMatrix(matrix);
                    break;
                case 2:
                    matrix = MoveNegativeElements(matrix);
                    break;
                case 3:
                    matrix = CompressMatrix(matrix);
                    break;
                case 4:
                    FindArithmeticRows(matrix);
                    break;
                case 5:
                    matrix = CreateMatrix();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("\nТакої дiї не iснує, спробуйте ще раз\n");
                    break;
            }
        }
    }
    public static void ShowArray(float[] array)
    {
        Console.WriteLine("Елементи масиву: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
        Console.WriteLine();
    }
    public static float[] MirrorArray(float[] array)
    {
        float[] newarray = new float[array.Length];
        int element = array.Length - 1;
        for (int i = 0; i < array.Length; i++)
        {
            newarray[i] = array[element];
            element--;
        }
        return newarray;
    }

    public static void SolveExpression(float[] array1, float[] array2)
    {
        float scalarProduct = 0;
        float answer = 0;
        float[] x = new float[array1.Length];
        float[] y = new float[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            scalarProduct += (array1[i] + array2[i]) * (array1[i] - array2[i]);
        }
        answer = 2 * scalarProduct;
        Console.WriteLine("Вiдповiдь: " + answer);
    }

    public static float[] SortByModule(float[] array)
    {
        int index = 0;
        float value = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            value = Math.Abs(array[i]);
            index = i;
            for (int j = i; j < array.Length; j++)
            {
                if (value > Math.Abs(array[j]))
                {
                    index = j;
                    value = Math.Abs(array[j]);
                }
            }
            value = array[i];
            array[i] = array[index];
            array[index] = value;
        }
        return array;
    }
    public static float[] MoveNegatives(float[] array)
    {
        int index = 0;
        float value = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            value = array[i];
            index = i;
            for (int j = i; j < array.Length; j++)
            {
                if (value > array[j] && array[j] < 0)
                {
                    index = j;
                    value = array[j];
                }
            }
            value = array[i];
            array[i] = array[index];
            array[index] = value;
        }
        return array;
    }

    public static float[,] MoveNegativeElements(float[,] matrix)
    {
        float[] copyColumn = new float[matrix.GetLength(0)];
        for (int i = 1; i < matrix.GetLength(0); i += 2)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                copyColumn[j] = matrix[i, j];
            }
            copyColumn = MoveNegatives(copyColumn);
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[i, j] = copyColumn[j];
            }
        }
        return matrix;
    }

    public static float[,] CompressMatrix(float[,] matrix)
    {
        Random random = new Random();
        int row = 0;
        int column = 0;
        int mainNumber = random.Next(0, matrix.GetLength(0) - 1);
        Console.WriteLine(mainNumber);
        float[,] newMatrix = new float[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i == mainNumber) i++;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (j == mainNumber) j++;
                newMatrix[column, row] = matrix[j, i];
                column++;
            }
            column = 0;
            row++;
        }
        Console.WriteLine(mainNumber);
        return newMatrix;
    }
    public static void FindArithmeticRows(float[,] matrix)
    {
        float difference = 0;
        bool isArithemtic = true;
        int rowsCount = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            isArithemtic = true;
            difference = matrix[1, i] - matrix[0, i];
            for (int j = 1; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] - matrix[j - 1, i] != difference)
                {
                    isArithemtic = false;
                }
            }
            if (isArithemtic)
            {
                rowsCount++;
                Console.WriteLine("Елементи {0} ряду утворюють арифметичну прогресiю", i + 1);
            }
            else Console.WriteLine("Елементи {0} ряду НЕ утворюють арифметичну прогресiю", i + 1);
        }
    }

    public static void ShowMatrix(float[,] matrix)
    {
        Console.WriteLine("Розмiр матрицi: {0}", matrix.Rank);
        Console.WriteLine("Матриця: ");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                Console.Write(String.Format("{0,5}", matrix[j, i]));
            }
            Console.WriteLine();
        }
    }
}