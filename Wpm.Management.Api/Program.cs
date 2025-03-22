using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Wpm.Management.Api.Application;
using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wpm.Management.Api", Version = "v1" });
});
builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddScoped<ManagementApplicationService>(); 
builder.Services.AddDbContext<ManagementDbContext>(options =>
{
    options.UseSqlite("Data Source=WpmManagement.db");
});

var app = builder.Build();
app.EnsureDbIsCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
