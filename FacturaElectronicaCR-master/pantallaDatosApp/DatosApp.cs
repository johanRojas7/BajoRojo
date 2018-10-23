using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;

namespace pantallaDatosApp
{
    public partial class DatosApp : Form
    {
        public DatosApp()
        {
            InitializeComponent();
        }

        private void DatosApp_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((txtPesas.Text == "") || (txtFolderSalidaLiquidaciones.Text == ""))
            {
                MessageBox.Show("Algun campo esta vacio");

            }
            else
            {
                liquidacion();
            }
 


        }

        public List<liquidaciones> liquidacion(){
           

 List<liquidaciones> lista = new List<liquidaciones>();



            char[] delimitadores = { ','};

            string fichero = txtFolderSalidaLiquidaciones.Text;
            string contenido = String.Empty;
           

            if (File.Exists(fichero))
            {
                contenido = File.ReadAllText(fichero);
                string[] lineas = contenido.Split(delimitadores);
                int contador = 0;
                string embarca = "";
                 string deta = "";
                  string proce = "";
                string mon = "";
                foreach (string linea in lineas)
                {
                    if (contador == 4) { contador = 0; }
                    if (contador == 3)
                    {
                        mon = linea;

                        liquidaciones nuevaLiquidacion = new liquidaciones(embarca, deta, proce, mon);

                        contador = 4;
                        lista.Add(nuevaLiquidacion);
                        embarca = "";
                        deta = "";
                        proce = "";
                        mon = "";

                    }

                    if (contador == 2)
                    {
                        contador = contador + 1;
                        
                        proce = linea;
                    }
                    if (contador == 1)
                {
                    
                    contador = contador + 1;
                    deta = linea;
                }

                if (contador == 0)
                {
                   
                    embarca = linea;
                    contador = contador + 1;

                }
                

                }
                

            }


            foreach (var x in lista) {
                MessageBox.Show("Nombre de la embarcacion: "+x.embarcacion+" Detalle: "+x.detalle+" Procedencia: "+x.procedencia+" Monto:"+x.monto);
                
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
