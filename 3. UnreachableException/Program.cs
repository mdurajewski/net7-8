using System.Diagnostics;
using _3._UnreachableException;

var status = GetStatus();

var statusName = status switch
{
    Status.Silver => "Silver status",
    Status.Gold => "Gold status",
    Status.Platinum => "Platinum status",
    _ => throw new UnreachableException()
};

Console.WriteLine(statusName);

Status GetStatus() => (Status)6;