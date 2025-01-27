using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Reports;
using System.Reflection;

namespace CodeChallanges.Benchmarking;

internal static class Benchmarker
{
	private static readonly ConcurrentDictionary<Type, bool> registeredBenchmarks = new();

	public static void AutoRegisterMarked()
	{
		var currAssem = Assembly.GetExecutingAssembly();
		var types = currAssem.GetTypes();
		var marked = types.Where(x => typeof(IBenchmark).IsAssignableFrom(x));
		foreach(var type in marked)
		{
			registeredBenchmarks.TryAdd(type, true);
		}
	}
	public static bool TryRegister<T>()
	{
		if(!Validate<T>())
		{
			return false;
		}
		return registeredBenchmarks.TryAdd(typeof(T), true);
	}

	public static bool TryRun<T>(Action<Summary> logSummaryResults, out Summary info)
	{
		if(!Validate<T>())
		{
			info = null!;
			return false;
		}
		var result = Runner<T>(out info);
		if(!result)
		{
			return false;
		}
		logSummaryResults(info);
		return true;
	}
	public static bool TryRun<T>(out Summary info)
	{
		if(!Validate<T>())
		{
			info = null!;
			return false;
		}
		return Runner<T>(out info);
	}
	private static bool Runner<T>(out Summary info)
	{
		if(!registeredBenchmarks.ContainsKey(typeof(T)))
		{
			info = null!;
			return false;
		}
		info = BenchmarkRunner.Run<T>();
		return true;
	}
	private static bool Validate<T>() =>
		!IsSealedOrAbstractOrStatic<T>() && !IsInterface<T>();
	private static bool IsSealedOrAbstractOrStatic<T>() =>
		typeof(T).IsSealed || typeof(T).IsAbstract;
	private static bool IsInterface<T>() =>
		typeof(T).IsInterface && typeof(T).GetCustomAttribute<CoClassAttribute>() == null;
}
