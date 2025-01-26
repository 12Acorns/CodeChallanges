using CodeChallanges.CC_FIndMissingN;
using CodeChallanges.CC_IsPalindrome;
using CodeChallanges;

Benchmarker.TryRegister<MissingNBenchmarker>();
Benchmarker.TryRegister<IsPalindromeBenchmarker>();

Benchmarker.TryRun<IsPalindromeBenchmarker>(out _);