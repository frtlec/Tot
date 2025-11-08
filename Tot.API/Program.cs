using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tot.Application.Dtos.Commands;
using Tot.Application.Handlers;
using Tot.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// --- Add DbContext ---
builder.Services.AddDbContext<TotPostgreSqlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateQuestionPoolCommand).Assembly);
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();         // JSON endpoint
    app.UseSwaggerUI();       // UI açýlýr (default: /swagger)
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
