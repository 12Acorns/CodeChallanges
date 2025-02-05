using CodeChallanges.Benchmarking;
using BenchmarkDotNet.Attributes;

namespace CodeChallanges.Challanges.CC_LongestIncreasingSubSequence;

public class LongestIncreasingSSBenchmarker : IBenchmark
{
	[Params((int[])[10, 22, 9, 33, 21, 50, 41, 60, 80], (int[])[10, 20, 35, 80], (int[])[2, 2, 2])]
	public int[]? _testCases;

	[Benchmark]
	public int LongestIncreasingSSOp2() =>
		LongestIncreasingSubSequence.LongestIncreasingSubSeqeuenceOp2(_testCases!);
	[Benchmark]
	public int LongestIncreasingSSOp1() =>
		LongestIncreasingSubSequence.LongestIncreasingSubSeqeuenceOp1(_testCases!);
	[Benchmark]
	public int LongestIncreasingSSBaseline() =>
		LongestIncreasingSubSequence.LongestIncreasingSubSeqeuenceBaseline(_testCases!);
}
