namespace _10._Interceptors;

public static class Interception
{
    [InterceptsLocation(
        filePath: "C:\\Users\\mdurajewski\\source\\repos\\net7-8\\10. Interceptors\\Program.cs",
        line: 5,
        character: 9)]
    public static void InterceptMethod1(this Example example) => Console.WriteLine("Hello from Interceptor");
}