using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections;
using System.Diagnostics;
using System;

namespace CodeChallanges.Utility;

[DebuggerDisplay("Value: {Value}, Index: {Index}")]
internal struct IndexedElement<TValue>
{
	public IndexedElement((int Index, TValue Value) tpl) : this(tpl.Value, tpl.Index) { }
	public IndexedElement((TValue Value, int Index) tpl) : this(tpl.Value, tpl.Index) { }
	public IndexedElement(TValue value, int index)
	{
		Value = value;
		Index = index;
	}

	public TValue Value { get; }
	public int Index { get; }


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

	public static implicit operator IndexedElement<TValue>((int index, TValue value) indexedTuple) => new(indexedTuple);
	public static implicit operator IndexedElement<TValue>((TValue value, int index) indexedTuple) => new(indexedTuple);
}
