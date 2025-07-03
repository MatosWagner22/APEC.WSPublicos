using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEC.WS.Infrastructura.Modelos
{
    public class RegistroUsoServicio
    {
        public int Id { get; set; }
        public string NombreServicio { get; set; } // Ej: "TasaCambio"
        public DateTime FechaInvocacion { get; set; }
    }
}
