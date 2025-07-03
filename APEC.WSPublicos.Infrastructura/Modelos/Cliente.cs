using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEC.WS.Infrastructura.Modelos
{
    public class Cliente
    {
        public string CedulaRnc { get; set; } // PK
        public char IndicadorSalud { get; set; } // 'S'/'N'
        public string Comentario { get; set; }
        public decimal MontoTotalAdeudado { get; set; }

        public List<HistorialCrediticio> Historiales { get; set; }
    }
}
