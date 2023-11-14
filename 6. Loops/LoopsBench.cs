using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace _6._Loops;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class LoopsBench
{
    private int[] ItemsArray;
    private List<int> ItemsList;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(333);
        var randomItems = Enumerable.Range(0, 1000).Select(_ => random.Next());
        ItemsArray = randomItems.ToArray();
        ItemsList = randomItems.ToList();
    }

    [Benchmark]
    public void For_Array()
    {
        for (int i = 0; i < ItemsArray.Length; i++)
        {
            var item = ItemsArray[i];
        }
    }

    [Benchmark]
    public void ForEach_Array()
    {
        foreach (var item in ItemsArray) { }
    }

    [Benchmark]
    public void For_List()
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            var item = ItemsList[i];
        }
    }

    [Benchmark]
    public void ForEach_List()
    {
        foreach (var item in ItemsList) { }
    }
}