﻿using System;
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
            Administrador administrador = new Administrador();
            administradorToolStripMenuItem.Text = administrador.ObtenerUsuario;
        }

        //Salir de el formulario hacia el Inicio de Sesion
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }


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

        private void boletosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            FormSistema form = new FormSistema();
            if (sistema.Aerolineas(form.dgvAerolineas) && sistema.Empleados(form.dgvempleados) && sistema.aviones(form.dgvAviones) && sistema.asientos(form.dgvAsientos))
            {
                form.ShowDialog();
            }
        }

        private void vuelosYRutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            FormVuelosRutas rutas = new FormVuelosRutas();
            if (sistema.vuelos(rutas.dgvvuelos) && sistema.Rutas(rutas.dgvrutas))
            {
                rutas.ShowDialog();
            }
        }

        private void administraciónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            FormUsuarios usuarios = new FormUsuarios();
            if (sistema.Usuario(usuarios.dgvPasajero))
            {
                usuarios.ShowDialog();
            }
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarVuelo buscar = new BuscarVuelo();
            buscar.Show();
            this.Hide();
        }
    }
}
