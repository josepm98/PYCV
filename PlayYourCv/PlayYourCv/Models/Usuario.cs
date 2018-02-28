using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PlayYourCV.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} ha de tener entre {2} y {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]

        public string Contrasenya { get; set; }
        [DataType(DataType.Password)]
        [Compare("Contrasenya")]
        [Display(Name = "Confirmación de password")]
        public string verificarcontra { get; set; }

        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool MostrarMascota { get; set; }
        public string FotoURL { get; set; }
    }
}
