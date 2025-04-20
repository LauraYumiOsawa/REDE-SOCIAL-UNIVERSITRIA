using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Universidade.Infra;
using Universidade.Infra.Interfaces;
using System.Reflection;
using Universidade.Infra.Repositories;
using Universidade.Domain;
using Universidade.Domain.Services;
using Universidade.Application;
using Universidade.Application.ApplicationServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();


builder.Services.AddScoped<EventoDomainService>();
builder.Services.AddScoped<EventoAppService>();

builder.Services.AddControllers()
    .AddApplicationPart(Assembly.Load("APIUni"));

var app = builder.Build();

app.UseRouting();
app.MapControllers(); 

app.Run();