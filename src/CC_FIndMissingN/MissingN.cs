using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

namespace CodeChallanges.CC_FIndMissingN;

internal static class MissingN
{
	public static int MissingNOp(int[] s)
	{
		if(s.Length == 1)
		{
			return -1;
		}
		var len = s.Length;
		var sum = Sum(s);
		int rem = len & 1; // mod 2
		var lP1 = len + 1;
		var lP1A = lP1 * -(rem - 1);
		var lP1R = lP1 + rem;
		var hLen = lP1 >> 1; // div 2
		return hLen * lP1R + lP1A - sum;
	}
	public static int MissingNBase(int[] s)
	{
		if(s.Length == 1)
		{
			return -1;
		}
		Array.Sort(s);
		for(int i = 1; i < s.Length; i++)
		{
			if(Difference(s[i], s[i - 1]) <= 1)
			{
				continue;
			}
			return s[i - 1] + 1;
		}
		return -1;
	}
	// https://en.algorithmica.org/hpc/simd/reduction/
	// https://stackoverflow.com/questions/67605744/writing-a-vector-sum-function-with-simd-system-numerics-and-making-it-faster-t
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	static int Sum(Span<int> e)
	{
		var eV = MemoryMarshal.Cast<int, Vector256<int>>(e);
		var accum = Vector256<int>.Zero;
		for(int i = 0; i < eV.Length; i++)
			accum = Avx2.Add(accum, eV[i]);
		var sum = VectorSum(accum);
		for(int i = eV.Length * Vector256<int>.Count; i < e.Length; i++)
			sum += e[i];
		return sum;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int VectorSum(Vector256<int> v)
	{
		var vLower = v.GetLower();
		var vUpper = v.GetUpper();
		vLower = Sse2.Add(vLower, vUpper);
		var hAdd = Ssse3.HorizontalAdd(vLower, vLower);
		return Sse41.Extract(hAdd, 0) + Sse41.Extract(hAdd, 1);
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Difference(int n, int m) =>
		Math.Abs(n - m);
}
