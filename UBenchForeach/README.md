## UBenchForeach project

#### Objectives

 - Compare speed of foreach vs for loop.
 - Compare speed of iterating T[], List<T>, and ArrayList.
 - Compare speed of iterating collection of int, string, struct, and KeyValuePair<int, string>  
 
#### Environment

 - Intel Core i7-4700MQ 2.4 GHz
 - 32 Gb DDR3 memory
 - Windows 10 Enterprise 64-bit
 - .NET Framework 4.5
 - Release/Any CPU build
 
#### Code

[Program.cs](Program.cs)

#### Iterating 5 items

```
int[] foreach                                 200000000 op 1.065 s  5.322 ns/op
int[] for                                     300000000 op 1.488 s  4.953 ns/op  93%
string[] foreach                              200000000 op 1.081 s  5.400 ns/op
string[] for                                  200000000 op 1.080 s  5.392 ns/op 100%
Point[] foreach                               300000000 op 1.621 s  5.396 ns/op
Point[] for                                   200000000 op 1.270 s  6.345 ns/op 117%
KeyValuePair<int, string>[] foreach           200000000 op 1.085 s  5.419 ns/op
KeyValuePair<int, string>[] for               200000000 op 1.081 s  5.401 ns/op  99%

List<int> foreach                              30000000 op 1.031 s 34.329 ns/op
List<int> for                                 200000000 op 1.795 s  8.963 ns/op  26%
List<string> foreach                           30000000 op 1.356 s 45.134 ns/op
List<string> for                              200000000 op 1.893 s  9.454 ns/op  20%
List<Point> foreach                            30000000 op 1.209 s 40.263 ns/op
List<Point> for                               200000000 op 1.761 s  8.794 ns/op  21%
List<KeyValuePair<int, string>> foreach        20000000 op 1.134 s 56.622 ns/op
List<KeyValuePair<int, string>> for           200000000 op 1.805 s  9.012 ns/op  15%

ArrayList of int foreach                       20000000 op 1.465 s 73.167 ns/op
ArrayList of int for                           50000000 op 1.261 s 25.200 ns/op  34%
ArrayList of string foreach                    20000000 op 1.630 s 81.384 ns/op
ArrayList of string for                        50000000 op 1.144 s 22.860 ns/op  28%
ArrayList of Point> foreach                    20000000 op 1.477 s 73.782 ns/op
ArrayList of Point for                         50000000 op 1.254 s 25.048 ns/op  33%
ArrayList of KeyValuePair<int, string> foreach 20000000 op 1.480 s 73.928 ns/op
ArrayList of KeyValuePair<int, string> for     50000000 op 1.281 s 25.592 ns/op  34%
```

#### Iterating 50 items

```
int[] foreach                                  30000000 op 1.036 s  34.490 ns/op
int[] for                                      50000000 op 1.357 s  27.104 ns/op  78%
string[] foreach                               30000000 op 1.113 s  37.061 ns/op
string[] for                                   30000000 op 1.083 s  36.048 ns/op  97%
Point[] foreach                                50000000 op 1.634 s  32.642 ns/op
Point[] for                                    50000000 op 1.674 s  33.431 ns/op 102%
KeyValuePair<int, string>[] foreach            30000000 op 1.160 s  38.614 ns/op
KeyValuePair<int, string>[] for                30000000 op 1.161 s  38.668 ns/op 100%

List<int> foreach                              10000000 op 1.688 s 168.620 ns/op
List<int> for                                  20000000 op 1.492 s  74.524 ns/op  44%
List<string> foreach                            5000000 op 1.376 s 274.835 ns/op
List<string> for                               20000000 op 1.607 s  80.239 ns/op  29%
List<Point> foreach                             5000000 op 1.089 s 217.646 ns/op
List<Point> for                                20000000 op 1.577 s  78.742 ns/op  36%
List<KeyValuePair<int, string>> foreach         3000000 op 1.055 s 351.251 ns/op
List<KeyValuePair<int, string>> for            20000000 op 1.564 s  78.100 ns/op  22%

ArrayList of int foreach                        3000000 op 1.414 s 470.766 ns/op
ArrayList of int for                            5000000 op 1.153 s 230.444 ns/op  48%
ArrayList of string foreach                     2000000 op 1.076 s 537.328 ns/op
ArrayList of string for                         5000000 op 1.187 s 237.218 ns/op  44%
ArrayList of Point> foreach                     3000000 op 1.395 s 464.320 ns/op
ArrayList of Point for                          5000000 op 1.159 s 231.532 ns/op  49%
ArrayList of KeyValuePair<int, string> foreach  3000000 op 1.432 s 476.905 ns/op
ArrayList of KeyValuePair<int, string> for      5000000 op 1.253 s 250.328 ns/op  52%
```

#### Iterating 500 items

```
int[] foreach                                   5000000 op 1.095 s  218.797 ns/op
int[] for                                       5000000 op 1.033 s  206.450 ns/op  94%
string[] foreach                                5000000 op 1.341 s  267.926 ns/op
string[] for                                    5000000 op 1.400 s  279.762 ns/op 104%
Point[] foreach                                 5000000 op 1.272 s  254.021 ns/op
Point[] for                                     5000000 op 1.470 s  293.651 ns/op 116%
KeyValuePair<int, string>[] foreach             5000000 op 1.254 s  250.448 ns/op
KeyValuePair<int, string>[] for                 5000000 op 1.465 s  292.642 ns/op 116%

List<int> foreach                               1000000 op 1.400 s 1397.867 ns/op
List<int> for                                   2000000 op 1.301 s  649.768 ns/op  46%
List<string> foreach                             500000 op 1.119 s 2236.566 ns/op
List<string> for                                2000000 op 1.577 s  787.741 ns/op  35%
List<Point> foreach                             1000000 op 1.870 s 1867.237 ns/op
List<Point> for                                 2000000 op 1.375 s  686.500 ns/op  36%
List<KeyValuePair<int, string>> foreach          500000 op 1.580 s 3155.367 ns/op
List<KeyValuePair<int, string>> for             2000000 op 1.397 s  697.543 ns/op  22%

ArrayList of int foreach                         300000 op 1.285 s 4277.612 ns/op
ArrayList of int for                             500000 op 1.059 s 2114.931 ns/op  49%
ArrayList of string foreach                      300000 op 1.471 s 4896.410 ns/op
ArrayList of string for                          500000 op 0.999 s 1996.114 ns/op  40%
ArrayList of Point> foreach                      300000 op 1.282 s 4269.100 ns/op
ArrayList of Point for                          1000000 op 1.992 s 1989.601 ns/op  46%
ArrayList of KeyValuePair<int, string> foreach   300000 op 1.328 s 4422.903 ns/op
ArrayList of KeyValuePair<int, string> for       500000 op 1.001 s 2000.416 ns/op  45%
```

#### ArrayList for vs List<T> foreach loop (500 items)

```
List<int> foreach                               1000000 op 1.400 s 1397.867 ns/op
ArrayList of int for                             500000 op 1.059 s 2114.931 ns/op 151%
List<string> foreach                             500000 op 1.119 s 2236.566 ns/op
ArrayList of string for                          500000 op 0.999 s 1996.114 ns/op  89%
List<Point> foreach                             1000000 op 1.870 s 1867.237 ns/op
ArrayList of Point for                          1000000 op 1.992 s 1989.601 ns/op 106%
List<KeyValuePair<int, string>> foreach          500000 op 1.580 s 3155.367 ns/op
ArrayList of KeyValuePair<int, string> for       500000 op 1.001 s 2000.416 ns/op  63%
```

#### Performance Analysis

 - Array foreach is as fast as for loop (%5 slower to 16% faster)
 - List<T> foreach is unexpectedly very slow compare to for loop (54% - 78% slower)
 - ArrayList foreach on average 2 times slower compare to for loop
 - ArrayList for loop for reference types outperforms List<T> foreach loop!
