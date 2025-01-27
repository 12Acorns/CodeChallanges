namespace CodeChallanges.Challanges.CC_FindLongestWord;

internal static class FindLongestWord
{
	public static string FindLongestStringOp2(string s)
	{
		int mEnd = 0, mStart = 0;
		int index = 0;
		while(index < s.Length)
		{
			int start = index;
			while(index < s.Length && s[index] != ' ')
			{
				index++;
			}
			if(index - start > mEnd - mStart)
			{
				mEnd = index;
				mStart = start;
			}
			index++;
		}
		return s[mStart..mEnd];
	}
	public static string FindLongestStringOp1(string s)
	{
		int index = 0;
		var sSpan = s.AsSpan();
		ReadOnlySpan<char> slice = [];
		while(index < s.Length)
		{
			int start = index;
			while(index < s.Length && s[index] != ' ')
			{
				index++;
			}
			if(index - start > slice.Length)
			{
				slice = sSpan[start..index];	
			}
			index++;
		}
		return slice.ToString();
	}
	public static string FindLongestStringBaseline(string s) => 
		s.Split(' ').OrderByDescending(x => x.Length).First();
}
