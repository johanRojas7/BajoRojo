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
        public pantallaPesas()
        {
            InitializeComponent();
        }


        private void Actualizar() {

            Double sumatoriaDinero = Convert.ToDouble(TotalMarlinBlanco.Text) + Convert.ToDouble(TotalMarlinRosado.Text) + Convert.ToDouble(TotalCornudaRosa.Text)
                + Convert.ToDouble(TotalVela.Text) + Convert.ToDouble(TotalEspada.Text) + Convert.ToDouble(TotalDoradoPrimera.Text) + Convert.ToDouble(TotalDoradoSegunda.Text)
                + Convert.ToDouble(TotalDorado36.Text) + Convert.ToDouble(TotalDorado13.Text) + Convert.ToDouble(TotalDoradoFlaco.Text) + Convert.ToDouble(TotalBolillo.Text) +
                Convert.ToDouble(TotalAleta.Text) + Convert.ToDouble(TotalEspadaNacional.Text) ;


            Double sumatoriaPesas = Convert.ToDouble(MBlanco.Text)+
           Convert.ToDouble(Mrosado.Text)+
           Convert.ToDouble(CRosado.Text)+
           Convert.ToDouble(vela.Text)+
           Convert.ToDouble(esp.Text)+
           Convert.ToDouble(D1.Text)+
           Convert.ToDouble(D2.Text)+
           Convert.ToDouble(D3.Text)+
           Convert.ToDouble(D13.Text)+
           Convert.ToDouble(DF.Text)+
           Convert.ToDouble(BO.Text)+
           Convert.ToDouble(AL.Text)+
           Convert.ToDouble(EN.Text);


            MontoTotalDinero.Text = Convert.ToString(sumatoriaDinero);
            MontoTotalPesasKg.Text = Convert.ToString(sumatoriaPesas);


        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            String embarcacion = comboBoxEmbarcacion.SelectedItem.ToString();
            PMarlinBlanco.Text = "";
            PMarlinRosado.Text = "";
            PCornudaRosa.Text = "";
            PPezVela.Text = "";
            PPezEspada.Text = "";
            PDoradoDePrimera.Text = "";
            PDoradoDeSegunda.Text = "";
            PDorado36.Text = "";
            PDorado13.Text = "";
            PDoradoFlaco.Text = "";
            PBolillo.Text = "";
            PAleta.Text = "";
            PEspadaNacional.Text = "";

            BajoDatos.PesasDatos nuevaBusqueda = new BajoDatos.PesasDatos();
            datos.DataSource = nuevaBusqueda.Buscar(embarcacion);
           
            datos.Columns.Remove("Embarcacion");
            arreglarDatos();

           

        }

        private void crearNuevaTabla(double MarlinBlanco,double MarlinRosado,double CornudaRosa,
        double Vela , double Espada , double Dorado1, double Dorado2, double Dorado3, double EspadaNacional,
        double Dorado12, double DoradoFlaco, double Bolillo, double Aleta) {

            MBlanco.Text = Convert.ToString(MarlinBlanco);
            Mrosado.Text = Convert.ToString(MarlinRosado);
            CRosado.Text = Convert.ToString(CornudaRosa);
            vela.Text = Convert.ToString(Vela);
            esp.Text = Convert.ToString(Espada);
            D1.Text = Convert.ToString(Dorado1);
            D2.Text = Convert.ToString(Dorado2);
            D3.Text = Convert.ToString(Dorado3);
            D13.Text = Convert.ToString(Dorado12);
            DF.Text = Convert.ToString(DoradoFlaco);
            BO.Text = Convert.ToString(Bolillo);
            AL.Text = Convert.ToString(Aleta);
            EN.Text = Convert.ToString(EspadaNacional);

           

        




     
        }

        private void arreglarDatos() {

            


            double MarlinBlanco = 0;
            double MarlinRosado = 0;
            double CornudaRosa = 0;
            double Vela = 0;
            double Espada = 0;
            double Dorado1 = 0;
            double Dorado2 = 0;
            double Dorado3 = 0;
            double EspadaNacional = 0;
            double Dorado12 = 0;
            double DoradoFlaco = 0;
            double Bolillo = 0;
            double Aleta = 0;
            int contador = 1;
            foreach (DataGridViewRow fila in datos.Rows)
            {

               
                if (datos.Rows.Count-1 >= contador)
                {
                    
                    if (fila.Cells[0].Value.ToString()== "MarlinBlanco")
                    {

                        MarlinBlanco = MarlinBlanco +Convert.ToDouble(fila.Cells[1].Value.ToString());
                       

                    }else
                    if (fila.Cells[0].Value.ToString().Equals("MarlinRosado"))
                    {

                        MarlinRosado = MarlinRosado + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }else
                    if (fila.Cells[0].Value.ToString().Equals("CornudaRosa"))
                    {

                        CornudaRosa = CornudaRosa + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }
                    if (fila.Cells[0].Value.ToString().Equals("Vela"))
                    {

                        Vela = Vela + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }
                    if (fila.Cells[0].Value.ToString().Equals("Espada1/2"))
                    {

                        Espada = Espada + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }
                    if (fila.Cells[0].Value.ToString().Equals("Dorado1"))
                    {

                        Dorado1 = Dorado1 + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }
                    if (fila.Cells[0].Value.ToString().Equals("Dorado2"))
                    {

                        Dorado2 = Dorado2 + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }
                    if (fila.Cells[0].Value.ToString().Equals("Dorado3-6"))
                    {

                        Dorado3 = Dorado3 + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }
                    if (fila.Cells[0].Value.ToString().Equals("EspadaNacional"))
                    {

                        EspadaNacional = EspadaNacional + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }
                    if (fila.Cells[0].Value.ToString().Equals("Dorado1-3"))
                    {

                        Dorado12 = Dorado12 + Convert.ToDouble(fila.Cells[1].Value.ToString());
                    }

                    if (fila.Cells[0].Value.ToString().Equals("DoradoFlaco"))
                    {

                        DoradoFlaco = DoradoFlaco + Convert.ToDouble(fila.Cells[1].Value.ToString());

                    }

                    if (fila.Cells[0].Value.ToString().Equals("Bolillo"))
                    {

                        Bolillo = Bolillo + Convert.ToDouble(fila.Cells[1].Value.ToString());

                    }

                    if (fila.Cells[0].Value.ToString().Equals("Aleta"))
                    {

                        Aleta = Aleta + Convert.ToDouble(fila.Cells[1].Value.ToString());

                    }

                }
                contador++;

            }

            crearNuevaTabla(MarlinBlanco,MarlinRosado,CornudaRosa, Vela,Espada ,
           Dorado1,Dorado2, Dorado3, EspadaNacional , Dorado12, DoradoFlaco,
          Bolillo, Aleta);

        }

        private void cambioMarlinBlanco(object sender, EventArgs e)
        {
            TotalMarlinBlanco.Text = "0";
            try {

                TotalMarlinBlanco.Text =Convert.ToString( Convert.ToDouble(MBlanco.Text) * Convert.ToDouble(PMarlinBlanco.Text));
            }
            catch {
                TotalMarlinBlanco.Text = "0";
            }

            Actualizar();


        }

        private void PMarlinRosado_TextChanged(object sender, EventArgs e)
        {

            TotalMarlinRosado.Text = "0";
            try
            {

                TotalMarlinRosado.Text = Convert.ToString(Convert.ToDouble(Mrosado.Text) * Convert.ToDouble(PMarlinRosado.Text));
            }
            catch
            {
                TotalMarlinRosado.Text = "0";
            }
            Actualizar();
        }

        private void PCornudaRosa_TextChanged(object sender, EventArgs e)
        {

            TotalCornudaRosa.Text = "0";
            try
            {

                TotalCornudaRosa.Text = Convert.ToString(Convert.ToDouble(CRosado.Text) * Convert.ToDouble(PCornudaRosa.Text));
            }
            catch
            {
                TotalCornudaRosa.Text = "0";
            }

            Actualizar();
        }

        private void PPezVela_TextChanged(object sender, EventArgs e)
        {

            TotalVela.Text = "0";
            try
            {

                TotalVela.Text = Convert.ToString(Convert.ToDouble(vela.Text) * Convert.ToDouble(PPezVela.Text));
            }
            catch
            {
                TotalVela.Text = "0";
            }

            Actualizar();

        }

        private void PPezEspada_TextChanged(object sender, EventArgs e)
        {
            TotalEspada.Text = "0";
            try
            {

                TotalEspada.Text = Convert.ToString(Convert.ToDouble(esp.Text) * Convert.ToDouble(PPezEspada.Text));
            }
            catch
            {
                TotalEspada.Text = "0";
            }
            Actualizar();
        }

        private void PDoradoDePrimera_TextChanged(object sender, EventArgs e)
        {
            TotalDoradoPrimera.Text = "0";
            try
            {

                TotalDoradoPrimera.Text = Convert.ToString(Convert.ToDouble(D1.Text) * Convert.ToDouble(PDoradoDePrimera.Text));
            }
            catch
            {
                TotalDoradoPrimera.Text = "0";
            }
            Actualizar();
        }

        private void PDoradoDeSegunda_TextChanged(object sender, EventArgs e)
        {
            TotalDoradoSegunda.Text = "0";
            try
            {

                TotalDoradoSegunda.Text = Convert.ToString(Convert.ToDouble(D2.Text) * Convert.ToDouble(PDoradoDeSegunda.Text));
            }
            catch
            {
                TotalDoradoSegunda.Text = "0";
            }
            Actualizar();
        }

        private void PDorado36_TextChanged(object sender, EventArgs e)
        {
            TotalDorado36.Text = "0";
            try
            {

                TotalDorado36.Text = Convert.ToString(Convert.ToDouble(D3.Text) * Convert.ToDouble(PDorado36.Text));
            }
            catch
            {
                TotalDorado36.Text = "0";
            }

            Actualizar();
        }

        private void PDorado13_TextChanged(object sender, EventArgs e)
        {
            TotalDorado13.Text = "0";
            try
            {

                TotalDorado13.Text = Convert.ToString(Convert.ToDouble(D13.Text) * Convert.ToDouble(PDorado13.Text));
            }
            catch
            {
                TotalDorado13.Text = "0";
            }

            Actualizar();
        }

        private void PDoradoFlaco_TextChanged(object sender, EventArgs e)
        {
            TotalDoradoFlaco.Text = "0";
            try
            {

                TotalDoradoFlaco.Text = Convert.ToString(Convert.ToDouble(DF.Text) * Convert.ToDouble(PDoradoFlaco.Text));
            }
            catch
            {
                TotalDoradoFlaco.Text = "0";
            }

            Actualizar();
        }

        private void PBolillo_TextChanged(object sender, EventArgs e)
        {
            TotalBolillo.Text = "0";
            try
            {

                TotalBolillo.Text = Convert.ToString(Convert.ToDouble(BO.Text) * Convert.ToDouble(PBolillo.Text));
            }
            catch
            {
                TotalBolillo.Text = "0";
            }

            Actualizar();
        }

        private void PAleta_TextChanged(object sender, EventArgs e)
        {
            TotalAleta.Text = "0";
            try
            {

                TotalAleta.Text = Convert.ToString(Convert.ToDouble(AL.Text) * Convert.ToDouble(PAleta.Text));
            }
            catch
            {
                TotalAleta.Text = "0";
            }

            Actualizar();
        }

        private void PEspadaNacional_TextChanged(object sender, EventArgs e)
        {
            TotalEspadaNacional.Text = "0";
            try
            {

                TotalEspadaNacional.Text = Convert.ToString(Convert.ToDouble(EN.Text) * Convert.ToDouble(PEspadaNacional.Text));
            }
            catch
            {
                TotalEspadaNacional.Text = "0";
            }
            Actualizar();
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
                String leyenda = "Tipo de Pescado     "+"Total Pesa"+    "    "+"Precio Por Kg    "+ "Total Monto de linea";
                leyenda=leyenda+ "Marlin Blanco       "+  MBlanco.Text+  "    "+PMarlinBlanco.Text+"   "+TotalMarlinBlanco.Text+ "\n\r";
                leyenda=leyenda+ "Marlin Rosado       " + Mrosado.Text + "    " + PMarlinRosado.Text + "   " + TotalMarlinRosado.Text + "\n\r";
                leyenda=leyenda+ "Cornuda Rosa        " + CRosado.Text + "    " + PCornudaRosa.Text + "   " + TotalCornudaRosa.Text + "\n\r";
                leyenda=leyenda+ "Vela                " + vela.Text +    "    " + PPezVela.Text + "   " + TotalVela.Text + "\n\r";
                leyenda=leyenda+ "Espada              " + esp.Text +     "    " + PPezEspada.Text + "   " + TotalEspada.Text + "\n\r";
                leyenda=leyenda+ "Dorado de primera   " + D1.Text +      "    " + PDoradoDePrimera.Text + "   " + TotalDoradoPrimera.Text + "\n\r";
                leyenda=leyenda+ "Dorado de segunda   " + D2.Text +      "    " + PDoradoDeSegunda.Text + "   " + TotalDoradoSegunda.Text + "\n\r";
                leyenda=leyenda+ "Dorado 3-6          " + D3.Text +      "    " + PDorado36.Text + "   " + TotalDorado36.Text + "\n\r";
                leyenda=leyenda+ "Dorado 1-3          " + D13.Text +     "    " + PDorado13.Text + "   " + TotalDorado13.Text + "\n\r";
                leyenda=leyenda+ "Dorado Flado        " + DF.Text +      "    " + PDoradoFlaco.Text + "   " + TotalDoradoFlaco.Text + "\n\r";
                leyenda=leyenda+ "Bolillo             " + BO.Text +      "    " + PBolillo.Text + "   " + TotalBolillo.Text + "\n\r";
                leyenda=leyenda+ "Aleta               " + AL.Text +      "    " + PAleta.Text + "   " + TotalAleta.Text + "\n\r";
                leyenda=leyenda+ "Espada Nacional     " + EN.Text +      "    " + PEspadaNacional.Text + "   " + TotalEspadaNacional.Text + "\n\r";
                leyenda = leyenda + "Monto total de factura: ₡"+MontoTotalDinero.Text;


                //Guarda en base de datos
                bool fun = nuevaFactura.Insertar(fechaActual, embarcacion,leyenda);
                if (fun == true) {

                    
                    //Limpiar todos los datos.
                    BajoDatos.PesasDatos eliminarPesa = new BajoDatos.PesasDatos();
                    eliminarPesa.Eliminar(embarcacion);
                    //TAMBIEN HAY QUE ENVIAR CALCULOS PARA LIQUIDACIONES



                } else { MessageBox.Show("Error a la hora de guardar"); }
                

            }



            }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
