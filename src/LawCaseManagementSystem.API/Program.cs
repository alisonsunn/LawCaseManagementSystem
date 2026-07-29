using LawCaseManagementSystem.Infrastructure;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Application.ReferenceData.Services;
using LawCaseManagementSystem.Infrastructure.Repositories;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;
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
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<LawFirmDbContext>();

    await dbContext.Database.MigrateAsync();

    if (!await dbContext.PracticeAreas.AnyAsync())
    {
        dbContext.PracticeAreas.AddRange(
            new PracticeArea
            {
                Id = Guid.NewGuid(),
                Name = "Family Law",
                Code = "FAMILY",
                DisplayOrder = 1,
                IsActive = true
            },
            new PracticeArea
            {
                Id = Guid.NewGuid(),
                Name = "Criminal Law",
                Code = "CRIMINAL",
                DisplayOrder = 2,
                IsActive = true
            },
            new PracticeArea
            {
                Id = Guid.NewGuid(),
                Name = "Old Practice Area",
                Code = "OLD",
                DisplayOrder = 99,
                IsActive = false
            }
        );

        await dbContext.SaveChangesAsync();
    }
}

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

app.MapControllers();

app.Run();

