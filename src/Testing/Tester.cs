using System.Runtime.InteropServices;

namespace CodeChallanges.Testing;

internal static class Tester
{
	/// <param name="operationDisplayAction">Method Name | Method Param and Expected Result | Actual Result</param>
	/// <returns></returns>
	public static bool Match<TData, TResult>(
		Func<TData, TResult> func,
		ReadOnlySpan<ExpectedResult<TData, TResult>> data,
		Action<string, ExpectedResult<TData, TResult>, TResult> operationDisplayAction,
		IComparer<TResult>? comparer = null)
	{
		comparer ??= Comparer<TResult>.Default;
		bool tOut = true;
		for(int i = 0; i < data.Length; i++)
		{
			var currData = data[i];
			var result = func(currData.Data);
			operationDisplayAction(func.Method.Name, currData, result);
			if(comparer.Compare(result, currData.Result) != 0)
			{
				tOut = false;
			}
		}
		return tOut;
	}
	public static bool Match<TData, TResult>(Func<TData, TResult> func, ReadOnlySpan<ExpectedResult<TData, TResult>> data, IComparer<TResult>? comparer = null)
	{
		comparer ??= Comparer<TResult>.Default;
		for(int i = 0; i < data.Length; i++)
		{
			var currData = data[i];
			var result = func(currData.Data);
			if(comparer.Compare(result, currData.Result) != 0)
			{
				return false;
			}
		}
		return true;
	}
}