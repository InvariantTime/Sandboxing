using Microsoft.AspNetCore.Mvc;
using Sandboxing.Api.Requests;
using Sandboxing.Domain;
using Sandboxing.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddSingleton<IWorkerQueue, RedisWorkerQueue>();

var app = builder.Build();

app.MapPost("api/sandbox/create", ([FromBody]CreateWorkRequest request, IWorkerQueue queue) =>
{
    var work = request.Create();
    queue.AddToQueue(work);
});

app.MapPost("api/sandbox/cancel{id:guid}", ([FromQuery]Guid id) =>
{
    
});

app.MapGet("api/sandbox/info", () =>
{
    
});


app.Run();