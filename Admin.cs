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

        

        private void btnIngresar_Click(object sender, EventArgs e)
        {
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
                if (administrador.IngresoAdministrador())
                {
                    MessageBox.Show("Bienvenido Administrador", "Cuenta Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscarVuelo vuelo = new BuscarVuelo();
                    vuelo.Show();
                    this.Hide();
                }
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txtUsuario, "");
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txtContraseña, "");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
        }
    }
}
