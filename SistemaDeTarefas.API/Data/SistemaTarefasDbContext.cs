using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.API.Data.Map;
using SistemaDeTarefas.API.Models;

namespace SistemaDeTarefas.API.Data;

public class SistemaTarefasDbContext : DbContext
{
    public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options) : base(options)
    {
    }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<TarefaModel> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TarefaMap());
        base.OnModelCreating(modelBuilder);
    }
}
