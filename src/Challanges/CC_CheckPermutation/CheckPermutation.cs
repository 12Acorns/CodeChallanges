using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using CodeChallanges.Testing;

namespace CodeChallanges.Challanges.CC_CheckPermutation;

internal static class CheckPermutation
{
	//public static bool CheckPermutationOp3(scoped ReadOnlySpan<char> a, scoped ReadOnlySpan<char> b)
	//{
	//	if(a.Length != b.Length)
	//	{
	//		return false;
	//	}
	//	// 0 - 25 index is a - z, 26 - 52 index is A - Z, 53 - 62 index is 0 - 9
	//	const int CHARMAPSIZE = 26 + 26 + 10;
	//	Span<int> charCountA = stackalloc int[CHARMAPSIZE];
	//	Span<int> charCountB = stackalloc int[CHARMAPSIZE];
	//	// Im sure there is some genious way to use SIMD to iterate quicker but am dumb
	//	for(int i = 0; i < a.Length; i++)
	//	{
	//		charCountA[GetIndex(a[i])]++;
	//		charCountB[GetIndex(b[i])]++;
	//	}
	//	// Be thankful its like this
	//	// Before I loaded them all but that was slower than using MemMarsh.
	//	// Probs some sort of caching issue when doing accumilation or something idk
	//	var vecAArr = MemoryMarshal.Cast<int, Vector256<int>>(charCountA);
	//	var vecASum =
	//		Avx2.Add(vecAArr[0],
	//		Avx2.Add(vecAArr[1],
	//		Avx2.Add(vecAArr[2],
	//		Avx2.Add(vecAArr[3],
	//		Avx2.Add(vecAArr[4],
	//		Avx2.Add(vecAArr[5],
	//					vecAArr[6]))))));
	//	var vecBArr = MemoryMarshal.Cast<int, Vector256<int>>(charCountB);
	//	var vecBSum =
	//		Avx2.Add(vecBArr[0],
	//		Avx2.Add(vecBArr[1],
	//		Avx2.Add(vecBArr[2],
	//		Avx2.Add(vecBArr[3],
	//		Avx2.Add(vecBArr[4],
	//		Avx2.Add(vecBArr[5],
	//					vecBArr[6]))))));
	//	// Idk if this is the fastest way but if they are equal a vector of -1 are created
	//	// Because of this, the cmp.AsByte produces 255 for each element (underflow)
	//	// And MoveMask will then I think pack it into a int?
	//	// Anywho, fast it to a uint and do comparison to uint.MaxValue (:
	//	var cmp = Avx2.CompareEqual(vecASum, vecBSum);
	//	var mask = (uint)Avx2.MoveMask(cmp.AsByte());
	//	if(mask != 0xffffffffU)
	//	{
	//		return false;
	//	}
	//	// Don't know why but casting from int to longs for packing causes the last value to be uint32.MaxValue
	//	var sliceA = charCountA[56..];
	//	var sliceB = charCountB[56..];
	//	return sliceA[0] + sliceA[1] + sliceA[2] + sliceA[3] + sliceA[4] + sliceA[5] ==
	//		   sliceB[0] + sliceB[1] + sliceB[2] + sliceB[3] + sliceB[4] + sliceB[5];
	//}
	// ^^^^^^^^^^^^^^^^^
	// Above is original
	// Courtosy of ChatGPT
	public static unsafe bool CheckPermutationOp3(scoped ReadOnlySpan<char> a, scoped ReadOnlySpan<char> b)
	{
		if(a.Length != b.Length)
			return false;

		const int CHARMAPSIZE = 62; // 26+26+10

		// Allocate a single counting array.
		int* counts = stackalloc int[CHARMAPSIZE];
		//Unsafe.InitBlockUnaligned(counts, 0, (uint)(CHARMAPSIZE * sizeof(int)));

		// Process both spans in one pass: increment for a, decrement for b.
		fixed(char* pa = a, pb = b)
		{
			for(int i = 0; i < a.Length; i++)
			{
				counts[GetIndex(pa[i])]++;
				counts[GetIndex(pb[i])]--;
			}
		}

		// Use AVX2 to check the first 56 counts (7 Vector256<int> elements, each 8 ints)
		int vectorCount = CHARMAPSIZE / 8; // 62/8 = 7 full vectors, remainder = 6
		for(int i = 0; i < vectorCount; i++)
		{
			// Load 8 counts at a time
			var vec = Avx.LoadVector256(counts + i * 8);
			// Test whether all 32 bits in each int are zero. TestZ returns true if all bits are zero.
			if(!Avx2.TestZ(vec, vec))
				return false;
		}

		// Check the remaining 6 counts
		int remainderStart = vectorCount * 8;
		for(int i = remainderStart; i < CHARMAPSIZE; i++)
		{
			if(counts[i] != 0)
				return false;
		}

		return true;
	}
	public static bool CheckPermutationOp2(string a, string b)
	{
		if(a.Length != b.Length)
		{
			return false;
		}
		// 0 - 25 index is a - z, 26 - 52 index is A - Z, 53 - 62 index is 0 - 9
		const int CHARMAPSIZE = 26 + 26 + 10;
		Span<int> charCount = stackalloc int[CHARMAPSIZE];
		for(int i = 0; i < a.Length; i++)
		{
			charCount[GetIndex(a[i])]++;
			charCount[GetIndex(b[i])]--;
		}
		var longCharCount = MemoryMarshal.Cast<int, long>(charCount);
		int j = 0;
		for(; j < CHARMAPSIZE >> 1; j++)
		{
			if(longCharCount[j] != 0)
			{
				return false;
			}
		}
		return true;
	}
	public static bool CheckPermutationOp1(string a, string b)
	{
		if(a.Length != b.Length)
		{
			return false;
		}
		var charMap = a.Distinct().ToDictionary(x => x, x => a.Count(y => y == x));
		foreach(var c in b)
		{
			ref var charCount = ref CollectionsMarshal.GetValueRefOrNullRef(charMap, c);
			if(Unsafe.IsNullRef(in charCount))
			{
				return false;
			}
			if(--charCount == 0)
			{
				charMap.Remove(c);
			}
		}
		return charMap.Count == 0;
	}
	public static bool CheckPermutationBaseline(string a, string b) =>
		a.Length != b.Length ? false
			: a.OrderBy(c => c).SequenceEqual(b.OrderBy(c => c));

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int GetIndex(char c) => c switch
	{
		>= 'a' and <= 'z' => c - 'a',
		>= 'A' and <= 'Z' => c - 'A' + 26,
		>= '0' and <= '9' => c - '0' + 52,
		_ => throw new System.ArgumentException("Invalid character")
	};
}
