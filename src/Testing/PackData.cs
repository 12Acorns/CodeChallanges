namespace CodeChallanges.Testing;

public readonly record struct PackData<T1, T2> 
{
	public PackData(T1 item1, T2 item2)
	{
		Item1 = item1;
		Item2 = item2;
	}

	public T1 Item1 { get; }
	public T2 Item2 { get; }

	public static implicit operator PackData<T1, T2>((T1, T2) tuple) =>
		new(tuple.Item1, tuple.Item2);
}
public readonly record struct PackData<T1, T2, T3>
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

	public static implicit operator PackData<T1, T2, T3>((T1, T2, T3) tuple) =>
		new(tuple.Item1, tuple.Item2, tuple.Item3);
}
public readonly record struct PackData<T1, T2, T3, T4>
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

	public static implicit operator PackData<T1, T2, T3, T4>((T1, T2, T3, T4) tuple) =>
		new(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
}