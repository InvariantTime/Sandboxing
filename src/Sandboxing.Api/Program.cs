using Microsoft.AspNetCore.Mvc;
using Sandboxing.Api.Requests;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();


var app = builder.Build();


app.Run();