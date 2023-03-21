using System.Diagnostics;
using Thread.PerformanceTest.Versions;

long start = 100;
long end = 1_000_000;

var sw = new Stopwatch();
//var func = PrimeNumberV1.PrimesInRange;
//var func = PrimeNumberV2.PrimesInRange;
//var func = PrimeNumberV3.PrimesInRange;
var func = PrimeNumberV4.PrimesInRange;

sw.Start();

var result = func(start, end);

sw.Stop();

Console.WriteLine($"{result} prime numbers found");
Console.WriteLine($"Time: {sw.ElapsedMilliseconds}ms");