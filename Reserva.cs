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
    public partial class Reserva : Form
    {
        public Reserva()
        {
            InitializeComponent();
            panelTarjeta.Visible = false; 
            panelEfectivo.Visible = false;
            panelBancaria.Visible = false;
        }

        private void cbx_Pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbx_Pago.SelectedIndex == 0)
            {
                panelTarjeta.Visible = true;
                panelEfectivo.Visible = false;
                panelBancaria.Visible = false;
            }if(cbx_Pago.SelectedIndex == 1)
            {
                panelTarjeta.Visible = false;
                panelEfectivo.Visible = true;
                panelBancaria.Visible = false;
            }
            if (cbx_Pago.SelectedIndex == 2)
            {
                panelTarjeta.Visible = false;
                panelEfectivo.Visible = false;
                panelBancaria.Visible = true;
            }
        }
    }
}
