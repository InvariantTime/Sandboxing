using Sandboxing.Domain;

namespace Sandboxing.Infrastructure.Working.Queues;

public interface IWorkerQueue
{
    ValueTask<bool> WriteAsync(Work work, CancellationToken cancellation = default);

    ValueTask<Work> ReadAsync(CancellationToken cancellation = default);
}