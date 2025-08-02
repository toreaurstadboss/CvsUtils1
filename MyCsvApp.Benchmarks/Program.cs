using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class CsvUtilsBenchmarks
{
    private readonly string[] testInputs = new[]
    {
        "apple,banana,orange",
        "  apple , , banana ,  orange  ,",
        ",,,",
        "  grape  ",
        ", lemon , lime ,",
        "   ,   ,  ",
        "a,b,c"
    };

    [Benchmark]
    public void SanitizeCsvValueV1()
    {
        foreach (var input in testInputs)
            CsvUtils.SanitizeCsvValueV1(input);
    }

    [Benchmark]
    public void SanitizeCsvValueV2()
    {
        foreach (var input in testInputs)
            CsvUtils.SanitizeCsvValueV2(input);
    }

    [Benchmark]
    public void SanitizeCsvValueV3()
    {
        foreach (var input in testInputs)
            CsvUtils.SanitizeCsvValueV3(input);
    }

    [Benchmark]
    public void SanitizeCsvValueV4()
    {
        foreach (var input in testInputs)
            CsvUtils.SanitizeCsvValueV4(input);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<CsvUtilsBenchmarks>();
    }
}