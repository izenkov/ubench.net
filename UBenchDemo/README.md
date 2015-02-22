## UBenchDemo project

#### Objectives

 - Compare speed of Math.Max with different numeric types.
 - Demonstrate different output formats.

#### Environment

 - Intel Core i7-4700MQ 2.4 GHz
 - 16 Gb DDR3 memory
 - Windows 8.1 Enterprise 64-bit
 - .NET Framework 4.5
 - Release/Any CPU build

#### Output format variations

```c#
Console.WriteLine(a.Bench());
```
```
<Bench_MathMax>b__0  500000000 op 1.211 s  2.419 ns/op
<Bench_MathMax>b__1  500000000 op 1.204 s  2.405 ns/op
<Bench_MathMax>b__2  300000000 op 1.067 s  3.553 ns/op
<Bench_MathMax>b__3  500000000 op 1.627 s  3.251 ns/op
<Bench_MathMax>b__4   50000000 op 1.202 s 24.006 ns/op
```
```c#
Console.WriteLine(a.Bench(50000000));
```
```
<Bench_MathMax>b__0   50000000 op 0.121 s  2.435 ns/op
<Bench_MathMax>b__1   50000000 op 0.120 s  2.397 ns/op
<Bench_MathMax>b__2   50000000 op 0.177 s  3.544 ns/op
<Bench_MathMax>b__3   50000000 op 0.162 s  3.247 ns/op
<Bench_MathMax>b__4   50000000 op 1.202 s 24.011 ns/op
```
```c#
Console.WriteLine(a.Bench(fmt: "ps"));
```
```
<Bench_MathMax>b__0  500000000 op 1200 ms  2401 ps/op
<Bench_MathMax>b__1  500000000 op 1201 ms  2402 ps/op
<Bench_MathMax>b__2  300000000 op 1066 ms  3555 ps/op
<Bench_MathMax>b__3  500000000 op 1632 ms  3265 ps/op
<Bench_MathMax>b__4   50000000 op 1200 ms 24011 ps/op
```
```c#
Console.WriteLine(a.Bench(50000000, "nsl"));
```
```
<Bench_MathMax>b__0   50000000 op 0.119 s 420168067.23 op/s  2.395 ns/op
<Bench_MathMax>b__1   50000000 op 0.118 s 423728813.56 op/s  2.367 ns/op
<Bench_MathMax>b__2   50000000 op 0.179 s 279329608.94 op/s  3.589 ns/op
<Bench_MathMax>b__3   50000000 op 0.162 s 308641975.31 op/s  3.250 ns/op
<Bench_MathMax>b__4   50000000 op 1.200 s  41666666.67 op/s 23.970 ns/op
```

#### Where
 
 - b__0: Math.Max(int, int)
 - b__1: Math.Max(long, long)
 - b__2: Math.Max(float, float)
 - b__3: Math.Max(double, double)
 - b__4: Math.Max(decimal, decimal)
 
#### Performance Analysis

 - The fastest numeric types are int and long.
 - Speed of int and long are practically the same.
 - Second best are float and double and they are 1.5 times slower to int/long.
 - Speed of float is 10% slower compare to double.
 - Slowest type is decimal and it 10 times slower compare to int/long.
