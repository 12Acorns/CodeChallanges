using CodeChallanges.Challanges.CC_LongestIncreasingSubSequence;
using CodeChallanges.Challanges.CC_FindTargetElementFromPivot;
using CodeChallanges.Challanges.CC_SumOfPerfectSquares;
using CodeChallanges.Challanges.CC_CheckPermutation;
using CodeChallanges.Challanges.CC_FindLongestWord;
using CodeChallanges.Challanges.CC_SumDivisibleByK;
using CodeChallanges.Challanges.CC_SumOfNegatives;
using CodeChallanges.Challanges.CC_IsSaddlePoint;
using CodeChallanges.Challanges.CC_IsPalindrome2;
using CodeChallanges.Challanges.CC_StringToArray;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeChallanges.Utility.String;
using CodeChallanges.Benchmarking;
using CodeChallanges.Extensions;
using CodeChallanges.Utility;
using System.Buffers;

//static string PP2(scoped ReadOnlySpan<StringView> s) =>
//	$"[{string.Join(", ", s.Select<StringView, string?>(x => $"\"{x.View}\""))}]";
//static string PP1(scoped ReadOnlySpan<string> s) =>
//	$"[{string.Join(", ", s.Select<string, string?>(x => $"\"{x}\""))}]";

//var r1 = StringToArray.StringToArrayBaseline("I love coding ");
//var r2 = StringToArray.StringToArrayOp1("I love coding ");
//var r3 = StringToArray.StringToArrayOp2("I love coding ", out var r3Strings);
//var r4 = StringToArray.StringToArrayOp2("I love coding", out var r4Strings);

//Console.WriteLine(PP1(r1));
//Console.WriteLine(PP1(r2));
//Console.WriteLine(PP2(r3Strings));
//Console.WriteLine(PP2(r4Strings));

//r3.Dispose();
//r4.Dispose();

//return;

Benchmarker.AutoRegisterMarked();
Benchmarker.TryRun<StringToArrayBenchmarker>(out _);