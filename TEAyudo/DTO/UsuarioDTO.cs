﻿namespace TEAyudo.DTO
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string FotoPerfil { get; set; }
        public string Domicilio { get; set; }
        public DateTime FechaNacimiento { get; set; }
        // Otras propiedades del usuario, si las tienes
    }

}