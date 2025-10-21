using Microsoft.Extensions.Hosting;
using Sandboxing.Domain;

namespace Sandboxing.Infrastructure;

public class BackgroundWorker : BackgroundService
{
    private readonly Queue<WorkDescription> _queue = new();
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested == false)
        {
            while (_queue.Any() == true)
            {
                var work = _queue.Dequeue();
                await Task.Delay(work.Delay, stoppingToken);
            }
        }
    }

    public void AddWork(WorkDescription description)
    {
        _queue.Enqueue(description);
    }
}