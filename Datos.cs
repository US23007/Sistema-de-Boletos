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
            DateTime time;
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Asegúrese de llenar el Nombre Completo del pasajero","Nombre Completo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtpasaporte.Text))
            {
                MessageBox.Show("Asegúrese de llenar el número de pasaporte","Pasaporte Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtfecha.Text))
            {
                MessageBox.Show("Asegúrese de llenar la fecha de nacimiento del pasajero","Fecha Vacia",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if (DateTime.TryParse(txtfecha.Text, out time))
            {
                time.ToString("yyyy-MM-dd");
            }
            if (cbxAsiento.SelectedIndex == -1 || cbxEquipaje.SelectedIndex == -1 || cbxn_Nacionalidad.SelectedIndex == -1 || cbx_Tipo_Pasajero.SelectedIndex == -1)
            {
                MessageBox.Show("Asegúrese de haber seleccionado el asiento , la nacionalidad, el tipo de pasajero o el tipo de equipaje", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string nombre = txtNombre.Text;
                string fecha = txtfecha.Text;
                string pasaporte = txtpasaporte.Text;
                int asiento = int.Parse(cbxAsiento.SelectedItem.ToString());
                string telefono = txt_Telefono.Text;
                string nacionalidad = cbxn_Nacionalidad.SelectedItem.ToString();
                string equipaje = cbxEquipaje.SelectedItem.ToString();
                string tipo = cbx_Tipo_Pasajero.SelectedItem.ToString();
                Pasajero pasajero = new Pasajero();
                pasajero.NombrePasajero = nombre;
                pasajero.Butaca = asiento;
                pasajero.Ingresar_Pasajero(nombre, time, pasaporte, asiento, telefono, nacionalidad, equipaje, tipo);
                if (pasajero.RegistrarPasajero() && pasajero.ReservarAsiento())
                {
                    FormPrincipal principal = new FormPrincipal();
                    principal.Show();
                    this.Hide();
                }
               
            }
            
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
