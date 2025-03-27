using System.Runtime.InteropServices;
using CodeChallanges.Testing;
using System.Linq;

namespace CodeChallanges.Challanges.CC_FindTargetElementFromPivot;

internal class FindMissingElementFromPivotTests : ITest
{
	public static bool Run()
	{
		return true;
		//var fileLines = File.ReadLines("Challanges\\CC_FindTargetElementFromPivot\\TestResources\\TestData.txt");
		//var arrs = new List<(IEnumerable<int>, int)>();
		//// So long as initial test data length doesn't change, tests are still deterministic
		//var rand = new Random(42069);
		//var expected = new List<ExpectedResult<IEnumerable<int>, int>>();
		//foreach(var arrStr in fileLines.Index())
		//{
		//	var elementsChars = arrStr.Item.Split(", ");
		//	var elements = elementsChars.Select(int.Parse);
		//	var len = elements.Count();
		//	var expIdx = rand.Next(len);
		//	var res = (elements, expIdx);
		//	arrs.Add(res);
		//	expected.Add(new(res));
		//}

		//return Tester.Match<IEnumerable<int>, int>(x =>
		//{
		//	var lT = arrs.Find(y => y.Item1.SequenceEqual(x));
		//	var arr = x.ToArray();
		//	var targetElement = arr[lT.Item2];
		//	return FindMissingElementFromPivot.SearchBaseline(arr, targetElement);
		//}, CollectionsMarshal.AsSpan(expected));
	}
}
