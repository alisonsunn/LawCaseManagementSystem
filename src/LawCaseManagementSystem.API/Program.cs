using LawCaseManagementSystem.Infrastructure;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Application.ReferenceData.Services;
using LawCaseManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LawFirmDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("LawFirmDatabase")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IPracticeAreaService, PracticeAreaService>();
builder.Services.AddScoped<IPracticeAreaRepository, PracticeAreaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// testing API and swagger
app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        status = "Healthy"
    });
});

app.Run();

