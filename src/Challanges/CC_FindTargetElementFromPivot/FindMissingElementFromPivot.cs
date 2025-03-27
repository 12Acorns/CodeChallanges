using BenchmarkDotNet.Validators;

namespace CodeChallanges.Challanges.CC_FindTargetElementFromPivot;

internal static class FindMissingElementFromPivot
{
	public static int SearchOp1(ReadOnlySpan<int> elements, int target)
	{
		int left = 0, right = elements.Length - 1;
		while(left <= right)
		{
			int mid = left + (right - left) / 2;
			if(elements[mid] == target)
			{
				return mid;
			}
			if(elements[left] <= elements[mid])
			{
				if(elements[left] <= target && target < elements[mid])
				{
					right = mid - 1;
					continue;
				}
				left = mid + 1;
				continue;
			}
			if(elements[mid] < target && target <= elements[right])
			{
				left = mid + 1;
				continue;
			}
			right = mid - 1;
		}
		return -1;
	}
	public static int SearchBaseline(ReadOnlySpan<int> elements, int target)
	{
		for(int i = 0; i < elements.Length; i++)
		{
			if(elements[i] == target)
			{
				return target;
			}
		}
		return -1;
	}
}
