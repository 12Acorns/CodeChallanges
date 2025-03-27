using CodeChallanges.Benchmarking;
using BenchmarkDotNet.Attributes;

namespace CodeChallanges.Challanges.CC_IsFib;

public class FibNBenchmarker : IBenchmark
{
	[Params(610, 610*10, 610*100)]
	public int _testCases;

	[Benchmark]
	public bool IsFibOp() =>
		IsFib.IsFibOp(_testCases);
	[Benchmark]
	public bool IsFibBaseline() =>
		IsFib.IsFibBaseline(_testCases);
}
