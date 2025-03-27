using CodeChallanges.Utility;

namespace CodeChallanges.Challanges.CC_IsSaddlePoint;

internal static class IsSaddlePoint
{
	public static bool ContainsSaddlePointBaseline(Matrix matrix)
	{
		var rows = matrix.RowLength;
		var collumns = matrix.CollumnLength;

		for(int i = 0; i < rows; i++)
		{
			var rowElements = GetCollumnElementsInRow(matrix, i);
			// Assume no duplicate vals
			var minRowElement = rowElements
				.OrderBy(x => x.Value)
				.First();

			var collumnElements = GetRowElementsInCollumn(matrix, minRowElement.Index);
			var maxCollumnElement = collumnElements
				.OrderByDescending(x => x.Value)
				.First();

			if(maxCollumnElement.Value == minRowElement.Value)
			{
				return true;
			}
		}
		return false;
	}

	private static IEnumerable<IndexedElement<int>> GetCollumnElementsInRow(Matrix matrix, int row)
	{
		for(int i = 0; i < matrix.CollumnLength; i++)
			yield return new(matrix[row, i], i);
	}
	private static IEnumerable<IndexedElement<int>> GetRowElementsInCollumn(Matrix matrix, int collumn)
	{
		for(int i = 0; i < matrix.RowLength; i++)
			yield return new(matrix[i, collumn], i);
	}
}
