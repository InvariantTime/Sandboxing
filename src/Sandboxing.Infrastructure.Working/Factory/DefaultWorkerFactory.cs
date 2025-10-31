using Microsoft.Extensions.Options;
using Sandboxing.Working;

namespace Sandboxing.Infrastructure.Working.Factory;

public class DefaultWorkerFactory : IWorkerFactory
{
    public WorkerFactoryOptions Options { get; }

    public DefaultWorkerFactory(IOptions<WorkerFactoryOptions> options)
    {
        Options = options.Value;
    }

    public ICollection<IWorker> BuildWorkers()
    {
        var workers = new IWorker[Options.WorkersCount];

        for (int i = 0; i < Options.WorkersCount; i++)
        {
            workers[i] = new BackgroundWorker();
        }

        return workers;
    }
}
