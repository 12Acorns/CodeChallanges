using CodeChallanges.Benchmarking;
using BenchmarkDotNet.Attributes;

namespace CodeChallanges.Challanges.CC_FindLongestWord;

[MemoryDiagnoser(true)]
public class FindLongestWordBenchmarker : IBenchmark
{
	[Params("The quick brown fox jumped over the lazy dog")]
	public string? _testCases;

	[Benchmark]
	public string FindLongestWordOp2() =>
		FindLongestWord.FindLongestStringOp2(_testCases!);
	[Benchmark]
	public string FindLongestWordOp1() =>
		FindLongestWord.FindLongestStringOp1(_testCases!);
	[Benchmark(Baseline = true)]
	public string FindLongestWordBaseline() =>
		FindLongestWord.FindLongestStringBaseline(_testCases!);
}
