namespace Sandboxing.Domain;

public class WorkDescription
{
    public Guid Id { get; }
    
    public string Name { get; }
    
    public int Delay { get; }

    public WorkDescription(string name, int delay)
    {
        Id = Guid.NewGuid();
        Name = name;
        Delay = delay;
    }
}