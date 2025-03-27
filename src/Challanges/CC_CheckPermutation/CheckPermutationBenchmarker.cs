using BenchmarkDotNet.Attributes;
using CodeChallanges.Benchmarking;
using System.Linq;

namespace CodeChallanges.Challanges.CC_CheckPermutation;

public class CheckPermutationBenchmarker : IBenchmark
{
	[Params(
		(string[])["abc", "bca"],
		//(string[])["fqu89fnfsNOWEHOFWE", "fqu89fnfsNOWEHOFKO"],
		(string[])["ABCDEGGHIJKLMNOPQRSTUVWXYZ0123456789", "9876543210ZYXWVUTSRQPONMLKJIHGGEDCBA"]
	)]
	public string[]? _testCases;

	[Benchmark]
	public bool CheckPermutationOp3() =>
		CheckPermutation.CheckPermutationOp3(_testCases![0], _testCases![1]);
	[Benchmark]
	public bool CheckPermutationOp2() =>
		CheckPermutation.CheckPermutationOp2(_testCases![0], _testCases![1]);

	//[Benchmark]
	//public bool CheckPermutationOp1() =>
	//	CheckPermutation.CheckPermutationOp1(_testCases![0], _testCases![1]);
	//[Benchmark]
	//public bool CheckPermutationBaseline() =>
	//	CheckPermutation.CheckPermutationBaseline(_testCases![0], _testCases![1]);
}
