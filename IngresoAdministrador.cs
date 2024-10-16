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
    public partial class IngresoAdministrador : Form
    {
        //Autor :Samuel De Jesús Umaña Sorto US23007 
        //Fecha : 15/10/2024
        // Version : 1.0

        /// <summary>
        /// Esta Clase nos serivra para la verificación en el acceso de administrador a la base de datos y en el login 
        /// </summary>
        /// 
        public IngresoAdministrador()
        {
            InitializeComponent();
            Conexion conexion = new Conexion();
            conexion.establecerConexion();
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
                ValidarIngreso usuario = new ValidarIngreso(txtUsuario.Text,txtContraseña.Text,txtcorreo.Text);
                usuario.IngresoAdministrador();
            }
        }
    }
}
