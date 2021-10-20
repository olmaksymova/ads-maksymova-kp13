
using System;
using static System.Console;
using static System.Convert;
using static System.Math;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Prime_or_not(long N)
            {
                long j;bool prime=true;
                for (j = 2; j <= Sqrt(N); j++)
                    if (N % j == 0)
                    {
                        prime = !prime;
                        break;
                    }
                return prime;
            }
            long n, Mersen_number;
            
            long i, j;
            Write("Введiть n: ");
            try
            {
                n = ToInt32(ReadLine());
            }
            catch
            {
                n = 0;
            }
            bool prime;
            if (n > 0)
            {
                if (n > 3)
                {
                    Write("Числа Мерсена: ");
                    for (i = 2; i < n; i++)
                    {
                        prime = Prime_or_not(i);
                        Mersen_number = (long)Pow(2, i) - 1;
                        if (Mersen_number < n)
                        {
                            if (prime && Prime_or_not(Mersen_number)==true)
                                Write($"{Mersen_number} ");
                        }
                        else
                            break;
                    }
                }
                else
                    WriteLine($"Чисел Мерсена, менших за {n}, не iснує ");
            }
            else
                WriteLine("Помилка вводу даних");

        }
    }
}