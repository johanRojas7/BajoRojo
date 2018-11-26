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

         
           
            if ((txtPesas.Text == ""))
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


                        MessageBox.Show("Datos guardados correctamente.");
                        txtPesas.Text = "";
                  
                   
                    
                    
                    

                }
                else if (dialogResult == DialogResult.No)
                {
                   
                    txtPesas.Text = "";
                   
                    MessageBox.Show("Proceso cancelado");
                }


            }



        }



        //Permite cargar en una lista las liquidaciones que se encuentran en un txt
        
        //Permite cargar en una lista las pesas que se encuentran en un txt
        public List<pesas> pesasEmbarcaciones() {
            List<pesas> lista = new List<pesas>();
            try
            {
                using (var reader = new StreamReader(txtPesas.Text))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        pesas nuevaPesa = new pesas(values[0].Replace("\0", ""), values[1].Replace("\0", ""), values[2].Replace("\0", ""));
                        lista.Add(nuevaPesa);

                    }
                }

            }
            catch {

            }
            return lista;

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

        private void txtPesas_TextChanged(object sender, EventArgs e)
        {

            string resultado = "";
            foreach (var x in pesasEmbarcaciones())
            {

                resultado = resultado + "Embarcacion: " + x.embarcacion.ToString() + ", Tipo de Pescado: " + x.tipoPescado.ToString() + ", Pesa: " + x.pesa.ToString()+ "\n";
              

            }

            richTextBox1.Text = resultado;
        
         

        }
    }
}
