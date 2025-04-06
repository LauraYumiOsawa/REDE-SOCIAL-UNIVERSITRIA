using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Universidade.Infra;
using Universidade.Infra.Interfaces;
using System.Reflection;
using Universidade.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers()
    .AddApplicationPart(Assembly.Load("APIUni"));

var app = builder.Build();

app.UseRouting();
app.MapControllers(); 

app.Run();