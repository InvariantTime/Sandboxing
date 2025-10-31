using Microsoft.AspNetCore.Mvc;
using Sandboxing.Domain;
using Sandboxing.Infrastructure.Working;
using Sandboxing.Infrastructure.Working.Factory;
using Sandboxing.Infrastructure.Working.Queues;
using Sandboxing.Worker.Requests;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<WorkerStartupService>();
builder.Services.AddSingleton<IWorkerFactory, DefaultWorkerFactory>();
builder.Services.AddSingleton<IWorkerQueue, DefaultWorkerQueue>();
builder.Services.Configure<WorkerFactoryOptions>(builder.Configuration.GetSection("WorkerOptions"));

var app = builder.Build();

app.MapPost("/worker/addWork", async (IWorkerQueue queue, [FromBody]WorkCreationRequest request, CancellationToken cancellation) =>
{
    var work = new Work(request.Name, request.Payload, request.Result);
    await queue.WriteAsync(work, cancellation);
});

app.MapGet("/worker/maxWorkers", (IWorkerFactory factory) =>
{
    return factory.Options.WorkersCount;
});


await app.RunAsync();