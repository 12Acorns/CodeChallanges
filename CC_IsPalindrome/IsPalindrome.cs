using System.Runtime.CompilerServices;

namespace CodeChallanges.CC_IsPalindrome;

internal static class IsPalindrome
{
	public static bool IsPalindromeBaseline(string s)
	{
		int from = 0, to = s.Length - 1;

		while(from < to)
		{
			if(s[from] == s[to])
			{
				from++;
				to--;
				continue;
			}
			var sSpan = s.AsSpan();
			// right shift segment
			var segment = sSpan[(from + 1)..(to + 1)];
			if(IsValidPalindrome(segment))
			{
				return true;
			}
			segment = sSpan[from..to];
			if(IsValidPalindrome(segment))
			{
				return true;
			}
			return false;
		}
		return false;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsValidPalindrome(ReadOnlySpan<char> s)
	{
		for(int i = 0, j = s.Length - 1; i < j; i++, j--)
		{
			if(s[i] != s[j])
			{
				return false;
			}
		}
		return true;
	}
}
