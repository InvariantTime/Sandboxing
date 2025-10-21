using Sandboxing.Domain;
using StackExchange.Redis;

namespace Sandboxing.Infrastructure;

public class RedisWorkerQueue : IWorkerQueue
{
    private readonly ConnectionMultiplexer _connection;

    public bool IsConnected => _connection.IsConnected;

    public RedisWorkerQueue()
    {
        _connection = ConnectionMultiplexer.Connect(new ConfigurationOptions()
        {
            AbortOnConnectFail = false,
            EndPoints =
            {
                {"job-queue", 6379}
            }
        });
    }
        
    public void AddToQueue(WorkDescription work)
    {
        
    }

    public bool Cancel(Guid id)
    {
        return true;
    }
}