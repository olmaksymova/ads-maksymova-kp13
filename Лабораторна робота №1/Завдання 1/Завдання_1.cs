
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


            double x, y, z, a, b;
            
            
            
            try
            {
                Write("Введiть x: ");
                x = ToDouble(ReadLine());
                Write("Введiть y: ");
                y = ToDouble(ReadLine());
                Write("Введiть z: ");
                z = ToDouble(ReadLine());
                if (z == 0 || x == 0 || x < y)
                    WriteLine("Данi числа не задовольняють ОДЗ");
                else
                {
                    double ch, zn;
                    ch = Pow(Abs(y) + Pow(z, 3), 1.0 / 3);
                    zn = Pow(x, 3) + x;
                    a = x + ch / zn;
                    if (a != 0)
                    {
                        b = Sqrt(x - y) / z + 1 / a / a;
                        WriteLine("a = {0}\tb = {1}", a,b);
                    }
                    else
                        WriteLine("Данi числа не задовольняють ОДЗ");
                }
            }
            catch
            {
                WriteLine("Помилка вводу даних");
            }
            
               
                

        }
    }
}