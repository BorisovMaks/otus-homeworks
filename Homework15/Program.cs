using System.Diagnostics;

namespace Homework15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 5, 10, 20 };

            foreach (int value in values)
            {
                Console.WriteLine($"value = {value}");

                Stopwatch sw = Stopwatch.StartNew();
                int recursionTime = FibonacciRecursive(value);
                sw.Stop();
                Console.WriteLine($"Рекурсивный метод: {recursionTime} Время {sw.Elapsed}");

                sw.Restart();
                int cycleTime = FibonacciIterative(value);
                sw.Stop();
                Console.WriteLine($"Итеративный метод: {cycleTime} Время {sw.Elapsed}\n");
            }
        }

        static int FibonacciRecursive(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        static int FibonacciIterative(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            int value = 0;
            int nextValue = 1;
            int tempSum;
            for (int i = 2; i <= n; i++)
            {
                tempSum = value + nextValue;
                value = nextValue;
                nextValue = tempSum;
            }
            return nextValue;
        }
    }
}
