using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEC.WS.Infrastructura.Modelos
{
    public class IndiceInflacion
    {
        public int Id { get; set; }
        public string Periodo { get; set; } // Formato "yyyymm"
        public decimal Valor { get; set; } // 999.99%
    }
}
