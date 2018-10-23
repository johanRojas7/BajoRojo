using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaElectronicaCR_CS.ClasesDatos
{
    public class DetalleFactura
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
        public double impuestoMonto{ get; set; }
        public double montoTotalLinea { get; set; }
        
        public DetalleFactura(int PnumeroDeLinea, string PtipoDeArticulo, string PcodigoArticulo, double Pcantidad,
            string PunidadDeMedida, string Pdetalle, double PprecioUnitario, double PmontoTotal, double PmontoDescuento,
             string PNaturalezaDescuento, double Psubtotal, double Pimpuesto, string PcodigoImpuesto, double PimpuestoTarifa,
            double PimpuestoMonto, double PmontoTotalLinea)
        {

            numeroDeLinea = PnumeroDeLinea;
            tipoDeArticulo = PtipoDeArticulo;
            codigoArticulo = PcodigoArticulo;
            cantidad = Pcantidad;
            unidadDeMedida = PunidadDeMedida;
            detalle = Pdetalle;
            precioUnitario = PprecioUnitario;
            montoTotal = PmontoTotal;
            montoDescuento = PmontoDescuento;
            NaturalezaDescuento = PNaturalezaDescuento;
            subtotal = Psubtotal;
            impuesto = Pimpuesto;
             codigoImpuesto = PcodigoImpuesto;
            impuestoTarifa = PimpuestoTarifa;
            impuestoMonto = PimpuestoMonto;
            montoTotalLinea = PmontoTotalLinea;


        }





    }
}
