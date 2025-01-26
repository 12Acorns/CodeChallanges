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
internal readonly record struct ExpectedResult<TData, TResult>
{
	public ExpectedResult(TData data, TResult result)
	{
		Data = data;
		Result = result;
	}
	public TData Data { get; }
	public TResult Result { get; }
}
internal readonly record struct PackData<T1, T2>
{
	public PackData(T1 item1, T2 item2)
	{
		Item1 = item1;
		Item2 = item2;
	}

	public T1 Item1 { get; }
	public T2 Item2 { get; }
}
internal readonly record struct PackData<T1, T2, T3>
{
	public PackData(T1 item1, T2 item2, T3 item3)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
	}

	public T1 Item1 { get; }
	public T2 Item2 { get; }
	public T3 Item3 { get; }
}
internal readonly record struct PackData<T1, T2, T3, T4>
{
	public PackData(T1 item1, T2 item2, T3 item3, T4 item4)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
		Item4 = item4;
	}

	public T1 Item1 { get; }
	public T2 Item2 { get; }
	public T3 Item3 { get; }
	public T4 Item4 { get; }
}