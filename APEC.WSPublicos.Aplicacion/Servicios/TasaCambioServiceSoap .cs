using APEC.WS.Aplicacion.Interfaces;
using APEC.WS.Infrastructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace APEC.WS.Aplicacion.Servicios
{
    public class TasaCambioServiceSoap : ITasaCambioServiceSoap
    {
        private readonly AppDbContext _context;

        public TasaCambioServiceSoap(AppDbContext context)
        {
            _context = context;
        }

        public decimal ObtenerTasa(string codigoMoneda)
        {
            if (string.IsNullOrWhiteSpace(codigoMoneda))
            {
                // Manejo de error compatible con SOAP
                throw new FaultException("El código de moneda no puede estar vacío");
            }

            codigoMoneda = codigoMoneda.Trim().ToUpper();

            var tasa = _context.TasasCambiarias
                .AsNoTracking()
                .FirstOrDefault(t => t.CodigoMoneda == codigoMoneda);

            if (tasa == null)
            {
                throw new FaultException($"No se encontró tasa para la moneda {codigoMoneda}");
            }

            return tasa.Monto;
        }
    }
}
