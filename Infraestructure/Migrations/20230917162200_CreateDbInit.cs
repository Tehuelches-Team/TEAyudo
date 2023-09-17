
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspecialidadId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPropuestas",
                columns: table => new
                {
                    EstadoPropuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPropuestas", x => x.EstadoPropuestaId);
                });

            migrationBuilder.CreateTable(
                name: "ObrasSociales",
                columns: table => new
                {
                    ObraSocialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.ObraSocialId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoUsuarios",
                columns: table => new
                {
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoUsuarios", x => x.EstadoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_EstadoUsuarios_EstadoUsuarioId",
                        column: x => x.EstadoUsuarioId,
                        principalTable: "EstadoUsuarios",
                        principalColumn: "EstadoUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "Acompanante",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ZonaLaboral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObraSocialId = table.Column<int>(type: "int", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisponibilidadSemanalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompanante", x => x.AcompananteId);
                    table.ForeignKey(
                        name: "FK_Acompanante_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });



            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CertUniDisc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.TutorId);
                    table.ForeignKey(
                        name: "FK_Tutor_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcompananteEspecialidad",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompananteEspecialidad", x => new { x.AcompananteId, x.EspecialidadId });
                    table.ForeignKey(
                        name: "FK_AcompananteEspecialidad_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcompananteEspecialidad_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcompananteObraSocial",
                columns: table => new
                {
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    ObrasocialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompananteObraSocial", x => new { x.AcompananteId, x.ObrasocialId });
                    table.ForeignKey(
                        name: "FK_AcompananteObraSocial_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompananteObraSocial_ObrasSociales_ObrasocialId",
                        column: x => x.ObrasocialId,
                        principalTable: "ObrasSociales",
                        principalColumn: "ObraSocialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisponibilidadesSemanales",
                columns: table => new
                {
                    DisponibilidadSemanalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadesSemanales", x => x.DisponibilidadSemanalId);
                    table.ForeignKey(
                        name: "FK_DisponibilidadesSemanales_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiagnosticoTEA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propuesta",
                columns: table => new
                {
                    PropuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    AcompananteId = table.Column<int>(type: "int", nullable: false),
                    InfoAdicional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    EstadoPropuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propuesta", x => x.PropuestaId);
                    table.ForeignKey(
                        name: "FK_Propuesta_Acompanante_AcompananteId",
                        column: x => x.AcompananteId,
                        principalTable: "Acompanante",
                        principalColumn: "AcompananteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propuesta_EstadoPropuestas_EstadoPropuestaId",
                        column: x => x.EstadoPropuestaId,
                        principalTable: "EstadoPropuestas",
                        principalColumn: "EstadoPropuestaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propuesta_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acompanante_UsuarioId",
                table: "Acompanante",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcompananteEspecialidad_EspecialidadId",
                table: "AcompananteEspecialidad",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_AcompananteObraSocial_ObrasocialId",
                table: "AcompananteObraSocial",
                column: "ObrasocialId");

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadesSemanales_AcompananteId",
                table: "DisponibilidadesSemanales",
                column: "AcompananteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoUsuarios_EstadoUsuarioId",
                table: "EstadoUsuarios",
                column: "EstadoUsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_TutorId",
                table: "Paciente",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuesta_AcompananteId",
                table: "Propuesta",
                column: "AcompananteId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuesta_EstadoPropuestaId",
                table: "Propuesta",
                column: "EstadoPropuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuesta_TutorId",
                table: "Propuesta",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutor_UsuarioId",
                table: "Tutor",
                column: "UsuarioId",
                unique: true);

            //DATA

            migrationBuilder.InsertData(
                table: "ObrasSociales", // Nombre de la tabla
                columns: new[] { "Nombre", "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[,]
                {
                                    { "OSDE", "Obra Social De Empresarios" },
                                    { "IOMA", "I O M A" }
                });
            migrationBuilder.InsertData(
                table: "EstadoUsuarios", // Nombre de la tabla
                columns: new[] { "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[] { "Pendinte de validar" });

            migrationBuilder.InsertData(
                table: "EstadoUsuarios", // Nombre de la tabla
                columns: new[] { "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[] { "Validado" });

            migrationBuilder.InsertData(
                table: "EstadoUsuarios", // Nombre de la tabla
                columns: new[] { "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[] { "Bloqueado" });
            migrationBuilder.InsertData(
               table: "Usuarios",
               columns: new[] { "Nombre", "Apellido", "CorreoElectronico", "Contrasena", "FotoPerfil", "Domicilio", "FechaNacimiento", "EstadoUsuarioId" },
               values: new object[] {  "Ariel",
                                        "Ortiz",
                                        "aortiz@yopmail.com",
                                        "1q2w3e4r" ,
                                        "/user/img/arielortiz.jpg" ,
                                        "Montevideo 600" ,
                                        "1980/10/01",
                                        "2"});

            migrationBuilder.InsertData(
               table: "Usuarios",
               columns: new[] { "Nombre", "Apellido", "CorreoElectronico", "Contrasena", "FotoPerfil", "Domicilio", "FechaNacimiento", "EstadoUsuarioId" },
               values: new object[] {  "Pablo",
                                        "Morel",
                                        "pmorel@yopmail.com",
                                        "1q2w3e4r" ,
                                        "/user/img/pablomorel.jpg" ,
                                        "Reconquista 2500" ,
                                        "1980/10/01",
                                        "2"});
            migrationBuilder.InsertData(
               table: "Usuarios",
               columns: new[] { "Nombre", "Apellido", "CorreoElectronico", "Contrasena", "FotoPerfil", "Domicilio", "FechaNacimiento", "EstadoUsuarioId" },
               values: new object[] {  "Marcelo",
                                        "Zona",
                                        "mzona@yopmail.com",
                                        "1q2w3e4r" ,
                                        "/user/img/marcelozona.jpg" ,
                                        "Paseo Colon 2500" ,
                                        "1980/10/01",
                                        "2"});


            migrationBuilder.InsertData(
                table: "Especialidades", // Nombre de la tabla
                columns: new[] { "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[] { "Acompañante Terapeutico" });

            migrationBuilder.InsertData(
                table: "Especialidades", // Nombre de la tabla
                columns: new[] { "Descripcion" }, // Columnas en las que deseas insertar datos
                values: new object[] { "Acompañante Escolar" });

            migrationBuilder.InsertData(
               table: "Tutor",
               columns: new[] { "UsuarioId", "CertUniDisc" },
               values: new object[] {  "1",
                                        "/user/doc/cud_user1.docx"});
            migrationBuilder.InsertData(
               table: "Tutor",
               columns: new[] { "UsuarioId", "CertUniDisc" },
               values: new object[] {  "2",
                                        "/user/doc/cud_user2.docx"});

            migrationBuilder.InsertData(
               table: "Tutor",
               columns: new[] { "UsuarioId", "CertUniDisc" },
               values: new object[] {  "3",
                                        "/user/doc/cud_user3.docx"});

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Nombre", "Apellido", "FechaNacimiento", "DiagnosticoTEA", "Sexo", "TutorId" },
                values: new object[] {  "Andrés",
                                        "Zona",
                                        "2013/10/02",
                                        "/user/pac/img/andreszona.jpg" ,
                                        "M" ,
                                        "1"});
            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Nombre", "Apellido", "FechaNacimiento", "DiagnosticoTEA", "Sexo", "TutorId" },
                values: new object[] {  "Mariano",
                                        "Zona",
                                        "2010/12/22",
                                        "/user/pac/img/marianozona.jpg" ,
                                        "M" ,
                                        "1"});

            //migrationBuilder.InsertData(
            //   table: "Acompanantes",
            //   columns: new[] { "ZonaLaboral", "EstadoUsuarioId", "ObraSocialId", "Contacto", "Documentacion", "EspecialidadId", "Experiencia", "UsuarioId", "DisponibilidadSemanalId" },
            //   values: new object[] {  "Florencio Varela",
            //                            "1",
            //                            "1",
            //                            "1550112233" ,
            //                            "/user/doc/cv.docx" ,
            //                            "1" ,
            //                            "string",
            //                            "1",
            //                            "1" });
            //migrationBuilder.InsertData(
            //   table: "Acompanantes",
            //   columns: new[] { "ZonaLaboral", "EstadoUsuarioId", "ObraSocialId", "Contacto", "Documentacion", "EspecialidadId", "Experiencia", "UsuarioId", "DisponibilidadSemanalId" },
            //   values: new object[] {  "Florencio Varela",
            //                            "2",
            //                            "1",
            //                            "1550223344" ,
            //                            "/user/doc/cv.docx" ,
            //                            "1" ,
            //                            "string",
            //                            "2",
            //                            "1" });




        }




        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompananteEspecialidad");

            migrationBuilder.DropTable(
                name: "AcompananteObraSocial");

            migrationBuilder.DropTable(
                name: "DisponibilidadesSemanales");

            migrationBuilder.DropTable(
                name: "EstadoUsuarios");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Propuesta");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "ObrasSociales");

            migrationBuilder.DropTable(
                name: "Acompanante");

            migrationBuilder.DropTable(
                name: "EstadoPropuestas");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
