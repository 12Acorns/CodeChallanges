using CodeChallanges.Testing;

namespace CodeChallanges.Challanges.CC_IsPerfect;

internal sealed class IsPerfectTests : ITest
{
	private static readonly ExpectedResult<int, bool>[] tests = Create();

	public static bool Run()
	{
		var a = Tester.Match<int, bool>(IsPerfect.IsPerfectBaseline, tests);
		var b = Tester.Match<int, bool>(IsPerfect.IsPerfectOptimised1, tests);
		return a && b;
	}

	private static ExpectedResult<int, bool>[] Create()
	{
		ExpectedResult<int, bool>[] expected = new ExpectedResult<int, bool>[10000];
		for(int i = 1; i < expected.Length; i++)
		{
			expected[i] = new(i, IsPerfect.IsPerfectBaseline(i));
		}
		return expected;
	}
}
