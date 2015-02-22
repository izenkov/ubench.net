## UBench.Net micro benchmark v 1.1
 
Inspired by Alois Kraus http://geekswithblogs.net/akraus1/archive/2008/12/16/127989.aspx
and Google Go 'testing' package
 
#### Implementation

UBench implements Bench() Extension Method
on Action and Action[] data types. Bench() method
returns result as string making it i/o agnostic.

#### NuGet package

[NuGet UBench package](https://www.nuget.org/packages/UBench)

#### Bench() Method signatures

```c#
string Bench(this Action func, int runs = 0, string fmt = null, int pad = 0)
string Bench(this Action[] funcs, int runs = 0, string fmt = null)
```
#### Where

 - **func**  - action to benchmark
 - **funcs** - array of actions to benchmark
 - **runs**  - number of runs/operations (default is 0 for running at least 1 second)
 - **fmt**   - output format string (default is null for default formatting)
 - **pad**   - pad right action method name (default is 0 for auto padding)

#### Benchmark code as simple as 1-2-3
 
```c#
using System;
using UBench; // 1 Add UBench namespace

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            long i = 2;
            Action a = () => { i++; };    // 2 Define action
            Console.WriteLine(a.Bench()); // 3 Benchmark action
            Console.WriteLine(i);
        }
    }
}
```
 
#### Usage

```c#
static void FuncToBench1() { code to bench is here }
static void FuncToBench2() { code to bench is here }
static void FuncToBench3() { code to bench is here }

// benchmark FuncToBench1() by running it for at least 1 sec
// default output format
Action a = FuncToBench1;
Console.WriteLine(a.Bench());

// benchmark Math.Max by running it for at least 1 sec
// default output format
int x = 1; int y = 2;
Action a = () => Math.Max(x, y);
Console.WriteLine(a.Bench());

// benchmark FuncToBench1() by running it for at least 1 sec
// default output format of picoseconds per operation
Action a = FuncToBench1;
Console.WriteLine(a.Bench(fmt: "ps"));

// benchmark FuncToBench1() by running it 100000 times using
// default output format
Action a = FuncToBench1;
Console.WriteLine(a.Bench(100000));

// benchmark FuncToBench1() by running it 100000 times using
// default output format of picoseconds per operation
Action a = FuncToBench1;
Console.WriteLine(a.Bench(100000, "ps"));

// benchmark FuncToBench1() by running it 1000 times using custom output format
Action a = FuncToBench1;
Console.WriteLine(a.Bench(1000, "Operations: {op} seconds: {s} op/s: {ops}"));

// compare speed of FuncToBench1(), FuncToBench2(), and FuncToBench3
// by running each function at least 1 second using default output format
Action[] a = { FuncToBench1, FuncToBench2, FuncToBench3 };
Console.WriteLine(a.Bench());

// compare speed of FuncToBench1(), FuncToBench2(), and FuncToBench3
// by running each function 1000 times using default output format
Action[] a = { FuncToBench1, FuncToBench2, FuncToBench3 };
Console.WriteLine(a.Bench(1000));
```

#### Format string tokens

 - **{op}**   - number of operations (runs)
 - **{ms}**   - elapsed time in milliseconds
 - **{s}**    - elapsed time in seconds
 - **{opms}** - operations per millisecond 
 - **{ops}**  - operations per second
 - **{nsop}** - nanoseconds per operation
 - **{psop}** - picoseconds per operation

#### Predefined format strings aliases

 - **"ns"**  -> "{op} op {s} s {nsop} ns/op"
 - **"nsl"** -> "{op} op {s} s {ops} op/s {nsop} ns/op"
 - **"ps"**  -> "{op} op {ms} ms {psop} ps/op"
 - **"psl"** -> "{op} op {ms} ms {opms} op/ms {psop} ps/op"

#### Where

 - **"ns"**  - nanoseconds (default)
 - **"nsl"** - nanoseconds long
 - **"ps"**  - picoseconds
 - **"psl"** - picoseconds long

#### Benchmark projects 

 - [UBenchDemo](UBenchDemo/README.md)
 - [UBenchConsole](UBenchConsole/README.md)
 - [UBenchFibonacci](UBenchFibonacci/README.md)
 - [UBenchMethod](UBenchMethod/README.md)
 
## License

[MIT](LICENSE.md)
