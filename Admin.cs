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
    public partial class Admin : Form   
    {
        public Admin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Este Form Admin funcionara como un módulo de acceso del administrador al programa 
        /// </summary>
       
        

        // Botón Ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validaciones de Campos
            if(string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                erp.SetError(txtUsuario, "Rellenar Campo");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContraseña.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                erp.SetError(txtContraseña, "Rellenar Campo");
                return;
            }
            else
            {
                erp.Clear();
                Administrador administrador = new Administrador();
                administrador.Validar(txtUsuario.Text, txtContraseña.Text);
                administrador.ObtenerUsuario = txtUsuario.Text;
                if (administrador.IngresoAdministrador())  // Instancia de Clases Administrador  para Verificación de Administrador 
                {
                    MessageBox.Show("Bienvenido Administrador", "Cuenta Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormPrincipal principal = new FormPrincipal();
                    principal.Show(); // Si los datos son correctos ingresamos al FormPrincipal 
                    this.Hide();
                }
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txtUsuario, "");  // Limpieza de erp
        } 

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txtContraseña, ""); // Limpieza de erp
        }

        //Limpiar Campos Usuario / Contraseña
        private void label5_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;     
            txtContraseña.Text = string.Empty;
        }

        // Cambio en el campo contraseña mostrar/no mostrar
        private void cbxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !cbxMostrar.Checked;
        }
    }
}
