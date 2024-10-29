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
        }

        private void dgvPasajero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                gbModificar.Visible = true;
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
                lbl_reserva.Text = fila.Cells["Número de Reserva"].Value.ToString();
                txt_Estado.Text = fila.Cells["Estado"].Value.ToString();
                DateTime fechaReserva = (DateTime)fila.Cells["Fecha de Reservación"].Value;
                lbl_fecha_reserva.Text = fechaReserva.ToString("MM/yy/dd");
            }
            

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Rellenar Campo", "Nombre Completo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (sistema.Consultar(dgvPasajero, txtNombre))
                {
                    MessageBox.Show("Usuario Encontrado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(patron);

            if (regex.IsMatch(txtNombre.Text))
            {
                erp.SetError(txtNombre, ""); // Sin errores
                btnBuscar.Enabled = true;
            }
            else
            {
                erp.SetError(txtNombre, "Solo se permiten letras");
                btnBuscar.Enabled = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            if (sistema.Usuario(dgvPasajero))
            {
                dgvPasajero.Refresh();
                txtNombre.Text = " ";
                MessageBox.Show("Datos Actualizados", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_Correo_TextChanged(object sender, EventArgs e)
        {
            string patronEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex validaEmail = new Regex(patronEmail);
            if (validaEmail.IsMatch(txt_Correo.Text))
            {
                erp.SetError(txt_Correo, "");
                btn_modificar.Enabled = true;
            }
            else
            {
                erp.SetError(txt_Correo, "Correo NO valido");
                btn_modificar.Enabled = false;
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
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo Nombre del Usuario:", "Modificar Usuario", "");

            do
            {
                if(String.IsNullOrEmpty(input) )
               
                if (!input.Any(char.IsLetter))
                {
                    MessageBox.Show("Solo se permiten letras", "Dato Nulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            } while (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input) && !input.Any(char.IsLetter));

            int id = int.Parse(lbl_Usuario.Text);
            Sistema sistema = new Sistema();
            if (sistema.ModificarUsuario(input, id)) {

                MessageBox.Show("Usuario modificado exitosamente","Proceso Completado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
