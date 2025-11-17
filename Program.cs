using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Serve `wwwroot/index.html` and other static assets
app.UseDefaultFiles(); // looks for index.html by default
app.UseStaticFiles();

app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();