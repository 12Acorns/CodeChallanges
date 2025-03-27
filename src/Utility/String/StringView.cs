using Iced.Intel;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareEngine;
using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeChallanges.Utility.String;

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Pack = 1, Size = SIZE)]
public readonly unsafe struct StringView
{
	public const int SIZE = INTPTRSIZEBYTES + sizeof(int);

	// IntPtr (void*) -> 8 Bytes
	const int INTPTRSIZEBYTES = 8;

	[FieldOffset(0)]
	private readonly nint _ptr;
	[FieldOffset(INTPTRSIZEBYTES)]
	private readonly int _length;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public StringView(in PinnedReference<string> s, int from, int length)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(from);
		ArgumentOutOfRangeException.ThrowIfNegative(length);
		if(from + length <= s.Value.Length)
		{
			_ptr = (nint)((char*)s.Pointer + from);
			_length = length;
			return;
		}
		throw new ArgumentOutOfRangeException(nameof(length));
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public StringView(in PinnedReference<string> s, ref readonly char from, int length)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(length);
		if(!Unsafe.IsNullRef(in from))
		{
			var fromPtr = Unsafe.AsPointer(ref Unsafe.AsRef(in from));
			var offset = (int)((char*)fromPtr - (char*)s.Pointer);

			_ptr = (nint)((char*)s.Pointer + offset);
			_length = length;
			return;
		}
		throw new ArgumentNullException(nameof(from));
		
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public StringView(in PinnedReference<string> s)
	{
		_ptr = s.Pointer;
		_length = s.Value.Length;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public StringView()
	{
		_ptr = nint.Zero;
		_length = 0;
	}

	public readonly char Start
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return _ptr == nint.Zero ? '\0' : *(char*)_ptr;
		}
	}
	public readonly int Length
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return _length;
		}
	}
	public readonly bool IsEmpty
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return Length > 0 && _ptr != IntPtr.Zero;
		}
	}
	public readonly ReadOnlySpan<char> View
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return 
				_ptr == nint.Zero || _length <= 0 
					? [] 
					: new ReadOnlySpan<char>((void*)_ptr, _length);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override string ToString() => View.ToString();

	public readonly char this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			unchecked
			{
				if((uint)index >= (uint)_length)
				{
					throw new IndexOutOfRangeException();
				}
			}
			return ((char*)_ptr)[index];
		}
	}
}
