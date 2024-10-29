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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
            gbModificar.Visible = false;
            picNombre.Enabled = false;
            picCorreo.Enabled = false;
            picReserva.Enabled = false;
            picAsiento.Enabled = false;
            picUsuario.Enabled = false;
            cbxAsientos.Visible = false;

        }

        private void dgvPasajero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbxAsientos.Visible = false;
                gbModificar.Visible = true;
                picNombre.Enabled = true;
                picCorreo.Enabled = true;
                picReserva.Enabled = true;
                picAsiento.Enabled = true;
                picUsuario.Enabled = true;
                DataGridViewRow fila = dgvPasajero.Rows[e.RowIndex];
                lbl_Usuario.Text = fila.Cells["Número de Usuario"].Value.ToString();
                txt_Nombre_Usuario.Text = fila.Cells["Usuario"].Value.ToString();
                txt_Correo.Text = fila.Cells["Correo"].Value.ToString();
                lblPasajero.Text = fila.Cells["Pasajero"].Value.ToString();
                txt_Nombre_Completo.Text = fila.Cells["Nombre Completo"].Value.ToString();
                DateTime fechaNacimiento = (DateTime)fila.Cells["Fecha de Nacimiento"].Value;
                lblfecha.Text = fechaNacimiento.ToString("MM/yy/dd");
                lbl_telefono.Text = fila.Cells["Teléfono"].Value.ToString();
                lbl_Pasaporte.Text = fila.Cells["Pasaporte"].Value.ToString();
                lbl_nacionalidad.Text = fila.Cells["Nacionalidad"].Value.ToString();
                lbl_tipo.Text = fila.Cells["Tipo de Pasajero"].Value.ToString();
                txt_asiento.Text = fila.Cells["Asiento"].Value.ToString();
                lblVuelos.Text = fila.Cells["Número de Vuelo"].Value.ToString();
                lblAviones.Text = fila.Cells["Número de Avion"].Value.ToString();
                lbl_reserva.Text = fila.Cells["Número de Reserva"].Value.ToString();
                txt_Estado.Text = fila.Cells["Estado"].Value.ToString();
                DateTime fechaReserva = (DateTime)fila.Cells["Fecha de Reservación"].Value;
                lbl_fecha_reserva.Text = fechaReserva.ToString("MM/yy/dd");
            }
            

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            if(string.IsNullOrEmpty(txtNombre_Buscar.Text) || string.IsNullOrWhiteSpace(txtNombre_Buscar.Text))
            {
                MessageBox.Show("Rellenar Campo", "Nombre Completo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (sistema.Consultar(dgvPasajero, txtNombre_Buscar))
                {
                    MessageBox.Show("Usuario Encontrado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(patron);

            if (regex.IsMatch(txtNombre_Buscar.Text))
            {
                erp.SetError(txtNombre_Buscar, ""); // Sin errores
                btnBuscar.Enabled = true;
            }
            else
            {
                erp.SetError(txtNombre_Buscar, "Solo se permiten letras");
                btnBuscar.Enabled = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            if (sistema.Usuario(dgvPasajero))
            {
                dgvPasajero.ClearSelection();
                txtNombre_Buscar.Text = " ";
                MessageBox.Show("Datos Actualizados", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     

        private void picModificar_Click(object sender, EventArgs e)
        {
           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }



        private void picUsuario_Click(object sender, EventArgs e)
        {
            bool esValido = false;
            string input=" ";

            while (!esValido) {

                 input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo Nombre del Usuario:", "Modificar Usuario", "");

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Rellenar Datos", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                if (!input.Any(char.IsLetter))
                {
                    MessageBox.Show("Solo se permiten letras", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                esValido = true;
            }

            int id = int.Parse(lbl_Usuario.Text);
            Sistema sistema = new Sistema();
            if (sistema.ModificarUsuario(input, id)) {

                MessageBox.Show("Usuario modificado exitosamente","Proceso Completado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                sistema.Usuario(dgvPasajero);
                Limpiar();
            }
        }

        public void Limpiar()
        {

            lbl_Usuario.Text = string.Empty;
            lbl_tipo.Text = string.Empty;
            lbl_telefono.Text = string.Empty;
            lbl_Pasaporte.Text = string.Empty;
            lblPasajero.Text = string.Empty;
            lbl_fecha_reserva.Text = string.Empty;
            lbl_nacionalidad.Text = string.Empty;
            lblfecha.Text = string.Empty;
            txt_asiento.Text = string.Empty;
            lbl_reserva.Text = string.Empty;
            txt_Nombre_Usuario.Text = string.Empty;
            txt_Nombre_Completo.Text = string.Empty;
            lblAviones.Text = string.Empty;
            lblVuelos.Text = string.Empty;
            txt_Estado.Text = string.Empty;
            txt_Correo.Text = string.Empty;
            dgvPasajero.ClearSelection();
            picNombre.Enabled = false;
            picCorreo.Enabled = false;
            picReserva.Enabled = false;
            picAsiento.Enabled = false;
            picUsuario.Enabled = false;

        }

        private void picNombre_Click(object sender, EventArgs e)
        {
            bool esValido = false;
            string input = " ";

            while (!esValido)
            {

                input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo Nombre del Pasajero:", "Modificar Nombre del Pasajero", "");

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Rellenar Datos", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                if (!input.Any(char.IsLetter))
                {
                    MessageBox.Show("Solo se permiten letras", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                esValido = true;
            }

            int id = int.Parse(lblPasajero.Text);
            Sistema sistema = new Sistema();
            if (sistema.ModificarNombreCompleto(input,id))
            {

                MessageBox.Show("Pasajero modificado exitosamente", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sistema.Usuario(dgvPasajero);
                Limpiar();
            }
        }

        private void picCorreo_Click(object sender, EventArgs e)
        {
            bool esValido = false;
            string input = " ";

            while (!esValido)
            {

                input = Microsoft.VisualBasic.Interaction.InputBox( "Ingrese el nuevo Correo Electrónico:", "Modificar Correo", "");


                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Rellenar Datos", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }
                if (!EsCorreoValido(input))
                {
                    MessageBox.Show("Correo no válido", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }


                esValido = true;
            }

            int id = int.Parse(lbl_Usuario.Text);
            Sistema sistema = new Sistema();
            if (sistema.ModificarCorreo(input,id))
            {

                MessageBox.Show("Correo modificado exitosamente", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sistema.Usuario(dgvPasajero);
                Limpiar();
            }
            
        }

        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Patrón básico para correos.
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }

        private void picAsiento_Click(object sender, EventArgs e)
        {
            int idVuelos = int.Parse(lblVuelos.Text);
            int idaViones = int.Parse(lblAviones.Text);
            Sistema sistema = new Sistema();
            if (sistema.ModificarAsiento(cbxAsientos, idVuelos, idaViones))
            {
                cbxAsientos.Visible = true;
            }
            else
            {
                cbxAsientos.Visible = false;
            }
        }

        private void cbxAsientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cambiar el asiento?",
                                               "Confirmación de Cambio de Asiento",
                                               MessageBoxButtons.OKCancel,
                                               MessageBoxIcon.Question);


            if (resultado == DialogResult.OK)
            {
                Sistema sistema = new Sistema();
                int idVuelo = int.Parse(lblVuelos.Text);
                int idAvion = int.Parse(lblAviones.Text);
                int asientoAntiguo = int.Parse(txt_asiento.Text);
                int idpasajero = int.Parse(lblPasajero.Text);
                int idnuevoAsiento = int.Parse(cbxAsientos.SelectedItem.ToString());

                if (sistema.LiberarAntiguoAsiento(idVuelo,idAvion,asientoAntiguo))
                {
                    if (sistema.ReservarNuevoAsiento(idVuelo, idAvion, idnuevoAsiento, idpasajero))
                    {
                        MessageBox.Show("Asiento Actualizado con Exito", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (resultado == DialogResult.Cancel)
            {
                cbxAsientos.Visible = false;
                MessageBox.Show("Cambio de asiento cancelado.","Proceso Cancelado",MessageBoxButtons.OK);
            }
        }
    }
}
