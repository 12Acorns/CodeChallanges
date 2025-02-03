using CodeChallanges.Testing;

namespace CodeChallanges.Challanges.CC_SumOfNegatives;

internal class SumOfNegativesTests : ITest
{
	private const int ARRSLENGTH = 20;
	private static readonly int[][] _preBuffer =
	[
		[1, -2, 3, -4, 5],
		[1, -2, 3, -4, 5, -6, 0, 55]
	];
	private static readonly ExpectedResult<int[], int>[] _preExpectedResults =
	[
		new(_preBuffer[0], -6),
		new(_preBuffer[1], -12)
	];

	public static bool Run()
	{
		var arr = Create(ARRSLENGTH, _preBuffer);
		var results = new ExpectedResult<int[], bool>[20];
		var tests = CreateTests(arr, _preExpectedResults);
		// a is redundant since used to create tests but hey ho
		var a = Tester.Match<int[], int>(SumOfNegatives.SumOfNegativesBaseline, tests);
		var b = Tester.Match<int[], int>(x => SumOfNegatives.SumOfNegativesOp1(x), tests);
		var c = Tester.Match<int[], int>(SumOfNegatives.SumOfNegativesOp2, tests);
		var d = Tester.Match<int[], int>(x => SumOfNegatives.SumOfNegativesOp3(x), tests);
		var e = Tester.Match<int[], int>(x => SumOfNegatives.SumOfNegativesOp4(x), tests);
		var f = Tester.Match<int[], int>(x => SumOfNegatives.SumOfNegativesOp5(x), tests);
		return a && b && c && d && e && f;
	}

	private static ExpectedResult<int[], int>[] CreateTests(int[][] arrs, ExpectedResult<int[], int>[]? preExpectedResult)
	{
		var res = new ExpectedResult<int[], int>[arrs.Length];
		preExpectedResult?.CopyTo(res.AsSpan());
		for(int i = preExpectedResult?.Length ?? 0; i < arrs.Length; i++)
		{
			res[i] = new ExpectedResult<int[], int>(arrs[i], SumOfNegatives.SumOfNegativesBaseline(arrs[i]));
		}
		return res;
	}
	private static int[][] Create(int arrs, int[][]? preBuffer = null)
	{
		var res = new int[arrs][];
		preBuffer?.CopyTo(res.AsSpan());
		for(int i = preBuffer?.Length ?? 0; i < arrs; i++)
		{
			var bufLength = Random.Shared.Next(5, 256);
			res[i] = new int[bufLength];
			for(int j = 0; j < bufLength; j++)
			{
				res[i][j] = Random.Shared.Next(-100, 101);
			}
		}
		return res;
	}
}
