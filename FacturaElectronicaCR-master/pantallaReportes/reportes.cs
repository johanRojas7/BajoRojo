using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pantallaReportes
{
    public partial class reportes : Form
    {
        public reportes()
        {
            InitializeComponent();
        }

        private void radioTodas_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEm.Enabled = false;
            
        }

        private void radioIndividual_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEm.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioIndividual.Checked == true) { MessageBox.Show("Entonces se busca y muestra individual"); }

            if (radioTodas.Checked == true) { MessageBox.Show("Entonces se muestra la comparacion de todas las lanchas"); }

        }
    }
}
