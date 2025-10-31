using Sandboxing.Domain;
using System.Threading.Channels;

namespace Sandboxing.Infrastructure.Working.Queues;

public class DefaultWorkerQueue : IWorkerQueue
{
    private readonly Channel<Work> _works = Channel.CreateUnbounded<Work>();

    public async ValueTask<bool> WriteAsync(Work work, CancellationToken cancellation = default)
    {
        await _works.Writer.WriteAsync(work, cancellation);
        return true;
    }

    public ValueTask<Work> ReadAsync(CancellationToken cancellation = default)
    {
        return _works.Reader.ReadAsync(cancellation);
    }
}
