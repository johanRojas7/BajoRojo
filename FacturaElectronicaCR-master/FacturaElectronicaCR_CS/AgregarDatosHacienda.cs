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
    public partial class AgregarDatosHacienda : Form
    {
        public AgregarDatosHacienda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (HayCamposVacios() == false)
            {

                try
                {
                    MessageBox.Show("Se envio la informacion");

                    //Guardar
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al intentar Guardar la informacion.");

                }
            }

            //Verifica si hay campos vacios, y si los hay lanza un mensaje
            if (HayCamposVacios() == true) { MessageBox.Show("Tiene campos vacios y/o incorrectos"); }

        }


        public Boolean HayCamposVacios() {
            //0 es igual a no
            // 1 es igual a si
            Boolean i = false;

            if ((txtFolderSalida.Text.Equals("") )|| (txtPathCertificado.Text == "") ||( txtCertificadoPIN.Text == "") ||( txtAPIClave.Text == "" )||( txtAPIUsuario.Text == "") || (comboEmbarcacion1.SelectedItem.Equals("")))
            {

                i = true;

            }
            else { i = false; }



            return i;
        }

        private void btnFolderSalida_Click(object sender, EventArgs e)
        {
            try
            {
                CargaFolderSalida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaFolderSalida()
        {
            try
            {
                FolderBrowserDialog iFolder = new FolderBrowserDialog();
                iFolder.ShowDialog();
                this.txtFolderSalida.Text = iFolder.SelectedPath;
                if (!this.txtFolderSalida.Text.EndsWith("\\"))
                {
                    this.txtFolderSalida.Text += "\\";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRutaCertificado_Click(object sender, EventArgs e)
        {
            try
            {
                BuscaCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuscaCertificado()
        {
            try
            {
                OpenFileDialog iFile = new OpenFileDialog();
                iFile.ShowDialog();
                this.txtPathCertificado.Text = iFile.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
