using Microsoft.EntityFrameworkCore;
using Refit;
using SistemaDeTarefas.API.Data;
using SistemaDeTarefas.API.Integracao;
using SistemaDeTarefas.API.Integracao.Interfaces;
using SistemaDeTarefas.API.Integracao.Refit;
using SistemaDeTarefas.API.Repositorios;
using SistemaDeTarefas.API.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<SistemaTarefasDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
    );

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br");
});

builder.Services.AddRouting(options => options.LowercaseUrls = false);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
