using BenchmarkDotNet.Attributes;
using CodeChallanges.Benchmarking;

namespace CodeChallanges.Challanges.CC_IsPerfect;

public class IsPerfectBenchmarker : IBenchmark
{
	[Params(6, 28, 497, 8128)]
	public int? _testCases;

	[Benchmark]
	public bool IsPerfectOptimised1() => IsPerfect.IsPerfectOptimised1(_testCases!.Value);
	[Benchmark(Baseline = true)]
	public bool IsPerfectBaseline() => IsPerfect.IsPerfectBaseline(_testCases!.Value);
}
