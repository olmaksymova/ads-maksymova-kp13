using System;
using System.Collections.Generic;
using static System.Console;
using static System.Convert;
using static System.Math;

namespace Варіант_4
{
    class Program
    {
        static List<double> Spiral(double[,] A)
        {
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            List<double> R = new List<double>(m * n);
            double current = 0;
            int row = 0, col = 0;
            double limit = (double)Min(n, m) / 2.0;

            while (current < limit)
            {
                for (int j = m - 1; j >= row && R.Count < A.GetLength(0) * A.GetLength(1); j--)
                    R.Add(A[n - 1, j]);
                n--;
                for (int i = n - 1; i >= col && R.Count < A.GetLength(0) * A.GetLength(1); i--)
                    R.Add(A[i, row]);
                row++;
                for (int j = row; j < m && R.Count < A.GetLength(0) * A.GetLength(1); j++)
                    R.Add(A[col, j]);
                col++;
                for (int i = col; i < n && R.Count < A.GetLength(0) * A.GetLength(1); i++)
                    R.Add(A[i, m - 1]);
                m--;
                current++;
            }
            return R;
        }


        static void Main(string[] args)
        {
            int N = 0, M = 0;
            try
            {
                while (N <= 0)
                {
                    Write("Введiть натуральне число N: ");
                    N = ToInt32(ReadLine());
                }
                while (M <= 0)
                {
                    Write("Введiть  натуральне число M: ");
                    M = ToInt32(ReadLine());
                }
                double[,] A = new double[N, M];

                Random rnd = new();

                WriteLine("Даний масив:");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        A[i, j] = Round(rnd.Next(-10, 10) + rnd.NextDouble(), 1);
                        Write($"{A[i, j]}  ");
                    }
                    WriteLine();
                }

                List<double> B = Spiral(A);
                WriteLine("Обхiд масиву по спiралi:");
                foreach (var item in B)
                    Write(item + "  ");

                if (M > 2)
                {
                    double min = A[0, 1], max = A[0, 1];
                    int start = 1, end = M - 1;
                    WriteLine();
                    int i = 0;
                    while (start - end < 0)
                    {
                        for (int j = start; j < end; j++)
                        {
                            if (A[i, j] > max)
                                max = A[i, j];
                            if (A[i, j] < min)
                                min = A[i, j];
                        }
                        start++;
                        end--;
                        i++;
                    }
                    double average = Round((min + max) / 2, 2);
                    WriteLine($"Отримана пiвсума: {average}");
                    start = 1;
                    end = M - 1;
                    i = 0;
                    while (start - end < 0)
                    {
                        for (int j = start; j < end; j++)
                        {
                            if (A[i, j] == max)
                            {
                                WriteLine($"Максимум та його координати: {max} ({i}, {j})");
                                max = 100;
                            }
                            if (A[i, j] == min)
                            {
                                WriteLine($"Мiнiмум та його координати: {min} ({i}, {j})");
                                min = -100;
                            }
                        }
                        start++;
                        end--;
                        i++;
                    }
                }
                else
                    Write("\nЗа даних умов елементiв мiж дiагоналями не iснує! ");
            }
            catch
            {
                WriteLine("Помилка введення даних!");
            }
        }
    }
}
