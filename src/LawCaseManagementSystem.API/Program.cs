using LawCaseManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LawFirmDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("LawFirmDatabase")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

