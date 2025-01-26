using BenchmarkDotNet.Attributes;

namespace CodeChallanges.CC_IsPalindrome;

public class IsPalindromeBenchmarker
{
	[Params("radkar", "urgawartcvacksdhcmnoyclilcyonmchddsmkcavctrawagru", 
			"rvhzlycppcylzhvt", "rbfzjychpjjmqjtujpvjmddrcignwzlhunegngbfctqnnziiznnqtcfbgngenuhlzwngicddmjvpjutjqmjjphcyjzfbr")]
	public string _testCases;

	[Benchmark]
	public bool IsPalindromeBaseline() =>
		IsPalindrome.IsPalindromeBaseline(_testCases);
}
