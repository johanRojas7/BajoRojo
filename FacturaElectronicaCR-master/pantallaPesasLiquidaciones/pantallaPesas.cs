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

            String embarcacion = comboBoxEmbarcacion.SelectedItem.ToString();


            BajoDatos.PesasDatos nuevaBusqueda = new BajoDatos.PesasDatos();
            datos.DataSource = nuevaBusqueda.Buscar(embarcacion);

            datos.Columns.Remove("Embarcacion");
            CrearLista();

            foreach (var j in lista) {
                MessageBox.Show("Pez: "+j.pez+"\n"+"Pesa total: "+ j.monto);

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
                BajoDatos.FacturasDatos nuevaFactura = new BajoDatos.FacturasDatos();


                DateTime hoy = DateTime.Now;
                string fechaActual = hoy.ToString("dd-MM-yyyy");
                string embarcacion = comboBoxEmbarcacion.SelectedItem.ToString();
             


                //Guarda en base de datos
                bool fun = nuevaFactura.Insertar(fechaActual, embarcacion,"");
                if (fun == true) {
                  
                   
                    MessageBox.Show("Almacenado correctamente");
                        
    

                } else { MessageBox.Show("Error a la hora de guardar"); }
                

            }



            }

      
    }
}
