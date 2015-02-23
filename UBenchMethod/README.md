## UBenchMethod project

#### Objectives

 - Compare speed of instance vs static methods.
 - Compare speed of local and non local variables as parameters.

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
Console.WriteLine(a.Bench(500000000, "ps")); 
```
 
#### Output

```
<Bench_Method>b__0  500000000 op 1038 ms  2077 ps/op
<Bench_Method>b__1  500000000 op 1038 ms  2076 ps/op
<Bench_Method>b__2  500000000 op 1333 ms  2667 ps/op
<Bench_Method>b__3  500000000 op 1038 ms  2076 ps/op
```
#### Where

 - b__0: instance method 
 - b__1: instance method, local variable as parameter
 - b__2: static method
 - b__2: static method, local variable as parameter
 
#### Performance Analysis

 - Looks like MS finally made instance methods as fast as static.
 - Static methods with non local parameters almost 30% slower.



