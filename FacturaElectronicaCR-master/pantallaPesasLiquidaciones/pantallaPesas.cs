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

namespace pantallaPesasLiquidaciones
{
    public partial class pantallaPesas : Form
    {
        List<objeto> lista;
        public pantallaPesas()
        {
            InitializeComponent();
        }


        private void botonBuscar_Click(object sender, EventArgs e)
        {
            datos2.Rows.Clear();
            String embarcacion = comboBoxEmbarcacion.SelectedItem.ToString();
            if (embarcacion == "Bajo Rojo")
            {
                //Aqui se procede a llenar la tabla normalmente solo que esta vez se accesa a una nueva tabla
                BajoDatos.PesasDatos nuevaBusqueda = new BajoDatos.PesasDatos();
                datos.DataSource = nuevaBusqueda.BuscarBajoRojo("A") ;

                datos.Columns.Remove("Embarcacion");
                CrearLista();

                foreach (var j in lista)
                {

                    datos2.Rows.Add(j.pez, Convert.ToString(j.monto), "", "");

                }

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

                }

                // ELIMINO DTOS DE EMBARCACION



                BajoDatos.FacturasDatos nuevaFactura = new BajoDatos.FacturasDatos();


                DateTime hoy = DateTime.Now;
                string fechaActual = hoy.ToString("dd-MM-yyyy");
                

                BajoDatos.PesasDatos eliminarPesa = new BajoDatos.PesasDatos();
                eliminarPesa.Eliminar(embarcacion);

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
                                        new FileStream(@"C:\Users\johan\Documents\Bajo Rojo\factura.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Factura control de pesas");
            doc.AddCreator("Bajo Rojo del pacifico s.a");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\johan\Documents\Bajo Rojo\Bajo.png");
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
            
            System.Diagnostics.Process.Start(@"C:\Users\johan\Documents\Bajo Rojo\factura.pdf");
           
        }

    }
}
