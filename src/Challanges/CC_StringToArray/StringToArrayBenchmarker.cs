using CodeChallanges.Utility.String;
using CodeChallanges.Benchmarking;
using BenchmarkDotNet.Attributes;
using CodeChallanges.Testing;
using CodeChallanges.Utility;
using System.Buffers;

namespace CodeChallanges.Challanges.CC_StringToArray;

[MemoryDiagnoser(false)]
public class StringToArrayBenchmarker : IBenchmark
{
	[Params("I love coding", "Wow wee, I am a really long string. I sure do hope this won't take TOO long hahahhah ")]
	public string? _testCases;

	// IN THIS CASE:
	// no gc handle is allocated so no dispose needs to be called
	[Benchmark]
	public ReadOnlySpan<StringView> STAOp2()
	{
		var pin = StringToArray.StringToArrayOp2(_testCases!, out var strings);
		pin.Dispose();
		return strings;
	}

	[Benchmark]
	public ReadOnlySpan<string> STAOp1() =>
		StringToArray.StringToArrayOp1(_testCases!);
	[Benchmark(Baseline = true)]
	public ReadOnlySpan<string> STABaseline() =>
		StringToArray.StringToArrayBaseline(_testCases!);
}
