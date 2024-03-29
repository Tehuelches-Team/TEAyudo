﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEAyudo;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(TEAyudoContext))]
    [Migration("20230917162200_CreateDbInit")]
    partial class CreateDbInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Acompanante", b =>
                {
                    b.Property<int>("AcompananteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcompananteId"));

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisponibilidadSemanalId")
                        .HasColumnType("int");

                    b.Property<string>("Documentacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<string>("Experiencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObraSocialId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("ZonaLaboral")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcompananteId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Acompanante", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AcompananteEspecialidad", b =>
                {
                    b.Property<int>("AcompananteId")
                        .HasColumnType("int");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.HasKey("AcompananteId", "EspecialidadId");

                    b.HasIndex("EspecialidadId");

                    b.ToTable("AcompananteEspecialidad");
                });

            modelBuilder.Entity("Domain.Entities.AcompananteObraSocial", b =>
                {
                    b.Property<int>("AcompananteId")
                        .HasColumnType("int");

                    b.Property<int>("ObrasocialId")
                        .HasColumnType("int");

                    b.HasKey("AcompananteId", "ObrasocialId");

                    b.HasIndex("ObrasocialId");

                    b.ToTable("AcompananteObraSocial");
                });

            modelBuilder.Entity("Domain.Entities.DisponibilidadSemanal", b =>
                {
                    b.Property<int>("DisponibilidadSemanalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisponibilidadSemanalId"));

                    b.Property<int>("AcompananteId")
                        .HasColumnType("int");

                    b.Property<int>("DiaSemana")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("DisponibilidadSemanalId");

                    b.HasIndex("AcompananteId");

                    b.ToTable("DisponibilidadesSemanales");
                });

            modelBuilder.Entity("Domain.Entities.Especialidad", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EspecialidadId");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Domain.Entities.EstadoPropuesta", b =>
                {
                    b.Property<int>("EstadoPropuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoPropuestaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoPropuestaId");

                    b.ToTable("EstadoPropuestas");
                });

            modelBuilder.Entity("Domain.Entities.EstadoUsuario", b =>
                {
                    b.Property<int>("EstadoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoUsuarioId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("EstadoUsuarioId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("EstadoUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.ObraSocial", b =>
                {
                    b.Property<int>("ObraSocialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObraSocialId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObraSocialId");

                    b.ToTable("ObrasSociales");
                });

            modelBuilder.Entity("Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosticoTEA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("PacienteId");

                    b.HasIndex("TutorId");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Propuesta", b =>
                {
                    b.Property<int>("PropuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropuestaId"));

                    b.Property<int>("AcompananteId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoPropuestaId")
                        .HasColumnType("int");

                    b.Property<string>("InfoAdicional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("PropuestaId");

                    b.HasIndex("AcompananteId");

                    b.HasIndex("EstadoPropuestaId");

                    b.HasIndex("TutorId");

                    b.ToTable("Propuesta", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tutor", b =>
                {
                    b.Property<int>("TutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorId"));

                    b.Property<string>("CertUniDisc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("TutorId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Tutor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoUsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entities.Acompanante", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Acompanante", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.AcompananteEspecialidad", b =>
                {
                    b.HasOne("Domain.Entities.Acompanante", "Acompanante")
                        .WithMany()
                        .HasForeignKey("AcompananteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Especialidad", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Acompanante");

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Domain.Entities.AcompananteObraSocial", b =>
                {
                    b.HasOne("Domain.Entities.Acompanante", "Acompanante")
                        .WithMany()
                        .HasForeignKey("AcompananteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ObraSocial", "ObraSocial")
                        .WithMany()
                        .HasForeignKey("ObrasocialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acompanante");

                    b.Navigation("ObraSocial");
                });

            modelBuilder.Entity("Domain.Entities.DisponibilidadSemanal", b =>
                {
                    b.HasOne("Domain.Entities.Acompanante", "Acompanante")
                        .WithMany("DisponibilidadesSemanales")
                        .HasForeignKey("AcompananteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Acompanante");
                });

            modelBuilder.Entity("Domain.Entities.EstadoUsuario", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithOne("EstadoUsuario")
                        .HasForeignKey("Domain.Entities.EstadoUsuario", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Paciente", b =>
                {
                    b.HasOne("Domain.Entities.Tutor", "Tutor")
                        .WithMany("Pacientes")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Domain.Entities.Propuesta", b =>
                {
                    b.HasOne("Domain.Entities.Acompanante", "Acompanante")
                        .WithMany("Propuestas")
                        .HasForeignKey("AcompananteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.EstadoPropuesta", "EstadoPropuesta")
                        .WithMany("Propuestas")
                        .HasForeignKey("EstadoPropuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Tutor", "Tutor")
                        .WithMany("Propuestas")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Acompanante");

                    b.Navigation("EstadoPropuesta");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Domain.Entities.Tutor", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Tutor", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Acompanante", b =>
                {
                    b.Navigation("DisponibilidadesSemanales");

                    b.Navigation("Propuestas");
                });

            modelBuilder.Entity("Domain.Entities.EstadoPropuesta", b =>
                {
                    b.Navigation("Propuestas");
                });

            modelBuilder.Entity("Domain.Entities.Tutor", b =>
                {
                    b.Navigation("Pacientes");

                    b.Navigation("Propuestas");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("EstadoUsuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
