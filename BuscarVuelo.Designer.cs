﻿
namespace Clave2_Grupo3_US23007_
{
    partial class BuscarVuelo
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dataHora = new System.Windows.Forms.DateTimePicker();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxDestino = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxOrigen = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picBuscar);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.calendar);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(4, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 388);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.planelanding_avion_3578;
            this.pictureBox2.Location = new System.Drawing.Point(235, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.plane_takeoff_13263;
            this.pictureBox1.Location = new System.Drawing.Point(1, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox4);
            this.groupBox5.Controls.Add(this.dataHora);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(663, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(180, 50);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hora de Llegada";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox4.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.clock_with_white_face_icon_icons_com_72804;
            this.pictureBox4.Location = new System.Drawing.Point(8, 22);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // dataHora
            // 
            this.dataHora.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dataHora.Location = new System.Drawing.Point(55, 18);
            this.dataHora.Name = "dataHora";
            this.dataHora.ShowUpDown = true;
            this.dataHora.Size = new System.Drawing.Size(102, 27);
            this.dataHora.TabIndex = 3;
            this.dataHora.ValueChanged += new System.EventHandler(this.dataHora_ValueChanged);
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(455, 59);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 1;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtfecha);
            this.groupBox4.Controls.Add(this.picCalendar);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(496, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 50);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fecha de Llegada";
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(53, 21);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.ReadOnly = true;
            this.txtfecha.Size = new System.Drawing.Size(100, 23);
            this.txtfecha.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtfecha, "Presione sobre el calendario");
            // 
            // picCalendar
            // 
            this.picCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendar.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.calendar_with_a_clock_time_tools_icon_icons_com_56831;
            this.picCalendar.Location = new System.Drawing.Point(8, 22);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(27, 23);
            this.picCalendar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCalendar.TabIndex = 3;
            this.picCalendar.TabStop = false;
            this.toolTip1.SetToolTip(this.picCalendar, "Seleccionar ");
            this.picCalendar.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxDestino);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(263, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 55);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Destino";
            // 
            // cbxDestino
            // 
            this.cbxDestino.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDestino.FormattingEnabled = true;
            this.cbxDestino.Location = new System.Drawing.Point(6, 24);
            this.cbxDestino.Name = "cbxDestino";
            this.cbxDestino.Size = new System.Drawing.Size(217, 24);
            this.cbxDestino.TabIndex = 2;
            this.cbxDestino.SelectedIndexChanged += new System.EventHandler(this.cbxDestino_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxOrigen);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 55);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Origen ";
            // 
            // cbxOrigen
            // 
            this.cbxOrigen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrigen.FormattingEnabled = true;
            this.cbxOrigen.Location = new System.Drawing.Point(5, 20);
            this.cbxOrigen.Name = "cbxOrigen";
            this.cbxOrigen.Size = new System.Drawing.Size(194, 24);
            this.cbxOrigen.TabIndex = 1;
            this.cbxOrigen.SelectedIndexChanged += new System.EventHandler(this.cbxOrigen_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(921, 426);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "El Salvador Blue Airlines";
            // 
            // picBuscar
            // 
            this.picBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscar.Image = global::Clave2_Grupo3_US23007_.Properties.Resources.searcher_magnifyng_glass_search_locate_find_icon_123813_1_;
            this.picBuscar.Location = new System.Drawing.Point(865, 23);
            this.picBuscar.Name = "picBuscar";
            this.picBuscar.Size = new System.Drawing.Size(26, 31);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBuscar.TabIndex = 5;
            this.picBuscar.TabStop = false;
            this.picBuscar.Click += new System.EventHandler(this.picBuscar_Click);
            this.picBuscar.MouseEnter += new System.EventHandler(this.picBuscar_MouseEnter);
            this.picBuscar.MouseLeave += new System.EventHandler(this.picBuscar_MouseLeave);
            // 
            // BuscarVuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BuscarVuelo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Boletos";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxDestino;
        private System.Windows.Forms.ComboBox cbxOrigen;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picCalendar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DateTimePicker dataHora;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.PictureBox picBuscar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}