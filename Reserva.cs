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

namespace Clave2_Grupo3_US23007_
{
    public partial class Reserva : Form
    {
        public Reserva()
        {
            InitializeComponent();
           
        }

        private void btnConfimar_Click(object sender, EventArgs e)
        {
            Reservaciones reservaciones = new Reservaciones();
            MontosAdicionales monto = new MontosAdicionales();
            Pagos pagos = new Pagos();
            if (reservaciones.ReservarEnDB())
            {
                if (monto.AgregarMontos() && monto.MostrarMontosAdicionales(pagos.lbl_Precio_Vuelo,pagos.lbl_Equipaje,pagos.lbl_Monto))
                {
                    pagos.Show();
                    this.Hide();
                }
                
            }
        }

        private void picPoliticas_Click(object sender, EventArgs e)
        {
            Reservaciones reservaciones = new Reservaciones();
            Politicas politicas = new Politicas();
            if (reservaciones.ObtenerPoliticas(politicas.lbl_Politicas,politicas.lbl_Horas))
            {
                politicas.ShowDialog();
            }
        }
    }
}
