using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StreamingService.Api.Middleware;
using StreamingService.Infrastructure;
using StreamingService.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddMediatR(StreamingService.Application.AssemblyReference.Assembly);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

UseMiddlewares();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void UseMiddlewares()
{
    app.UseMiddleware<ModelStateValidationMiddleware>();
}