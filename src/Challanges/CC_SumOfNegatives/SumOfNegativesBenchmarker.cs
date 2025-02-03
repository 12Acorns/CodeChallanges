using BenchmarkDotNet.Attributes;
using CodeChallanges.Benchmarking;

namespace CodeChallanges.Challanges.CC_SumOfNegatives;

[MemoryDiagnoser]
public class SumOfNegativesBenchmarker : IBenchmark
{
	// Expect: -6, -12
	[Params((int[])[1, -2, 3, -4, 5], (int[])[1, -2, 3, -4, 5, -6, 0, 55])]
	public int[]? _testCases;

	[Benchmark]
	public int SumOfNegativesOp5() => SumOfNegatives.SumOfNegativesOp4(_testCases!);
	[Benchmark]
	public int SumOfNegativesOp4() => SumOfNegatives.SumOfNegativesOp4(_testCases!);
	//[Benchmark]
	//public int SumOfNegativesOp3() => SumOfNegatives.SumOfNegativesOp3(_testCases!);
	//[Benchmark]
	//public int SumOfNegativesOp2() => SumOfNegatives.SumOfNegativesOp2(_testCases!);
	[Benchmark]
	public int SumOfNegativesOp1() => SumOfNegatives.SumOfNegativesOp1(_testCases!);
	//[Benchmark]
	//public int SumOfNegativesBaseline() => SumOfNegatives.SumOfNegativesBaseline(_testCases!);
}
