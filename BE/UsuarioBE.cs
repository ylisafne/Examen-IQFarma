using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE
    {
        public int Codigo { get; set; }
        public string Usuari { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int CodigoArea { get; set; }
    }
}
