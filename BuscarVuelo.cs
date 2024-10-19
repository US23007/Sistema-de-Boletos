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
    public partial class BuscarVuelo : Form
    {
        public Size tamaño;
        public BuscarVuelo()
        {
            InitializeComponent();
            Conexion conexion = new Conexion();
            conexion.establecerConexion();
            Vuelos vuelos = new Vuelos();
            vuelos.ObtenrRutas(cbxOrigen,cbxDestino);
            calendar.Visible = false;
            cbxOrigen.Focus();
            tamaño = picBuscar.Size;
            dataHora.Value = DateTime.Now;
            gbxResultados.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            bool esvisible = false;

            if (!calendar.Visible == false){
                esvisible = false;
                calendar.Visible = esvisible;
            }
            else
            {
                esvisible = true;
                calendar.Visible = esvisible;
            }

        }

        

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            if(e.Start.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Debe ingresar una fecha mayor a la actual ", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtfecha.Text = " ";
                return;
            }
            else
            {
                calendar.Visible = false;
                dataHora.Focus();
                txtfecha.Text = e.Start.ToString("yyyy/M/dd");
            }
           
            
        }

        private void cbxOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDestino.Focus();
        }

        private void cbxDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfecha.Focus();
        }

        private void dataHora_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void picBuscar_MouseEnter(object sender, EventArgs e)
        {
            picBuscar.Size = new Size((int)(tamaño.Width * 1.3), (int)(tamaño.Height * 1.3));
        }

        private void picBuscar_MouseLeave(object sender, EventArgs e)
        {
            picBuscar.Size = tamaño;
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            DateTime horaActual = DateTime.Now;
        
            if (cbxOrigen.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese un lugar de Origen", "Ciudad Origen Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (cbxDestino.SelectedIndex ==-1)
            {
                MessageBox.Show("Ingrese un lugar de Destino", "Ciudad Destino Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }if(txtfecha.Text == " ")
            {
                MessageBox.Show("Ingrese una Fecha de salida", "Fecha Salida Vacia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dataHora.Value.Hour == horaActual.Hour && dataHora.Value.Minute == horaActual.Minute )
            {
                MessageBox.Show("Ingrese una Hora de salida diferente a la actual", "Hora de Salida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                gbxResultados.Visible = true;
                string origen = cbxOrigen.SelectedItem.ToString();
                string destino = cbxDestino.SelectedItem.ToString();
                DateTime fecha = DateTime.Parse(txtfecha.Text);
                TimeSpan hora = dataHora.Value.TimeOfDay;
                Vuelos viaje = new Vuelos();
                viaje.Viaje(origen, destino, fecha, hora);
                viaje.ObtenerVuelosDisponibles(dgvDatos);
            }
        }

        private void btn_Ver_Mas_Click(object sender, EventArgs e)
        {
            if(dgvDatos.SelectedRows.Count > 0)
            { 
                foreach(DataGridViewRow fila in dgvDatos.SelectedRows)
                {
                 
                    int idvuelo = int.Parse(fila.Cells["ID"].Value.ToString());
                    Vuelos vuelos = new Vuelos();
                    vuelos.ObtenerId = idvuelo;
                    Console.WriteLine("Variable en vuelo:" + vuelos.ObtenerId);
                    MessageBox.Show("Cargando Información.....", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Informacion informacion = new Informacion();
                    informacion.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.","Seleccionar una Fila",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvDatos.SelectedRows) 
                {
                    int idvuelo = int.Parse(fila.Cells["ID"].Value.ToString());
                    
                    MessageBox.Show("Seleccion Completada", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Para continuar debe de Iniciar Sesion o Registrarse", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    IngresoAdministrador ingreso = new IngresoAdministrador();
                    ingreso.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Seleccionar una Fila", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

    }
}
