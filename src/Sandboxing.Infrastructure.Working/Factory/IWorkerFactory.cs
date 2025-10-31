using Sandboxing.Working;
using System.Collections.Immutable;

namespace Sandboxing.Infrastructure.Working.Factory;

public interface IWorkerFactory
{
    WorkerFactoryOptions Options { get; }

    ICollection<IWorker> BuildWorkers();
}