using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayYourCV.Models
{
    public class Cv
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }
        public int IdUsuario { get; set; }
    }
}
