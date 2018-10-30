using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaElectronicaCR_CS.ClasesDatos
{
    public class DetallesFactura
    {
        public int numeroDeLinea { get; set; }
        public string tipoDeArticulo { get; set; }
        public string codigoArticulo { get; set; }
        public double cantidad { get; set; }
        public string unidadDeMedida { get; set; }
        public string detalle { get; set; }
        public double precioUnitario { get; set; }
        public double montoTotal { get; set; }
        public double montoDescuento { get; set; }
        public string NaturalezaDescuento { get; set; }
        public double subtotal { get; set; }
        public double impuesto { get; set; }
        public string codigoImpuesto { get; set; }
        public double impuestoTarifa { get; set; }
        public double impuestoMonto { get; set; }
        public double montoTotalLinea { get; set; }

    }
}
