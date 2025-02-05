using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Collections.Generic;
using CodeChallanges.Extensions;
using System.Runtime.Intrinsics;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
using System.Runtime.InteropServices.Swift;
using System.Reflection.Emit;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;

namespace CodeChallanges.Challanges.CC_SumOfPerfectSquares;
internal static class SumOfPerfectSquares
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe int SumOfPerfectSquaresSIMDOp1(ReadOnlySpan<int> arr)
	{
		// minimum needed to use SIMD w/v256
		if(arr.Length < 8)
		{
			return SumOfPerfectSquaresScalarBaseline(arr);
		}

		var v256Nums = MemoryMarshal.Cast<int, Vector256<int>>(arr);
		var count = Vector256<int>.Count;
		var vSum = Vector256<int>.Zero;
		for(int i = 0; i < v256Nums.Length; i++)
		{
			var curr = v256Nums[i];
			var sqrt = Avx2.Sqrt(Avx2.ConvertToVector256Single(curr));
			var floor = Avx2.Floor(sqrt);
			var equal = Avx2.CompareEqual(sqrt, floor);
			var toInt = Vector256.AsInt32(equal);
			var iVals = curr * -toInt;
			var squared = iVals * iVals;
			vSum = Avx2.Add(vSum, squared);
		}
		var sum = vSum.AVXVSum();
		return sum + SumOfPerfectSquaresScalarBaseline(arr[(v256Nums.Length * count)..]);
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SumOfPerfectSquaresScalarBaseline(ReadOnlySpan<int> nums)
	{
		int sum = 0;
		for(int i = 0; i < nums.Length; i++)
		{
			var num = nums[i];
			if(num <= 0)
			{
				continue;
			}
			if(IsPerfectSquare(num))
			{
				sum += num * num;
			}
		}
		return sum;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsPerfectSquare(int num)
	{
		var sqrt = Math.Sqrt(num);
		var floor = Math.Floor(sqrt);
		return sqrt == floor;
	}
}
