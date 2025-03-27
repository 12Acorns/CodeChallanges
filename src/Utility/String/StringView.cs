using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareEngine;
using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeChallanges.Utility.String;

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = SIZE)]
public readonly unsafe struct StringView
{
	public const int SIZE = INTPTRSIZEBYTES + sizeof(int);

	// IntPtr (void*) -> 8 Bytes
	const int INTPTRSIZEBYTES = 8;

	public StringView(in PinnedReference<string> s, int from, int length)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(from);
		ArgumentOutOfRangeException.ThrowIfNegative(length);
		if(from + length > s.Value.Length)
		{
			throw new ArgumentOutOfRangeException(nameof(length));
		}

		_ptr = (nint)((char*)s.Pointer + from);
		_length = length;
	}
	public StringView(in PinnedReference<string> s, ref readonly char from, int length)
	{
		if(Unsafe.IsNullRef(in from))
		{
			throw new ArgumentNullException(nameof(from));
		}
		ArgumentOutOfRangeException.ThrowIfNegative(length);
		var fromPtr = Unsafe.AsPointer(ref Unsafe.AsRef(in from));
		var offset = (int)((char*)fromPtr - (char*)s.Pointer);

		_ptr = (nint)((char*)s.Pointer + offset);
		_length = length;
	}
	public StringView(in PinnedReference<string> s)
	{
		_ptr = s.Pointer;
		_length = s.Value.Length;
	}
	public StringView()
	{
		_ptr = nint.Zero;
		_length = 0;
	}

	[FieldOffset(0)]
	private readonly nint _ptr;
	[FieldOffset(INTPTRSIZEBYTES)]
	private readonly int _length;

	public char Start => _ptr == nint.Zero ? '\0' : *(char*)_ptr;
	public int Length => _length;
	public ReadOnlySpan<char> View =>
		_ptr == nint.Zero || _length <= 0 ? [] : new ReadOnlySpan<char>((void*)_ptr, _length);

	public override string ToString() => View.ToString();

	public char this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if(index < 0 || index >= _length)
			{
				throw new IndexOutOfRangeException();
			}
			return ((char*)_ptr)[index];
		}
	}
}
