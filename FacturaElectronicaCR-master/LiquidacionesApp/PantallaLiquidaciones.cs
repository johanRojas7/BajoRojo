using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiquidacionesApp
{
    public partial class PantallaLiquidaciones : Form
    {
        public PantallaLiquidaciones()
        {
            InitializeComponent();
        }

        private void botonBuscarPesa_Click(object sender, EventArgs e)
        {
            String embarcacion = comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString();

            BajoDatos.LiquidacionesDatos nuevaBusqueda = new BajoDatos.LiquidacionesDatos();
            datos.DataSource = nuevaBusqueda.Buscar(embarcacion);

            nombreEmbarcacion.Text = embarcacion;
            propietario.Text = PropietarioNombre(embarcacion);
            total();


        }

        private string PropietarioNombre(string embarcacion) {
            string nombre = "";
            if (embarcacion == "DonEmi") { nombre = "NOMBRE 1"; }
            if (embarcacion == "Gemelo") { nombre = "NOMBRE 2"; }
            if (embarcacion == "SantaCruz") { nombre = "NOMBRE 3"; }
            if (embarcacion == "PuntaBlancaN") { nombre = "NOMBRE 4"; }
            if (embarcacion == "LaTania") { nombre = "NOMBRE 5"; }
            if (embarcacion == "Uzziel") { nombre = "NOMBRE 6"; }
            if (embarcacion == "Dasnet") { nombre = "NOMBRE 7"; }
            if (embarcacion == "WilbertJose") { nombre = "NOMBRE 8"; }
            if (embarcacion == "DonPedro") { nombre = "NOMBRE 9"; }
            if (embarcacion == "LadyLiz") { nombre = "NOMBRE 10"; }
          



            return nombre;
        }


        private void total() {
            double x = 0;
            int contador = 1;
            foreach (DataGridViewRow fila in datos.Rows)
            {
                if (datos.Rows.Count - 1 >= contador)
                {

                  x=x+Convert.ToDouble( fila.Cells[3].Value.ToString());

                }

                contador++;


            }

            totalAlistos.Text = Convert.ToString(x);
        }




    }
}
