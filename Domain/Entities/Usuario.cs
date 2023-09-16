﻿namespace Domain.Entities

{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string FotoPerfil { get; set; }
        public string Domicilio { get; set; }
        public DateTime FechanNacimiento { get; set; }
        public List<Tutor> Tutores { get; set; }
        public ICollection<Acompanante> Acompanantes { get; set; }
    }

}
