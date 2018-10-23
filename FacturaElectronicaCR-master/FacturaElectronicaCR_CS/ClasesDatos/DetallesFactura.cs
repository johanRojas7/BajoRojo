using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaElectronicaCR_CS.ClasesDatos
{
    public class DetallesFactura
    {
        public string numeroLinea { get; set; }
        public string articuloTipo { get; set; }
        public string articuloCodigo { get; set; }
        public string cantidad { get; set; }
        public string unidadDeMedida { get; set; }
        public string detalle { get; set; }
        public string precioUnitario { get; set; }
        public string montoTotal { get; set; }
        public string montoDescuento { get; set; }
        public string natualezaDescuento { get; set; }
        public string subtotal { get; set; }
        public string codigoImpuesto { get; set; }
        public string impuestoTarifa { get; set; }
        public string impuestoMonto{ get; set; }
        public string montoTotalLinea { get; set; }
        
    }
}
