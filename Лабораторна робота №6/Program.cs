using System;
using static System.Console;
namespace lab6
{

    class Program
    {
        public static void Main(String[] args)
        {
            Deque q = new Deque();
            string command = "1", example = "abccba";
            string Input;
            bool result = false;

            while (command != "2")
            {
                ColorWriteLine("Оберiть команду (\"0\" - контрольний приклад,\"1\" - ваша строка,\"2\" - вихiд):");
                command = ReadLine();

                if (command == "1")
                {
                    do
                    {
                        q = new Deque();
                        ColorWriteLine("Введiть строкy: ");
                        Input = ReadLine();
                        
                        while (Input.Length % 2 != 0 || Input.Length == 0)
                        {
                            ColorWriteLine("Введiть число символiв кратне двом: ");
                            Input = ReadLine();
                        }

                        StringToDeque(q, Input);
                        result = q.isPalindrome();

                        if (!result)
                        {
                            ColorWriteLine("Дана строка не палiндром. Введiть iншу: ");
                        }
                    }
                    while (!result);
                    printResult(q);
                }

                else if (command == "0")
                {
                    ColorWriteLine("Строка-приклад: " + example);

                    StringToDeque(q, example);

                    if (q.isPalindrome())
                        printResult(q);
                    else
                    {
                        ColorWriteLine("Дана строка не є палiндромом");
                    }
                }

                else if (command == "2")
                    break;
                else
                {
                    ColorWriteLine("Невiрно введенi данi!");
                }
            }
        }
        static public void printResult(Deque q)
        {
            ColorWriteLine("Дана строка є палiндромом!");
            q.printHalfDeque();
            q.printTransposition();
            WriteLine();
        }
        static public void StringToDeque(Deque q, string input)
        {
            for (int i = 0; i < input.Length; i++)
                q.insertTail(input[i]);

            ForegroundColor = ConsoleColor.DarkRed;
            BackgroundColor = ConsoleColor.White;
            q.printDeque();
            ResetColor();
        }
        static public void ColorWriteLine(string output)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            BackgroundColor = ConsoleColor.White;
            Write(output);
            ResetColor();
            WriteLine();
        }
    }

}
