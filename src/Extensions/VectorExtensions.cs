using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;

namespace CodeChallanges.Extensions;

internal static class VectorExtensions
{
	public static int AVXVSum(this Vector256<int> vector)
	{
		var vUpper = Avx2.ExtractVector128(vector, 1);
		var vLower = Avx2.ExtractVector128(vector, 0);
			vLower = Avx2.Add(vLower, vUpper);
		var hAdd = Avx2.HorizontalAdd(vLower, vLower);
		return Avx2.Extract(hAdd, 0) + Avx2.Extract(hAdd, 1);
	}
}
