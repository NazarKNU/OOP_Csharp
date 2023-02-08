using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static void Main()
    {
        TMSMatrix matrix1 = new TMSMatrix(3, new float[,] { {1, 2, 3 }, {4, 5, 6 }, {7, 8, 9 } });
        TMSMatrix matrix2 = new TMSMatrix(3, new float[,] { {9, 8, 7 }, {6, 5, 4 }, {3, 2, 1 } });
        matrix1.Transpose();
        matrix2.Transpose();
        int matrixNumber = 1;
        int action = 0;
        while (action != 12)
        {
            Console.WriteLine("\n1. Вiдобразити матрицю\n" +
                "2. Ввести iншi данi\n" +
                "3. Знайти максимальне число\n" +
                "4. Знайти мiнiмальне число\n" +
                "5. Знайти суму елементiв\n" +
                "6. Додати до матрицi iншу\n" +
                "7. Вiдняти вiд матрицi iншу\n" +
                "8. Помножити матрицю на iншу\n" +
                "9. Транспонувати матрицю\n" +
                "10. Знайти визначник\n" +
                "11. Редагувати iншу матрицю\n" +
                "12. Завершити програму\n\n" +
                "Оберiть дiю: ");
            action = Convert.ToInt32(Console.ReadLine());
            if (matrixNumber == 1) 
            { 
                switch (action)
                {
                    case 1:
                        matrix1.ShowInfo();
                        break;
                    case 2:
                        matrix1.EnterData();
                        break;
                    case 3:
                        matrix1.FindMax();
                        break;
                    case 4:
                        matrix1.FindMin();
                        break;
                    case 5:
                        matrix1.SumOfElements();
                        break;
                    case 6:
                        matrix1 += matrix2;
                        break;
                    case 7:
                        matrix1 -= matrix2;
                        break;
                    case 8:
                        matrix1 *= matrix2;
                        break;
                    case 9:
                        matrix1.Transpose();
                        break;
                    case 10:
                        matrix1.FindDeterminant();
                        break;
                    case 11:
                        matrixNumber = 2;
                        break;
                    case 12:
                        break;
                    default:
                        Console.WriteLine("\nТакої дiї не iснує, спробуйте ще раз\n");
                        break;
                }
            }
            else 
            { 
                switch (action)
                {
                    case 1:
                        matrix2.ShowInfo();
                        break;
                    case 2:
                        matrix2.EnterData();
                        break;
                    case 3:
                        matrix2.FindMax();
                        break;
                    case 4:
                        matrix2.FindMin();
                        break;
                    case 5:
                        matrix2.SumOfElements();
                        break;
                    case 6:
                        matrix2 += matrix1;
                        break;
                    case 7:
                        matrix2 -= matrix1;
                        break;
                    case 8:
                        matrix2 *= matrix1;
                        break;
                    case 9:
                        matrix2.Transpose();
                        break;
                    case 10:
                        matrix2.FindDeterminant();
                        break;
                    case 11:
                        matrixNumber = 1;
                        break;
                    case 12:
                        break;
                    default:
                        Console.WriteLine("\nТакої дiї не iснує, спробуйте ще раз\n");
                        break;
                } 
            }
        }
    }
    public class TSMatrix
    {
        public int sizeOfMatrix;
        public float[,] matrixElements;

        public TSMatrix()
        {
            sizeOfMatrix = 3;
            matrixElements = new float[sizeOfMatrix, sizeOfMatrix];
            Random randNum = new Random();
            for (int j = 0; j < sizeOfMatrix; j++)
            {
                for (int i = 0; i < sizeOfMatrix; i++)
                {
                    matrixElements[i, j] = randNum.Next(-10, 10);
                }
            }
        }
        public TSMatrix(int sizeOfMatrix, float[,] matrixElements)
        {
            this.sizeOfMatrix = sizeOfMatrix;
            this.matrixElements = matrixElements;
        }
        public TSMatrix(TSMatrix previousMatrix)
        {
            sizeOfMatrix = previousMatrix.sizeOfMatrix;
            matrixElements = previousMatrix.matrixElements;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Розмiр матрицi: {0}", sizeOfMatrix);
            Console.WriteLine("Матриця: ");
            for (int j = 0; j < sizeOfMatrix; j++)
            {
                for (int i = 0; i < sizeOfMatrix; i++)
                {
                    Console.Write(String.Format("{0,5}", matrixElements[i, j]));
                }
                Console.WriteLine();
            }
        }
        public void EnterData()
        {
            Console.WriteLine("Введiть новий розмiр матрицi: ");
            int newSize = Convert.ToInt32(Console.ReadLine());
            float[,] newElements = new float[newSize, newSize];
            for (int j = 0; j < newSize; j++)
            {
                for (int i = 0; i < newSize; i++)
                {
                    Console.WriteLine("Введiть {0},{1} елемент: ", i, j);
                    newElements[i, j] = Convert.ToSingle(Console.ReadLine());
                }
            }
            sizeOfMatrix = newSize;
            matrixElements = newElements;
        }
        public void FindMin()
        {
            float min = matrixElements[0, 0];
            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    if (matrixElements[i, j] < min) min = matrixElements[i, j];
                }
            }
            Console.WriteLine("Найменше число у матрицi: " + min);
        }
        public void FindMax()
        {
            float max = matrixElements[0, 0];
            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    if (matrixElements[i, j] > max) max = matrixElements[i, j];
                }
            }
            Console.WriteLine("Найбiльше число у матрицi: " + max);
        }
        public void SumOfElements()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв, якi бажаєте додати: ");
            int count = Convert.ToInt32(Console.ReadLine());
            float sum = 0;
            int[] coords = new int[2];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введiть X елемента №{0}: ", i + 1);
                coords[0] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введiть Y елемента №{0}: ", i + 1);
                coords[1] = Convert.ToInt32(Console.ReadLine());
                sum += matrixElements[coords[0], coords[1]];
            }
            Console.WriteLine("Сума {0} елементiв: {1}", count, sum);
        }
        public static TSMatrix operator +(TSMatrix a) => a;
        public static TSMatrix operator +(TSMatrix a, TSMatrix b)
        {
            float[,] newElements = new float[a.sizeOfMatrix, a.sizeOfMatrix];
            for (int i = 0; i < a.sizeOfMatrix; i++)
            {
                for (int j = 0; j < a.sizeOfMatrix; j++)
                {
                    newElements[i, j] = a.matrixElements[i, j] + b.matrixElements[i, j];
                }
            }
            return new TSMatrix(a.sizeOfMatrix, newElements);
        }
        public static TSMatrix operator -(TSMatrix a)
        {
            float[,] newElements = new float[a.sizeOfMatrix, a.sizeOfMatrix];
            for (int i = 0; i < a.sizeOfMatrix; i++)
            {
                for (int j = 0; j < a.sizeOfMatrix; j++)
                {
                    newElements[i, j] = -a.matrixElements[i, j];
                }
            }
            return new TSMatrix(a.sizeOfMatrix, newElements);
        }
        public static TSMatrix operator -(TSMatrix a, TSMatrix b)
        {
            float[,] newElements = new float[a.sizeOfMatrix, a.sizeOfMatrix];
            for (int i = 0; i < a.sizeOfMatrix; i++)
            {
                for (int j = 0; j < a.sizeOfMatrix; j++)
                {
                    newElements[i, j] = a.matrixElements[i, j] - b.matrixElements[i, j];
                }
            }
            return new TSMatrix(a.sizeOfMatrix, newElements);
        }
    }

    public class TMSMatrix : TSMatrix
    {
        public TMSMatrix()
        {
            sizeOfMatrix = 3;
            Random randNum = new Random();
            for (int j = 0; j < sizeOfMatrix; j++)
            {
                for (int i = 0; i < sizeOfMatrix; i++)
                {
                    matrixElements[i, j] = randNum.Next(-10, 10);
                }
            }
        }
        public TMSMatrix(int sizeOfMatrix, float[,] matrixElements)
        {
            this.sizeOfMatrix = sizeOfMatrix;
            this.matrixElements = matrixElements;
        }
        public TMSMatrix(TMSMatrix previousMatrix)
        {
            sizeOfMatrix = previousMatrix.sizeOfMatrix;
            matrixElements = previousMatrix.matrixElements;
        }
        public void Transpose()
        {
            float[,] newElements = new float[sizeOfMatrix, sizeOfMatrix];
            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    newElements[i, j] = matrixElements[j, i];
                }
            }
            matrixElements = newElements;
        }
        public void FindDeterminant()
        {
            float determinant = 0;
            float num = 1;
            if (sizeOfMatrix >= 3)
            {
                for (int i = 0; i < sizeOfMatrix; i++)
                {
                    num = 1;
                    int k = i;
                    for (int j = 0; j < sizeOfMatrix; j++)
                    {
                        if (k >= sizeOfMatrix) k = 0;
                        num *= matrixElements[k, j];
                        Console.WriteLine("{0} {1} {2}", i, j, k);
                        k++;
                    }
                    determinant += num;
                    Console.WriteLine("Визначник матрицi: " + determinant);
                }
                for (int i = sizeOfMatrix - 1; i >= 0; i--)
                {
                    num = 1;
                    int k = i;
                    for (int j = 0; j < sizeOfMatrix; j++)
                    {
                        if (k < 0) k = sizeOfMatrix - 1;
                        num *= matrixElements[k, j];
                        k--;
                    }
                    determinant -= num;
                }
            }
            else
            {
                determinant = matrixElements[0, 0] * matrixElements[1, 1] - matrixElements[1, 0] * matrixElements[0, 1];
            }
            Console.WriteLine("Визначник матрицi: " + determinant);
        }

        public static TMSMatrix operator +(TMSMatrix a, TMSMatrix b)
        {
            float[,] newElements = new float[a.sizeOfMatrix, a.sizeOfMatrix];
            for (int i = 0; i < a.sizeOfMatrix; i++)
            {
                for (int j = 0; j < a.sizeOfMatrix; j++)
                {
                    newElements[i, j] = a.matrixElements[i, j] + b.matrixElements[i, j];
                }
            }
            return new TMSMatrix(a.sizeOfMatrix, newElements);
        }
        public static TMSMatrix operator -(TMSMatrix a, TMSMatrix b)
        {
            float[,] newElements = new float[a.sizeOfMatrix, a.sizeOfMatrix];
            for (int i = 0; i < a.sizeOfMatrix; i++)
            {
                for (int j = 0; j < a.sizeOfMatrix; j++)
                {
                    newElements[i, j] = a.matrixElements[i, j] - b.matrixElements[i, j];
                }
            }
            return new TMSMatrix(a.sizeOfMatrix, newElements);
        }
        public static TMSMatrix operator *(TMSMatrix a, float b)
        {
            float[,] newElements = new float[a.sizeOfMatrix, a.sizeOfMatrix];
            for (int i = 0; i < a.sizeOfMatrix; i++)
            {
                for (int j = 0; j < a.sizeOfMatrix; j++)
                {
                    newElements[i, j] *= b;
                }
            }
            return new TMSMatrix(a.sizeOfMatrix, newElements);
        }
        public static TMSMatrix operator *(TMSMatrix a, TMSMatrix b)
        {
            float[,] newElements = new float[a.sizeOfMatrix, a.sizeOfMatrix];
            for (int j = 0; j < a.sizeOfMatrix; j++)
            {
                for (int i = 0; i < a.sizeOfMatrix; i++)
                {
                    for (int k = 0; k < a.sizeOfMatrix; k++)
                    {
                        newElements[i, j] += a.matrixElements[k, j] * b.matrixElements[i, k];
                    }
                }
            }
            return new TMSMatrix(a.sizeOfMatrix, newElements);
        }
    }
}