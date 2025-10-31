using Sandboxing.Infrastructure.Working.Queues;
using Sandboxing.Working;

namespace Sandboxing.Infrastructure.Working;

public class BackgroundWorker : IWorker
{
    private Task? _executionTask;
    private CancellationTokenSource? _cancellation;

    public Task RunAsync(IWorkerQueue queue, CancellationToken cancellation)
    {
        if (_executionTask != null && _executionTask.Status == TaskStatus.Running)
            throw new InvalidOperationException("Worker is already running");

        _cancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellation);
        _executionTask = Task.Run(() =>  ExecuteAsync(queue, _cancellation.Token), _cancellation.Token);

        return Task.CompletedTask;
    }

    public Task CancelWorkAsync()
    {
        throw new NotImplementedException();//TODO: cancel works
    }

    public async Task StopAsync()
    {
        if (_executionTask == null)
            return;

        try
        {
            _cancellation?.Cancel();
            await _executionTask;
        }
        catch(OperationCanceledException)
        {
        }
    }

    private static async Task ExecuteAsync(IWorkerQueue queue, CancellationToken cancellation)
    {
        while (cancellation.IsCancellationRequested == false)
        {
            var job = await queue.ReadAsync(cancellation);
            await Task.Delay(job.Payload, cancellation);//TODO cancellation for work

            //TODO: Work completion notifier
            Console.WriteLine($"Complete task [{job.Name}] with result [{job.ResultValue}]");
        }
    }
}
