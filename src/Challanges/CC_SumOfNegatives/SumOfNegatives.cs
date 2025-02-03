using System.Runtime.CompilerServices;

namespace CodeChallanges.Challanges.CC_SumOfNegatives;

internal static class SumOfNegatives
{
	public static unsafe int SumOfNegativesOp5(int[] arr)
	{
		int sum = 0;
		fixed(int* start = arr)
		{
			for(int i = arr.Length - 1; i >= 0; i--)
			{
				var num = start[i];
				sum += num & (num >> 31);
			}
		}
		return sum;
	}
	public static int SumOfNegativesOp4(ReadOnlySpan<int> arr)
	{
		int sum = 0;
		for(int i = arr.Length - 1; i >= 0; i--)
		{
			var num = arr[i];
			sum += num & NegSign(num);
		}
		return sum;
	}
	public static int SumOfNegativesOp3(ReadOnlySpan<int> arr)
	{
		int sum = 0;
		for(int i = arr.Length - 1; i >= 0; i--)
		{
			var num = arr[i];
			sum += num * PosSign(num);
		}
		return sum;
	}
	public static int SumOfNegativesOp2(int[] arr) =>
		arr.Sum(x => x * PosSign(x));
	public static int SumOfNegativesOp1(ReadOnlySpan<int> arr)
	{
		int sum = 0;
		for(int i = arr.Length - 1; i >= 0; i--)
		{
			sum += Math.Min(arr[i], 0);
		}
		return sum;
	}
	public static int SumOfNegativesBaseline(int[] arr) =>
		arr.Sum(x => Math.Min(x, 0));

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int NegSign(int num) => num >> 31;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int PosSign(int num) => -(num >> 31);
}
