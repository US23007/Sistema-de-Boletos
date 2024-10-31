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
        /// <summary>
        /// Este Form servira para la busqueda de vuelos detallando el lugar de Origen , Destino ,Hora de Salida , Fecha de Salida etc 
        /// </summary>
        public Size tamaño;
        public BuscarVuelo()
        {
            InitializeComponent();
            Conexion conexion = new Conexion(); // Instancia de la clase Conexion para verificar si la conexion ha sido exitosa al inicio de la ejecucion del programa
            conexion.Conectar();
            Vuelos vuelos = new Vuelos(); //Instancia de la clase Vuelos
            vuelos.ObtenrRutas(cbxOrigen,cbxDestino);  // Método de la clase vuelos
            calendar.Visible = false; 
            cbxOrigen.Focus();
            tamaño = picBuscar.Size;
            dataHora.Value = DateTime.Now;
            gbxResultados.Visible = false;
        }


        //Funcion para activar o desactivar el Calendario para la recoleccion de la Fecha de Salida del vuelo
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

  
        // Evento Focus
        private void cbxOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDestino.Focus();
        }

        private void cbxDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfecha.Focus();
        }

       
        //Función para agrandar la imagen de buscar
        private void picBuscar_MouseEnter(object sender, EventArgs e)
        {
            picBuscar.Size = new Size((int)(tamaño.Width * 1.3), (int)(tamaño.Height * 1.3));
        }

        //Volver al tamaño original de la imagen buscar
        private void picBuscar_MouseLeave(object sender, EventArgs e)
        {
            picBuscar.Size = tamaño;
        }


        // Botón Buscar que muestra la informacion  de vuelos según la elección del usuario
        private void picBuscar_Click(object sender, EventArgs e)
        {
            DateTime horaActual = DateTime.Now;
        
            if (cbxOrigen.SelectedIndex == -1)   // Validaciones en Origen
            {
                MessageBox.Show("Ingrese un lugar de Origen", "Ciudad Origen Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (cbxDestino.SelectedIndex ==-1) // Validaciones en Destino
            {
                MessageBox.Show("Ingrese un lugar de Destino", "Ciudad Destino Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }if(txtfecha.Text == " ") // Validaciones en Fecha de Salida Vacia
            {
                MessageBox.Show("Ingrese una Fecha de salida", "Fecha Salida Vacia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dataHora.Value.Hour == horaActual.Hour && dataHora.Value.Minute == horaActual.Minute ) // Validacion para no ingresar fechas menores a la actual 
            {
                MessageBox.Show("Ingrese una Hora de salida diferente a la actual", "Hora de Salida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                gbxResultados.Visible = true;
                string origen = cbxOrigen.SelectedItem.ToString();  // Variable Origen 
                string destino = cbxDestino.SelectedItem.ToString(); // Variable Destino 
                DateTime fecha = DateTime.Parse(txtfecha.Text); // Variable Fecha Salida 
                TimeSpan hora = dataHora.Value.TimeOfDay;  // Variable Hora Salida
                Vuelos viaje = new Vuelos(); // Instancia de clase vuelo
                viaje.Viaje(origen, destino, fecha, hora); // Método para consultar los vuelos disponibles en la base de datos 
                viaje.ObtenerVuelosDisponibles(dgvDatos); // Método para cargar los datos encontrados en un datagridview
            }
        }


        //Botón Ver Más que muestra información adicional del vuelo seleccionado
        private void btn_Ver_Mas_Click(object sender, EventArgs e)
        {  
            if(dgvDatos.SelectedRows.Count > 0)  // Tomar la fila o vuelo seleccionado de la dgvDatos 
            { 
                foreach(DataGridViewRow fila in dgvDatos.SelectedRows)
                {
                 
                    int idvuelo = int.Parse(fila.Cells["ID"].Value.ToString()); // Variable idvuelo
                    Vuelos vuelos = new Vuelos(); // Instancia de la clase vuelos 
                    vuelos.ObtenerId = idvuelo; // Método para obtener el ID de vuelo seleccionado
                   
                    MessageBox.Show("Cargando Información.....", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Imagen imagen = new Imagen(); // Instancia de la clase Imagen
                    Informacion info = new Informacion(); // Instancia de el Form Informacion 
                    if ( imagen.MostrarInformacion (info.lbldescripcion, info.origen, info.destino, info.horasalida, info.lblOrigen, info.duracion, info.picImagen,
                        info.lblaerolinea, info.lblprecio, info.lbldestino, info.horallegada, info.lblaeropuertoorigen, info.lblaeropuertodestino, info.lbldistancia, info.lblEmpleados)) 
                        //Método para mostrar los datos adicionales del vuelo 
                    {
                        info.ShowDialog(); // Abrir el Form Información 
                        
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar la informacion ", "Comunicarse con Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                    
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.","Seleccionar una Fila",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
        }


        //Botón Seleccionar que toma la informacion del vuelo seleccionado
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)  // Tomar la fila o vuelo seleccionado de la dgvDatos 
            {
                foreach (DataGridViewRow fila in dgvDatos.SelectedRows) 
                {
                    int idvuelo = int.Parse(fila.Cells["ID"].Value.ToString());  // Variable idVuelo
                    int avion = int.Parse(fila.Cells["ID del Avión"].Value.ToString()); // Variable idAvion
                    Vuelos vuelos = new Vuelos(); // Instncia  de Clase Vuelos 
                    vuelos.ObtenerId = idvuelo; // Método para Obtener el ID de Vuelo Seleccionado para usos posteriores
                    vuelos.ObtenerAvion = avion; // Método para Obtener el ID de Avion Seleccionado para usos posteriores
                    MessageBox.Show("Seleccion Completada", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Para continuar debe de llenar algunos datos del Pasajero", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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

   

        // Validacion para el calendario 
        private void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date <= DateTime.Now.Date) // Validacion para no ingresar fechas menores a la actual 
            {
                MessageBox.Show("Debe ingresar una fecha mayor a la actual ", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtfecha.Text = " ";
                return;
            }
            else
            {
                calendar.Visible = false;  // Fecha Correcta
                dataHora.Focus();
                txtfecha.Text = e.Start.ToString("yyyy/M/dd");
            }

        }

        

       
    }
}
