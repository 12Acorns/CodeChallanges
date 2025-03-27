using CodeChallanges.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallanges.Challanges.CC_SumDivisibleByK;

internal static class SumDivisibleByK
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SumDivisibleByKOp2(ReadOnlySpan<int> arr, int k)
	{
		var modVec = Vector256.Create(k);
		var vArr = MemoryMarshal.Cast<int, Vector256<int>>(arr);
		var vSum = Vector256<int>.Zero;
		for(int i = 0; i < vArr.Length; i++)
		{
			var ele = vArr[i];
			var l = Mod(ele, modVec);
			var mask = Avx2.CompareEqual(l, Vector256<int>.Zero);
			vSum = Avx2.Add(vSum, ele * -mask);
		}
		int sum = vSum.AVXVSum();
		for(int i = vArr.Length * Vector256<int>.Count; i < arr.Length; i++)
		{
			sum += arr[i] % k == 0 ? arr[i] : 0;
		}
		return sum;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SumDivisibleByKOp1(ReadOnlySpan<int> arr, int k)
	{
		int sum = 0;
		for(int i = 0; i < arr.Length; i++) 
		{
			sum += arr[i] % k == 0 ? arr[i] : 0;
		}
		return sum;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SumDivisibleByKBaseline(int[] arr, int k) =>
		arr.Sum(x => x % k == 0 ? x : 0);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector256<int> Mod(Vector256<int> a, Vector256<int> n)
	{
		var aSin = Avx2.ConvertToVector256Single(a);
		var nSin = Avx2.ConvertToVector256Single(n);
		var div = Avx2.Divide(aSin, nSin);
		var floor = Avx2.Floor(div);
		var mul = Avx2.Multiply(nSin, floor);
		var mulInt = Avx2.ConvertToVector256Int32(mul);
		var sub = Avx2.Subtract(a, mulInt);
		return sub;
	}
}
