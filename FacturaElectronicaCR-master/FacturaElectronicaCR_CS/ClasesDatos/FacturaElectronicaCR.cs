using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;

namespace FacturaElectronicaCR_CS.ClasesDatos
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.VisualBasic;

    public class FacturaElectronicaCR
    {
        private XmlDocument _xml_factura;
        private System.IO.MemoryStream mXML;

        private string _numeroConsecutivo = "";
        private string _numeroClave = "";
        private Emisor _emisor;
        private Receptor _receptor;
        private string _condicionVenta = "";
        private string _plazoCredito = "";
        private string _medioPago = "";
        private List<DetallesFactura> _dsDetalle;
        private string _codigoMoneda = "";
        private decimal _tipoCambio;

        public FacturaElectronicaCR(string numeroConsecutivo, string numeroClave, Emisor emisor, Receptor receptor,
                                    string condicionVenta, string plazoCredito, string medioPago,
                                    List<DetallesFactura> dsDetalle, string codigoMoneda, decimal tipoCambio)
        {
            _numeroConsecutivo = numeroConsecutivo;
            _numeroClave = numeroClave;
            _emisor = emisor;
            _receptor = receptor;
            _condicionVenta = condicionVenta;
            _plazoCredito = plazoCredito;
            _medioPago = medioPago;
            _dsDetalle = dsDetalle;
            _codigoMoneda = codigoMoneda;
            _tipoCambio = tipoCambio;
        }

        // 'Este documento esta para la factura electronica, 
        // 'Para la nota de credito es un documento similar pero cambia algunos nodos.
        // 'Lo vemos luego.

        // 'Segun la normativa, estos son los datos basicos que seguramente van a ocupar,
        // 'Es posible que algunos no los ocupen y requieran otros, es normal y los veremos conforme vayamos 
        // 'desarrollando la factura. Cuando se envien los datos a Hacienda, ahi seguramente nos daremos cuenta en las pruebas

        public XmlDocument CreaXMLFacturaElectronica()
        {
            try
            {
                mXML = new System.IO.MemoryStream();

                System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(mXML, System.Text.Encoding.UTF8);

                XmlDocument docXML = new XmlDocument();

                GeneraXML(writer);

                mXML.Seek(0, System.IO.SeekOrigin.Begin);

                docXML.Load(mXML);

                writer.Close();

                // Retorna el documento xml y ahi se puede salvar docXML.Save
                return docXML;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraXML(System.Xml.XmlTextWriter writer) // As System.Xml.XmlTextWriter
        {
            try
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("FacturaElectronica");

                writer.WriteAttributeString("xmlns", "https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica");
                writer.WriteAttributeString("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
                writer.WriteAttributeString("xmlns:vc", "http://www.w3.org/2007/XMLSchema-versioning");
                writer.WriteAttributeString("xmlns:xs", "http://www.w3.org/2001/XMLSchema");

                // La clave se crea con la función CreaClave de la clase Datos
                writer.WriteElementString("Clave", _numeroClave);

                // 'El numero de secuencia es de 20 caracteres, 
                // 'Se debe de crear con la función CreaNumeroSecuencia de la clase Datos
                writer.WriteElementString("NumeroConsecutivo", _numeroConsecutivo);

                // 'El formato de la fecha es yyyy-MM-ddTHH:mm:sszzz
                writer.WriteElementString("FechaEmision", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"));

                writer.WriteStartElement("Emisor");

                writer.WriteElementString("Nombre", _emisor.Nombre);
                writer.WriteStartElement("Identificacion");
                writer.WriteElementString("Tipo", _emisor.Identificacion_Tipo);
                writer.WriteElementString("Numero", _emisor.Identificacion_Numero);
                writer.WriteEndElement(); // 'Identificacion

                // '-----------------------------------
                // 'Los datos de las ubicaciones los puede tomar de las tablas de datos, 
                // 'Debe ser exacto al que hacienda tiene registrado para su compañia
                writer.WriteStartElement("Ubicacion");
                writer.WriteElementString("Provincia", _emisor.Ubicacion_Provincia);
                writer.WriteElementString("Canton", _emisor.Ubicacion_Canton);
                writer.WriteElementString("Distrito", _emisor.Ubicacion_Distrito);
                writer.WriteElementString("Barrio", _emisor.Ubicacion_Barrio);
                writer.WriteElementString("OtrasSenas", _emisor.Ubicacion_OtrasSenas);
                writer.WriteEndElement(); // 'Ubicacion

                writer.WriteStartElement("Telefono");
                writer.WriteElementString("CodigoPais", _emisor.Telefono_CodigoPais);
                writer.WriteElementString("NumTelefono", _emisor.Telefono_Numero.ToString());
                writer.WriteEndElement(); // 'Telefono

                writer.WriteElementString("CorreoElectronico", _emisor.CorreoElectronico);

                writer.WriteEndElement(); // Emisor
                                          // '------------------------------------
                                          // 'Receptor es similar con emisor, los datos opcionales siempre siempre siempre omitirlos.
                                          // 'La ubicacion para el receptor es opcional por ejemplo
                writer.WriteStartElement("Receptor");
                writer.WriteElementString("Nombre", _receptor.Nombre);
                writer.WriteStartElement("Identificacion");
                // 'Los tipos de identificacion los puede ver en la tabla de datos
                writer.WriteElementString("Tipo", _receptor.Identificacion_Tipo);
                writer.WriteElementString("Numero", _receptor.Identificacion_Numero);
                writer.WriteEndElement(); // 'Identificacion

                writer.WriteStartElement("Telefono");
                writer.WriteElementString("CodigoPais", _receptor.Telefono_CodigoPais);
                writer.WriteElementString("NumTelefono", _receptor.Telefono_Numero.ToString());
                writer.WriteEndElement(); // 'Telefono

                writer.WriteElementString("CorreoElectronico", _receptor.CorreoElectronico);

                writer.WriteEndElement(); // Receptor
                                          // '------------------------------------

                // 'Loa datos estan en la tabla correspondiente
                writer.WriteElementString("CondicionVenta", _condicionVenta);
                // '01: Contado
                // '02: Credito
                // '03: Consignación
                // '04: Apartado
                // '05: Arrendamiento con opcion de compra
                // '06: Arrendamiento con función financiera
                // '99: Otros

                // 'Este dato se muestra si la condicion venta es credito
                writer.WriteElementString("PlazoCredito", _plazoCredito);

                writer.WriteElementString("MedioPago", _medioPago);
                // '01: Efectivo
                // '02: Tarjeta
                // '03: Cheque
                // '04: Transferecia - deposito bancario
                // '05: Recaudado por terceros            
                // '99: Otros

                writer.WriteStartElement("DetalleServicio");

                // '-------------------------------------
                foreach (var xt in _dsDetalle)
                {
                    
                    writer.WriteStartElement("LineaDetalle");
                   
                    writer.WriteElementString("NumeroLinea", xt.numeroDeLinea.ToString());

                    writer.WriteStartElement("Codigo");
                   
                    writer.WriteElementString("Tipo", xt.tipoDeArticulo.ToString());
                    writer.WriteElementString("Codigo", xt.codigoArticulo.ToString());
                    writer.WriteEndElement(); // 'Codigo

                    writer.WriteElementString("Cantidad", xt.cantidad.ToString());
                    // 'Para las unidades de medida ver la tabla correspondiente
                    writer.WriteElementString("UnidadMedida", xt.unidadDeMedida.ToString());
                    writer.WriteElementString("Detalle", xt.detalle.ToString());
                    writer.WriteElementString("PrecioUnitario", String.Format("{0:N3}", xt.precioUnitario.ToString()));
                    writer.WriteElementString("MontoTotal", String.Format("{0:N3}",xt.montoTotal.ToString()));
                    writer.WriteElementString("MontoDescuento", String.Format("{0:N3}", xt.montoDescuento.ToString()));
                    writer.WriteElementString("NaturalezaDescuento", xt.NaturalezaDescuento.ToString());
                    writer.WriteElementString("SubTotal", String.Format("{0:N3}", xt.subtotal.ToString()));

                    writer.WriteStartElement("Impuesto");
                    writer.WriteElementString("Codigo", xt.codigoImpuesto.ToString());
                    writer.WriteElementString("Tarifa", xt.impuestoTarifa.ToString());
                   writer.WriteElementString("Monto", xt.impuestoMonto.ToString());
                  writer.WriteEndElement(); // Impuesto

                    writer.WriteElementString("MontoTotalLinea", String.Format("{0:N3}", xt.montoTotalLinea.ToString()));

                    writer.WriteEndElement(); // LineaDetalle
                }
                // '-------------------------------------

                writer.WriteEndElement(); // DetalleServicio


                writer.WriteStartElement("ResumenFactura");

                // Estos campos son opcionales, solo fin desea facturar en dólares
                writer.WriteElementString("CodigoMoneda", _codigoMoneda);
                writer.WriteElementString("TipoCambio", "1.00000");
                // =================

                //SACAR CALCULOS PARA FACTURA

               
                
                double totalComprobante=0;

                double montoTotalImpuesto = 0;

               foreach (var y in _dsDetalle) {

                   
                    montoTotalImpuesto = montoTotalImpuesto + y.impuestoMonto;



               }

                totalComprobante = 0 + montoTotalImpuesto;
                


                

                // 'En esta parte los totales se pueden ir sumando linea a linea cuando se carga el detalle
                // 'ó se pasa como parametros al inicio
                writer.WriteElementString("TotalServGravados", "0.00000");
                writer.WriteElementString("TotalServExentos", "0.00000");


                writer.WriteElementString("TotalMercanciasGravadas", "0.00000");
                writer.WriteElementString("TotalMercanciasExentas", "0.00000");

                writer.WriteElementString("TotalGravado", "0.00000");
                writer.WriteElementString("TotalExento", "0.00000");

                writer.WriteElementString("TotalVenta", "0.00000");
                writer.WriteElementString("TotalDescuentos", "0.00000");
                writer.WriteElementString("TotalVentaNeta", "0.00000");
                writer.WriteElementString("TotalImpuesto", String.Format("{0:N3}", montoTotalImpuesto.ToString()));
                writer.WriteElementString("TotalComprobante", String.Format("{0:N3}", totalComprobante.ToString()));
                writer.WriteEndElement(); // ResumenFactura

                // 'Estos datos te los tiene que brindar los encargados del area financiera
                writer.WriteStartElement("Normativa");
                writer.WriteElementString("NumeroResolucion", "DGT-R-48-2016");
                writer.WriteElementString("FechaResolucion", "07-10-2016 01:00:00");
                writer.WriteEndElement(); // Normativa

                // 'Aqui va la firma, despues la agregamos.

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
