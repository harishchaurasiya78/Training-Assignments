using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ✅ Middleware: Log requests & responses
app.Use(async (context, next) =>
{
    Console.WriteLine($"Incoming request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Outgoing response: {context.Response.StatusCode}");
});

// ✅ Middleware: Error handling
app.UseExceptionHandler("/error.html");

// ✅ Middleware: Enforce HTTPS
app.UseHttpsRedirection();

// ✅ Serve static files from wwwroot
app.UseStaticFiles();

// ✅ Default route
app.MapGet("/", () => "Hello, Middleware World!");

app.Run();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
    await next();
});

