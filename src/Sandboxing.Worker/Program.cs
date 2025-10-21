using Microsoft.AspNetCore.Mvc;
using Sandboxing.Domain;
using Sandboxing.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<BackgroundWorker>();

var app = builder.Build();

app.MapPost("api/worker/start", ([FromBody]WorkDescription work, BackgroundWorker worker) =>
{
    worker.AddWork(work);
});

app.MapGet("api/worker/freeWorkers", () =>
{
    return 1;
});


await app.RunAsync();