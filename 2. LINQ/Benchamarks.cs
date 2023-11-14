using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace _2._LINQ;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser(false)]
public class Benchamarks
{
    [Params(100)]
    public int Size { get; set; }

    private IEnumerable<int> items;

    [GlobalSetup]
    public void Setup()
    {
        items = Enumerable.Range(1, Size).ToArray();
    }

    [Benchmark]
    public int Min() => items.Min();

    [Benchmark]
    public int Max() => items.Max();

    [Benchmark]
    public int Sum() => items.Sum();

    [Benchmark]
    public double Avg() => items.Average();
}