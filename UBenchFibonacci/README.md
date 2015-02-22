## UBenchFibonacci project

#### Objectives

 - Compare speed of Fibonacci(5) and Fibonacci(30) for different implementations.

#### Environment

 - Intel Core i7-4700MQ 2.4 GHz
 - 16 Gb DDR3 memory
 - Windows 8.1 Enterprise 64-bit
 - .NET Framework 4.5
 - Release/Any CPU build

#### Parameters

```c#
Console.WriteLine(a.Bench()); 
```
 
#### Fibonacci(5) output

```
<Bench_Fib>b__0   50000000 op 1.384 s 27.643 ns/op
<Bench_Fib>b__1  100000000 op 1.703 s 17.005 ns/op
<Bench_Fib>b__2   20000000 op 1.675 s 83.645 ns/op
```

#### Fibonacci(30) output

```
<Bench_Fib>b__0        300 op 1.409 s 4691399.183 ns/op
<Bench_Fib>b__1        500 op 1.363 s 2723458.094 ns/op
<Bench_Fib>b__2   20000000 op 1.678 s 83.813 ns/op
```

#### Where

 - b__0: slow recursive algorithm
 - b__1: slow recursive alternative algorithm
 - b__2: fast doubling algorithm
 
#### Performance Analysis

 - Algorithms do matter!
 - Fastest algorithm is not always faster all the time.



