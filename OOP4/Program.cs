using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

class Program
{
    
    public static void Main()
    {
        TSMatrix matrix1 = new TSMatrix();
        TSMatrix matrix2 = new TSMatrix(matrix1);
        int matrixNumber = 1;
        int action = 0;
        while (action != 5)
        {
            Console.WriteLine("\n1. Вiдобразити матрицю\n" +
                "2. Ввести iншi данi\n" +
                "3. Знайти максимальне число\n" +
                "4. Знайти мiнiмальне число\n" +
                "5. Завершити програму\n\n" +
                "Оберiть дiю: ");
            action = Convert.ToInt32(Console.ReadLine());
            if (matrixNumber == 1)
            {
                switch (action)
                {
                    case 1:
                        matrix1.PrintMatrix();
                        break;
                    case 2:
                        matrix1.EnterData();
                        break;
                    case 3:
                        matrix1 = matrix1.MultiplyMatrices(matrix1, matrix2);
                        break;
                    case 4:
                        matrixNumber = 2;
                        break;
                    case 5:
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
                        matrix2.PrintMatrix();
                        break;
                    case 2:
                        matrix2.EnterData();
                        break;
                    case 3:
                        matrix2 = matrix2.MultiplyMatrices(matrix2, matrix1);
                        break;
                    case 4:
                        matrixNumber = 1;
                        break;
                    case 5:
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
        public LinkedList<LinkedList<float>> matrixElements;

        public TSMatrix()
        {
            matrixElements = new LinkedList<LinkedList<float>>();
            Random randNum = new Random();
            matrixElements.AddLast(new LinkedList<float>(new float[] { randNum.Next(-10, 10), randNum.Next(-10, 10), randNum.Next(-10, 10) }));
            matrixElements.AddLast(new LinkedList<float>(new float[] { randNum.Next(-10, 10), randNum.Next(-10, 10), randNum.Next(-10, 10) }));
            matrixElements.AddLast(new LinkedList<float>(new float[] { randNum.Next(-10, 10), randNum.Next(-10, 10), randNum.Next(-10, 10) }));
            matrixElements.AddLast(new LinkedList<float>(new float[] { randNum.Next(-10, 10), randNum.Next(-10, 10), randNum.Next(-10, 10) }));
        }
        public TSMatrix(TSMatrix previousMatrix)
        {
            matrixElements = previousMatrix.matrixElements;
        }
        public TSMatrix(LinkedList<LinkedList<float>> matrixElements)
        {
            this.matrixElements = matrixElements;
        }
        public void PrintMatrix()
        {
            Console.WriteLine("Розмiр матрицi: {0} x {1}", matrixElements.Count, matrixElements.First.Value.Count);
            Console.WriteLine("Матриця: ");
            foreach (var row in matrixElements)
            {
                foreach (var element in row)
                    Console.Write(String.Format("{0,5}", element));
                Console.WriteLine();
            }
        }
        
        public void EnterData()
        {
            Console.WriteLine("Введiть кількість рядків матрицi: ");
            int newRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кількість стовпців матрицi: ");
            int newColumns = Convert.ToInt32(Console.ReadLine());
            float[] array = new float[newColumns];
            LinkedList<LinkedList<float>> newMatrix = new LinkedList<LinkedList<float>>();
            for (int j = 0; j < newRows; j++)
            {
                for (int i = 0; i < newColumns; i++)
                {
                    Console.WriteLine("Введiть {0},{1} елемент: ", j, i);
                    array[i] = Convert.ToSingle(Console.ReadLine());
                }
                newMatrix.AddLast(new LinkedList<float>(array));
            }
            matrixElements = newMatrix;
        }
        
        public LinkedList<LinkedList<float>> MultiplyMatrices(LinkedList<LinkedList<float>> matrix1, LinkedList<LinkedList<float>> matrix2)
        {
            int rows1 = matrix1.Count;
            int cols1 = matrix1.First.Value.Count;
            int rows2 = matrix2.Count;
            int cols2 = matrix2.First.Value.Count;

            if (cols1 != rows2)
                throw new Exception("Матриці не можна перемножити");

            LinkedList<LinkedList<float>> result = new LinkedList<LinkedList<float>>();

            for (int i = 0; i < rows1; i++)
            {
                result.AddLast(new LinkedList<float>());
                for (int j = 0; j < cols2; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < cols1; k++)
                        sum += GetElement(matrix1,i, k) * GetElement(matrix2, k, j);
                    result.Last.Value.AddLast(sum);
                }
            }

            return result;
        }

        public TSMatrix MultiplyMatrices(TSMatrix matrixA, TSMatrix matrixB)
        {
            LinkedList<LinkedList<float>> matrix1 = matrixA.matrixElements;
            LinkedList< LinkedList<float>> matrix2 = matrixB.matrixElements;
            TSMatrix resultMatrix = new TSMatrix(MultiplyMatrices(matrix1, matrix2));
            return resultMatrix;
        }

        public float GetElement(LinkedList<LinkedList<float>> matrix, int row, int col)
        {
            var currentRow = matrix.First;
            for (int i = 0; i < row; i++)
                currentRow = currentRow.Next;

            var currentElement = currentRow.Value.First;
            for (int i = 0; i < col; i++)
                currentElement = currentElement.Next;

            return currentElement.Value;
        }
    }
}