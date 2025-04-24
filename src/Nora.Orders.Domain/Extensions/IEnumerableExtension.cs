namespace Nora.Orders.Domain.Extensions;

public static class IEnumerableExtension
{
    public async static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, CancellationToken, ValueTask> AsynchronousAction)
    {
        const decimal PercentualUsage = .7m;
        int LogicalProcessors = Environment.ProcessorCount * 2;
        var maxThreads = Convert.ToInt32(Math.Ceiling(LogicalProcessors * PercentualUsage));

        await Parallel.ForEachAsync<T>(source ?? [], new ParallelOptions { MaxDegreeOfParallelism = maxThreads }, AsynchronousAction);
    }
}