using BenchmarkDotNet.Attributes;
using CodeChallanges.Benchmarking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallanges.Challanges.CC_SumDivisibleByK;

public class SumDivisibleByKBenchmark : IBenchmark
{
	private const int K = 10;

	[Params((int[])[10, 20, 30, 40, 50, 65, 75, 85, 95, 105, 115])]
	public int[]? _testParam;

	[Benchmark]
	public int SumOfDivisibleByKOp2() =>
		SumDivisibleByK.SumDivisibleByKOp2(_testParam!, K);
	[Benchmark]
	public int SumOfDivisibleByKOp1() =>
		SumDivisibleByK.SumDivisibleByKOp1(_testParam!, K);
	[Benchmark]
	public int SumOfDivisibleByKBaseline() => 
		SumDivisibleByK.SumDivisibleByKBaseline(_testParam!, K);
}
