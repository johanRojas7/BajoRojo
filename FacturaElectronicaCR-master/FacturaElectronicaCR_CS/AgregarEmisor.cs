using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturaElectronicaCR_CS
{
    public partial class AgregarEmisor : Form
    {
        public AgregarEmisor()
        {
            InitializeComponent();
        }

        private void AgregarEmisor_Load(object sender, EventArgs e)
        {

        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            if (camposVacios() == true) { MessageBox.Show("Hay campos que estan vacios o incorrectos"); }
            else {
                //Extrae todos los datos del formulario y los devuelve como un objeto Emisor.
                ClasesDatos.Emisor nuevoEmisor;
                nuevoEmisor = conversorDeDatos();
                String emisorDeEmbarcacionAGuardar = comboEmbarcacion.SelectedItem.ToString();



                if (nuevoEmisor == null) { MessageBox.Show("Lo sentimos no se logro guardar la informacion."); }
                else {
                    String y = "Correo: " + nuevoEmisor.CorreoElectronico + " ID " + nuevoEmisor.Identificacion_Numero + " Tipo id " + nuevoEmisor.Identificacion_Tipo;
                    //Limpia luego los datos del formulario.
                    limpiarDatos();
                    //Entonces se procede a guardar los datos de acuerdo al emisor
                    textostrarEmisor.Text = y;

                    MessageBox.Show("Guardado exitosamente.");

                }



               
            }




        }

        private ClasesDatos.Emisor conversorDeDatos() {

            String nombre=textNombreTributante.Text;
            String tipoID="NINGUNO";

            

            if (comboTipoID.SelectedItem.ToString().Equals("Cedula Fisica")) { tipoID = "01"; }
            if (comboTipoID.SelectedItem.ToString().Equals("Cedula Juridica")) { tipoID = "02"; }
            if (comboTipoID.SelectedItem.ToString().Equals("DIMEX")) { tipoID = "03"; }
            if (comboTipoID.SelectedItem.ToString().Equals("NITE")) { tipoID = "04"; }

            Boolean numeroCorrecto = true;
            String numeroID="00"+textNumeroID.Text;
            String provincia="5";
            String canton="01";   
            String distrito="04"; //SANTA ELENA
            String barrio="02";
            String otras=textOtrasSenas.Text;
            int numeroTel=0;
            try {  numeroTel = Int32.Parse(textNumeroTel.Text);


            }catch {
                numeroCorrecto = false;
                MessageBox.Show("El formato del numero de telefono que ingreso es incorrecto."); }
            
            String correo=textCorreoElectronico.Text;


           ClasesDatos.Emisor nuevoEmisor = new ClasesDatos.Emisor(nombre,tipoID,numeroID,provincia,canton,distrito,barrio,otras,"506",numeroTel,correo);

            if (numeroCorrecto == false) { nuevoEmisor = null; }
            

            return nuevoEmisor;
        }

        private void limpiarDatos() {
            comboEmbarcacion.SelectedItem = null;
            textNombreTributante.Text= "";
            comboTipoID.SelectedItem = null;
            textNumeroID.Text = "";
           
            textOtrasSenas.Text = "";
            textNumeroTel.Text = "";
            textCorreoElectronico.Text = "";




        }


        private Boolean camposVacios() {
            Boolean campos = false;

if(comboEmbarcacion.SelectedItem==null || textNombreTributante.Text=="" || comboTipoID.SelectedItem==null|| textNumeroID.Text == "" || textOtrasSenas.Text == "" || textNumeroTel.Text == "" || textCorreoElectronico.Text == "")
            {
                campos = true;
            }
            else
            {

                campos = false;
            }



            return campos;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            String buscarEstaEmbarcacion = comboEmbarcacionBuscar.SelectedItem.ToString();


            //Aqui se busca y se devuelve de la base de datos la informacion



        }
    }
}
