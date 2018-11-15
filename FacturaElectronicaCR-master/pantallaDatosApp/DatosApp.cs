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


using System.IO;
using CsvHelper;

namespace pantallaDatosApp
{
    public partial class pantallaDatosApp : Form
    {
        
        public pantallaDatosApp()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            if ((txtPesas.Text == "") || (txtFolderSalidaLiquidaciones.Text == ""))
            {
                MessageBox.Show("Algun campo esta vacio.");

            }
            else
            {

                DialogResult dialogResult = MessageBox.Show("Esta apunto de guardar esta informacion, esta seguro realizarlo ", "Bajo Rojo del Pacifico ", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    foreach (var x in pesasEmbarcaciones())
                    {
                        BajoDatos.PesasDatos nuevaPesa = new BajoDatos.PesasDatos();
                        nuevaPesa.Insertar(x.embarcacion.ToString(), x.tipoPescado.ToString(), x.pesa.ToString());

                    }

                    foreach (var y in liquidacion())
                    {
                        BajoDatos.LiquidacionesDatos nuevaLiquidacion = new BajoDatos.LiquidacionesDatos();
                        nuevaLiquidacion.Insertar(y.embarcacion.ToString(), y.detalle.ToString(), y.procedencia.ToString(), y.monto.ToString());

                    }

                    txtFolderSalidaLiquidaciones.Text = "";
                    txtPesas.Text = "";
                    

                }
                else if (dialogResult == DialogResult.No)
                {
                    txtFolderSalidaLiquidaciones.Text = "";
                    txtPesas.Text = "";
                   
                    MessageBox.Show("Proceso cancelado");
                }


            }



        }



        //Permite cargar en una lista las liquidaciones que se encuentran en un txt
        public List<liquidaciones> liquidacion() {


            List<liquidaciones> lista = new List<liquidaciones>();

            using (var reader = new StreamReader(txtFolderSalidaLiquidaciones.Text))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                   liquidaciones nuevaLiquidacion = new liquidaciones(values[0].Replace("\0", ""), values[1].Replace("\0", ""), values[2].Replace("\0", ""), values[3].Replace("\0", ""));
                    lista.Add(nuevaLiquidacion);
                   
                }
            }

            
            return lista;
        }

        //Permite cargar en una lista las pesas que se encuentran en un txt
        public List<pesas> pesasEmbarcaciones() {
            List<pesas> lista = new List<pesas>();
            
            using (var reader = new StreamReader(txtFolderSalidaLiquidaciones.Text))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    pesas nuevaPesa = new pesas(values[0].Replace("\0", ""), values[1].Replace("\0", ""), values[2].Replace("\0", ""));
                    lista.Add(nuevaPesa);

                }
            }
            
            return lista;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog iFile = new OpenFileDialog();
                iFile.ShowDialog();
                this.txtFolderSalidaLiquidaciones.Text = iFile.FileName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog iFile = new OpenFileDialog();
                iFile.ShowDialog();
                this.txtPesas.Text = iFile.FileName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
