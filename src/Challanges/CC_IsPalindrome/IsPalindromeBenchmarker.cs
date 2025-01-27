using CodeChallanges.Benchmarking;
using BenchmarkDotNet.Attributes;

namespace CodeChallanges.Challanges.CC_IsPalindrome;

public class IsPalindromeBenchmarker : IBenchmark
{
	[Params("radkar", "urgawartcvacksdhcmnoyclilcyonmchddsmkcavctrawagru",
			"rvhzlycppcylzhvt", "rbfzjychpjjmqjtujpvjmddrcignwzlhunegngbfctqnnziiznnqtcfbgngenuhlzwngicddmjvpjutjqmjjphcyjzfbr")]
	public string? _testCases;

	[Benchmark]
	public bool IsPalindromeBaseline() =>
		IsPalindrome.IsPalindromeBaseline(_testCases!);
}
