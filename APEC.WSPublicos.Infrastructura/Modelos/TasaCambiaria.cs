using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEC.WS.Infrastructura.Modelos
{
    public class TasaCambiaria
    {
        public int Id { get; set; }
        public string CodigoMoneda { get; set; } // "PES", "DOL", "EUR"
        public decimal Monto { get; set; } // 999.99
    }
}
