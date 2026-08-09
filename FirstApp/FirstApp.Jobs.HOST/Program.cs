using FirstApp.Jobs;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScheduledJobs(builder.Configuration);

var host = builder.Build();
await host.RunAsync();
