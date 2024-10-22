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
            txtNombre.Focus();
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

     


        private void btnContinuar_Click(object sender, EventArgs e)
        {

        }

        private void picCompra_Click(object sender, EventArgs e)
        {
            Imagen imagen = new Imagen();
            Informacion info = new Informacion();
            if (imagen.MostrarInformacion(info.lbldescripcion, info.origen, info.destino, info.horasalida, info.lblOrigen, info.duracion, info.picImagen,
                       info.lblaerolinea, info.lblprecio, info.lbldestino, info.horallegada, info.lblaeropuertoorigen, info.lblaeropuertodestino, info.lbldistancia, info.lblEmpleados))
            {
                info.ShowDialog();

            }
            else
            {
                MessageBox.Show("Error al cargar la informacion ", "Comunicarse con Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            txtfecha.Focus();
        }

        private void txtpasaporte_Leave(object sender, EventArgs e)
        {
            cbxAsiento.Focus();
        }

        private void cbxAsiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Telefono.Focus();
        }

        private void txt_Telefono_Leave(object sender, EventArgs e)
        {
            cbxn_Nacionalidad.Focus();
        }

        private void cbxn_Nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxEquipaje.Focus();
        }

        private void pagCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Debe ingresar una fecha mayor a la actual ", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtfecha.Text = " ";
                return;
            }
            else
            {
                pagCalendar.Visible = false;
                txtfecha.Text = e.Start.ToString("yyyy/M/dd");
                txtpasaporte.Focus();
            }
        }

        private void txtpasaporte_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[A-Z]\d{9}$";  
            Regex validaPasaporte = new Regex(patron);

            if (validaPasaporte.IsMatch(txtpasaporte.Text))
            {
                erp.SetError(txtpasaporte, "");
                btnContinuar.Enabled = true;
            }
            else
            {
                erp.SetError(txtpasaporte, "Pasaporte no válido. Debe ser una letra seguida de 9 dígitos.");
                btnContinuar.Enabled = false;
            }
        }
    }
}
