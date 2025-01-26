using CodeChallanges.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallanges.CC_IsPalindrome;
internal sealed class IsPalindromeTests : ITest
{
	private static readonly string[] input = File.ReadLines("CC_IsPalindrome\\TestResources\\TestData.txt").ToArray();

	public static bool Run()
	{
		var expected = input.Select(x => new ExpectedResult<string, bool>(data: x, true)).ToArray();
		var f5 = new ArraySegment<ExpectedResult<string, bool>>(expected, 0, 5)
			.Select(static x => new ExpectedResult<string, bool>(x.Data, false)).ToArray();

		var l5 = new ArraySegment<ExpectedResult<string, bool>>(expected, input.Length - 5, 5)
			.Select(static x => new ExpectedResult<string, bool>(x.Data, false)).ToArray();

		var eSpan = expected.AsSpan();
		f5.CopyTo(eSpan[..5]);
		l5.CopyTo(eSpan[^5..]);

		return Tester.Match<string, bool>(IsPalindrome.IsPalindromeBaseline, expected, (name, dataAndResult, actualResult) =>
		{
			Console.WriteLine($"{name}({dataAndResult.Data})\nExpect '{dataAndResult.Result}'\nGot '{actualResult}'\n");
		});
	}
}
