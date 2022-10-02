using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csh_lab04
{
    class Program
    {
        public class MyMatrix
        {
            public double[,] matrix;
            public int lines;
            public int columns;

            public MyMatrix(int lineCount, int columnCount)
            {
                matrix = new double[lineCount, columnCount];
                lines = lineCount;
                columns = columnCount;
                for (int i = 0; i < lineCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            public MyMatrix(int lineCount, int columnCount, int randBegin, int randEnd)
            {
                matrix = new double[lineCount, columnCount];
                lines = lineCount;
                columns = columnCount;
                Random rand = new Random();
                for (int i = 0; i < lineCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    { 
                        int rnd = rand.Next(randBegin, randEnd);
                        matrix[i, j] = rnd;
                    }
                }
            }

            public double this[int elem1, int elem2]
            {
                get
                {
                    return matrix[elem1, elem2];
                }
                set
                {
                    matrix[elem1, elem2] = value;
                }
            }
            static public MyMatrix operator +(MyMatrix matx1, MyMatrix matx2)
            {
                MyMatrix newMatX = new MyMatrix(matx1.lines, matx1.columns);
                for (int i = 0; i < matx1.lines; i++)
                {
                    for (int j = 0; j < matx1.columns; j++)
                    {
                        newMatX[i, j] = matx1[i, j] + matx2[i, j];
                    }
                }
                return newMatX;
            }

            static public MyMatrix operator -(MyMatrix matx1, MyMatrix matx2)
            {
                MyMatrix newMatX = new MyMatrix(matx1.lines, matx1.columns);
                for (int i = 0; i < matx1.lines; i++)
                {
                    for (int j = 0; j < matx1.columns; j++)
                    {
                        newMatX[i, j] = matx1[i, j] - matx2[i, j];
                    }
                }
                return newMatX;
            }

            static public MyMatrix operator *(MyMatrix matx1, MyMatrix matx2)
            {
                MyMatrix newMatX = new MyMatrix(matx1.lines, matx1.columns);
                for(int i = 0; i < matx1.lines; i++)
                {
                    for (int j = 0; j < matx1.columns; j++)
                    {
                        newMatX[i, j] = 0;
                        for (int k = 0; k < matx1.columns; k++)
                        {
                            newMatX[i, j] += matx1[i, k] * matx2[k, j];
                        }
                    }
                }
                return newMatX;
            }

            static public MyMatrix operator *(MyMatrix matx1, double num)
            {
                MyMatrix newMatX = new MyMatrix(matx1.lines, matx1.columns);
                for (int i = 0; i < matx1.lines; i++)
                {
                    for (int j = 0; j < matx1.columns; j++)
                    {
                        newMatX[i, j] = matx1[i, j] * num;
                    }
                }
                return newMatX;
            }

            static public MyMatrix operator /(MyMatrix matx1, double num)
            {
                MyMatrix newMatX = new MyMatrix(matx1.lines, matx1.columns);
                for (int i = 0; i < matx1.lines; i++)
                {
                    for (int j = 0; j < matx1.columns; j++)
                    {
                        newMatX[i, j] = matx1[i, j] / num;
                    }
                }
                return newMatX;
            }

            public void print()
            {
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine("\r");
                }
            }


        }
        static void Main(string[] args)
        {
            int line;
            int column;
            int numsRangeFirst;
            int numsRangeSecond;

            Console.WriteLine("Введите количество строк матриц:");
            line = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов матриц:");
            column = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите нижнюю границу диапазона чисел для заполнения:");
            numsRangeFirst = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите верхнюю границу диапазона чисел для заполнения:");
            numsRangeSecond = int.Parse(Console.ReadLine());

            MyMatrix mat1 = new MyMatrix(line, column, numsRangeFirst, numsRangeSecond);

            Console.WriteLine("Введите нижнюю границу диапазона чисел для заполнения:");
            numsRangeFirst = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите верхнюю границу диапазона чисел для заполнения:");
            numsRangeSecond = int.Parse(Console.ReadLine());

            MyMatrix mat2 = new MyMatrix(line, column, numsRangeFirst, numsRangeSecond);


            MyMatrix newmat = new MyMatrix(line, column);

            Console.WriteLine("Первая матрица:");
            mat1.print();

            Console.WriteLine("Вторая матрица:");
            mat2.print();


            Console.WriteLine("Сложение матриц:");
            newmat = mat1 + mat2;
            newmat.print();

            Console.WriteLine("Вычитание матриц:");
            newmat = mat1 - mat2;
            newmat.print();

            Console.WriteLine("Умножение матрицы на матрицу:");
            newmat = mat1 * mat2;
            newmat.print();

            Console.WriteLine("Введите число на которое вы хотите умножить/разделить матрицу:");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Умножение матрицы на число:");
            newmat = mat1 * num;
            newmat.print();

            Console.WriteLine("Деление матрицы на число:");
            newmat = mat1 / num;
            newmat.print();
        }
    }
}
