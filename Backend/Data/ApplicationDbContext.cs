using Microsoft.EntityFrameworkCore;
using ZocoAPI.Models;

namespace ZocoAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Estudio> Estudios { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }
    public DbSet<SessionLog> SessionLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar relaciones
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Estudios)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Direcciones)
            .WithOne(d => d.Usuario)
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.SessionLogs)
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configurar índices únicos
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
