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

        string liquidacionMostrar = "";
        string pesasMostrar = "";
        public DatosApp()
        {
            InitializeComponent();
        }

        private void DatosApp_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            pesasMostrar = "";
            liquidacionMostrar = "";
            if ((txtPesas.Text == "") || (txtFolderSalidaLiquidaciones.Text == ""))
            {
                MessageBox.Show("Algun campo esta vacio.");

            }
            else
            {


                foreach (var x in liquidacion())
                {

                    liquidacionMostrar= liquidacionMostrar + "Embarcacion: " + x.embarcacion.ToString() + " Detalle: " + x.detalle + " Procedencia: " + x.procedencia + " Monto:" + x.monto+"\n";
                   // MessageBox.Show("Embarcacion: " + x.embarcacion.ToString()+" Detalle: " + x.detalle+" Procedencia: "+x.procedencia+" Monto:"+x.monto);
                   
                }

                foreach (var x in pesasEmbarcaciones())
                {
                    pesasMostrar = pesasMostrar + "Embarcacion: " + x.embarcacion.ToString() + " Detalle: " + x.tipoPescado + " Pesa: " + x.pesa;
                   // MessageBox.Show("Embarcacion: " + x.embarcacion.ToString() + " Detalle: " + x.tipoPescado + " Pesa: " + x.pesa);

                }

            
            }
 


        }



        //Permite cargar en una lista las liquidaciones que se encuentran en un txt
        public List<liquidaciones> liquidacion(){
           

 List<liquidaciones> lista = new List<liquidaciones>();



            char[] delimitadores = { '^'};

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


           


            return lista;
}


        //Permite cargar en una lista las pesas que se encuentran en un txt
        public List<pesas> pesasEmbarcaciones() {


            List<pesas> lista = new List<pesas>();



            char[] delimitadores = { '^' };

            string fichero = txtPesas.Text;
            string contenido = String.Empty;


            if (File.Exists(fichero))
            {
                contenido = File.ReadAllText(fichero);
                string[] lineas = contenido.Split(delimitadores);
                int contador = 0;


                string embarca = "";
                string tipoPescado = "";
                string pesa = "";
              
                foreach (string linea in lineas)
                {
                    if (contador == 3) { contador = 0; }


                    if (contador == 2)
                    {
                        pesa = linea;

                        pesas nuevaPesa = new pesas(embarca, tipoPescado, pesa);

                        contador = 3;
                        lista.Add(nuevaPesa);
                        embarca = "";
                        tipoPescado = "";
                        pesa = "";
                       

                    }

                   
                    if (contador == 1)
                    {

                        contador = contador + 1;
                        tipoPescado = linea;
                    }

                    if (contador == 0)
                    {

                        embarca = linea;
                        contador = contador + 1;

                    }


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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("No hay informacion Para Guardar"); }

            else {

                DialogResult dialogResult = MessageBox.Show("Esta apunto de guardar esta informacion, esta seguro realizarlo ", "Bajo Rojo del Pacifico ", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    MessageBox.Show("Guardado exitosamente");

                    //AQUI SE LLAMA A LA BASE DE DATOS Y SE GUARDAN LOS DATOS QUE SE ENCUENTRAN EN LA LISTA.
                    txtFolderSalidaLiquidaciones.Text = "";
                    txtPesas.Text = "";




                }
                else if (dialogResult == DialogResult.No)
                {
                    txtFolderSalidaLiquidaciones.Text = "";
                    txtPesas.Text = "";
                    textBox1.Text = "";
                    MessageBox.Show("Proceso cancelado");
                }

               


            }
        }

        private void radioLiq_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = liquidacionMostrar;
        }

        private void radioPesas_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = pesasMostrar;
            
        }
    }
}
