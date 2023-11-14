using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace _13._Enums;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser(false)]
[HideColumns("Job", "RatioSD", "Error")]
public class EnumsBenchy
{
    private readonly Day monday = Day.Monday;

    [Benchmark]
    public bool IsDefined() => Enum.IsDefined(monday);

    [Benchmark]
    public string? GetName() => Enum.GetName(monday);

    [Benchmark]
    public string[] GetNames() => Enum.GetNames<Day>();

    [Benchmark]
    public Day[] GetValues() => Enum.GetValues<Day>();

    [Benchmark]
    public string? Enum_ToString() => monday.ToString();

    [Benchmark]
    public (bool, Day) TryParse()
    {
        var parsed = Enum.TryParse<Day>("Monday", out var day);
        return (parsed, day);
    }
}