using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallanges.Challanges.CC_IsPalindrome2;
internal static class IsPalindrome2
{
	private static Lazy<EqualityComparer<char>> CreateOrGetEqualityComparer { get; } = new(() =>
		EqualityComparer<char>.Create((x, y) => char.ToLowerInvariant(x) == char.ToLowerInvariant(y), x => x.GetHashCode()));

	//public static bool IsPalindromeOp1(string s)
	//{

	//}
	public static bool IsPalindromeLinqBaseline(string s)
	{
		var n = s.Where(char.IsLetterOrDigit);
		var rev = n.Reverse();
		return n.SequenceEqual(rev, CreateOrGetEqualityComparer.Value);
	}
}
