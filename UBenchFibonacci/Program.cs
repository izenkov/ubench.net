using System;
using System.Text;
using System.Numerics;

using UBench;

namespace UBenchFibonacci
{
    class Program
    {
        static int N;
        static int I0, I1, I2, I3;
        static BigInteger B0, B1;

        // Slow recursive algorithm
        static int FibRecursive(int n)
        {
            if (n <= 1)
                return n;
            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }

        // Slow recursive alternative algorithm
        static int FibRecursiveAlt(int n)
        {
            if (n <= 2)
                return 1;
            return FibRecursiveAlt(n - 1) + FibRecursiveAlt(n - 2);
        }

        // Fast dynamic algorithm
        static int FibDynamic(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }
            return a;
        }

        // Fast dynamic algorithm using BigInteger
        static BigInteger FibDynamicBigInt(int n)
        {
            BigInteger a = BigInteger.Zero;
            BigInteger b = BigInteger.One;
            for (long i = 0; i < n; i++)
            {
                BigInteger c = a + b;
                a = b;
                b = c;
            }
            return a;
        }

        // Fast doubling algorithm
        static int FibDoubling(int n)
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

        // Fast doubling algorithm using BigInteger
        static BigInteger FibDoublingBigInt(int n)
        {
            BigInteger a = BigInteger.Zero;
            BigInteger b = BigInteger.One;
            for (int i = 31; i >= 0; i--)
            {
                BigInteger d = a * (b * 2 - a);
                BigInteger e = a * a + b * b;
                a = d;
                b = e;
                if ((((uint)n >> i) & 1) != 0)
                {
                    BigInteger c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a;
        }

        static void Recursive()      { I0 = FibRecursive(N); }
        static void RecursiveAlt()   { I1 = FibRecursiveAlt(N); }
        static void Dynamic()        { I2 = FibDynamic(N); }
        static void Doubling()       { I3 = FibDoubling(N); }
        static void DynamicBigInt()  { B0 = FibDynamicBigInt(N); }
        static void DoublingBigInt() { B1 = FibDoublingBigInt(N); }

        static void Bench_Fib(int n)
        {
            N = n;
            Action[] a = { Recursive, RecursiveAlt, Dynamic, Doubling, DynamicBigInt, DoublingBigInt };
            Console.WriteLine("Running Fibonacci({0}) implementations benchmark...\n", n);
            Console.WriteLine(a.Bench());
        }

        static void Bench_FibBigInt(int n)
        {
            N = n;
            Action[] a = { DynamicBigInt, DoublingBigInt };
            Console.WriteLine("Running Fibonacci({0}) fast BigInteger implementations benchmark...\n", n);
            Console.WriteLine(a.Bench());
        }

        static void Main(string[] args)
        {
            // make sure that compiler optimizer will not substitute int1 with constant
            if (args.Length > 0)
                N = Convert.ToInt32(args[0]);

            Bench_Fib(2);
            Bench_Fib(5);
            Bench_Fib(10);
            Bench_Fib(30);

            Console.WriteLine("I0 = {0} I1 = {1} I2 = {2} I3 = {3} B0 = {4} B1 = {5}\n", I0, I1, I2, I3, B0, B1);

            Bench_FibBigInt(50);
            Bench_FibBigInt(100);
            Bench_FibBigInt(200);
            Bench_FibBigInt(500);

            Console.WriteLine("B0 = {0} B1 = {1}\n", B0, B1);
        }
    }
}