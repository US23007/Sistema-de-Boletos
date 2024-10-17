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
        public BuscarVuelo()
        {
            InitializeComponent();
            Vuelos vuelos = new Vuelos();
            vuelos.ObtenrRutas(cbxOrigen,cbxDestino);
            calendar.Visible = false;
            dataHora.Visible = true;
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
        }
    }
}
