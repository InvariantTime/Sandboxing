using Microsoft.Extensions.Hosting;
using Sandboxing.Infrastructure.Working.Factory;
using Sandboxing.Infrastructure.Working.Queues;
using Sandboxing.Working;

namespace Sandboxing.Infrastructure.Working;

public class WorkerStartupService : IHostedService
{
    private readonly ICollection<IWorker> _workers;
    private readonly IWorkerQueue _queue;

    public WorkerStartupService(IWorkerQueue queue, IWorkerFactory factory)
    {
        _queue = queue;
        _workers = factory.BuildWorkers();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var runs = _workers.Select(x => x.RunAsync(_queue, cancellationToken));
        return Task.WhenAll(runs);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        var stops = _workers.Select(x => x.StopAsync());
        return Task.WhenAll(stops);
    }
}
