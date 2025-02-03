using CodeChallanges.Challanges.CC_FindLongestWord;
using CodeChallanges.Challanges.CC_SumOfNegatives;
using CodeChallanges.Challanges.CC_IsPerfect;
using CodeChallanges.Benchmarking;
using CodeChallanges.Challanges.CC_IsSaddlePoint;

//Console.WriteLine(SumOfNegativesTests.Run());

var matrix = new int[,]
{
	{ 1, 2, 3 },
	{ 4, 5, 6 },
	{ 7, 8, 9 }
};
var matrix2 = new int[,]
{
	{ 1, 2, 3 },
	{ 4, 5, 6 },
	{ 10, 18, 4}
};
var matrix3 = new int[,]
{
	{ 1, 2, 3 },
	{ 40, 20, 60 },
	{ 10, 18, 4 }
};

Console.WriteLine(IsSaddlePoint.ContainsSaddlePointBaseline(new Matrix(matrix)));
Console.WriteLine(IsSaddlePoint.ContainsSaddlePointBaseline(new Matrix(matrix2)));
Console.WriteLine(IsSaddlePoint.ContainsSaddlePointBaseline(new Matrix(matrix3)));

return;

Benchmarker.AutoRegisterMarked();
Benchmarker.TryRun<SumOfNegativesBenchmarker>(out _);