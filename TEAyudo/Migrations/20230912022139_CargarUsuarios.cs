using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CargarUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //   table: "Usuario",
            //   columns: new[] { "Nombre", "Apellido", "CorreoElectronico", "Contrasena", "FotoPerfil", "Domicilio", "FechanNacimiento" },
            //   values: new object[] {  "Ariel",
            //                            "Ortiz",
            //                            "aortiz@yopmail.com",
            //                            "1q2w3e4r" ,
            //                            "/user/img/arielortiz.jpg" ,
            //                            "Montevideo 600" ,
            //                            "20/04/1980"});

            //migrationBuilder.InsertData(
            //   table: "Usuario",
            //   columns: new[] { "Nombre", "Apellido", "CorreoElectronico", "Contrasena", "FotoPerfil", "Domicilio", "FechanNacimiento" },
            //   values: new object[] {  "Pablo",
            //                            "Morel",
            //                            "pmorel@yopmail.com",
            //                            "1q2w3e4r" ,
            //                            "/user/img/pablomorel.jpg" ,
            //                            "Reconquista 2500" ,
            //                            "20/05/1985"});
            //migrationBuilder.InsertData(
            //   table: "Usuario",
            //   columns: new[] { "Nombre", "Apellido", "CorreoElectronico", "Contrasena", "FotoPerfil", "Domicilio", "FechanNacimiento" },
            //   values: new object[] {  "Marcelo",
            //                            "Zona",
            //                            "mzona@yopmail.com",
            //                            "1q2w3e4r" ,
            //                            "/user/img/marcelozona.jpg" ,
            //                            "Paseo Colon 2500" ,
            //                            "20/06/1990"});
            //migrationBuilder.InsertData(
            //   table: "Acompanantes",
            //   columns: new[] { "ZonaLaboral", "EstadoUsuarioId", "ObraSocialId", "Contacto", "Documentacion", "EspecialidadId", "Experiencia", "DisponibilidadSemanalId" },
            //   values: new object[] {  "Florencio Varela",
            //                            "1",
            //                            "1",
            //                            "1550112233" ,
            //                            "/user/doc/cv.docx" ,
            //                            "1" ,
            //                            "string",
            //                            "1"});
            //migrationBuilder.InsertData(
            //   table: "Acompanantes",
            //   columns: new[] { "ZonaLaboral", "EstadoUsuarioId", "ObraSocialId", "Contacto", "Documentacion", "EspecialidadId", "Experiencia", "DisponibilidadSemanalId" },
            //   values: new object[] {  "Florencio Varela",
            //                            "2",
            //                            "1",
            //                            "1550223344" ,
            //                            "/user/doc/cv.docx" ,
            //                            "1" ,
            //                            "string",
            //                            "1"});
            //migrationBuilder.InsertData(
            //   table: "Tutores",
            //   columns: new[] { "CertUniDisc", "EstadoUsuarioId", "UsuarioId" },
            //   values: new object[] {  "/user/doc/cud.pdf",
            //                            "1",
            ////                            "3"});

            //migrationBuilder.InsertData(
            //    table: "ObraSocial", // Nombre de la tabla
            //    columns: new[] { "Nombre", "Descripcion" }, // Columnas en las que deseas insertar datos
            //    values: new object[,]
            //    {
            //            { "OSDE", "Obra Social De Empresarios" },
            //            { "IOMA", "I O M A" }
            //        // Agrega más filas según sea necesario
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
  
        }
    }
}
