using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using TheWatcher.API.Monitor.Hubs;
using TheWatcher.API.Monitor.Services;
using TheWatcher.Domain.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddHostedService<MonitorService>();

builder.Host.UseSerilog();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Services
    .AddDbContext<TheWatcherDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TheWatcher")))
    ;

builder.Services.AddCors(options =>
{
    options.AddPolicy("GUI", builder =>
    {
        builder
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("https://localhost:4200")
            ;
    });
});

builder
    .Services
    .AddSignalR(options => options.EnableDetailedErrors = true)
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("GUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<MonitorHub>("/monitorhub");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("TheWatcher.API.Monitor.log")
    .CreateLogger()
    ;

try
{
    Log.Information("Starting web host");
    app.Run();
    return 1;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 0;
}
finally
{
    Log.CloseAndFlush();
}
