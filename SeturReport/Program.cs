using Microsoft.EntityFrameworkCore;
using SeturReport.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ReportDbContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString("ReportDbContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
