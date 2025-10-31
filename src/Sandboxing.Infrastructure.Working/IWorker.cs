using Sandboxing.Infrastructure.Working.Queues;

namespace Sandboxing.Working;

public interface IWorker
{
    Task RunAsync(IWorkerQueue queue, CancellationToken cancellation);

    Task StopAsync();

    Task CancelWorkAsync();
}