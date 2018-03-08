using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayYourCV.Models
{
    public class Objetivo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
    }
}
