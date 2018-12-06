using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Rectangle = iTextSharp.text.Rectangle;

namespace pantallaPesasLiquidaciones
{
    public partial class pantallaPesas : Form
    {
        List<objeto> lista;
       public string nombreCliente = "";
        public string cedulaCliente = "";
        public string telefonoCliente = "";
        public string direccionCliente = "";
        public string numeroMatricula = "";
        public pantallaPesas()
        {
            InitializeComponent();
        }


        private void botonBuscar_Click(object sender, EventArgs e)
        {
            datos2.Rows.Clear();

            try
            {
                String embarcacion = comboBoxEmbarcacion.SelectedItem.ToString();
                if (embarcacion == "Bajo Rojo")
                {
                    //Aqui se procede a llenar la tabla normalmente solo que esta vez se accesa a una nueva tabla
                    BajoDatos.PesasDatos nuevaBusqueda = new BajoDatos.PesasDatos();
                    datos.DataSource = nuevaBusqueda.BuscarBajoRojo("A");

                    datos.Columns.Remove("Embarcacion");
                    CrearLista();

                    double puntarenas1 = 0;
                    double puntarenas2 = 0;
                    double puntarenas3 = 0;

                    foreach (var j in lista)
                    {
                       
                        datos2.Rows.Add(j.pez, Convert.ToString(j.monto), "", "");

                    }

                    
                    datos.DataSource = nuevaBusqueda.Buscar("Puntarenas 1");

                    datos.Columns.Remove("Embarcacion");
                    CrearLista();

                    foreach (var pun1 in lista)
                    {

                        puntarenas1 = puntarenas1 + pun1.monto;
      
                    }

                    
                    datos.DataSource = nuevaBusqueda.Buscar("Puntarenas 2");

                    datos.Columns.Remove("Embarcacion");
                    CrearLista();

                    foreach (var pun2 in lista)
                    {

                        puntarenas2 = puntarenas2 + pun2.monto;

                    }

                    datos.DataSource = nuevaBusqueda.Buscar("Puntarenas 3");

                    datos.Columns.Remove("Embarcacion");
                    CrearLista();

                    foreach (var pun3 in lista)
                    {

                        puntarenas3 = puntarenas3 + pun3.monto;

                    }
                    ///
                    if (puntarenas1>0) { datos2.Rows.Add("Puntarenas 1", puntarenas1.ToString(), "", ""); }
                    if (puntarenas2 > 0) { datos2.Rows.Add("Puntarenas 2", puntarenas2.ToString(), "", ""); }
                    if (puntarenas3 > 0) { datos2.Rows.Add("Puntarenas 3", puntarenas3.ToString(), "", ""); }
                   


                }
                else
                {

                    BajoDatos.PesasDatos nuevaBusqueda = new BajoDatos.PesasDatos();
                    datos.DataSource = nuevaBusqueda.Buscar(embarcacion);

                    datos.Columns.Remove("Embarcacion");
                    CrearLista();

                    foreach (var j in lista)
                    {

                        datos2.Rows.Add(j.pez, Convert.ToString(j.monto), "", "");

                    }

                }
            }
            catch { MessageBox.Show("Ocurrio un error."); }


          

        }


        private void CrearLista(){
            lista = new List<objeto>();
           
            Boolean SeEncontroAlgo = false;

           
                foreach (DataGridViewRow fila in datos.Rows)
            {

                try
                {
                    foreach (var x in lista)
                    {

                        try
                        {
                            //si el pezcado de la lista es igual al de el data, entonces se suma la pesa.
                            if (x.pez == (fila.Cells[0].Value.ToString()))
                            {

                                x.monto = x.monto + Convert.ToDouble(fila.Cells[1].Value.ToString());
                                SeEncontroAlgo = true;
                            }

                        }
                        catch { }


                    }
                    if (SeEncontroAlgo == false)
                    {
                        objeto nuevo = new objeto(fila.Cells[0].Value.ToString(), Convert.ToDouble(fila.Cells[1].Value.ToString()));
                        lista.Add(nuevo);
                    }
                    if (SeEncontroAlgo == true) { SeEncontroAlgo = false; }






                }
                catch { }

            }


        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta apunto de guardar esta informacion, esta seguro realizarlo ", "Bajo Rojo del Pacifico ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                string embarcacion = comboBoxEmbarcacion.SelectedItem.ToString();
                //INSERTO DATOS PARA FACTURA BAJO ROJO
                //Solo sucede si la embarcacion seleccionada es distinta a bajo rojo
                BajoDatos.PesasDatos bajoFactura = new BajoDatos.PesasDatos();
                BajoDatos.FacturasDatos nuevaInfo = new BajoDatos.FacturasDatos();
                if (embarcacion != "Bajo Rojo")
                {
                    foreach (DataGridViewRow fila in datos2.Rows)
                    {
                        try
                        {
                            bajoFactura.InsertarBajoRojo("A", fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString());
                            nuevaInfo.Insertar(embarcacion, fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString());
                        }
                        catch {

                          
                        }


                    }

                }

                if (embarcacion == "Bajo Rojo") {
                    BajoDatos.PesasDatos eliminar = new BajoDatos.PesasDatos();
                    eliminar.EliminarBajo("A");
                    eliminar.Eliminar("Puntarenas 1");
                    eliminar.Eliminar("Puntarenas 2");
                    eliminar.Eliminar("Puntarenas 3");

                }

                // ELIMINO DTOS DE EMBARCACION



                BajoDatos.FacturasDatos nuevaFactura = new BajoDatos.FacturasDatos();


                DateTime hoy = DateTime.Now;
                string fechaActual = hoy.ToString("dd-MM-yyyy");
                

                BajoDatos.PesasDatos eliminarPesa = new BajoDatos.PesasDatos();
                eliminarPesa.Eliminar(embarcacion);

               
                datos2.DataSource = null;

                CrearDocumento(fechaActual,GenerarLista(),MontoTotalDinero.Text);
                Imprimir();
                

            }



            }




        private void MontoTotalPesa() {
            double resultado = 0;
            foreach (DataGridViewRow fila in datos2.Rows)
            {
                try {
                    resultado = resultado + Convert.ToDouble(fila.Cells[1].Value.ToString());
                }
                catch { }
                

            }
            MontoTotalPesasKg.Text = String.Format("{0:n}", resultado);

       }

            private void MontoTotalEco() {

            double resultado = 0;
            foreach (DataGridViewRow fila in datos2.Rows)
            {
                try
                {
                    resultado = resultado + Convert.ToDouble(fila.Cells[3].Value.ToString());
                }
                catch { }


            }
            MontoTotalDinero.Text = String.Format("{0:n}", resultado);


        }

        private void datos2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try {
                datos2.Rows[e.RowIndex].Cells["TotalLinea"].Value = String.Format("{0:n}", Convert.ToDouble(datos2.Rows[e.RowIndex].Cells["TotalPesa"].Value)* Convert.ToDouble(datos2.Rows[e.RowIndex].Cells["Precio"].Value));
                MontoTotalPesa();
                MontoTotalEco();
            } catch { }

            

        }


        private List<ObjetoFactura> GenerarLista() {
            List<ObjetoFactura> lista = new List<ObjetoFactura>();
            foreach (DataGridViewRow fila in datos2.Rows)
            {
                try
                {
                    ObjetoFactura nuevoObjeto = new ObjetoFactura(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), fila.Cells[2].Value.ToString(), fila.Cells[3].Value.ToString());
                    lista.Add(nuevoObjeto);
                }
                catch { }


            }


            return lista;
        }
        private void CrearDocumento(string fecha, List<ObjetoFactura> lista, string total)
        {

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
           
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\Jordan\Documents\Bajo Rojo\Factura.pdf", FileMode.Create));
           
            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Factura control de pesas");
            doc.AddCreator("Bajo Rojo del pacifico s.a");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\Jordan\Documents\Bajo Rojo\Bajo.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 500 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            doc.Add(imagen);

            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Factura control de pesas"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Embarcacion: " + comboBoxEmbarcacion.SelectedItem.ToString() + "  Fecha: "+fecha));
            doc.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(4);
            
            table.AddCell("Descripcion");
            table.AddCell("Cantidad");
            table.AddCell("Precio");
            table.AddCell("Total");

            foreach (var x in lista) {

                table.AddCell(x.pez);
                table.AddCell(x.pesa);
                table.AddCell(x.precio);
                table.AddCell(x.totalLinea);

            }

            


            doc.Add(table);

            doc.Add(new Paragraph("Monto total:₡"+ total));
            doc.Add(Chunk.NEWLINE);

            doc.Close();
            writer.Close();



        }
        private void Imprimir()
        {
            
            System.Diagnostics.Process.Start(@"C:\Users\johan\Documents\Bajo Rojo\Factura.pdf");
           
        }


       

        private void button2_Click(object sender, EventArgs e)
        {
          // MessageBox.Show( ObtenerConsecutivo(""));
                CreatePDF(GenerarLista());
                Imprimir();
          

        }

        private string ObtenerConsecutivo(string embarcacion) {
            string numero = "";
            int numero1 = 100;

            try {

                BajoDatos.FacturasDatos consecutivo = new BajoDatos.FacturasDatos();
                numero = numero1.ToString("0000");


            }
            catch { numero = "0000"; }
            return numero;
        }

        private void CreatePDF(List<ObjetoFactura> lista)
        {
            // Create a Document object
            Document document = new Document(PageSize.A4, 70, 70, 70, 70);

            //MemoryStream
           
            PdfWriter writer = PdfWriter.GetInstance(document,
                                        new FileStream(@"C:\Users\johan\Documents\Bajo Rojo\Factura.pdf", FileMode.Create));

            // First, create our fonts
            var titleFont = FontFactory.GetFont("Arial", "14", Font.Bold);
            var boldTableFont = FontFactory.GetFont("Arial", "10", Font.Bold);
            var bodyFont = FontFactory.GetFont("Arial", "10", Font.Bold);
            iTextSharp.text.Rectangle pageSize = writer.PageSize;

            // Open the Document for writing
            document.Open();
            //Add elements to the document here
            //Add elements to the document here

            #region Top table
            // Create the header table 
            PdfPTable headertable = new PdfPTable(3);
            headertable.HorizontalAlignment = 0;
            headertable.WidthPercentage = 100;
            headertable.SetWidths(new float[] { 4, 2, 4 });  // then set the column's __relative__ widths
            headertable.DefaultCell.Border = Rectangle.NO_BORDER;
            //headertable.DefaultCell.Border = Rectangle.BOX; //for testing
            headertable.SpacingAfter = 30;
            PdfPTable nested = new PdfPTable(1);
            nested.DefaultCell.Border = Rectangle.BOX;
            
            PdfPCell nextPostCell1 = new PdfPCell(new Phrase("ABC Co.,Ltd", bodyFont));
            nextPostCell1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            nested.AddCell(nextPostCell1);
            PdfPCell nextPostCell2 = new PdfPCell(new Phrase("111/206 Moo 9, Ramkhamheang Road,", bodyFont));
            nextPostCell2.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            nested.AddCell(nextPostCell2);
            PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Nonthaburi 11120", bodyFont));
            nextPostCell3.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            nested.AddCell(nextPostCell3);
            PdfPCell nesthousing = new PdfPCell(nested);
            nesthousing.Rowspan = 4;
            nesthousing.Padding = 0f;
            headertable.AddCell(nesthousing);

            headertable.AddCell("");
            PdfPCell invoiceCell = new PdfPCell(new Phrase("Factura de ventas.", titleFont));
            invoiceCell.HorizontalAlignment = 2;
            invoiceCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(invoiceCell);
            PdfPCell noCell = new PdfPCell(new Phrase("No :", bodyFont));
            noCell.HorizontalAlignment = 2;
          
            noCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(noCell);
            var xxh = new BaseColor(255, 30, 30);
            var Calibri8 = FontFactory.GetFont("Calibri", 12, xxh);
            headertable.AddCell(new Phrase(ObtenerConsecutivo(""), Calibri8));
            PdfPCell dateCell = new PdfPCell(new Phrase("Fecha :", bodyFont));
            dateCell.HorizontalAlignment = 2;
            dateCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(dateCell);
            headertable.AddCell(new Phrase("2 de febrero 2018", bodyFont));
            PdfPCell billCell = new PdfPCell(new Phrase("Direccion :", bodyFont));
            billCell.HorizontalAlignment = 2;
            billCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(billCell);
            headertable.AddCell(new Phrase("Johan"+ "\n" +"La Cruz", bodyFont));
            document.Add(headertable);
            #endregion


            #region Items Table
            //Create body table
            PdfPTable itemTable = new PdfPTable(4);
            itemTable.HorizontalAlignment = 0;
            itemTable.WidthPercentage = 100;
            itemTable.SetWidths(new float[] { 40, 15, 20, 30 });  // then set the column's __relative__ widths
            itemTable.SpacingAfter = 40;
            itemTable.DefaultCell.Border = Rectangle.BOX;
            PdfPCell cell1 = new PdfPCell(new Phrase("Tipo Pescado", boldTableFont));
            cell1.BackgroundColor = new iTextSharp.text.BaseColor(145, 205, 255);
            cell1.HorizontalAlignment = 1;
            itemTable.AddCell(cell1);
            PdfPCell cell2 = new PdfPCell(new Phrase("Cantidad Kg", boldTableFont));
            cell2.BackgroundColor = new iTextSharp.text.BaseColor(145, 205, 255);
            cell2.HorizontalAlignment = 1;
            itemTable.AddCell(cell2);
            PdfPCell cell3 = new PdfPCell(new Phrase("Precio/Kg", boldTableFont));
            cell3.BackgroundColor = new iTextSharp.text.BaseColor(145, 205, 255);
            cell3.HorizontalAlignment = 1;
            itemTable.AddCell(cell3);
            PdfPCell cell4 = new PdfPCell(new Phrase("Monto", boldTableFont));
            cell4.BackgroundColor = new iTextSharp.text.BaseColor(145, 205, 255);
            cell4.HorizontalAlignment = 1;
            itemTable.AddCell(cell4);

            foreach (var x in lista)
            {
                PdfPCell numberCell = new PdfPCell(new Phrase(x.pez, bodyFont));
                numberCell.HorizontalAlignment = 0;
                numberCell.PaddingLeft = 10f;
                numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                itemTable.AddCell(numberCell);

                PdfPCell descCell = new PdfPCell(new Phrase(x.pesa, bodyFont));
                descCell.HorizontalAlignment = 0;
                descCell.PaddingLeft = 10f;
                descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                itemTable.AddCell(descCell);

                PdfPCell qtyCell = new PdfPCell(new Phrase(x.precio, bodyFont));
                qtyCell.HorizontalAlignment = 0;
                qtyCell.PaddingLeft = 10f;
                qtyCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                itemTable.AddCell(qtyCell);

                PdfPCell amtCell = new PdfPCell(new Phrase(x.totalLinea, bodyFont));
                amtCell.HorizontalAlignment = 1;
                amtCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                itemTable.AddCell(amtCell);

            }
            // Table footer
            PdfPCell totalAmtCell1 = new PdfPCell(new Phrase(""));
            totalAmtCell1.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
            itemTable.AddCell(totalAmtCell1);
            PdfPCell totalAmtCell2 = new PdfPCell(new Phrase(""));
            totalAmtCell2.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
            itemTable.AddCell(totalAmtCell2);
            PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("Monto Total ", boldTableFont));
            totalAmtStrCell.Border = Rectangle.TOP_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
            totalAmtStrCell.HorizontalAlignment = 1;
            itemTable.AddCell(totalAmtStrCell);
          
            PdfPCell totalAmtCell = new PdfPCell(new Phrase( MontoTotalDinero.Text, boldTableFont));
            totalAmtCell.HorizontalAlignment = 1;
            itemTable.AddCell(totalAmtCell);

            PdfPCell cell = new PdfPCell(new Phrase("***Factura emitida por software Bajo Rojo del Pacifico S.A***", bodyFont));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1;
            itemTable.AddCell(cell);
            document.Add(itemTable);
            #endregion


            //Approved by
            PdfContentByte cb = new PdfContentByte(writer);
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            cb = writer.DirectContent;
            cb.BeginText();
            cb.SetFontAndSize(bf, 10);
            cb.SetTextMatrix(pageSize.GetLeft(300), 200);
            cb.ShowText("Aprobado por: ");
            cb.EndText();
            

            cb = new PdfContentByte(writer);
            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            cb = writer.DirectContent;
            cb.BeginText();
            cb.SetFontAndSize(bf, 10);
            cb.SetTextMatrix(pageSize.GetLeft(70), 100);
            cb.ShowText("Factura impresa por Bajo Rojo del Pacifico Sociedad Anonima.");
            cb.EndText();

            writer.CloseStream = false; //set the closestream property
                                        // Close the Document without closing the underlying stream
            document.Close();
           
        }
        

        private void CrearDatos(string embarcacion) {
            if (embarcacion=="Don Emi")
            {
                 nombreCliente = "Gustavo Lara Lopez";
                 cedulaCliente = "5-301-980";
                 telefonoCliente = "8593-8786";
                 direccionCliente = "";
                 numeroMatricula = "GPC-8525";
            }

            if (embarcacion == "Gemelo") {
                nombreCliente = "Gustavo Lara Lopez";
                cedulaCliente = "5-301-980";
                telefonoCliente = "8593-8786";
                direccionCliente = "";
                numeroMatricula = "P-12863";
            }

            if (embarcacion == "Santa Cruz") {
                nombreCliente = "Elizabeth Garcia Aleman";
                cedulaCliente = "5-0376-0044";
                telefonoCliente = "8527-2975";
                direccionCliente = "De la Escuela de Cuajiniquil, 350 Mts. Suroeste, Cuajiniquil,La Cruz, Guanacaste.";
                numeroMatricula = "P-094";
            }

            if (embarcacion == "Punta Blanca N") {
                nombreCliente = "Jordan Lopez Lopez";
                cedulaCliente = "5-0433-0308";
                telefonoCliente = "2679-1261 . Cel.: 8834-1743";
                direccionCliente = "Detras de Supercompro, Cuajiniquil, La Cruz, Guanacaste.";
                numeroMatricula = "P-12720";
            }

            if (embarcacion == "La Tania") {
                nombreCliente = "Pedro Celestino Lara Carmona";
                cedulaCliente = "5-150-273";
                telefonoCliente = "2679-1009";
                direccionCliente = "De la Escuela Aguas Calientes 500 mts. Sur Cuajiniquil,La Cruz, Guanacaste.";
                numeroMatricula = "GPC-1637";

            }
            if (embarcacion == "Uzziel") {
                nombreCliente = "Jordan Lopez Lopez";
                cedulaCliente = "5-0433-0308";
                telefonoCliente = "2679-1261 . Cel.: 8834-1743";
                direccionCliente = "Detras de Supercompro, Cuajiniquil, La Cruz, Guanacaste.";
                numeroMatricula = "PG-6934";
            }
            if (embarcacion == "Dasnet") {
                nombreCliente = "Migel Bermudez Juarez";
                cedulaCliente = "9-096-424";
                telefonoCliente = "2679-1017";
                direccionCliente = "2 K. antes de la entrada de Cuajiniquil La Cruz, Guanacaste.";
                numeroMatricula = "GPC-8025";
            }
            if (embarcacion == "Darien Lg") {
                nombreCliente = "Vilma Garcia Lobo";
                cedulaCliente = "5-312-521";
                telefonoCliente = "8722-6596";
                direccionCliente = "Costado Oeste de Licorera Los Corrales,Cuajiniquil,La Cruz,Guanacaste.";
                numeroMatricula = "PG 8534";
            }
            if (embarcacion == "Don Pedro") {
                nombreCliente = "Pedro Celestino Lara Carmona";
                cedulaCliente = "5-150-273";
                telefonoCliente = "2679-1009";
                direccionCliente = "De la Escuela Aguas Calientes 500 mts. Sur Cuajiniquil,La Cruz, Guanacaste.";
                numeroMatricula = "GPC-8701";
            }
            if (embarcacion == "Lady Liz") {
                nombreCliente = "LADY LIZ DEL MAR, S.A";
                cedulaCliente = "3-101-518534";
                telefonoCliente = "2661-2545  . Fax: 2662-1535";
                direccionCliente = "Barrio El Carmen, Puntarenas";
                numeroMatricula = "P-4648";
            }
            if (embarcacion == "Danny 2") {
                nombreCliente = "";
                cedulaCliente = "";
                telefonoCliente = "";
                direccionCliente = "";
                numeroMatricula = "";

            }
            if (embarcacion == "Bajo Rojo") {
                nombreCliente = "Bajo Rojo del Pacifico S.A";
                cedulaCliente = "3-101-715950";
                telefonoCliente = "2679-1023";
                direccionCliente = "1 Km oeste de la terminal pesquera Puerto de Mora.";
                numeroMatricula = "No aplica.";

            }



        }
    }
}
