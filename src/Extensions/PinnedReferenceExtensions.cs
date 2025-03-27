using System.Runtime.CompilerServices;
using CodeChallanges.Utility;

namespace CodeChallanges.Extensions;

internal static unsafe class PinnedReferenceExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ReadOnlySpan<T> AsSpan<T>(this in PinnedReference<T> pinnedReference, int offset, int length)
		where T : class => new ReadOnlySpan<T>((void*)pinnedReference.GetPointerOffset(offset), length);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IntPtr GetPointerOffset<T>(this in PinnedReference<T> pinnedReference, int offset)
		where T : class
	{
		ArgumentOutOfRangeException.ThrowIfNegative(offset, nameof(offset));
		if(pinnedReference.Value is ICollection<T> col)
		{
			ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(offset, col.Count, nameof(offset));
		}
		if(pinnedReference.Value is T[] arr)
		{
			ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(offset, arr.Length, nameof(offset));
		}
		if(pinnedReference.Value is string s)
		{
			ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(offset, s.Length, nameof(offset));
		}
		return pinnedReference.Pointer + offset;
	}
}
