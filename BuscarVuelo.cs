using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    public partial class BuscarVuelo : Form
    {
        public Size tamaño;
        public BuscarVuelo()
        {
            InitializeComponent();
            Vuelos vuelos = new Vuelos();
            vuelos.ObtenrRutas(cbxOrigen,cbxDestino);
            calendar.Visible = false;
            dataHora.Visible = true;
            cbxOrigen.Focus();
            tamaño = picBuscar.Size;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            bool esvisible = false;

            if (!calendar.Visible == false){
                esvisible = false;
                calendar.Visible = esvisible;
            }
            else
            {
                esvisible = true;
                calendar.Visible = esvisible;
            }

        }

        

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtfecha.Text = e.Start.ToString("yyyy/M/dd");
            calendar.Visible = false;
            dataHora.Focus();
            
        }

        private void cbxOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDestino.Focus();
        }

        private void cbxDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfecha.Focus();
        }

        private void dataHora_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void picBuscar_MouseEnter(object sender, EventArgs e)
        {
            picBuscar.Size = new Size((int)(tamaño.Width * 1.3), (int)(tamaño.Height * 1.3));
        }

        private void picBuscar_MouseLeave(object sender, EventArgs e)
        {
            picBuscar.Size = tamaño;
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            DateTime horaActual = DateTime.Now;
        
            if (cbxOrigen.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese un lugar de origen", "Ciudad Origen Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (cbxDestino.SelectedIndex ==-1)
            {
                MessageBox.Show("Ingrese un lugar de Destino", "Ciudad Destino Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }if(txtfecha.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una fecha de salida", "Fecha Salida Vacia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dataHora.Value.Hour == horaActual.Hour && dataHora.Value.Minute == horaActual.Minute)
            {
                MessageBox.Show("Ingrese una hora de salida diferente a la actual", "Hora de Salida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
    }
}
