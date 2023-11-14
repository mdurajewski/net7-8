using _2._LINQ;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchamarks>();

//var item = Enumerable.Range(1,100).ToArray();

//var max = item.Max();
//var min =  item.Min();
//var avg = item.Average();
//var sum  = item.Sum();