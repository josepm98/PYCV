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
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "")]

        public string EmpresaEscuela { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public string Lugar { get; set; }
        [Required]
        public string Posicion { get; set; }
        [Required]
        [Display(Name = "Fecha Inicio")]

        public DateTime FechaInicio { get; set; }
        [Required]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }
        public string Hablado { get; set; }
        public string Escrito { get; set; }
        public string Leido { get; set; }
        public string NivelGeneral { get; set; }
}
}
