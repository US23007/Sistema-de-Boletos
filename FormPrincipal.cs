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
    public partial class FormPrincipal : Form
    {
        // Este Formulario Contendra todas las opciones del Sistema de Boletos
        public FormPrincipal()
        {
            InitializeComponent();
            ValidarIngreso validar = new ValidarIngreso();
            administradorToolStripMenuItem.Text = validar.ObtenerUsuario;
        }

        //Salir de el formulario hacia el Inicio de Sesion
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoAdministrador ingreso = new IngresoAdministrador();
            ingreso.Show();
            this.Hide();
        }

       
    }
}
