## UBenchFibonacci project

#### Objectives

 - Compare speed of different Fibonacci implementations.

#### Environment

 - Intel Core i7-4700MQ 2.4 GHz
 - 16 Gb DDR3 memory
 - Windows 8.1 Enterprise 64-bit
 - .NET Framework 4.5
 - Release/Any CPU build
 
#### Code

[Program.cs](Program.cs)

#### Parameters

```c#
Console.WriteLine(a.Bench()); 
```
 
#### Fibonacci(2)

```
Recursive       200000000 op 1.426 s    7.120 ns/op
RecursiveAlt    300000000 op 1.298 s    4.323 ns/op
Dynamic         200000000 op 1.023 s    5.108 ns/op
Doubling         20000000 op 1.725 s   86.141 ns/op
DynamicBigInt    20000000 op 1.773 s   88.528 ns/op
DoublingBigInt     200000 op 1.223 s 6107.080 ns/op
```

#### Fibonacci(5)

```
Recursive        50000000 op 1.349 s   26.953 ns/op
RecursiveAlt    100000000 op 1.687 s   16.847 ns/op
Dynamic         200000000 op 1.377 s    6.877 ns/op
Doubling         20000000 op 1.687 s   84.247 ns/op
DynamicBigInt     5000000 op 1.098 s  219.425 ns/op
DoublingBigInt     200000 op 1.241 s 6196.201 ns/op
```

#### Fibonacci(10)

```
Recursive         5000000 op 1.452 s  290.054 ns/op
RecursiveAlt     10000000 op 1.810 s  180.817 ns/op
Dynamic         200000000 op 1.962 s    9.796 ns/op
Doubling         20000000 op 1.692 s   84.503 ns/op
DynamicBigInt     3000000 op 1.346 s  448.145 ns/op
DoublingBigInt     200000 op 1.252 s 6250.569 ns/op
```

#### Fibonacci(30)

```
Recursive             300 op 1.305 s 4345302.873 ns/op
RecursiveAlt          500 op 1.365 s 2726112.326 ns/op
Dynamic          50000000 op 1.084 s      21.662 ns/op
Doubling         20000000 op 1.729 s      86.355 ns/op
DynamicBigInt     1000000 op 1.324 s    1322.651 ns/op
DoublingBigInt     200000 op 1.283 s    6406.900 ns/op
```

#### Fibonacci(50)

```
DynamicBigInt      500000 op 1.240 s 2476.566 ns/op
DoublingBigInt     200000 op 1.307 s 6529.005 ns/op
```

#### Fibonacci(100)

```
DynamicBigInt      200000 op 1.630 s 8139.839 ns/op
DoublingBigInt     200000 op 1.425 s 7117.356 ns/op
```

#### Fibonacci(200)

```
DynamicBigInt      100000 op 2.001 s 19987.721 ns/op
DoublingBigInt     200000 op 1.563 s 7807.817 ns/op
```

#### Fibonacci(500)

```
DynamicBigInt       20000 op 1.188 s 59330.860 ns/op
DoublingBigInt     200000 op 1.822 s 9100.109 ns/op
```

#### Where

 - Recursive     : slow recursive algorithm
 - RecursiveAlt  : slow recursive alternative algorithm
 - Dynamic       : fast dynamic algorithm
 - Doubling      : fast doubling algorithm
 - DynamicBigInt : fast dynamic algorithm using BigInteger
 - DoublingBigInt: fast doubling algorithm using BigInteger
 
#### Performance Analysis

 - Algorithms do matter!
 - BigInteger is very slow, use it only if there are no alternatives.
 - No algorithm is the winner for all N.
 - Recursion is acceptable for N < 10
 - Dynamic algorithm is very good for N < 100
 - Doubling algorithm is the champion for N > 100


