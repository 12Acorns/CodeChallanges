using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;

namespace CodeChallanges.Utility;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
public readonly record struct PinnedReference<T> : IDisposable
{
	public static PinnedReference<T> Empty => new();

	private readonly GCHandle _handle;
	private readonly IntPtr _pointer;

	/// <exception cref="ArgumentNullException"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public PinnedReference(T obj)
	{
		ArgumentNullException.ThrowIfNull(obj, nameof(obj));
		_handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
		_pointer = _handle.AddrOfPinnedObject();
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public PinnedReference()
	{
		_handle = default;
		_pointer = IntPtr.Zero;
	}

	public readonly T Value
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return (T)_handle.Target!;
		}
	}
	public readonly IntPtr Pointer
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return _pointer;
		}
	}

	public void Dispose()
	{
		if(_handle.IsAllocated)
		{
			_handle.Free();
		}
	}
}
