using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeChallanges.Challanges.CC_StringToMorse;
internal static class StringToMorseCode
{
	private const int WHITESPACEOFFSET = 1;
	private const int LETTEROFFSET = WHITESPACEOFFSET + 26;

	private static readonly string[] _characterMap =
	[
		//' '
		" / ",
		//'A'
		".-",
		//'B'
		"-...",
		//'C'
		"-.-.",
		//'D'
		"-..",
		//'E'
		".",
		//'F'
		"..-.",
		//'G'
		"--.",
		//'H'
		"....",
		//'I'
		"..",
		//'J'
		".---",
		//'K'
		"-.-",
		//'L'
		".-..",
		//'M'
		"--",
		//'N'
		"-.",
		//'O'
		"---",
		//'P'
		".--.",
		//'Q'
		"--.-",
		//'R'
		".-.",
		//'S'
		"...",
		//'T'
		"-",
		//'U'
		"...",
		//'V'
		"-",
		//'W'
		".--",
		//'X'
		"-..-",
		//'Y'
		"-.--",
		//'Z'
		"--..",
		//'0'
		"-----",
		//'1'
		".----",
		//'2'
		"..---",
		//'3'
		"...--",
		//'4'
		"....-",
		//'5'
		".....",
		//'6'
		"-....",
		//'7'
		"--...",
		//'8'
		"---..",
		//'9'
		"----.",
	];
	private static readonly string[] _lookupTable = CreateLookupTable();

	public static string ToMorseOp3(string s)
	{
		int length = CalculateLength(s);
		return string.Create(length, s, (buffer, input) =>
		{
			int morseStringIndex = 0;
			for(int i = 0; i < input.Length; i++)
			{
				ReadOnlySpan<char> morseString = _lookupTable[input[i]];
				morseString.CopyTo(buffer.Slice(morseStringIndex));
				morseStringIndex += morseString.Length;
			}
		});
	}
	public static string ToMorseOp2(string s) => string.Create(CalculateLengthOp1(s), _characterMap, (buffer, map) =>
	{
		int originalStringIndex = 0;
		int morseStringIndex = 0;
		while(originalStringIndex < s.Length)
		{
			var currentOriginalChar = char.ToLower(s[originalStringIndex]);
			scoped ReadOnlySpan<char> morseString = currentOriginalChar switch
			{
				' ' => _characterMap[0],
				>= '0' and <= '9' => _characterMap[currentOriginalChar - '0' + LETTEROFFSET],
				_ => _characterMap[currentOriginalChar - 'a' + WHITESPACEOFFSET]
			};
			morseString.CopyTo(buffer.Slice(morseStringIndex, morseString.Length));
			morseStringIndex += morseString.Length;
			originalStringIndex++;
		}
	});
	public static string ToMorseOp1(string s) => string.Create(CalculateLengthOp1(s), _characterMap, (buffer, map) =>
	{
		int originalStringIndex = 0;
		int morseStringIndex = 0;
		while(originalStringIndex < s.Length)
		{
			var currentOriginalChar = char.ToLower(s[originalStringIndex]);
			ReadOnlySpan<char> morseString;
			// Get current replacement string for char
			if(currentOriginalChar is ' ')
			{
				morseString = _characterMap[0];
			}
			else if(char.IsLetter(currentOriginalChar))
			{
				morseString = map[currentOriginalChar - 'a' + WHITESPACEOFFSET];
			}
			else
			{
				morseString = map[currentOriginalChar - '0' + LETTEROFFSET];
			}
			int local = 0;
			while(local < morseString.Length)
			{
				buffer[morseStringIndex++] = morseString[local++];
			}
			originalStringIndex++;
		}
	});
	public static string ToMorseBaseline(string s) => string.Create(CalculateLengthBaseline(s), _characterMap, (buffer, map) =>
	{
		int originalStringIndex = 0;
		int morseStringIndex = 0;
		while(originalStringIndex < s.Length)
		{
			var currentOriginalChar = char.ToLower(s[originalStringIndex]);
			ReadOnlySpan<char> morseString;
			// Get current replacement string for char
			if(currentOriginalChar is ' ')
			{
				morseString = _characterMap[0];
			}
			else if(char.IsLetter(currentOriginalChar))
			{
				morseString = map[currentOriginalChar - 'a' + WHITESPACEOFFSET];
			}
			else
			{
				morseString = map[currentOriginalChar - '0' + LETTEROFFSET];
			}
			int local = 0;
			while(local < morseString.Length)
			{
				buffer[morseStringIndex++] = morseString[local++];
			}
			originalStringIndex++;
		}
	});

	// Assume all chars in string are valid
	private static int CalculateLengthOp1(string s)
	{
		int length = 0;
		for(int i = 0; i < s.Length; i++)
		{
			var @char = char.ToLower(s[i]);
			length += @char switch
			{
				' ' => 3,
				>= '0' and <= '9' => _characterMap[@char - '0' + LETTEROFFSET].Length,
				_ => _characterMap[@char - 'a' + WHITESPACEOFFSET].Length
			};
		}
		return length;
	}
	// Assume all chars in string are valid
	private static int CalculateLengthBaseline(string s)
	{
		int length = 0;
		for(int i = 0; i < s.Length; i++)
		{
			var @char = char.ToLower(s[i]);
			length += @char switch
			{
				' ' => 3,
				'0' or '1' or '2' or '3' or '4' or '5' or
				'6' or '7' or '8' or '9' => _characterMap[@char - '0' + LETTEROFFSET].Length,
				_ => _characterMap[@char - 'a' + WHITESPACEOFFSET].Length
			};
		}
		return length;
	}

	private static int CalculateLength(string s)
	{
		int length = 0;
		foreach(char c in s)
			length += _lookupTable[c].Length;
		return length;
	}
	private static string[] CreateLookupTable()
	{
		var table = new string[256]; // Enough for ASCII
		table[' '] = _characterMap[0];
		for(char c = 'A'; c <= 'Z'; c++)
			table[c] = table[char.ToLower(c)] = _characterMap[c - 'A' + WHITESPACEOFFSET];

		for(char c = '0'; c <= '9'; c++)
			table[c] = _characterMap[c - '0' + LETTEROFFSET];

		return table;
	}
}
