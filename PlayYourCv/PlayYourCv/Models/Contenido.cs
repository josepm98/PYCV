using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PlayYourCV.Models
{
    public class Contenido
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "{0} ha de tener entre {2} y {1} caracteres.", MinimumLength = 6)]
        public string Descripcion { get; set; }
        [Required]
        public string EmpresaEscuela { get; set; }

        [Required]
        [Display(Name = "Lugar")]
        public string Lugar { get; set; }
        [Required]
        public string Posicion { get; set; }

        [Required]
        [Display(Name = "Fecha inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha fin")]
        public DateTime FechaFin { get; set; }

        public string Hablado { get; set; }
        public string Escrito { get; set; }
        public string Leido { get; set; }
        public string NivelGeneral { get; set; }
}
}
