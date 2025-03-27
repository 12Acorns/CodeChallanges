using System.Runtime.CompilerServices;

namespace CodeChallanges.Extensions;

internal static class SpanLinqExtensions
{
	/// <returns><paramref name="destination"/></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Span<TTo> Select<TFrom, TTo>(this scoped ReadOnlySpan<TFrom> source, Span<TTo> destination, Func<TFrom, TTo> selector)
	{
		ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length, destination.Length, nameof(destination));
		ArgumentNullException.ThrowIfNull(selector);
		for(int i = 0; i < source.Length; i++)
		{
			destination[i] = selector(source[i]);
		}
		return destination;
	}
	/// <returns>a new span of <typeparamref name="TTo"/></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Span<TTo> Select<TFrom, TTo>(this scoped ReadOnlySpan<TFrom> source, Func<TFrom, TTo> selector) =>
		Select(source, new TTo[source.Length], selector);
	/// <returns><paramref name="destination"/></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Span<TTo> Select<TFrom, TTo>(this scoped Span<TFrom> source, Span<TTo> destination, Func<TFrom, TTo> selector) =>
		Select((ReadOnlySpan<TFrom>)source, destination, selector);
	/// <returns>a new span of <typeparamref name="TTo"/></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Span<TTo> Select<TFrom, TTo>(this scoped Span<TFrom> source, Func<TFrom, TTo> selector) =>
		Select((ReadOnlySpan<TFrom>)source, selector);
}
