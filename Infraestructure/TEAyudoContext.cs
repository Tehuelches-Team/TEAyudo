using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infraestructure;

namespace TEAyudo;
public class TEAyudoContext :DbContext
{
    public DbSet<Acompanante> Acompanantes { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<EstadoPropuesta> EstadoPropuestas { get; set; }
    public DbSet<EstadoUsuario> EstadoUsuarios{ get; set; }
    public DbSet<ObraSocial> ObrasSociales { get; set; }
    public DbSet<Propuesta> Propuestas { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<AcompananteEspecialidad> AcompanantesEspecialidades { get; set; }
    public DbSet<AcompananteEspecialidad> AcompanantesObraSocial { get; set; }
    public DbSet<DisponibilidadSemanal> DisponibilidadesSemanales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.ToTable("Tutor");
            entity.HasKey(t => t.TutorId);
            entity.Property(t => t.TutorId);
            entity.HasMany<Paciente>(t => t.Pacientes)
                .WithOne(p => p.Tutor)
                .HasForeignKey(p => p.TutorId);

        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasOne(t => t.Usuario)
            .WithOne()
            .HasForeignKey<Tutor>(t => t.UsuarioId);

        });

        modelBuilder.Entity<EstadoUsuario>(entity =>
        {
            entity.ToTable("EstadoUsuario");
            entity.HasKey(eu => eu.EstadoUsuarioId);
            entity.Property(eu => eu.EstadoUsuarioId);
            entity.HasOne(eu => eu.Tutor)
                .WithOne(t => t.EstadoUsuario)
                .HasForeignKey<EstadoUsuario>(t => t.EstadoUsuarioId);
        });

        modelBuilder.Entity<EstadoUsuario>(entity =>
        {
            entity.HasOne(e => e.Acompanante)
                .WithOne(t => t.EstadoUsuario)
                .HasForeignKey<Acompanante>(t => t.EstadoUsuarioId);

        });

        modelBuilder.Entity<Propuesta>(entity =>
        {
            entity.ToTable("Propuesta");
            entity.HasKey(p => p.PropuestaId);
            entity.Property(p => p.PropuestaId);
            entity.HasOne(p => p.Tutor)
                .WithMany(t => t.Propuestas)
                .HasForeignKey(p => p.TutorId)
                .OnDelete(DeleteBehavior.Restrict); // Configura ON DELETE NO ACTION
        });

        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.ToTable("Acompanante");
            entity.HasKey(a => a.AcompananteId);
            entity.Property(a => a.AcompananteId);
            entity.HasOne(a => a.Usuario)
                .WithOne()
                .HasForeignKey<Acompanante>(a => a.UsuarioId);

        });
        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.HasOne(a => a.Usuario)
            .WithOne()
            .HasForeignKey<Acompanante>(a => a.UsuarioId);

        });
        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.HasMany(a => a.Especialidades)
            .WithMany(e => e.Acompanantes)
            .UsingEntity<AcompananteEspecialidad>(
                j => j.HasOne(ae => ae.Especialidad).WithMany().OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(ae => ae.Acompanante).WithMany().OnDelete(DeleteBehavior.Restrict));
         });

        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.HasMany(a => a.DisponibilidadesSemanales)
            .WithOne(ds => ds.Acompanante)
            .HasForeignKey(ds => ds.AcompananteId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Acompanante>()
            .HasMany(a => a.Especialidades)
            .WithMany(e => e.Acompanantes)
            .UsingEntity<AcompananteEspecialidad>(
                j => j.HasOne(ae => ae.Especialidad).WithMany(),
                j => j.HasOne(ae => ae.Acompanante).WithMany());

        modelBuilder.Entity<Acompanante>()
            .HasMany(a => a.ObrasSociales)
            .WithMany(os => os.Acompanantes)
            .UsingEntity<AcompananteObraSocial>(
                j => j.HasOne(aos => aos.ObraSocial).WithMany(),
                j => j.HasOne(aos => aos.Acompanante).WithMany());

        modelBuilder.Entity<Propuesta>()
            .HasOne(p => p.Acompanante)
            .WithMany(a => a.Propuestas)
            .HasForeignKey(p => p.AcompananteId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TEAyudo;Trusted_Connection=True;TrustServerCertificate=True");
    }

}

