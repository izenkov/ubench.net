## UBenchConsole project

#### Objectives

 - Find the fastest way to output integer to std output.

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
Console.WriteLine(funcs.Bench()); 
```
 
#### Output to console

```
Fn_0      30000 op 1.242 s 41363.376 ns/op
Fn_1      50000 op 1.508 s 30120.324 ns/op
Fn_2      50000 op 1.454 s 29042.004 ns/op
Fn_3      50000 op 1.481 s 29579.135 ns/op
Fn_4      50000 op 1.474 s 29437.773 ns/op
Fn_5      50000 op 1.470 s 29362.330 ns/op
```

#### Output to file on 72000 RPM Hard drive

```
Fn_0     500000 op 1.661 s 3318.189 ns/op
Fn_1    1000000 op 1.793 s 1790.589 ns/op
Fn_2    1000000 op 1.743 s 1740.832 ns/op
Fn_3    1000000 op 1.989 s 1986.520 ns/op
Fn_4    1000000 op 1.956 s 1953.793 ns/op
Fn_5    1000000 op 1.954 s 1951.546 ns/op
```

#### Output to file on RAM drive

```
Fn_0     500000 op 1.617 s 3230.260 ns/op
Fn_1    1000000 op 1.716 s 1713.449 ns/op
Fn_2    1000000 op 1.687 s 1685.343 ns/op
Fn_3    1000000 op 1.842 s 1839.513 ns/op
Fn_4    1000000 op 1.835 s 1832.963 ns/op
Fn_5    1000000 op 1.847 s 1844.801 ns/op
```

#### Where

 - Fn_0: Console.WriteLine(int1); 
 - Fn_1: Console.WriteLine(int1.ToString());
 - Fn_2: Console.Write(int1.ToString() + Environment.NewLine);
 - Fn_3: Console.WriteLine("{0}", int1);
 - Fn_4: Console.Write("{0}{1}", int1, Environment.NewLine);
 - Fn_5: Console.Write("{0}" + Environment.NewLine, int1);
 
#### Performance Analysis

 - Fastest version is Fn_2.
 - Slowest version is Fn_0.
 - Fn_2 output to HD file 16.7 times faster compare to console.
 - Fn_2 output to RAM file 17.2 times faster compare to console.
 - Fn_0 142% slower Fn_2 with console output.
 - Fn_0 190% slower Fn_2 with file output.
 - In general output to file is 10 times faster compare to console.
 - Output to HD file is almost as fast as RAM given enough cache memory.


