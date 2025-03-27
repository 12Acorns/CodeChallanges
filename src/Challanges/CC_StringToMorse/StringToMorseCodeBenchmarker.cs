using CodeChallanges.Benchmarking;
using BenchmarkDotNet.Attributes;

namespace CodeChallanges.Challanges.CC_StringToMorse;

public class StringToMorseCodeBenchmarker : IBenchmark
{
	private static readonly string _testCases = " abcdefghijklmnopqrstuvwxyz 0123456789 ";

	[Benchmark]
	public string ToMorseOp3() => StringToMorseCode.ToMorseOp3(_testCases!);
	//[Benchmark]
	//public string ToMorseOp2() => StringToMorseCode.ToMorseOp2(_testCases!);
	//[Benchmark]
	//public string ToMorseOp1() => StringToMorseCode.ToMorseOp1(_testCases!);
	[Benchmark]
	public string ToMorseBaseline() => StringToMorseCode.ToMorseBaseline(_testCases!);
}
