﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemaFacturacionPantallasPrincipales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AbrirFormEnPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panelContenedor.Controls.OfType<Forms>().FirstOrDefault();

            //si el formulario/instancia no existe, nueva instancia y mostrar
            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelContenedor.Controls.Add(formulario);
                panelContenedor.Tag = formulario;
                formulario.Show();
                
                formulario.BringToFront();
                //formulario.FormClosed += new FormClosedEventHandler(CloseForms);               
            }
            else
            {
                
                formulario.BringToFront();

                //Si la instancia esta minimizada mostramos
                if (formulario.WindowState == FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }

            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void botonFaturacion_Click(object sender, EventArgs e)
        {
          
            AbrirFormEnPanel<FacturaElectronicaCR_CS.TestFacturaXMLCR>();
        }

        private void botonPesas_Click(object sender, EventArgs e)
        {
            
            AbrirFormEnPanel<pantallaPesasLiquidaciones.pesasLiquidaciones>();

        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {

            
            AbrirFormEnPanel<pantallaDatosApp.DatosApp>();

        }

        private void botonReportes_Click(object sender, EventArgs e)
        {
            
            AbrirFormEnPanel<pantallaReportes.reportes>();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //prueba

            DialogResult dialogResult = MessageBox.Show("Esta apunto de cerrar la aplicacion. ¿Desea salir de la aplicacion ? ", "Bajo Rojo del Pacifico ", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {

                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
             
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}