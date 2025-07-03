using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEC.WS.Infrastructura.Modelos
{
    public class HistorialCrediticio
    {
        public int Id { get; set; }
        public string RncEmpresa { get; set; }
        public string ConceptoDeuda { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoAdeudado { get; set; }

        public string ClienteCedulaRnc { get; set; } // FK
        public Cliente Cliente { get; set; }
    }
}
