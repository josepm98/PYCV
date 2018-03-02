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
        public string EmpresaEscuela { get; set; }
        [Required]
        public string Lugar { get; set; }
        [Required]
        public string Posicion { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        public string Hablado { get; set; }
        public string Escrito { get; set; }
        public string Leido { get; set; }
        public string NivelGeneral { get; set; }
}
}
