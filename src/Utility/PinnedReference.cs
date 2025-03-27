using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace CodeChallanges.Utility;

public readonly record struct PinnedReference<T> : IDisposable
	where T : class
{
	public static PinnedReference<T> Empty => new();

	private readonly GCHandle _handle;
	private readonly IntPtr _pointer;

	/// <exception cref="ArgumentNullException"></exception>
	public PinnedReference(T obj)
	{
		ArgumentNullException.ThrowIfNull(obj, nameof(obj));
		_handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
		_pointer = _handle.AddrOfPinnedObject();
	}
	public PinnedReference()
	{
		_handle = default;
		_pointer = IntPtr.Zero;
	}

	public T Value => (T)_handle.Target!;
	public IntPtr Pointer => _pointer;

	public void Dispose()
	{
		if(_handle.IsAllocated)
		{
			_handle.Free();
		}
	}
}
