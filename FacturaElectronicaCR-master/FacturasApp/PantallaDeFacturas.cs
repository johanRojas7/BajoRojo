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

            try
            {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }


                if (todo.Checked) {

                    BajoDatos.FacturasDatos busquedaGeneral = new BajoDatos.FacturasDatos();
                    datos.DataSource = busquedaGeneral.BuscarTodos();
                    GenerarTodos();

                }


                if (individual.Checked) {
                    BajoDatos.FacturasDatos busquedaGeneral = new BajoDatos.FacturasDatos();
                    datos.DataSource = busquedaGeneral.Buscar(comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString());
                    Especifico();
                }

               
            }

            catch {
                MessageBox.Show("Ocurrio un error. Verifique bien embarcacion seleccionada.");


            }

            
        }


        private void Especifico() {
            List<objeto> lista = new List<objeto>();

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
                            if (x.embarca == fila.Cells[1].Value.ToString())
                            {

                                x.monto = x.monto + Convert.ToDouble(fila.Cells[2].Value.ToString());
                                SeEncontroAlgo = true;
                            }

                        }
                        catch { }


                    }
                    if (SeEncontroAlgo == false)
                    {
                        objeto nuevo = new objeto(fila.Cells[1].Value.ToString(), Convert.ToDouble(fila.Cells[2].Value.ToString()));
                        lista.Add(nuevo);
                    }
                    if (SeEncontroAlgo == true) { SeEncontroAlgo = false; }






                }
                catch { }

            }
            double rangoMayor = ObtenerMayor(lista);
            foreach (var j in lista)
            {
               
                this.chart1.Series["KG"].Points.AddXY(j.embarca, map(j.monto, 0, rangoMayor, 0, 100));

            }



        }

        private void GenerarTodos() {
            List<objeto> lista = new List<objeto>();

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
                            if (x.embarca == fila.Cells[0].Value.ToString())
                            {

                                x.monto = x.monto + Convert.ToDouble(fila.Cells[2].Value.ToString());
                                SeEncontroAlgo = true;
                            }

                        }
                        catch { }


                    }
                    if (SeEncontroAlgo == false)
                    {
                        objeto nuevo = new objeto(fila.Cells[0].Value.ToString(),Convert.ToDouble(fila.Cells[2].Value.ToString()));
                        lista.Add(nuevo);
                    }
                    if (SeEncontroAlgo == true) { SeEncontroAlgo = false; }






                }
                catch { }

            }

            double rangoMayor = ObtenerMayor(lista);

            foreach (var j in lista) {
              
            this.chart1.Series["KG"].Points.AddXY(j.embarca, map(j.monto, 0,rangoMayor, 0, 100));

            }


        }


        private double ObtenerMayor(List<objeto> lista) {
            double resultado = 0;

            foreach (var x in lista) {

                if (x.monto > resultado) {
                    resultado = x.monto;
                }

            }

            return resultado;
        }
     

        private double map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

     
    }
}
