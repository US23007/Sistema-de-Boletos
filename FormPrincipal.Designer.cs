
namespace Clave2_Grupo3_US23007_
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarOModificarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boletosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vuelosYRutasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administradorToolStripMenuItem,
            this.boletosToolStripMenuItem,
            this.vuelosYRutasToolStripMenuItem,
            this.reservasToolStripMenuItem,
            this.cerrarProgramaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(710, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraciónDeUsuariosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.administradorToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.admin_lock_padlock_icon_205893;
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.administradorToolStripMenuItem.Text = "Usuario";
            // 
            // administraciónDeUsuariosToolStripMenuItem
            // 
            this.administraciónDeUsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoUsuarioToolStripMenuItem,
            this.cancelarOModificarReservaToolStripMenuItem});
            this.administraciónDeUsuariosToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.group_profile_users_icon_icons_com_73540;
            this.administraciónDeUsuariosToolStripMenuItem.Name = "administraciónDeUsuariosToolStripMenuItem";
            this.administraciónDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.administraciónDeUsuariosToolStripMenuItem.Text = "Administración de Usuarios";
            this.administraciónDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeUsuariosToolStripMenuItem_Click);
            // 
            // nuevoUsuarioToolStripMenuItem
            // 
            this.nuevoUsuarioToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.user_add_new_insert_icon_205821;
            this.nuevoUsuarioToolStripMenuItem.Name = "nuevoUsuarioToolStripMenuItem";
            this.nuevoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.nuevoUsuarioToolStripMenuItem.Text = "Nuevo Usuario";
            this.nuevoUsuarioToolStripMenuItem.Click += new System.EventHandler(this.nuevoUsuarioToolStripMenuItem_Click);
            // 
            // cancelarOModificarReservaToolStripMenuItem
            // 
            this.cancelarOModificarReservaToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.edit_modify_icon_149489;
            this.cancelarOModificarReservaToolStripMenuItem.Name = "cancelarOModificarReservaToolStripMenuItem";
            this.cancelarOModificarReservaToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.cancelarOModificarReservaToolStripMenuItem.Text = "Cancelar o Modificar Reserva";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources._1486564399_close_81512;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // boletosToolStripMenuItem
            // 
            this.boletosToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.plane_takeoff_13263;
            this.boletosToolStripMenuItem.Name = "boletosToolStripMenuItem";
            this.boletosToolStripMenuItem.Size = new System.Drawing.Size(159, 20);
            this.boletosToolStripMenuItem.Text = "Ficha Técnica de Vuelos";
            this.boletosToolStripMenuItem.ToolTipText = "Información sobre Aerolineas,Vuelos,Aviones,Asientos";
            this.boletosToolStripMenuItem.Click += new System.EventHandler(this.boletosToolStripMenuItem_Click);
            // 
            // vuelosYRutasToolStripMenuItem
            // 
            this.vuelosYRutasToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.facebook_placeholder_for_locate_places_on_maps_icon_icons_com_57151;
            this.vuelosYRutasToolStripMenuItem.Name = "vuelosYRutasToolStripMenuItem";
            this.vuelosYRutasToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.vuelosYRutasToolStripMenuItem.Text = "Vuelos y Rutas";
            this.vuelosYRutasToolStripMenuItem.Click += new System.EventHandler(this.vuelosYRutasToolStripMenuItem_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.fileinterfacesymboloftextpapersheet_79740;
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.reservasToolStripMenuItem.Text = "Ver Reservas y Pagos";
            this.reservasToolStripMenuItem.Click += new System.EventHandler(this.reservasToolStripMenuItem_Click);
            // 
            // cerrarProgramaToolStripMenuItem
            // 
            this.cerrarProgramaToolStripMenuItem.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.emblemunreadable_93487;
            this.cerrarProgramaToolStripMenuItem.Name = "cerrarProgramaToolStripMenuItem";
            this.cerrarProgramaToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.cerrarProgramaToolStripMenuItem.Text = "Cerrar Programa";
            this.cerrarProgramaToolStripMenuItem.Click += new System.EventHandler(this.cerrarProgramaToolStripMenuItem_Click);
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 24);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(710, 469);
            this.Contenedor.TabIndex = 1;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(710, 493);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistemas de Boletos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boletosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.ToolStripMenuItem vuelosYRutasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarOModificarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarProgramaToolStripMenuItem;
    }
}