using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace _5._Regex;

[MemoryDiagnoser]
public partial class RegexBench
{
    //RFC 5322
    private const string EmailRegex =
        @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";

    private readonly Regex oldRegex = new (EmailRegex);
    private readonly Regex oldCompiledRegex = new(EmailRegex, RegexOptions.Compiled);
    
    [GeneratedRegex(EmailRegex)]
    private  partial Regex NewRegex(); 

    [Params("mateusz.durajewski@gmail.com", "test.com")]
    public string Email { get; set; } = default!;

    [Benchmark]
    public bool Old_IsMatch() => new Regex(EmailRegex).IsMatch(Email);

    [Benchmark]
    public bool OldCompiled_IsMatch() => new Regex(EmailRegex, RegexOptions.Compiled).IsMatch(Email);

    [Benchmark]
    public bool New_IsMatch() => NewRegex().IsMatch(Email);
}