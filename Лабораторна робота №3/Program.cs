using static System.Console;
namespace лаба_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = System.ConsoleColor.White;
            int[] Unsorted1 = { 5, 0, 58, 1000, 19, 1, 1, 90, 33, 67 };
            int[] Array1 = CombSort(Unsorted1, 0, false);
            int start;

            Print(Unsorted1);

            start = FindSortedIndex(Array1, 0, 0);
            Array1 =CombSort(Array1, start, true);
            start = FindSortedIndex(Array1, 1, start);
            SortAllUnSorted(Array1, FindUnsorted(Unsorted1), start);

            ColorPrint(Array1, start);

            int[] Unsorted2 = { 21, 30, 0, 51, 1001 };
            int[] Array2 = CombSort(Unsorted2, 0, false);

            Print(Unsorted2);

            start = FindSortedIndex(Array2, 0, 0);
            Array2 = CombSort(Array2, start, true);
            start = FindSortedIndex(Array2, 1, start);
            SortAllUnSorted(Array2, FindUnsorted(Unsorted2), start);

            ColorPrint(Array2, start);

            WriteLine("\nПримiтка:\n    Червоний - елементи, що не пiдлягають сортуванню\n" +
                "    Синiй та жовтий - елементи, вiдсортованi за 1 та 2 ознакою вiдповiдно");
        }
        /*Вивід даного масиву*/
        static void Print(int[] Array)
        {
            Write("\n Даний масив:\n    ");
            int N = Array.Length;
            for (int i = 0; i < N; i++)
                Write($" {Array[i] } ");
            WriteLine();
        }
        /*Сортування гребінцем за однією з ознак*/
        static int[] CombSort(int[] Unsorted, int start, bool IsOdd)
        {
            int[] Arr = Unsorted;
            int N = Arr.Length;
            int gap = N - start; bool sorted = false;
            while (gap != 1 || !sorted)
            {
                sorted = true;
                gap = (int)(gap / 1.247330950103979);
                if (gap < 1)
                    gap = 1;
                for (int i = start; i < N - gap; i++)
                {
                    if (Sort(Arr[i + gap], N, IsOdd ? 1 : 0))
                        if (Arr[i] < Arr[i + gap] || !Sort(Arr[i], N, IsOdd ? 1 : 0))
                        {
                            int temp = Arr[i];
                            Arr[i] = Arr[i + gap];
                            Arr[i + gap] = temp;
                            sorted = false;
                        }
                }
            }
            return Arr;
        }
        /*Перевірка чи підлягає елемент масиву сортуванню*/
        static bool Sort(int a, int N, int IsOdd)
        {
            return ((a % 2 == IsOdd && a % N == IsOdd) ? true : false);
        }

        /*Вставка елементів, що не підлягають сортуванню 
         у відсортований масив*/
        static void SortAllUnSorted(int[] Sorted, int[] Unsorted, int start)
        {
            int count = 0;
            for (int i = start; i < Sorted.Length; i++)
            {
                Sorted[i] = Unsorted[count];
                count++;
            }
        }
        /*Пошук індексу в відсортованому масиві, на якому елемент не підлягає 
          сортуванню за однією з ознак*/
        static int FindSortedIndex(int[] A, byte IsOdd, int start)
        {
            int N = A.Length;
            int count = start;
            for (int i = start; i < N; i++)
            {
                if (A[i] % N == IsOdd)
                    count++;
                else
                    break;
            }
            return count;
        }
        /*Запис елементів, що не підлягають сортуванню у їх початковому порядку*/
        static int[] FindUnsorted(int[] Arr)
        {
            int N = Arr.Length;
            int count = 0;
            int[] Unsorted = new int[N];
            for (int i = 0; i < N; i++)
                if (!(Sort(Arr[i], N, 0) || Sort(Arr[i], N, 1)))
                {
                    Unsorted[count] = Arr[i];
                    count++;
                }
            return Unsorted;
        }
       /*Візуальний вивід масиву*/
        static void ColorPrint(int[] A, int start)
        {

            Write(" Вiдсортований масив:\n    ");
            int N = A.Length;
            if (start == N)
                for (int i = 0; i < N; i++)
                {
                    if (Sort(A[i], N, 0))
                    {
                        BackgroundColor = System.ConsoleColor.Blue;
                        ForegroundColor = System.ConsoleColor.Black;
                    }

                    else
                     if (Sort(A[i], N, 1))
                    {
                        BackgroundColor = System.ConsoleColor.Yellow;
                        ForegroundColor = System.ConsoleColor.Black;
                    }
                    else
                        BackgroundColor = System.ConsoleColor.Black;

                    Write($" {A[i]} ");
                }
            else
                for (int i = 0; i < N; i++)
                {
                    if (!(A[i] % 2 == 0 && A[i] % N == 0) && !(A[i] % N == 1 && A[i] % N == 1))
                    {
                        BackgroundColor = System.ConsoleColor.Red;
                        ForegroundColor = System.ConsoleColor.Black;
                    }
                    Write($" {A[i]} ");
                }
            ForegroundColor = System.ConsoleColor.White;
            BackgroundColor = System.ConsoleColor.Black;
            WriteLine();
        }

       
    }
}
