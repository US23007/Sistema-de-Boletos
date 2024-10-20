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
    public partial class Datos : Form
    {
        public Datos()
        {
            InitializeComponent();
            pagCalendar.Visible = false;
        }

        private void btnir_Click(object sender, EventArgs e)
        {
            FormPrincipal principal = new FormPrincipal();
            principal.Show();
            this.Hide();
        }

        private void picCalendario_Click(object sender, EventArgs e)
        {
            bool esvisible = false;

            if (!pagCalendar.Visible == false)
            {
                esvisible = false;
                pagCalendar.Visible = esvisible;
            }
            else
            {
                esvisible = true;
                pagCalendar.Visible = esvisible;
            }
        }

        private void pagCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Debe ingresar una fecha mayor a la actual ", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtfecha.Text = " ";
                return;
            }
            else
            {
                
                txtfecha.Text = e.Start.ToString("yyyy/M/dd");
            }
        }

        private void txtpasaporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            string patron = @"^[A - Z]\d{ 9}$";
            Regex validaPasasporte = new Regex(patron);
            if (validaPasasporte.IsMatch(txtpasaporte.Text))
            {
                erp.SetError(txtpasaporte, "");
                btnContinuar.Enabled = true;
            }
            else{
                erp.SetError(txtpasaporte, "Pasaporte No valiado");
                btnContinuar.Enabled = false;
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {

        }

        private void picCompra_Click(object sender, EventArgs e)
        {
            Informacion info = new Informacion();
            info.ShowDialog();
        }
    }
}
