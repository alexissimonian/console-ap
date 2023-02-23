using App.Domain.Interfaces;
using App.Domain.Services;
using App.Persistence.EFPersonneRepository.Models;
using App.Persistence.EFPersonneRepository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<PersonneContext>(opt =>
    opt.UseInMemoryDatabase("Personnes"));
builder.Services.AddScoped<IPersonneService, PersonneService>();
builder.Services.AddScoped<IPersonneRepository, PersonneRepository>();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.Run();