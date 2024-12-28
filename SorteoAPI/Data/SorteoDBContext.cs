namespace SorteoAPI.Models;
using Microsoft.EntityFrameworkCore;


public class SorteoDBContext: DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Sorteo> Sorteos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<NumAsignado> NumAsignados { get; set; }

    public SorteoDBContext(DbContextOptions<SorteoDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
        modelBuilder.Entity<Sorteo>().HasKey(s => s.IdSorteo);
        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
        modelBuilder.Entity<NumAsignado>().HasKey(n => n.Id);
        modelBuilder.Entity<NumAsignado>().ToTable("NumerosAsignados");

        // Relación entre Cliente y Sorteo
        modelBuilder.Entity<Sorteo>()
            .HasOne(s => s.Cliente)
            .WithMany(c => c.Sorteos)
            .HasForeignKey(s => s.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación entre Cliente y Usuario
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Cliente)
            .WithMany(c => c.Usuarios)
            .HasForeignKey(u => u.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación entre Cliente y NumAsignado
        modelBuilder.Entity<NumAsignado>()
            .HasOne(n => n.Cliente)
            .WithMany(c => c.NumAsignados)
            .HasForeignKey(n => n.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación entre NumAsignado y Usuario
        modelBuilder.Entity<NumAsignado>()
            .HasOne(n => n.Usuario)
            .WithMany(u => u.NumAsignados)
            .HasForeignKey(n => n.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación entre NumAsignado y Sorteo
        modelBuilder.Entity<NumAsignado>()
            .HasOne(n => n.Sorteo)
            .WithMany(s => s.NumAsignados)
            .HasForeignKey(n => n.IdSorteo)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
