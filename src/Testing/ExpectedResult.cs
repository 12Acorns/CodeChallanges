using CodeChallanges.Utility;
using System.Runtime.CompilerServices;

namespace CodeChallanges.Testing;

internal readonly record struct ExpectedResult<TData, TResult>
{
	public ExpectedResult(IndexedElement<TData> element)
	{
		if(typeof(TResult) != typeof(int))
		{
			throw new ArgumentException("TResult is not an int. Expected an int because indexed elements index is treated as the result");
		}
		Data = element.Value;
		Result = Unsafe.BitCast<int, TResult>(element.Index);
	}
	public ExpectedResult(TData data, TResult result)
	{
		Data = data;
		Result = result;
	}
	public TData Data { get; }
	public TResult Result { get; }
}
