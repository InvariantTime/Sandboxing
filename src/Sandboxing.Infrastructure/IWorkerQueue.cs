using Sandboxing.Domain;

namespace Sandboxing.Infrastructure;

public interface IWorkerQueue
{
    bool IsConnected { get; }
    
    void AddToQueue(WorkDescription description);

    bool Cancel(Guid id);
}