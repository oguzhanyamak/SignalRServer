using BackProcess.Models;
using BackProcess.Subscription;
using BackProcess.Subscription.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SignalR;
using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowCredentials().AllowAnyMethod().SetIsOriginAllowed(origin => true)));
builder.Services.AddSingleton<DatabaseSubscription<Worker>>();
builder.Services.AddSingleton<DatabaseSubscription<Sale>>();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseDatabaseSubscription<DatabaseSubscription<Sale>>("Sales");
app.UseDatabaseSubscription<DatabaseSubscription<Worker>>("Workers");
app.MapControllers();
app.MapHubs();
app.Run();
