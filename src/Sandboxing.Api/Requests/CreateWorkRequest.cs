using Sandboxing.Domain;

namespace Sandboxing.Api.Requests;

public record CreateWorkRequest
{
    public int Delay { get; init; }

    public string Name { get; init; } = string.Empty;

    public WorkDescription Create()
    {
        return new WorkDescription(Name, Delay);
    }
}