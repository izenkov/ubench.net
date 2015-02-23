using System;
using System.Text;

using UBench;

namespace UBenchConsole
{
    class Program
    {
        static int int1;

        // functions to benchmark (what is the fastest way to output integer to console?)
        static void Fn_0() { Console.WriteLine(int1); }
        static void Fn_1() { Console.WriteLine(int1.ToString()); }
        static void Fn_2() { Console.Write(int1.ToString() + Environment.NewLine); }
        static void Fn_3() { Console.WriteLine("{0}", int1); }
        static void Fn_4() { Console.Write("{0}{1}", int1, Environment.NewLine); }
        static void Fn_5() { Console.Write("{0}" + Environment.NewLine, int1); }

        static void Main(string[] args)
        {
            // make sure that compiler optimizer will not substitute int1 and int2 with constants
            int1 = 2;
            if (args.Length > 0)
                int1 = Convert.ToInt32(args[0]);

            // create array of static functions to benchmark
            Action[] funcs = { Fn_0, Fn_1, Fn_2, Fn_3, Fn_4, Fn_5 };

            // run benchmark and output results to console
            Console.WriteLine(funcs.Bench());

            // make sure that compiler optimizer keeps int1 till the end
            Console.WriteLine("int1 = {0}", int1);
        }
    }
}