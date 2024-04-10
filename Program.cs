using BenchmarkDotNet.Running;

namespace ImageSharpBenchmark;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}
