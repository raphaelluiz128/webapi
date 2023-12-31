using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Refit;
using webapi.Data;
using webapi.Filters;
using webapi.Integration;
using webapi.Integration.Interfaces;
using webapi.Integration.Refit;
using webapi.Repositories;
using webapi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
    c.SchemaFilter<SwaggerSkipPropertyFilter>();
});

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<TarefasDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped<IUsuarioRep, UsuarioRep>();
builder.Services.AddScoped<ITarefaRep, TarefaRep>();
builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
