using CodeChallanges.Challanges.CC_IsSaddlePoint;

using static BenchmarkDotNet.Attributes.MarkdownExporterAttribute;

namespace CodeChallanges.Challanges.CC_LongestIncreasingSubSequence;

internal static class LongestIncreasingSubSequence
{
	private static readonly IndexedElement<int> Default = new(-1, -1);

	public static int LongestIncreasingSubSeqeuenceOp2(int[] arr)
	{
		Span<int> mLis = stackalloc int[arr.Length];
		for(int i = 0; i < arr.Length; i++)
		{
			for(int j = 0; j < i; j++)
			{
				if(arr[i] > arr[j])
				{
					mLis[i] = Math.Max(mLis[i], mLis[j] + 1);
				}
			}
		}
		return Max(mLis) + 1;
	}
	public static int LongestIncreasingSubSeqeuenceOp1(int[] arr)
	{
		int currSeq, maxSeq = 0;
		for(int i = 0; i < arr.Length; i++)
		{
			currSeq = 0;
			var next = -2;
			while(next < arr.Length)
			{
				if(next is -2)
				{
					next = i;
				}
				else
				{
					next = GetNextUpComingSmallestOp1(arr, next);
				}
				if(next is -1)
				{
					break;
				}
				currSeq++;
			}
			if(currSeq > maxSeq)
			{
				maxSeq = currSeq;
			}
		}
		return maxSeq;
	}
	public static int LongestIncreasingSubSeqeuenceBaseline(int[] arr)
	{
		int currSeq, maxSeq = 0;
		for(int i = 0; i < arr.Length; i++)
		{
			currSeq = 0;
			var next = Default;
			while(next.Index < arr.Length)
			{
				if(next == Default)
				{
					next = new(arr[i], i);
				}
				else
				{
					next = GetNextUpComingSmallest(arr, next);
				}
				if(next.Index is -1)
				{
					break;
				}
				currSeq++;
			}
			if(currSeq > maxSeq)
			{
				maxSeq = currSeq;
			}
		}
		return maxSeq;
	}
	private static int Max(ReadOnlySpan<int> arr)
	{
		int m = arr[0];
		for(int i = 1; i < arr.Length; i++)
		{
			m = Math.Max(m, arr[i]);
		}
		return m;
	}
	private static int GetNextUpComingSmallestOp1(int[] arr, int index)
	{
		if(index is < 0 || index >= arr.Length)
		{
			return -1;
		}
		var val = arr[index];
		for(int i = index + 1; i < arr.Length; i++)
		{
			if(arr[i] > val)
			{
				return i;
			}
		}
		return -1;
	}
	private static IndexedElement<int> GetNextUpComingSmallest(int[] arr, IndexedElement<int> element)
	{
		var (value, index) = element;
		if(index is < 0 || index >= arr.Length)
		{
			return new(-1, -1);
		}
		for(int i = index + 1; i < arr.Length; i++)
		{
			var val = arr[i];
			if(val > value)
			{
				return new(val, i);
			}
		}
		return new(-1, -1);
	}
}
