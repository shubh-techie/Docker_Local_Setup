using FirstApp.API;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFirstAppApi();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
