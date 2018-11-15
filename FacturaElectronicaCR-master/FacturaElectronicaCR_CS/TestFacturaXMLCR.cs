using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace FacturaElectronicaCR_CS
{
    public partial class TestFacturaXMLCR : Form
    {

        public string numeroComprobante = "0000000033";
        public string clave = "";
        public string numeroConsecutivo = "";
        public string xmlFactura = "";
        public TestFacturaXMLCR()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {


            
            try
            {
                if (this.txtXMLSinFirma.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el XML Sin Firmar");
                    this.txtXMLSinFirma.Focus();
                    return;
                }

               

                if ((this.txtPathCertificado.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Debe indicar la ruta del certificado a usar en la firma");
                    BuscaCertificado();
                }

                if ((this.txtFolderSalida.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Debe indicar la ruta del folder donde grabar los archivos");
                    CargaFolderSalida();
                }

                CargaDatosXML();

                Procesa(this.txtXMLSinFirma.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaDatosXML()
        {
            try
            {
                XmlDocument xmlEnvia = new XmlDocument();
                xmlEnvia.LoadXml(this.txtXMLSinFirma.Text);
                this.txtConsecutivo.Text = xmlEnvia.GetElementsByTagName("NumeroConsecutivo")[0].InnerText;
                this.txtClave.Text = xmlEnvia.GetElementsByTagName("Clave")[0].InnerText;
                this.txtEmisorNumero.Text = xmlEnvia.GetElementsByTagName("Emisor")[0]["Identificacion"]["Numero"].InnerText;
                this.txtEmisorTipo.Text = xmlEnvia.GetElementsByTagName("Emisor")[0]["Identificacion"]["Tipo"].InnerText;

                if (xmlEnvia.GetElementsByTagName("Receptor").Count == 0)
                {
                    if (!(xmlEnvia.GetElementsByTagName("Receptor")[0]["Identificacion"] == null))
                    {
                        this.txtReceptorNumero.Text = xmlEnvia.GetElementsByTagName("Receptor")[0]["Identificacion"]["Numero"].InnerText;
                        this.txtReceptorTipo.Text = xmlEnvia.GetElementsByTagName("Receptor")[0]["Identificacion"]["Tipo"].InnerText;
                    }
                }

                this.txtFecha.Text = xmlEnvia.GetElementsByTagName("FechaEmision")[0].InnerText;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public void Procesa(string xmlFactura)
        {
            if (!this.txtFolderSalida.Text.EndsWith("\\"))
            {
                this.txtFolderSalida.Text += "\\";
            }

            string directorio = this.txtFolderSalida.Text;
            string nombreArchivo = this.txtConsecutivo.Text;

            XmlDocument xmlDocSF = new XmlDocument();
            xmlDocSF.LoadXml(xmlFactura);
            xmlDocSF.Save((directorio + (nombreArchivo + "_01_SF.xml")));
            XmlTextWriter xmlTextWriter = new XmlTextWriter((directorio + (nombreArchivo + "_01_SF.xml")), new System.Text.UTF8Encoding(false));
            xmlDocSF.WriteTo(xmlTextWriter);
            xmlTextWriter.Close();
            xmlDocSF = null;
            
            Firma _firma = new Firma();
            _firma.FirmaXML_Xades((directorio + nombreArchivo),this.txtPathCertificado.Text,this.txtCertificadoPIN.Text);

            XmlDocument xmlElectronica = new XmlDocument();
            xmlElectronica.Load((directorio + (nombreArchivo + "_02_Firmado.xml")));

            this.txtXMLFirmado.Text = xmlElectronica.OuterXml;

            Emisor myEmisor = new Emisor();
            myEmisor.numeroIdentificacion = this.txtEmisorNumero.Text;
            myEmisor.TipoIdentificacion = this.txtEmisorTipo.Text;

            Receptor myReceptor = new Receptor();
            if ((this.txtReceptorNumero.Text.Trim().Length > 0))
            {
                myReceptor.sinReceptor = false;
                myReceptor.numeroIdentificacion = this.txtReceptorNumero.Text;
                myReceptor.TipoIdentificacion = this.txtReceptorTipo.Text;
            }
            else
            {
                myReceptor.sinReceptor = true;
            }
            
            Recepcion myRecepcion = new Recepcion();
            myRecepcion.emisor = myEmisor;
            myRecepcion.receptor = myReceptor;

            myRecepcion.clave = this.txtClave.Text;
            myRecepcion.fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            myRecepcion.comprobanteXml = Funciones.EncodeStrToBase64(xmlElectronica.OuterXml);

            xmlElectronica = null;

            string Token = "";
            Token = getToken();
            this.txtTokenHacienda.Text = Token;

            Comunicacion enviaFactura = new Comunicacion();
            enviaFactura.EnvioDatos(Token, myRecepcion);
            string jsonEnvio = "";
            jsonEnvio = enviaFactura.jsonEnvio;
            string jsonRespuesta = "";
            jsonRespuesta = enviaFactura.jsonRespuesta;
            txtJSONEnvio.Text = jsonEnvio;
            txtJSONRespuesta.Text = jsonRespuesta;
            System.IO.StreamWriter outputFile = new System.IO.StreamWriter((directorio
                            + (nombreArchivo + "_03_jsonEnvio.txt")));
            outputFile.Write(jsonEnvio);
            outputFile.Close();
            outputFile = new System.IO.StreamWriter((directorio
                            + (nombreArchivo + "_04_jsonRespuesta.txt")));
            outputFile.Write(jsonRespuesta);
            outputFile.Close();
            if (!(enviaFactura.xmlRespuesta == null))
            {
                this.txtRespuestaHacienda.Text = enviaFactura.xmlRespuesta.OuterXml;
                enviaFactura.xmlRespuesta.Save((directorio
                                + (nombreArchivo + "_05_RESP.xml")));
            }
            else
            {
                outputFile = new System.IO.StreamWriter((directorio
                                + (nombreArchivo + "_05_RESP_SinRespuesta.txt")));
                outputFile.Write("");
                outputFile.Close();
                this.txtRespuestaHacienda.Text = "Consulte en unos minutos, factura se est� procesando.";
                this.txtRespuestaHacienda.Text = (this.txtRespuestaHacienda.Text + ("\r\n" + ("\r\n" + "Consulte por Clave")));
                this.txtRespuestaHacienda.Text = (this.txtRespuestaHacienda.Text + ("\r\n" + ("\r\n" + enviaFactura.mensajeRespuesta)));
            }
            MessageBox.Show(enviaFactura.mensajeRespuesta);
        }

        private void btnConsultaClave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtFolderSalida.Text.EndsWith("\\"))
                {
                    this.txtFolderSalida.Text += "\\";
                }

                if ((this.txtClave.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Indique la clave a consultar");
                    this.txtClave.Focus();
                    return;
                }

                string directorio = this.txtFolderSalida.Text;
                string nombreArchivo;
                if ((txtConsecutivo.Text.Trim().Length == 0))
                {
                    nombreArchivo = this.txtClave.Text;
                }
                else
                {
                    nombreArchivo = this.txtConsecutivo.Text;
                }

                string Token = "";
                Token = getToken();
                this.txtTokenHacienda.Text = Token;

                Comunicacion enviaFactura = new Comunicacion();
                enviaFactura.ConsultaEstatus(Token, this.txtClave.Text);

                string jsonRespuesta = "";
                jsonRespuesta = enviaFactura.jsonRespuesta;
                txtJSONRespuesta.Text = jsonRespuesta;
                System.IO.StreamWriter outputFile = new System.IO.StreamWriter((directorio
                                + (nombreArchivo + "_06_jsonRespuestaClave.txt")));
                outputFile.Write(jsonRespuesta);
                outputFile.Close();
                if (!(enviaFactura.xmlRespuesta == null))
                {
                    this.txtRespuestaHacienda.Text = enviaFactura.xmlRespuesta.OuterXml;
                    enviaFactura.xmlRespuesta.Save((directorio
                                    + (nombreArchivo + "_07_RespuestaClave.xml")));
                }
                else
                {
                    this.txtRespuestaHacienda.Text = "Consulte en unos minutos, factura se est� procesando.";
                    this.txtRespuestaHacienda.Text = (this.txtRespuestaHacienda.Text + ("\r\n" + ("\r\n" + "Consulte por Clave")));
                    this.txtRespuestaHacienda.Text = (this.txtRespuestaHacienda.Text + ("\r\n" + ("\r\n" + enviaFactura.mensajeRespuesta)));
                }

                MessageBox.Show(enviaFactura.mensajeRespuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string getToken()
        {
            try
            {
                TokenHacienda iTokenHacienda = new TokenHacienda();
                iTokenHacienda.GetTokenHacienda(this.txtAPIUsuario.Text, this.txtAPIClave.Text);
                return iTokenHacienda.accessToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnFolderSalida_Click(object sender, EventArgs e)
        {
            try
            {
                CargaFolderSalida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaFolderSalida()
        {
            try
            {
                FolderBrowserDialog iFolder = new FolderBrowserDialog();
                iFolder.ShowDialog();
                this.txtFolderSalida.Text = iFolder.SelectedPath;
                if (!this.txtFolderSalida.Text.EndsWith("\\"))
                {
                    this.txtFolderSalida.Text += "\\";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRutaCertificado_Click(object sender, EventArgs e)
        {
            try
            {
                BuscaCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuscaCertificado()
        {
            try
            {
                OpenFileDialog iFile = new OpenFileDialog();
                iFile.ShowDialog();
                this.txtPathCertificado.Text = iFile.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsecutivo_Clave_Click(object sender, EventArgs e)
        {
            try
            {
                
                CreaClave_NumeroConsecutivo creaNumeroClave = new CreaClave_NumeroConsecutivo();
         
                creaNumeroClave.ShowDialog();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
      

        private void button3_Click(object sender, EventArgs e)
        {


            Boolean parpadear = false;


            try
            {
                parpadear = true;
                btnProcesar.Visible = true;
                
                
                string embarcacionSeleccionada = comboEmbarcacion.SelectedItem.ToString();
                string condicionVenta = comboCondicionVenta.SelectedItem.ToString();
                string medioDePago = comboMedioPago.SelectedItem.ToString();


           
                


                if (condicionVenta.Equals("Contado")) { condicionVenta = "01"; }
                if (condicionVenta.Equals("Credito")) { condicionVenta = "02"; }
                if (condicionVenta.Equals("Consignación")) { condicionVenta = "03"; }
                if (condicionVenta.Equals("Apartado")) { condicionVenta = "04"; }
                if (condicionVenta.Equals("Arrendamiento con opcion de compra")) { condicionVenta = "05"; }
                if (condicionVenta.Equals("Arrendamiento con función financiera")) { condicionVenta = "06"; }
                if (condicionVenta.Equals("Otros")) { condicionVenta = "99"; }


                if (medioDePago.Equals("Efectivo")) { medioDePago = "01"; }
                if (medioDePago.Equals("Tarjeta")) { medioDePago = "02"; }
                if (medioDePago.Equals("Cheque")) { medioDePago = "03"; }
                if (medioDePago.Equals("Transferecia - deposito bancario")) { medioDePago = "04"; }
                if (medioDePago.Equals("Recaudado por terceros")) { medioDePago = "05"; }
                if (medioDePago.Equals("Otros")) { medioDePago = "99"; }


                CrearConsecutivo();
                crearClave();

                ClasesDatos.FacturaElectronicaCR nuevaFactura = new ClasesDatos.FacturaElectronicaCR(numeroConsecutivo, clave, crearEmisor(embarcacionSeleccionada), crearReceptor("Bajo Rojo"),"01", "0","04", crearDetallesFactura(embarcacionSeleccionada), "CRC", 1);


                xmlFactura = GetXMLAsString(nuevaFactura.CreaXMLFacturaElectronica());

                txtXMLSinFirma.Text = xmlFactura;
                
            }



            catch {
                parpadear = false;
                btnProcesar.Visible = false;
                MessageBox.Show("Se produjo un error, verifique que los campos esten bien."); }

            if (parpadear == true) { parpadearBoton(); }


        }

        public void parpadearBoton() {


            int milliseconds = 250;

            for (int i = 0; i < 4; i++)
            {
                btnProcesar.Visible = true;
                btnProcesar.BackColor = Color.FromArgb(125, 247, 23);
                Application.DoEvents();

                System.Threading.Thread.Sleep(milliseconds);
                btnProcesar.BackColor = Color.FromArgb(169, 211, 255);
                Application.DoEvents();
                System.Threading.Thread.Sleep(milliseconds);
            }

        }

        public void crearClave() {


            //Tipo de comprobante 01-FACTURA ELECTRONICA, 02 NOTA DE DEBITO
            //Situacion comprobante 1= normal , 2= Contingencia, 3= sin internet
            //Codigo pais 506 Costa Rica
            //Terminal o punto de venta(codigo punto de venta), en este caso como solo es uno es: 00001
            //Numero id es el numero de el emisor en hacienda , ejemplo de cedula juridica = 3101715950

            DateTime fecha = DateTime.Now;

            string codigoSeguridad = CreaCodigoSeguridad("01", "001", "00001", fecha.Date, numeroComprobante);
            
            

            clave = CreaClave("506",fecha.Day.ToString(),fecha.Month.ToString(),fecha.Year.ToString(), "003101715950", numeroConsecutivo,"1",codigoSeguridad);

        }
        
        public void CrearConsecutivo() {

            //Tipo de comprobante 01-FACTURA ELECTRONICA, 02 NOTA DE DEBITO
            // Casa matriz es 001  , ya que corresponde a el establecimiento principal
            //Terminal Pos 00001, ya que solo se cuenta con una.
            // Numero de factura es un numero consecutivo de 10 digitos
            // un ejemplo de numero de factura es :  0000000001 , este numero debe ir cambiando
            //Por ejemplo para la segunda factura debe ser: 0000000002

            numeroConsecutivo = CreaNumeroConsecutivo("001 ", "00001", "01", numeroComprobante);

        }

        public string GetXMLAsString(XmlDocument myxml)
        {
            return myxml.OuterXml;
        }

        public ClasesDatos.Receptor crearReceptor(string receptor) {

            //Con el string de receptor se busca en la base de datos todo los datos del receptor
            ClasesDatos.Receptor nuevoReceptor = new ClasesDatos.Receptor("EL BAJO ROJO DEL PACIFICO SOCIEDAD ANONIMA", "02", "3101715950", "5","01","04","04","Cuajiniquil","506",26791023,"bajorojoj@gmail.com");

            return nuevoReceptor;

        }

        public ClasesDatos.Emisor crearEmisor(string emisor) {


            //Con el string emisor de busca en la base de datos todos los datos del emisor
            // Tipo de id es el tipo de identificacion 

            // 01 CEDULA FISICA
            //02 CEDULA JURIDICA
            //03 DIMEX
           // 04 NITE


            //Numero factura 19

            ClasesDatos.Emisor nuevoEmisor = new ClasesDatos.Emisor("EL BAJO ROJO DEL PACIFICO SOCIEDAD ANONIMA", "02","3101715950","5","10","04","02", "1 km oeste de la terminal pesquera Puerto de Mora.", "506",26791023,"bajorojoj@gmail.com");


            return nuevoEmisor;


        }

        public List<ClasesDatos.DetallesFactura> crearDetallesFactura(string embarcacion) {

            //Aqui salen los codigos https://www.hacienda.go.cr/ATV/ComprobanteElectronico/docs/esquemas/2016/v4/ANEXOS%20Y%20ESTRUCTURAS.pdf
           
           

            //Se crea un objeto detalle que se va a agregar a la lista detalles
            ClasesDatos.DetallesFactura detalle = new ClasesDatos.DetallesFactura();
            detalle.codigoArticulo="2345";
            detalle.tipoDeArticulo ="04"; //Es decir de uso interno
            detalle.cantidad = 10;
            detalle.codigoImpuesto ="01"; //Es decir de ventas
            detalle.detalle ="Dorado de primera";
            detalle.impuestoMonto =260; // se calcula  (subtotal * porcentaje de impuesto 0.13)
            detalle.impuestoTarifa =13;
            detalle.montoDescuento = 0;
            detalle.montoTotal = 10*200;// Cantidad por precio unitario
            detalle.montoTotalLinea = 2000+260;  //SUBTOTAL mas monto de impuesto
            detalle.NaturalezaDescuento ="Descuento al cliente";
            detalle.numeroDeLinea =1;
            detalle.precioUnitario = 200;
            detalle.subtotal = 2000-0; // Monto total-monto descuento concedido
            detalle.unidadDeMedida ="kg";


            //Lista en donde se guardan los detalles
            List<ClasesDatos.DetallesFactura> nuevoDetalles = new List<ClasesDatos.DetallesFactura>();
            nuevoDetalles.Add(detalle);

            return nuevoDetalles;

        }

        public string CreaNumeroConsecutivo(string CasaMatriz, string TerminalPOS, string TipoComprobante, string NumeroFactura)
        {
            // 'CasaMatriz debe de se de tres caracteres m�ximo
            // 'Terminal debe ser máximo 5 cataracteres
            // 'Tipo comprobante dos caracteres
            // 'NumeroFactura diez caracteres, si se llega al numero máximo, comienza de 1 nuevamente
            try
            {
                if ((CasaMatriz.Trim().Length > 3))
                {
                    throw new Exception("Casa Matiz no debe de superar los 3 caracteres");
                }

                if ((TerminalPOS.Trim().Length > 5))
                {
                    throw new Exception("Numero de terminal no debe de superar los 5 caracteres");
                }

                if ((TipoComprobante.Trim().Length > 2))
                {
                    throw new Exception("Tipo Comprobante no debe de superar los 2 caracteres");
                }

                if ((NumeroFactura.Trim().Length > 10))
                {
                    throw new Exception("Numero Factura no debe de superar los 10 caracteres");
                }

                string NumeroSecuencia = "";
                NumeroSecuencia = CasaMatriz.Trim().PadLeft(3, '0');
                NumeroSecuencia = (NumeroSecuencia + TerminalPOS.Trim().PadLeft(5, '0'));
                NumeroSecuencia = (NumeroSecuencia + TipoComprobante.Trim().PadLeft(2, '0'));
                NumeroSecuencia = (NumeroSecuencia + NumeroFactura.Trim().PadLeft(10, '0'));
                if ((NumeroSecuencia.Trim().Length < 20))
                {
                    throw new Exception("Numero de secuencia inválido, debe tener 20 caracteres");
                }

                return NumeroSecuencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static string CreaClave(string CodigoPais, string Dia, string Mes, string Anno, string NumeroIdentifiaccion, string NumeracionConsecutiva, string SituacionComprobante, string CodigoSeguridad)
        {
            // 'CodigoPais tres caracteres 
            // 'Dia y Mes dos caracteres
            // 'Año dos caracteres
            // 'Numero idenficacion es el numero de cedula del emisor, 12 caracteres máximo
            // 'Numero consecutivo 20 caracteres, generados en la funcion CreaNumeroSecuencia
            // 'Situacion comprobante un caracter, 1.Normal 2.Contingencia 3.Sin Internet
            // 'Codigo Seguridad 8 caracteres generado con la funci�n CreaCodigoSeguridad
            try
            {
                if (Anno.Trim().Length == 4)
                    Anno = Anno.Substring(2, 2);

                if ((CodigoPais.Trim().Length != 3))
                {
                    throw new Exception("Codigo país  debe tener 3 caracteres");
                }

                if ((Dia.Trim().Length > 2))
                {
                    throw new Exception("Día no debe de superar los 2 caracteres");
                }

                if ((Mes.Trim().Length > 2))
                {
                    throw new Exception("Mes no debe de superar los 2 caracteres");
                }

                if ((Anno.Trim().Length > 2))
                {
                    throw new Exception("Año no debe de superar los 2 caracteres");
                }

                if ((NumeroIdentifiaccion.Trim().Length > 12))
                {
                    throw new Exception("Número Identifiacción de superar los 12 caracteres");
                }

                if ((NumeracionConsecutiva.Trim().Length != 20))
                {
                    throw new Exception("Numero Consecutivo  debe tener 20 caracteres");
                }

                if ((SituacionComprobante.Trim().Length > 1))
                {
                    throw new Exception("Situacion Comprobante debe tener un caracter");
                }

                if ((CodigoSeguridad.Trim().Length > 8))
                {
                    throw new Exception("Código seguridad no debe de superar los 8 caracteres");
                }

               

                string Clave = "";
                Clave = CodigoPais;
                Clave = (Clave + Dia.PadLeft(2, '0'));
                Clave = (Clave + Mes.PadLeft(2, '2'));
                Clave = (Clave + Anno.PadLeft(2, '0'));
                Clave = (Clave + NumeroIdentifiaccion.PadLeft(12, '0'));
                Clave = (Clave + NumeracionConsecutiva);
                Clave = (Clave + SituacionComprobante);
                Clave = (Clave + CodigoSeguridad);
                if ((Clave.Length != 50))
                {
                    throw new Exception("Clave inválida, debe de tener 50 caracteres");
                }

                return Clave;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static string CreaCodigoSeguridad(string TipoComprobante, string Localidad,
                                        string CodigoPuntoVenta, DateTime Fecha,
                                        string NumeroFactura)
        {
            // 'Los parametros TipoComprobante, Localidad y CodigoPuntoVenta pueden modificarse por otros valores, siempre manteniendo la longitud
            // 'Tipo Comprobante debe tener 2 caracteres máximo
            // 'Localidad debe tener 3 caracteres máximo
            // 'Punto de Venta debe de tener 5 caracteres máximo
            // 'Fecha es un campo datetime, debe ser la fecha de la factura
            // 'Número Factura debe tener máximo 10 caracteres y debe ser el mismo parámetro que se usa en la funcion GeneraNumeroSecuencia
            try
            {
                if ((TipoComprobante.Trim().Length > 2))
                {
                    throw new Exception("Tipo Comprobante debe tener 2 caracteres");
                }

                if ((Localidad.Trim().Length > 3))
                {
                    throw new Exception("Localidad no debe de superar los 3 caracteres");
                }

                if ((CodigoPuntoVenta.Trim().Length > 5))
                {
                    throw new Exception("Codigo Punto Venta no debe de superar los 5 caracteres");
                }

                if ((NumeroFactura.Trim().Length > 10))
                {
                    throw new Exception("Numero Factura no de superar los 10 caracteres");
                }

                string concatenado = "";
                concatenado = (concatenado + TipoComprobante.PadLeft(2, '0'));
                concatenado = (concatenado + Localidad.PadLeft(3, '0'));
                concatenado = (concatenado + CodigoPuntoVenta.PadLeft(5, '0'));
                concatenado = (concatenado + Fecha.ToString("yyyyMMddHHmmss"));
                concatenado = (concatenado + NumeroFactura.PadLeft(10, '0'));
                if ((concatenado.Length != 34))
                {
                    throw new Exception("El concatenado debe de ser de 34 caracteres para poder calcular el código de seguridad");
                }

                int calculo = 0;
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(0, 1)) * 3));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(1, 1)) * 2));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(2, 1)) * 9));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(3, 1)) * 8));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(4, 1)) * 7));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(5, 1)) * 6));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(6, 1)) * 5));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(7, 1)) * 4));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(8, 1)) * 3));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(9, 1)) * 2));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(10, 1)) * 9));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(11, 1)) * 8));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(12, 1)) * 7));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(13, 1)) * 6));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(14, 1)) * 5));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(15, 1)) * 4));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(16, 1)) * 3));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(17, 1)) * 2));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(18, 1)) * 9));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(19, 1)) * 8));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(20, 1)) * 7));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(21, 1)) * 6));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(22, 1)) * 5));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(23, 1)) * 4));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(24, 1)) * 3));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(25, 1)) * 2));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(26, 1)) * 9));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(27, 1)) * 8));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(28, 1)) * 7));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(29, 1)) * 6));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(30, 1)) * 5));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(31, 1)) * 4));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(32, 1)) * 3));
                calculo = (calculo
                            + (int.Parse(concatenado.Substring(33, 1)) * 2));
                int mDV = 0;
                int digitoMod = 0;
                digitoMod = (calculo % 11);
                if (((digitoMod == 0)
                            || (digitoMod == 1)))
                {
                    mDV = 0;
                }
                else
                {
                    mDV = (11 - digitoMod);
                }

                return (TipoComprobante.PadLeft(2, '0')
                            + (calculo.ToString().PadLeft(5, '0') + mDV.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                AgregarEmisor frm = new AgregarEmisor();

                frm.Show();
            }
            catch {
                MessageBox.Show("Se produjo un error, volver a intentar mas tarde.");
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Decimal a = 200;
            Decimal b = 2;
            Double c = 2000;

            MessageBox.Show("Decimal "+ a);
            MessageBox.Show("Decimal multi " + a*b);
            MessageBox.Show("Double " + String.Format("{0:N3}", c.ToString()));

        }
    }
}
