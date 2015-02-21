using System;
using System.Text;

using UBench;

namespace UBenchDemo
{
    class Program
    {
        static int int1;

        // Slow recursive
        static int Fib0(int n)
        {
            if (n <= 1)
                return n;
            return Fib0(n - 1) + Fib0(n - 2);
        }

        // Slow recursive alternative
        static int Fib1(int n)
        {
            if (n <= 2)
                return 1;
            return Fib1(n - 1) + Fib1(n - 2);
        }

        // Fast doubling algorithm
        static int Fib2(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 31; i >= 0; i--)
            {
                int d = a * (b * 2 - a);
                int e = a * a + b * b;
                a = d;
                b = e;
                if ((((uint)n >> i) & 1) != 0)
                {
                    int c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a;
        }

        static void Bench_Fib()
        {
            int n1 = int1; // use local variable for speed
            Action[] a = { () => { int1 = Fib0(n1); }, () => { int1 = Fib1(n1); }, () => { int1 = Fib2(n1); } };
            Console.WriteLine(a.Bench());
        }

        static void Main(string[] args)
        {
            // make sure that compiler optimizer will not substitute int1 with constant
            int1 = 30;
            if (args.Length > 0)
                int1 = Convert.ToInt32(args[0]);

            Console.WriteLine("Running Fibonacci implementation benchmark...\n");
            Bench_Fib();

            // make sure that compiler optimizer keeps int1 till the end
            Console.WriteLine("int1 = {0}", int1);
        }
    }
}