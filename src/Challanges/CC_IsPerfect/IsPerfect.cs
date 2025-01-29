using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace CodeChallanges.Challanges.CC_IsPerfect;

internal static class IsPerfect
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe bool IsPerfectOptimised1(int num)
	{
		var res = 1;
		var sqrt = (int)Math.Sqrt(num);

		for(int i = 2; i <= sqrt; i++)
		{
			if(num % i == 0)
			{
				res += i;
				res += num / i;
			}
		}
		return res == num;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsPerfectBaseline(int num)
	{
		var res = 1;
		for(int i = 2; i < num / 2 + 1; i++)
		{
			if(num % i == 0)
			{
				res += i;
			}
		}
		return res == num;
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
}
