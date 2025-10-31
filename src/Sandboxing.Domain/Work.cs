namespace Sandboxing.Domain;

public class Work
{
    public string Name { get; }
    
    public int Payload { get; } //payload

    public string ResultValue { get; } = string.Empty;

    public Work(string name, int payload)
    {
        Name = name;
        Payload = payload;
    }

    public Work(string name, int payload, string resultValue)
    {
        Name = name;
        Payload = payload;
        ResultValue = resultValue;
    }
}