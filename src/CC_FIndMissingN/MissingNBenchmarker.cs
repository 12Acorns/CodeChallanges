using BenchmarkDotNet.Attributes;

namespace CodeChallanges.CC_FIndMissingN;

public class MissingNBenchmarker
{
	[Params((int[])[1, 2, 4, 6, 3, 7, 8], (int[])[1, 2, 4, 6, 3, 7, 8, 9, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20])]
	public int[] _s;

	[Benchmark]
	public void MissingNOptimised() =>
		MissingN.MissingNOp(_s);
	[Benchmark]
	public void MissingNF() =>
		MissingN.MissingNBase(_s);
}