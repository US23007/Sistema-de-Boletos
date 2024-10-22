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
    public partial class IngresoAdministrador : Form
    {
        //Autor :Samuel De Jesús Umaña Sorto US23007 
        //Fecha : 15/10/2024
        // Version : 1.0

        /// <summary>
        /// Esta Clase nos serivra para la verificación en el acceso de administrador a la base de datos y en el login para evitar robo de información
        /// </summary>
        /// 
        public IngresoAdministrador()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validaciones de Entrada de Datos
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                erp.SetError(txtUsuario, "Campo Vacio");
                return;

            }
            else if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                erp.SetError(txtContraseña, "Campo vacio");
                
            }
            else if (string.IsNullOrEmpty(txtcorreo.Text))
            {
                erp.SetError(txtcorreo, "Campo vacio");
                
            }
            else
            {
                ValidarIngreso validar = new ValidarIngreso();
                Pasajero pasajero = new Pasajero();
                Datos datos = new Datos();
                validar.Validar(txtUsuario.Text, txtContraseña.Text, txtcorreo.Text);

                if (validar.IngresoUsuario() && pasajero.ObtenerAsientos(datos.cbxAsiento))
                {
                    validar.ObtenerUsuario = txtUsuario.Text;
                    Console.WriteLine(validar.ObtenerUsuario);
                    datos.Show();
                    this.Hide();
                }
                else
                {

                    BuscarVuelo vuelo = new BuscarVuelo();
                    vuelo.Show();
                    this.Hide();
                    
                }
            }
        }

        // Validaciones de Usuario
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)|| char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                btnIngresar.Enabled = true;
            }
            else
            {
                e.Handled = true;
                erp.SetError(txtUsuario, "Ingresar solo letras");
                btnIngresar.Enabled = false;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txtUsuario, "");
        }

        //Validaciones de Contraseña
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txtContraseña, "");
        }

        //Validacion de Correo Electronico (Método Visto en Guias)
        private void txtcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            string patronEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex validaEmail = new Regex(patronEmail);
            if (validaEmail.IsMatch(txtcorreo.Text))
            {
                erp.SetError(txtcorreo, "");
                btnIngresar.Enabled =true;
                btnRegistrase.Enabled = true;
            }
            else
            {
                erp.SetError(txtcorreo, "Email NO valido");
                btnIngresar.Enabled = false;
                btnRegistrase.Enabled = false;
            }
        }

        //Funcionalidad para Mostrar la Contraseña
        private void cbxContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxContraseña.Checked == true)
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        //Limpiar los campos y demás componentes
        private void label5_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtcorreo.Text = string.Empty;
            erp.Clear();
            cbxContraseña.Checked = false;
            MessageBox.Show("Datos limpios", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnRegistrase_Click(object sender, EventArgs e)
        {
            ValidarIngreso validar = new ValidarIngreso();
            Pasajero pasajero = new Pasajero();
            Datos datos = new Datos();

            if (validar.RegistrarEnDB(txtUsuario.Text, txtcorreo.Text, txtContraseña.Text) && pasajero.ObtenerAsientos(datos.cbxAsiento))
            {
                validar.ObtenerUsuario = txtUsuario.Text;
                datos.Show();
                this.Hide();
            }
            else
            {
                return;
            }

        }
    }
}
