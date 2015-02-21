using System;
using System.Text;

using UBench;

namespace UBenchDemo
{
    class Program
    {
        static int int1, int2;

        // class methods to benchmark (static vs instance method)
        class Foo
        {
            public void IncNumInstance(ref int num) { num++; }
            public static void IncNumStatic(ref int num) { num++; }
        }

        // run benchmark with lambda functions calling class functions
        // compare speed of instance vs static methods with local and non local parameters
        static void Bench_Method(int runs = 0, string fmt = null)
        {
            // create class instance & local vars
            var obj = new Foo(); int i1 = int1; int i2 = int2;

            // functions to benchmark
            Action f0 = () => obj.IncNumInstance(ref int1); // instance
            Action f1 = () => obj.IncNumInstance(ref i1);   // instance local
            Action f2 = () => Foo.IncNumStatic(ref int2);   // static 
            Action f3 = () => Foo.IncNumStatic(ref i2);     // static local

            // create array of functions to benchmark
            Action[] a = { f0, f1, f2, f3 };

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

            Console.WriteLine("Running static vs instance method benchmark...\n");
            Bench_Method(500000000, "ps");

            // make sure that compiler optimizer keeps int1 and int2 till the end
            Console.WriteLine("int1 = {0} int2 = {1}", int1, int2);
        }
    }
}