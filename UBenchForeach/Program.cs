using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

using UBench;

namespace UBenchForeach
{
    struct Point
    {
        internal int x;
        internal int y;
    } 

    class Program
    {
        static ArrayList al_int1, al_int2;
        static ArrayList al_str1, al_str2;
        static ArrayList al_pnt1, al_pnt2;
        static ArrayList al_kvp1, al_kvp2;

        static List<int>    l_int1, l_int2;
        static List<string> l_str1, l_str2;
        static List<Point>  l_pnt1, l_pnt2;
        static List<KeyValuePair<int, string>> l_kvp1, l_kvp2;

        static int[]    a_int1, a_int2;
        static string[] a_str1, a_str2;
        static Point[]  a_pnt1, a_pnt2;
        static KeyValuePair<int, string>[] a_kvp1, a_kvp2;

        static int sum1, sum2;

        // support methods

        private static string UUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        // Get ArrayList

        private static ArrayList GetIntAList(int count)
        {
            var al = new ArrayList();
            for (int i = 0; i < count; i++)
                al.Add(i);
            return al;
        }

        private static ArrayList GetStrAList(int count)
        {
            var al = new ArrayList();
            for (int i = 0; i < count; i++)
                al.Add(UUID());
            return al;
        }

        private static ArrayList GetPntAList(int count)
        {
            var al = new ArrayList();
            for (int i = 0; i < count; i++)
                al.Add(new Point() { x = i, y = i });
            return al;
        }

        private static ArrayList GetKvpAList(int count)
        {
            var al = new ArrayList();
            for (int i = 0; i < count; i++)
                al.Add(new KeyValuePair<int, string>(i, UUID()));
            return al;
        }

        // Get List<T>

        private static List<int> GetIntList(int count)
        {
            var l = new List<int>();
            for (int i = 0; i < count; i++)
                l.Add(i);
            return l;
        }

        private static List<string> GetStrList(int count)
        {
            var l = new List<string>();
            for (int i = 0; i < count; i++)
                l.Add(UUID());
            return l;
        }

        private static List<Point> GetPntList(int count)
        {
            var l = new List<Point>();
            for (int i = 0; i < count; i++)
                l.Add(new Point() { x = i, y = i } );
            return l;
        }

        private static List<KeyValuePair<int, string>> GetKvpList(int count)
        {
            var l = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < count; i++)
                l.Add(new KeyValuePair<int, string>(i, UUID()));
            return l;
        }

        // Get T[]

        private static int[] GetIntArr(int count)
        {
            var a = new int[count];
            for (int i = 0; i < count; i++)
                a[i] = i;
            return a;
        }

        private static string[] GetStrArr(int count)
        {
            var a = new string[count];
            for (int i = 0; i < count; i++)
                a[i] = UUID();
            return a;
        }

        private static Point[] GetPntArr(int count)
        {
            var a = new Point[count];
            for (int i = 0; i < count; i++)
                a[i] = new Point() { x = i, y = i };
            return a;
        }

        private static KeyValuePair<int, string>[] GetKvpArr(int count)
        {
            var a = new KeyValuePair<int, string>[count];
            for (int i = 0; i < count; i++)
                a[i] = new KeyValuePair<int, string>(i, UUID());
            return a;
        }

        /// <summary>
        /// T[]
        /// </summary>

        // int[] iteration

        [UBench(Alias = "int[] foreach")]
        static void IntArrForEach()
        {
            int total = 0;
            foreach (var i in a_int1)
                total += i;
            sum1 = total;
        }

        [UBench(Alias = "int[] for")]
        static void IntArrFor()
        {
            int total = 0;
            for (int i = 0; i < a_int2.Length; i++)
                total += a_int2[i];
            sum2 = total;
        }

        // string[] iteration

        [UBench(Alias = "string[] foreach")]
        static void StrArrForEach()
        {
            int total = 0;
            foreach (var s in a_str1)
                total += s.Length;
            sum1 = total;
        }

        [UBench(Alias = "string[] for")]
        static void StrArrFor()
        {
            int total = 0, count = a_str2.Length;
            for (int i = 0; i < count; i++)
                total += a_str2[i].Length;
            sum2 = total;
        }

        // Point[] iteration

        [UBench(Alias = "Point[] foreach")]
        static void PntArrForEach()
        {
            int total = 0;
            foreach (var p in a_pnt1)
                total += p.x;
            sum1 = total;
        }

        [UBench(Alias = "Point[] for")]
        static void PntArrFor()
        {
            int total = 0;
            for (int i = 0; i < a_pnt2.Length; i++)
                total += a_pnt2[i].x;
            sum2 = total;
        }

        // KeyValuePair<int, string>[] iteration

        [UBench(Alias = "KeyValuePair<int, string>[] foreach")]
        static void KvpArrForEach()
        {
            int total = 0;
            foreach (var kv in a_kvp1)
                total += kv.Key;
            sum1 = total;
        }

        [UBench(Alias = "KeyValuePair<int, string>[] for")]
        static void KvpArrFor()
        {
            int total = 0;
            for (int i = 0; i < a_kvp2.Length; i++)
                total += a_kvp2[i].Key;
            sum2 = total;
        }

        /// <summary>
        /// List<T>
        /// </summary>

        // List<int> iteration

        [UBench(Alias = "List<int> foreach")]
        static void IntListForEach()
        {
            int total = 0;
            foreach (var i in l_int1)
                total += i;
            sum1 = total;
        }

        [UBench(Alias = "List<int> for")]
        static void IntListFor()
        {
            int total = 0;
            for (int i = 0; i < l_int2.Count; i++)
                total += l_int2[i];
            sum2 = total;
        }

        // List<string> iteration

        [UBench(Alias = "List<string> foreach")]
        static void StrListForEach()
        {
            int total = 0;
            foreach (var l in l_str1)
                total += l.Length;
            sum1 = total;
        }

        [UBench(Alias = "List<string> for")]
        static void StrListFor()
        {
            int total = 0;
            for (int i = 0; i < l_str2.Count; i++)
                total += l_str2[i].Length;
            sum2 = total;
        }

        // List<Point> iteration

        [UBench(Alias = "List<Point> foreach")]
        static void PntListForEach()
        {
            int total = 0;
            foreach (var p in l_pnt1)
                total += p.x;
            sum1 = total;
        }

        [UBench(Alias = "List<Point> for")]
        static void PntListFor()
        {
            int total = 0;
            for (int i = 0; i < l_pnt2.Count; i++)
                total += l_pnt2[i].x;
            sum2 = total;
        }

        // List<KeyValuePair<int, string>> iteration
        [UBench(Alias = "List<KeyValuePair<int, string>> foreach")]
        static void KvpListForEach()
        {
            int total = 0;
            foreach (var kv in l_kvp1)
                total += kv.Key;
            sum1 = total;
        }

        [UBench(Alias = "List<KeyValuePair<int, string>> for")]
        static void KvpListFor()
        {
            int total = 0;
            for (int i = 0; i < l_kvp2.Count; i++)
                total += l_kvp2[i].Key;
            sum2 = total;
        }

        /// <summary>
        /// ArrayList
        /// </summary>

        // ArrayList int iteration

        [UBench(Alias = "ArrayList of int foreach")]
        static void IntAListForEach()
        {
            int total = 0;
            foreach (int e in al_int1)
                total += e;
            sum1 = total;
        }

        [UBench(Alias = "ArrayList of int for")]
        static void IntAListFor()
        {
            int total = 0;
            for (int i = 0; i < al_int2.Count; i++)
                total += (int)al_int2[i];
            sum2 = total;
        }

        // ArrayList string iteration

        [UBench(Alias = "ArrayList of string foreach")]
        static void StrAListForEach()
        {
            int total = 0;
            foreach (string e in al_str1)
                total += e.Length;
            sum1 = total;
        }

        [UBench(Alias = "ArrayList of string for")]
        static void StrAListFor()
        {
            int total = 0;
            for (int i = 0; i < al_str2.Count; i++)
                total += ((string)al_str2[i]).Length;
            sum2 = total;
        }

        // ArrayList Point iteration

        [UBench(Alias = "ArrayList of Point> foreach")]
        static void PntAListForEach()
        {
            int total = 0;
            foreach (Point p in al_pnt1)
                total += p.x;
            sum1 = total;
        }

        [UBench(Alias = "ArrayList of Point for")]
        static void PntAListFor()
        {
            int total = 0;
            for (int i = 0; i < al_pnt2.Count; i++)
                total += ((Point)al_pnt2[i]).x;
            sum2 = total;
        }

        // ArrayList KeyValuePair<int, string> iteration

        [UBench(Alias = "ArrayList of KeyValuePair<int, string> foreach")]
        static void KvpAListForEach()
        {
            int total = 0;
            foreach (KeyValuePair<int, string> e in al_kvp1)
                total += e.Key;
            sum1 = total;
        }

        [UBench(Alias = "ArrayList of KeyValuePair<int, string> for")]
        static void KvpAListFor()
        {
            int total = 0;
            for (int i = 0; i < al_kvp2.Count; i++)
                total += ((KeyValuePair<int, string>)al_kvp2[i]).Key;
            sum2 = total;
        }

        /// <summary>
        /// Bench T[]
        /// </summary>

        private static void BenchArr(int count)
        {
            a_int1 = GetIntArr(count);
            a_int2 = GetIntArr(count);
            a_kvp1 = GetKvpArr(count);
            a_kvp2 = GetKvpArr(count);
            a_pnt1 = GetPntArr(count);
            a_pnt2 = GetPntArr(count);
            a_str1 = GetStrArr(count);
            a_str2 = GetStrArr(count);

            Action[] a = new Action[] { IntArrForEach, IntArrFor, StrArrForEach, StrArrFor, PntArrForEach, PntArrFor, KvpArrForEach, KvpArrFor };

            WriteLine("Iterating {0} T[] items ... \n", count);
            WriteLine(a.Bench());
        }

        /// <summary>
        /// Bench List<>
        /// </summary>

        private static void BenchLst(int count)
        {
            l_str1 = GetStrList(count);
            l_str2 = GetStrList(count);
            l_kvp1 = GetKvpList(count);
            l_kvp2 = GetKvpList(count);
            l_pnt1 = GetPntList(count);
            l_pnt2 = GetPntList(count);
            l_int1 = GetIntList(count);
            l_int2 = GetIntList(count);

            Action[] a = new Action[] { IntListForEach, IntListFor, StrListForEach, StrListFor, PntListForEach, PntListFor, KvpListForEach, KvpListFor };

            WriteLine("Iterating {0} List<T> items ... \n", count);
            WriteLine(a.Bench());
        }

        /// <summary>
        /// Bench ArrayList
        /// </summary>

        private static void BenchAList(int count)
        {
            al_str1 = GetStrAList(count);
            al_str2 = GetStrAList(count);
            al_kvp1 = GetKvpAList(count);
            al_kvp2 = GetKvpAList(count);
            al_pnt1 = GetPntAList(count);
            al_pnt2 = GetPntAList(count);
            al_int1 = GetIntAList(count);
            al_int2 = GetIntAList(count);

            Action[] a = new Action[] { IntAListForEach, IntAListFor, StrAListForEach, StrAListFor, PntAListForEach, PntAListFor, KvpAListForEach, KvpAListFor };

            WriteLine("Iterating {0} ArrayList items ... \n", count);
            WriteLine(a.Bench());
        }

        /// <summary>
        /// main
        /// </summary>

        static void Main(string[] args)
        {
            var runs = new int[] { 5 , 50, 500 };

            foreach (int r in runs)
            {
                BenchArr(r);   // T[]
                BenchLst(r);   // List<T>
                BenchAList(r); // ArrayList of T
            }
        }
    }
}
