using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections;
using System.Diagnostics;
using System;

namespace CodeChallanges.Challanges.CC_IsSaddlePoint;

[DebuggerDisplay("Value: {Value}, Index: {Index}")]
internal struct IndexedElement<TValue>
{
	public IndexedElement(TValue value, int index)
	{
		Value = value;
		Index = index;
	}

	public TValue Value { get; }
	public int Index { get; }

	public void Deconstruct(out TValue value, out int index)
	{
		value = Value;
		index = Index;
	}

	public static bool operator ==(IndexedElement<TValue> @this, IndexedElement<TValue> other)
	{
		if(@this.Index != other.Index)
		{
			return false;
		}
		var val = @this.Value;
		if(val == null)
		{
			return other.Value == null;
		}
		return val switch
		{
			IComparable<TValue> iComparableV => iComparableV.CompareTo(other.Value) == 0,
			IComparer<TValue> iComparerV => iComparerV.Compare(val, other.Value) == 0,
			IComparable iComparable => iComparable.CompareTo(other.Value) == 0,
			IComparer iComparer => iComparer.Compare(val, other.Value) == 0,
			_ => val!.Equals(other.Value)
		};
	}
	public static bool operator !=(IndexedElement<TValue> @this, IndexedElement<TValue> other) =>
		!(@this == other);

	public override bool Equals(object? obj)
	{
		if(obj == null || obj is not IndexedElement<TValue> val)
		{
			return false;
		}
		return this == val;
	}

	public override int GetHashCode() =>
		HashCode.Combine(Value, Index);
}
