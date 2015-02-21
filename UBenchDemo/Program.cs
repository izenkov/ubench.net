using System;
using System.Text;

using UBench;

namespace UBenchDemo
{
    class Program
    {
        static int int1, int2;

        // run benchmark with lambda functions
        // compare speed of Math.Max for different numeric types
        static void Bench_MathMax(int runs = 0, string fmt = null)
        {
            int     i1 = int1; int     i2 = int2;
            long    l1 = int1; long    l2 = int2;
            float   f1 = int1; float   f2 = int2;
            double  d1 = int1; double  d2 = int2;
            decimal e1 = int1; decimal e2 = int2;

            // create array of functions to benchmark
            Action[] a = { () => Math.Max(i1, i2), () => Math.Max(l1, l2), () => Math.Max(f1, f2), () => Math.Max(d1, d2), () => Math.Max(e1, e2) };

            // run every function 'runs' times and output result according to 'fmt'
            Console.WriteLine(a.Bench(runs, fmt));
        }

        static void Main(string[] args)
        {
            // make sure that compiler optimizer will not substitute int1 and int2 with constants
            int1 = 2;
            if (args.Length > 0)
                int1 = Convert.ToInt32(args[0]);
            int2 = int1 + 2;

            Console.WriteLine("Compare speed of Math.Max with different types:\n");

            Console.WriteLine("0: Math.Max(int, int)");
            Console.WriteLine("1: Math.Max(long, long)");
            Console.WriteLine("2: Math.Max(float, float)");
            Console.WriteLine("3: Math.Max(double, double)");
            Console.WriteLine("4: Math.Max(decimal, decimal)\n");

            Console.WriteLine("Running benchmark (default parameters)...\n");
            Bench_MathMax();

            Console.WriteLine("Running benchmark (run 50000000 times)...\n");
            Bench_MathMax(50000000);

            Console.WriteLine("Running benchmark (picoseconds/operation)...\n");
            Bench_MathMax(fmt: "ps");

            Console.WriteLine("Running benchmark (run 50000000 times, long format)...\n");
            Bench_MathMax(50000000, "nsl");

            // make sure that compiler optimizer keeps int1 and int2 till the end
            Console.WriteLine("int1 = {0} int2 = {1}", int1, int2); 
        }
    }
}