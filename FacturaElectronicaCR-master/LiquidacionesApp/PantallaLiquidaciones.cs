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

        public string fechaSeleccionada;
        public PantallaLiquidaciones()
        {
            InitializeComponent();
        }

        private void botonBuscarPesa_Click(object sender, EventArgs e)
        {
            String embarcacion = comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString();
            
            
                BajoDatos.LiquidacionesDatos nuevaBusqueda = new BajoDatos.LiquidacionesDatos();
                datos.DataSource = nuevaBusqueda.BuscarRegistro(embarcacion);
                datos.Columns.Remove("embarcacion");
            
            
           // total();


        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            String embarcacion = combo.SelectedItem.ToString();
            //Crear nueva liquidacion

            DialogResult dialogResult = MessageBox.Show("Desea crear una nueva hoja de alistos? ", "Bajo Rojo del Pacifico ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                if (embarcacion != "")
                {


                    DateTime hoy = DateTime.Now;
                    string fechaActual = hoy.ToString("dd-MM-yyyy");
                    try
                    {
                        BajoDatos.LiquidacionesDatos nuevaLiquidacion = new BajoDatos.LiquidacionesDatos();
                        nuevaLiquidacion.InsertarRegistro(embarcacion, fechaActual);

                        MessageBox.Show("Exito: Nueva hoja de liquidacion creada.");
                    }

                    catch
                    {

                        MessageBox.Show("Error: Ocurrio algo inesperado y no se creo la hoja de liquidacion.");
                    }
                }
                else {
                    MessageBox.Show("Debe seleccionar una embarcacion");

                }

            }


                

           


        }


        private void totalAPagar() {
            string resultado = "";

            resultado = Convert.ToString(Convert.ToDouble(totalAbonos.Text) - Convert.ToDouble(totalAlistos.Text));

            totalPagar.Text = String.Format("{0:n}", Convert.ToDouble(resultado));

        }

       


        private void datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.datos.Columns[e.ColumnIndex].Name == "fecha")
            {

                try
                {
                    string fecha = (string)this.datos.Rows[e.RowIndex].Cells["fecha"].Value;
                    fechaSeleccionada = fecha;
                    llenarDatos2(fecha,comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString());
                    llenarTablaAbonos();
                    totalAlistos.Text = String.Format("{0:n}",Convert.ToDouble(Calculo()));
                    totalAbonos.Text = String.Format("{0:n}", Convert.ToDouble(CalculoAbonos()));
                    totalAPagar();
                }
                catch { MessageBox.Show("Error"); }


            }


        

        }

        private void llenarTablaAbonos() {
            try
            {
                BajoDatos.LiquidacionesDatos nuevaBusqueda = new BajoDatos.LiquidacionesDatos();
                datosAbono.DataSource = nuevaBusqueda.BuscarAbono(comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString(), fechaSeleccionada);
                datosAbono.Columns.Remove("embarcacion");
                datosAbono.Columns.Remove("fecha");
            }


            catch
            {

                MessageBox.Show("Error a la hora de buscar total abono");
            }


        }


        private void llenarDatos2(string fecha, string embarcacion)
        {
            try {
                BajoDatos.LiquidacionesDatos nuevaBusqueda = new BajoDatos.LiquidacionesDatos();
                datos2.DataSource = nuevaBusqueda.Buscar(embarcacion, fecha);
                datos2.Columns.Remove("embarcacion");
                datos2.Columns.Remove("fecha");
            }
            

            catch {

                MessageBox.Show("No hay datos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string resumen = "Resumen de liquidacion: "+"\n"+"Procedencia: "+procedencia.Text+"\n"+"Detalle: "+detalle.Text+"\n" +"Monto economico: ₡"+ String.Format("{0:n}",Convert.ToDouble(monto.Text));
            
            MessageBox.Show(resumen);

            DialogResult dialogResult = MessageBox.Show("Desea agregar esta nueva liquidacion?", "Bajo Rojo del Pacifico ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                if (comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString() == "" || fechaSeleccionada == "" || detalle.Text == "" || procedencia.Text == "" || monto.Text == "") { MessageBox.Show("Hay datos erroneos o vacios."); }
                else
                {
                    try
                    {
                        BajoDatos.LiquidacionesDatos nuevaBusqueda = new BajoDatos.LiquidacionesDatos();
                        nuevaBusqueda.Insertar(comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString(), fechaSeleccionada, detalle.Text, procedencia.Text, monto.Text);
                        datos.DataSource = null;
                        datos2.DataSource = null;
                        fechaSeleccionada = "";
                        detalle.Text = "";
                        procedencia.Text = "";
                        monto.Text = "";


                        MessageBox.Show("Liquidacion correctamente agregada.");
                    }
                    catch
                    {

                        MessageBox.Show("Error al insertar nueva liquidacion");
                    }
                }
            }
           
        }

        private string Calculo()
        {
            string resultado = "";
            double calculo = 0;
        
            foreach (DataGridViewRow fila in datos2.Rows)
            {


                try { calculo = calculo + Convert.ToDouble(fila.Cells[2].Value.ToString()); }
                catch { }
                    
                  
            }

            resultado = Convert.ToString(calculo);
            
            return resultado;
        }

        private string CalculoAbonos() {
            string abono = "";
            double calculo = 0;

            foreach (DataGridViewRow fila in datosAbono.Rows)
            {


                try { calculo = calculo + Convert.ToDouble(fila.Cells[0].Value.ToString()); }
                catch { }


            }

            abono = Convert.ToString(calculo);
           

            return abono;
        }

        

        private void botonMonto_Click(object sender, EventArgs e)


        {

            string resumen = "";
            resumen = "Resumen de abono."+"\n"+"Monto total: "+String.Format("{0:n}", Convert.ToDouble(montoEconomico.Text));
            MessageBox.Show(resumen);
            DialogResult dialogResult = MessageBox.Show("Desea agregar esta nuevo abono?", "Bajo Rojo del Pacifico ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (montoEconomico.Text == "") { MessageBox.Show("Debe de ingresar un monto economico"); }
                else
                {
                    try
                    {

                        BajoDatos.LiquidacionesDatos nuevoAbono = new BajoDatos.LiquidacionesDatos();
                        nuevoAbono.InsertarAbono(comboBoxEmbarcacionpLiquidacion.SelectedItem.ToString(), fechaSeleccionada, montoEconomico.Text);
                        MessageBox.Show("Agregado correctamente.");
                        montoEconomico.Text = "";


                    }
                    catch
                    {
                        MessageBox.Show("Error al ingresar datos");
                    }
                }
            }
        }
    }
}
