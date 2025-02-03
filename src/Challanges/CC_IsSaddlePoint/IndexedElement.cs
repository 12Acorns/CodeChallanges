namespace CodeChallanges.Challanges.CC_IsSaddlePoint;

internal readonly struct IndexedElement<TValue>
{
	public IndexedElement(TValue value, int index)
	{
		Value = value;
		Index = index;
	}

	public TValue Value { get; }
	public int Index { get; }
}
