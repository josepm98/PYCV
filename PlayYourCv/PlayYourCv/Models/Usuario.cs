using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayYourCV.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Contrasenya { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool MostrarMascota { get; set; }
        public string FotoURL { get; set; }
    }
}
