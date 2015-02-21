/*
 * UBench micro benchmark v 1.1
 * 
 * Copyright (C) Igor P. Zenkov 2014, 2015
 * 
 * Inspired by Alois Kraus http://geekswithblogs.net/akraus1/archive/2008/12/16/127989.aspx
 * and Google Go 'testing' package
 * 
 * Implementation:
 * 
 * UBench implements Bench() Extension Method
 * on Action and Action[] data types. Bench() method
 * returns result as string making it i/o agnostic.
 * 
 * Bench() Method signatures:
 * 
 * string Bench(this Action func, int runs = 0, string fmt = null, int pad = 0)
 * string Bench(this Action[] funcs, int runs = 0, string fmt = null)
 * 
 * Where:
 * 
 *  func  - action to benchmark
 *  funcs - array of actions to benchmark
 *  runs  - number of runs/operations (default is 0 for running at least 1 second)
 *  fmt   - output format string (default is null for default formatting)
 *  pad   - pad right action method name (default is 0 for auto padding)
 * 
 * Usage:
 * 
 * static void FuncToBench1() { code to bench is here }
 * static void FuncToBench2() { code to bench is here }
 * static void FuncToBench3() { code to bench is here }
 * 
 * // benchmark FuncToBench1() by running it for at least 1 sec
 * // default output format
 * Action a = FuncToBench1;
 * Console.WriteLine(a.Bench());
 * 
 * // benchmark Math.Max by running it for at least 1 sec
 * // default output format
 * int x = 1; int y = 2;
 * Action a = () => Math.Max(x, y);
 * Console.WriteLine(a.Bench());
 *
 * // benchmark FuncToBench1() by running it for at least 1 sec
 * // default output format of picoseconds per operation
 * Action a = FuncToBench1;
 * Console.WriteLine(a.Bench(fmt: "ps"));
 * * 
 * // benchmark FuncToBench1() by running it 100000 times using
 * // default output format
 * Action a = FuncToBench1;
 * Console.WriteLine(a.Bench(100000));
 *
 * // benchmark FuncToBench1() by running it 100000 times using
 * // default output format of picoseconds per operation
 * Action a = FuncToBench1;
 * Console.WriteLine(a.Bench(100000, "ps"));
 * 
 * // benchmark FuncToBench1() by running it 1000 times using custom output format
 * Action a = FuncToBench1;
 * Console.WriteLine(a.Bench(1000, "Operations: {op} seconds: {s} op/s: {ops}"));
 *
 * // compare speed of FuncToBench1(), FuncToBench2(), and FuncToBench3
 * // by running each function at least 1 second using default output format
 * Action[] a = { FuncToBench1, FuncToBench2, FuncToBench3 };
 * Console.WriteLine(a.Bench());
 * 
 * // compare speed of FuncToBench1(), FuncToBench2(), and FuncToBench3
 * // by running each function 1000 times using default output format
 * Action[] a = { FuncToBench1, FuncToBench2, FuncToBench3 };
 * Console.WriteLine(a.Bench(1000));
 * 
 * Format string tokens:
 * 
 * {op}   - number of operations (runs)
 * {ms}   - elapsed time in milliseconds
 * {s }   - elapsed time in seconds
 * {opms} - operations per millisecond
 * {ops } - operations per second
 * {nsop} - nanoseconds per operation
 * {psop} - picoseconds per operation
 * 
 * Predefined format strings aliases:
 * 
 * "ns"  -> "{op} op {s} s {nsop} ns/op"
 * "nsl" -> "{op} op {s} s {ops} op/s {nsop} ns/op"
 * "ps"  -> "{op} op {ms} ms {psop} ps/op"
 * "psl" -> "{op} op {ms} ms {opms} op/ms {psop} ps/op"
 * 
 * Where:
 * 
 * ns  - nanoseconds (default)
 * nsl - nanoseconds long
 * ps  - picoseconds
 * psl - picoseconds long
 * 
 */

using System;
using System.Text;
using System.Diagnostics;

namespace UBench
{
    /// <summary>
    /// Helper class to output performance related data like number of runs,
    /// elapsed time, frequency, and nanoseconds per run.
    /// </summary>
    public static class Extension
    {
        // roundDown10 rounds a number down to the nearest power of 10.
        static int RoundDown10(int n)
        {
            var tens = 0;

            // tens = floor(log_10(n))
            for (; n >= 10; tens++)
                n = n / 10;

            // result = 10^tens
            int result = 1;
            for (int i = 0; i < tens; i++)
                result *= 10;

            return result;
        }

        // roundUp rounds x up to a number of the form [1eX, 2eX, 3eX, 5eX].
        static int RoundUp(int n)
        {
            var b = RoundDown10(n); // base

            if (n <= b) return b;
            if (n <= (2 * b)) return 2 * b;
            if (n <= (3 * b)) return 3 * b;
            if (n <= (5 * b)) return 5 * b;

            return 10 * b;
        }

        // force garbage collection
        static void CollectGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        // run n times and return running time in nanoseconds
        static long RunN(Action func, int n)
        {
            CollectGC();
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
                func();
            watch.Stop();
            return watch.ElapsedMilliseconds * 1000L;
        }

        // calculate number of runs for given running time
        static int GetRunsPerBenchTime(Action func, long benchNsec)
        {
            const int MAX_RUN = 1000000000;
            // Run the benchmark for a single iteration in case it's expensive.
            int last, n = 1;
   	
            // run and time it
            long nsec = RunN(func, n); double nsop = nsec / (double)n;

            // Run the benchmark for at least the specified amount of time.
            for (; nsec < benchNsec && n < MAX_RUN; ) {
   	            last = n;
   	            // Predict required iterations.
                n = (nsop <= 0) ? MAX_RUN : (int)(nsec / nsop); 

   	            // Run more iterations than we think we'll need (1.2x).
   	            // Don't grow too fast in case we had timing errors previously.
   	            // Be sure to run at least one more than last time.
   	            n = Math.Max(Math.Min(n+n/5, 100*last), last+1);

   	            // Round up to something easy to read.
                n = RoundUp(n);

                // run and time it
                nsec = RunN(func, n); nsop = nsec / (double)n;
            }
            return n;
        }

        private static string GetFmtStr(string fname, string fmt)
        {
            const string FMT_NSEC_S = "{op} op {s} s {nsop} ns/op";
            const string FMT_NSEC_L = "{op} op {s} s {ops} op/s {nsop} ns/op";
            const string FMT_PSEC_S = "{op} op {ms} ms {psop} ps/op";
            const string FMT_PSEC_L = "{op} op {ms} ms {opms} op/ms {psop} ps/op";

            fname += " "; if (fmt == null) fmt = "ns"; // default

            if (fmt == "ns")  return fname + FMT_NSEC_S; // nanoseconds short
            if (fmt == "nsl") return fname + FMT_NSEC_L; // nanoseconds long
            if (fmt == "ps")  return fname + FMT_PSEC_S; // picoseconds short
            if (fmt == "psl") return fname + FMT_PSEC_L; // picoseconds long

            return fname + fmt; // custom
        }

        /// <summary>
        /// Execute given function and output timing values to string.
        /// </summary>
        /// <param name="func">Function to bench.</param>
        /// <param name="fmt">Format string which can contain {op}, {ms}, {s}, {opms}, {ops}, {nsop}, or {psop}.</param>
        public static string Bench(this Func<int> func, string fmt)
        {
            var watch = Stopwatch.StartNew ();
            int runs = func();  // Execute function and get number of iterations back
            watch.Stop ();

            // replace named tokens
            string  fmtStr = fmt.Replace("{op}",   "{0,10}") // operations (runs)
                                .Replace("{ms}",   "{1,4}")  // elapsed milliseconds
                                .Replace("{s}",    "{2}")    // elapsed seconds
                                .Replace("{opms}", "{3,6}")  // operations per millisecond
                                .Replace("{ops}",  "{4,12}") // operations per second
                                .Replace("{nsop}", "{5,6}")  // nanoseconds per operation
                                .Replace("{psop}", "{6,5}"); // picoseconds per operation

            // get nanoseconds & picoseconds per tick hardware info
            long nsecPerTick = (1000L * 1000L * 1000L) / Stopwatch.Frequency;
            long psecPerTick = (1000L * 1000L * 1000L * 1000L) / Stopwatch.Frequency;

            // get performance info
            long nsec = watch.ElapsedTicks * nsecPerTick;
            long psec = watch.ElapsedTicks * psecPerTick;
            long msec = watch.ElapsedMilliseconds;

            double psop  = psec / runs; // calculate picoseconds per operation
            double nsop  = nsec / (double)runs; // calculate nanoseconds per operation
            double sec   = msec / 1000.0d;
            double mfreq = runs / msec; // calculate frequency (calls per millisecond)
            double sfreq = runs / sec; // calculate frequency (calls per second)

            try
            {
                return String.Format (
                    fmtStr,               // Format string
                    runs.ToString(),      // {0} Expanded token {op}
                    msec.ToString(),      // {1} Expanded token {ms}
                    sec.ToString("F3"),   // {2} Expanded token {s}    formatted as float with 3 digits precision
                    mfreq.ToString(),     // {3} Expanded token {opms}
                    sfreq.ToString("F2"), // {4} Expanded token {ops}  formatted as float with 2 digits precision
                    nsop.ToString("F3"),  // {5} Expanded token {nsop} formatted as float with 3 digits precision
                    psop.ToString()       // {6} Expanded token {psop}
                ); 
            }
            catch (FormatException ex)
            {
                throw new FormatException (
                    String.Format("Unexpected token(s) or invalid format string." +
                                  "Expected tokens: {{op}}/{{0}}, {{ms}}/{{1}}, " +
                                  "{{s}}/{{2}}, {{opms}}/{{3}}, {{ops}}/{{4}}, {{nsop}}/{{5}}, {{psop}}/{{6}}: \"{0}\"", fmt), ex);
            }
        }

        /// <summary>
        /// Execute given function n-times and output timing values to string.
        /// </summary>
        /// <param name="func">Function to call.</param>
        /// <param name="runs">Number of iterations.</param>
        /// <param name="fmt">Format string which can contain {op}, {ms}, {s}, {opms}, {ops}, {nsop}, or {psop}.</param>
        /// <param name="pad">Pad right function name with spaces
        public static string Bench(this Action func, int runs = 0, string fmt = null, int pad = 0)
        {
            string fmtStr = GetFmtStr(func.Method.Name.PadRight(pad), fmt);

            // calculate runs if not provided
            if (runs == 0)
                runs = GetRunsPerBenchTime(func, 1000L * 1000L);

            // pre-run before timing
            // collect garbage before and after
            CollectGC();
            for (int i = 0; i < (runs / 10); i++ )
                func();
            CollectGC();

            Func<int> f = () =>
            {
                for (int i = 0; i < runs; i++)
                {
                    func();
                }
                return runs;
            };
            return f.Bench(fmtStr);
        }

        /// <summary>
        /// Execute given functions n-times and output timing values to string.
        /// </summary>
        /// <param name="funcs">Array functions to bench.</param>
        /// <param name="runs">Number of iterations.</param>
        /// <param name="fmt">Format string which can contain {op}, {ms}, {s}, {opms}, {ops}, {nsop}, or {psop}.</param>
        public static string Bench(this Action[] funcs, int runs = 0, string fmt = null)
        {
            int len, maxLen = 0;
            for (int i = 0; i < funcs.Length; i++)
            {
                len = funcs[i].Method.Name.Length;
                if (len > maxLen)
                    maxLen = len;
            }

            var sb = new StringBuilder();
            for (int i = 0; i < funcs.Length; i++)
                sb.AppendLine(funcs[i].Bench(runs, fmt, maxLen));

            return sb.ToString();
        }
    }
}
