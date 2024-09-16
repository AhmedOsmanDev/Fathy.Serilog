using Fathy.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

var openApiInfo = new OpenApiInfo
{
    Title = "Fathy.Serilog",
    Version = "v1"
};

builder.Services.AddSwaggerService(openApiInfo);

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/{openApiInfo.Version}/swagger.json", openApiInfo.Title);
});

app.MapGet("/", () => "Hello, World!");

app.Run();
