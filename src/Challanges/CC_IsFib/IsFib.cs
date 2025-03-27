using System.Runtime.CompilerServices;

namespace CodeChallanges.Challanges.CC_IsFib;

internal static class IsFib
{
	private const double SQRT5 = 2.23606797749979d;
	private const double HALFSQRT5 = 0.5d * SQRT5;
	private const double INVERSESQRT5 = 1 / SQRT5;
	private const double TWOPHI = 1 + SQRT5;
	private const double PHI = TWOPHI / 2d;
	private const double NATLOG2 = 0.6931471805599d;
	private const double NATLOG2PHI = 1.1743590056195d;
	private const double RECIPROCALNATLOG2MINUSNATLOG2PHI = 1 / (NATLOG2 - NATLOG2PHI);

	public static bool IsFibOp(int n)
	{
		if(n < 0)
		{
			return false;
		}
		if(n < 4)
		{
			return true;
		}
		var _input = GetInputOfPossibleFibFromOutputX(n);
		var _ceilInput = (int)Math.Ceiling(_input);
		return n == (int)GetFib(_ceilInput);
	}
	public static bool IsFibBaseline(int n)
	{
		if(n < 0)
		{
			return false;
		}
		if(n < 4)
		{
			return true;
		}

		int k = 0;
		int j = 1;
		while(k < n)
		{
			var tmp = k;
			k += j;
			j = tmp;
		}
		return k == n;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int GetFib(int n) =>
		(int)Math.FusedMultiplyAdd(PhiN(n), INVERSESQRT5, 0.5);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static double GetInputOfPossibleFibFromOutputX(int x) =>
		ComputeTopHalf(x) * RECIPROCALNATLOG2MINUSNATLOG2PHI;
	// Assume n > 0.5
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static double ComputeTopHalf(int input) =>
		-Math.Log(HALFSQRT5 * (2 * input - 1));
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static double PhiN(int y)
	{
		const double PHISQUARED = PHI * PHI;
		var x = PHI;
		for(int i = 0; i < y >> 1; i++)
		{
			x *= PHISQUARED;
		}
		if((y & 1) == 0)
		{
			return x / PHI;
		}
		return x;
	}
}
