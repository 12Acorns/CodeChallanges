using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeChallanges.Utility.String;
using CodeChallanges.Extensions;
using CodeChallanges.Testing;
using CodeChallanges.Utility;
using System.Buffers;

namespace CodeChallanges.Challanges.CC_StringToArray;

internal static class StringToArray
{
	public static unsafe PinnedReference<string> StringToArrayOp2(string s, out ReadOnlySpan<StringView> strings)
	{
		strings = [];
		if(string.IsNullOrWhiteSpace(s))
		{
			return PinnedReference<string>.Empty;
		}

		Span<StringView> store = stackalloc StringView[(s.Length >> 1) + (s.Length & 1)];
		Unsafe.SkipInit(out store);
		var pin = new PinnedReference<string>(s);
		fixed(char* sPtr = s)
		{
			char* relStart = sPtr;
			char* end = sPtr + s.Length;
			int i = 0;
			while(relStart < end)
			{
				char* space = relStart;
				while(space < end && *space != ' ')
				{
					space++;
				}

				int length = (int)(space - relStart);
				if(length > 0)
				{
					store[i++] = new(pin, (int)(relStart - sPtr), length);
				}

				relStart = space + 1; // Move past space
			}
			var destination = new StringView[i];
			Unsafe.SkipInit(out destination);
			fixed(StringView* destinationPtr = destination, storePtr = store)
			{
				var size = i * StringView.SIZE;
				Buffer.MemoryCopy(storePtr, destinationPtr, size, size);
			}
			strings = destination;
			return pin;
		}
	}
	// ChatGPT optimised apparently
	public static unsafe ReadOnlySpan<string> StringToArrayOp1(string s)
	{
		if(string.IsNullOrWhiteSpace(s))
		{
			return [];
		}

		// Determine exact allocation size by counting spaces
		int spaceCount = 0;
		foreach(char c in s)
			if(c == ' ')
				spaceCount++;

		int wordCount = spaceCount + 1; // Words = spaces + 1
		Span<PackData<IntPtr, int>> store = stackalloc PackData<IntPtr, int>[wordCount];

		int i = 0;
		fixed(char* sPtr = s)
		{
			char* relStart = sPtr;
			char* end = sPtr + s.Length;

			while(relStart < end)
			{
				char* space = relStart;
				while(space < end && *space != ' ')
					space++;

				int length = (int)(space - relStart);
				if(length > 0) // Ignore consecutive spaces
				{
					store[i++] = new((IntPtr)relStart, length);
				}

				relStart = space + 1; // Move past space
			}

			// Convert spans to strings directly
			var result = new string[i];
			for(int j = 0; j < i; j++)
			{
				result[j] = new string((char*)store[j].Item1, 0, store[j].Item2);
			}

			return result;
		}
	}
	public static string[] StringToArrayBaseline(string s) => 
		string.IsNullOrWhiteSpace(s) ? [] : s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
}
