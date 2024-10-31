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
        /// <summary>
        /// Este Formulario Contendra todas las opciones del Sistema de Boletos como administracion de Usuarios , Ver Aerolineas , Aviones , Asiento ,Tripulantes,Vuelos,Rutas,Reservas,Pagos,Poiticas etc
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            Administrador administrador = new Administrador(); //instancia de clase administrador 
            administradorToolStripMenuItem.Text = administrador.ObtenerUsuario; // Asignar el Usuario Obtenido en la clase Administrador en el Form Admin
        }

        //Salir de el formulario hacia el Inicio de Sesion
        

        //Cerrar Sesion del Administrador
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }


        //Método para Mostrar los Forms dentro de un panel (idea Descartada)
        private void AbrirFormulario(object form)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Contenedor.Controls.Add(fh);
            this.Contenedor.Tag = fh;
            fh.Show();

        }


        // Mostrar Datos de Aerolineas , Aviones , Asientos  y Tripulacion 
        private void boletosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema(); // Instancia de la clase Sistema 
            FormSistema form = new FormSistema();  // Instancia de FormSistema
            if (sistema.Aerolineas(form.dgvAerolineas) && sistema.Empleados(form.dgvempleados) && sistema.aviones(form.dgvAviones) && sistema.asientos(form.dgvAsientos))
                //Método para obtener  las aerolineas , Empleados , aviones , asientos de la clase Sistema y mostrar en sus respectivas tablas
            {
                form.ShowDialog(); // Abrir 
            }
        }

        // Mostrar Datos Vuelos y Rutas
        private void vuelosYRutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema(); // Instancia de la clase Sistema
            FormVuelosRutas rutas = new FormVuelosRutas(); // Instancia de FormVuelosRutas
            if (sistema.vuelos(rutas.dgvvuelos) && sistema.Rutas(rutas.dgvrutas)) //Método para obtener vuelos , rutas de la clase Sistema y mostrar en sus respectivas tablas
            {
                rutas.ShowDialog(); // Abrir 
            }
        }

        //Administrar Usuarios 
        private void administraciónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema(); // Instancia de la clase Sistema 
            FormUsuarios usuarios = new FormUsuarios();  // Instancia de Form Usuarios
            if (sistema.Usuario(usuarios.dgvPasajero)) // Método para llenar los datos de la cosulta de los usuarios en el dgvpasajeros de el FormUsuario
            {
                usuarios.ShowDialog(); // Si encuntra datos abre el Form Usuario
            }
        }

        // Ingresar un nuevo Usuario - Pasajero
        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarVuelo buscar = new BuscarVuelo(); // Instancia de FormBuscarVuelos
            buscar.Show(); //Abrir 
            this.Hide();
        }



        // Mostrar Datos de Reservas,Pagos  y Politicas
        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema(); // Instancia de la clase Sistema  
            FormReservasPago form = new FormReservasPago(); // Instancia de FormReservaPagos 
            if (sistema.Reservaciones(form.dgvReservas) && sistema.Pagos(form.dgvPagos) && sistema.Politicas(form.dgvPoliticas)) { 
            // Método para llenar los datos de la cosulta de las reservas ,pagos , politicas y mostrar en sus respectivas tablas 
                form.ShowDialog();
            }
        }


        //Cerra Programa 
        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
