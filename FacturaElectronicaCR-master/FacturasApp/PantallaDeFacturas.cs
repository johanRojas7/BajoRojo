using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace FacturasApp
{
    public partial class PantallaDeFacturas : Form
    {
        public PantallaDeFacturas()
        {
            InitializeComponent();
        }

        private void botonBuscarLiquidacion_Click(object sender, EventArgs e)
        {

            string embarcacion = comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString();

            BajoDatos.FacturasDatos nuevaBusqueda = new BajoDatos.FacturasDatos();
            datos.DataSource = nuevaBusqueda.Buscar(embarcacion);
            llenarTablaDT();



            
        }

        private void llenarTablaDT() {
            int contador = 1;
            foreach (DataGridViewRow fila in datos.Rows)
            {
                if (datos.Rows.Count - 1 >= contador)
                {

            dt.Rows.Add(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), fila.Cells[2].Value.ToString(),"Imprimir");

                }

                contador++;


            }


            }


        private string buscarFactura(string id) {
            string factura = "";

            int contador = 1;
            foreach (DataGridViewRow fila in datos.Rows)
            {
                if (datos.Rows.Count - 1 >= contador)
                {



                    if (fila.Cells[0].Value.ToString()==id) {

                        factura = fila.Cells[3].Value.ToString();
                    }

                }

                contador++;


            }

            return factura;
        }

        private void dt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dt.Columns[e.ColumnIndex].Name == "ii")
            {
                string nombre = (string)this.dt.Rows[e.RowIndex].Cells["id"].Value;
                
               //ENVIAR STRING NOMBRE A FACTURA

                MessageBox.Show(buscarFactura(nombre));
              //  CrearDocumento(buscarFactura(nombre));
            }
        }

        private void Imprimir() {
            System.Diagnostics.Process.Start(@"C:\Users\johan\Documents\Bajo Rojo\prueba.pdf");
        }

        private void CrearDocumento(string datos) {

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\johan\Documents\Bajo Rojo\prueba.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Factura control de pesas");
            doc.AddCreator("Bajo Rojo del pacifico s.a");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Factura control de pesas"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Embarcacion", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Total de pesas", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("Total de kg", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            

            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblPrueba);



            doc.Close();
            writer.Close();



        }
    }
}
