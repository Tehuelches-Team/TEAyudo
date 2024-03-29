﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class DisponibilidadSemanal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DisponibilidadSemanalId { get; set; }
        public int AcompananteId { get; set; }
        public int DiaSemana { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }

        public Acompanante Acompanante { get; set; }
    }

}
