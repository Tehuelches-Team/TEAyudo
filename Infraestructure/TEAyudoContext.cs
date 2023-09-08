using Microsoft.EntityFrameworkCore;

namespace TEAyudo;
public class TEAyudoContext :DbContext
{
    public DbSet<Acompanante> Acompanantes { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<EstadoPropuesta> EstadoPostulaciones { get; set; }
    public DbSet<ObraSocial> ObrasSociales { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Tutor> Tutores { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //      RELACION UNO A MUCHOS
        modelBuilder.Entity<Tutor>()
            .HasMany(t => t.Pacientes)
            .WithOne(p => p.Tutor)
            .HasForeignKey(p => p.TutorId);

        modelBuilder.Entity<EstadoUsuario>()
            .HasOne(e => e.Tutor)
            .WithOne(t => t.EstadoUsuario)
            .HasForeignKey<Tutor>(t => t.EstadoUsuarioId);

        modelBuilder.Entity<Propuesta>()
            .HasOne(p => p.Tutor)
            .WithMany(t => t.Propuestas)
            .HasForeignKey(p => p.TutorId)
            .OnDelete(DeleteBehavior.Restrict); // Configura ON DELETE NO ACTION

        modelBuilder.Entity<Tutor>()
            .HasOne(t => t.Usuario)
            .WithOne()
            .HasForeignKey<Tutor>(t => t.UsuarioId);

        modelBuilder.Entity<Acompanante>()
            .HasOne(a => a.Usuario)
            .WithOne()
            .HasForeignKey<Acompanante>(a => a.UsuarioId);

        //      RELACION UNO A UNO
        //modelBuilder.Entity<ENTIDAD1>()
        //    .HasOne(u => u.ENTIDAD2)
        //    .WithOne(p => p.ENTIDAD1)
        //    .HasForeignKey<ENTIDAD1>(p => p.ENTIDAD1_ID);

        modelBuilder.Entity<EstadoUsuario>()
            .HasOne(e => e.Acompanante)
            .WithOne(t => t.EstadoUsuario)
            .HasForeignKey<Acompanante>(t => t.EstadoUsuarioId);


        modelBuilder.Entity<Acompanante>()
            .HasMany(a => a.Especialidades)
            .WithMany(e => e.Acompanantes)
            .UsingEntity<AcompananteEspecialidad>(
                j => j.HasOne(ae => ae.Especialidad).WithMany().OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(ae => ae.Acompanante).WithMany().OnDelete(DeleteBehavior.Restrict)
            );

        //RELACION UNO A MUCHOS
        //modelBuilder.Entity<ENTIDAD1>()
        //.HasMany(a => a.ENTIDAD2S)
        //.WithOne(l => l.ENTIDAD1)
        //.HasForeignKey(l => l.ENTIDAD1Id);

        //      RELACION UNO A MUCHOS
        //      Un acompañante puede tener mas de una disponibilidad horaria


        //RELACION MUCHOS A MUCHOS
        //modelBuilder.Entity<ENTIDAD1>()
        //    .HasMany(e => e.ENTIDAD2S)
        //    .WithMany(c => c.ENTIDAD2S)
        //    .UsingEntity<ENTIDAD1ENTIDAD2>(
        //j => j.HasOne(ic => ic.ENTIDAD2).WithMany(),
        //j => j.HasOne(ic => ic.ENTIDAD1S).WithMany()

        modelBuilder.Entity<Acompanante>()
            .HasMany(a => a.DisponibilidadesSemanales)
            .WithOne(ds => ds.Acompanante)
            .HasForeignKey(ds => ds.AcompananteId)
            .OnDelete(DeleteBehavior.Restrict);
      
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



        //RELACION UNO A MUCHOS
        //modelBuilder.Entity<ENTIDAD1>()
        //.HasMany(a => a.ENTIDAD2S)
        //.WithOne(l => l.ENTIDAD1)
        //.HasForeignKey(l => l.ENTIDAD1Id);

        //      RELACION UNO A UNO
        //modelBuilder.Entity<ENTIDAD1>()
        //    .HasOne(u => u.ENTIDAD2)
        //    .WithOne(p => p.ENTIDAD1)
        //    .HasForeignKey<ENTIDAD1>(p => p.ENTIDAD1_ID);





    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TEAyudo_JT;Trusted_Connection=True;TrustServerCertificate=True");
    }

}

