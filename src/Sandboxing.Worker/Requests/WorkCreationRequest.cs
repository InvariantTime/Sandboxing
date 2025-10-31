namespace Sandboxing.Worker.Requests;

public record class WorkCreationRequest(string Name, int Payload, string Result);
