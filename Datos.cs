using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    /// <summary>
    /// Este Form Datos se utilizara para la recoleccion de datos de el Pasajero 
    /// </summary>
    public partial class Datos : Form
    {
        public Datos()
        {
            InitializeComponent();
            pagCalendar.Visible = false;
            txtNombre.Focus();
            Pasajero pasajero = new Pasajero(); //Instancia de la clase Pasajero 
            pasajero.ObtenerCantidadAsientos(lblCantidadAsientos, lblAsientosDisponibles); //Método para Obtener la cantidad de asiento segun el vuelo y avion y llenarlos en los comboboxs
        }

       

        //Funcion para mostrar el calendario
        private void picCalendario_Click(object sender, EventArgs e)
        {
            bool esvisible = false;

            if (!pagCalendar.Visible == false)
            {
                esvisible = false;
                pagCalendar.Visible = esvisible;
            }
            else
            {
                esvisible = true;
                pagCalendar.Visible = esvisible;
            }
        }

     

        // Botón Continuar que nos llevara al Form de Reservas 
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            DateTime time;
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) // Validacion de Vacio 
            {
                MessageBox.Show("Asegúrese de llenar el Nombre Completo del pasajero","Nombre Completo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtpasaporte.Text))// Validacion de Vacio 
            {
                MessageBox.Show("Asegúrese de llenar el número de pasaporte","Pasaporte Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtfecha.Text)) // Validacion de Vacio 
            {
                MessageBox.Show("Asegúrese de llenar la fecha de nacimiento del pasajero","Fecha Vacia",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if (DateTime.TryParse(txtfecha.Text, out time)) // Validacion de Fecha con el formato correspondiente en la base de datos 
            {
                time.ToString("yyyy-MM-dd");
            }
            if (cbxAsiento.SelectedIndex == -1 || cbxEquipaje.SelectedIndex == -1 || cbxn_Nacionalidad.SelectedIndex == -1 || cbx_Tipo_Pasajero.SelectedIndex == -1) // Validacion de ComboBoxs sin seleccionar
            {
                MessageBox.Show("Asegúrese de haber seleccionado el asiento , la nacionalidad, el tipo de pasajero o el tipo de equipaje", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string nombre = txtNombre.Text;  // Variable nombre
                string fecha = txtfecha.Text;  // Variable fecha
                string pasaporte = txtpasaporte.Text; // Variable Pasaporte
                int asiento = int.Parse(cbxAsiento.SelectedItem.ToString()); // Variable Asiento obtenido del Combobox previamente llenado directo de la DB
                string telefono = txt_Telefono.Text; // Variable Telefon
                string nacionalidad = cbxn_Nacionalidad.SelectedItem.ToString(); // Variable Nacionalidad 
                string equipaje = cbxEquipaje.SelectedItem.ToString(); // Variable Equipaje
                string tipo = cbx_Tipo_Pasajero.SelectedItem.ToString(); // Variable Tipo de Pasajero
                Pasajero pasajero = new Pasajero(); // Instancia de la clase Pasajero
                Reservaciones reservaciones = new Reservaciones(); // Instancia de la clase Reservaciones 

                Reserva reserva = new Reserva(); // Instancia de el Form Reserva
                pasajero.NombrePasajero = nombre; // Método para Obtener el Nombre de el Pasajero
                pasajero.ObtenerSitio = asiento; //  Método para Obtener Asiento Preferido de el Pasajero
                pasajero.Butaca = asiento; //  Método del tipo static para conserva el asiento preferido de el pasajero
                pasajero.TipoMaletas = equipaje; //  Método para obtener el tipo de equipaje 
                // Console.WriteLine("equipaje" + pasajero.TipoMaletas);  // Mensaje Opcional 
                pasajero.Ingresar_Pasajero(nombre, time, pasaporte, asiento, telefono, nacionalidad, equipaje, tipo); // Método de la clase Pasajero para obtener los datos de un nuevo pasajero con sus parametros 
                if (pasajero.RegistrarPasajero() && pasajero.ReservarAsiento()) // Método de la clase Pasajero para registrar un nuevo pasajero y Método para reservar el asiento elejido
                {

                   if (reservaciones.MostrarInformacionPasajero(reserva.lbl_Nombre, reserva.lblPasaporte, reserva.lbl_Telefono, reserva.lbl_Nacimiento, reserva.lbl_Nacionalidad, reserva.lbl_Pasajero, reserva.lbl_Equipaje, reserva.lbl_Asiento) && reservaciones.ObtenerDetallesVuelo(reserva.lbl_Aerolinea,
                       reserva.lbl_Numero_Vuelo, reserva.lbl_Origen, reserva.lbl_Destino, reserva.lbl_Salida, reserva.lbl_Llegada, reserva.lbl_Avion, reserva.lbl_Hora_Salida, reserva.lbl_Hora_Llegada, reserva.lbl_Puerta, reserva.lbl_Precio))
                       //Método de la clase reservaciones para Mostrar la informacion de el pasajero y la informacion de el vuelo a reservar con sus parametros respectivos
                    {
                        reserva.Show(); // Si todo sale bien abre el Form Reserva
                        this.Hide();
                    }

                }

            }
            
        }

        // picCompra muestra la informacion adicional de el vuelo sin necesidad de retroceder al Form BuscarVuelo
        private void picCompra_Click(object sender, EventArgs e)
        {
            Imagen imagen = new Imagen(); // Instancia de clase imagen 
            Informacion info = new Informacion(); // Instancia de el Form Informacion para mostrar informacion adicional de el vuelo
            if (imagen.MostrarInformacion(info.lbldescripcion, info.origen, info.destino, info.horasalida, info.lblOrigen, info.duracion, info.picImagen,
                       info.lblaerolinea, info.lblprecio, info.lbldestino, info.horallegada, info.lblaeropuertoorigen, info.lblaeropuertodestino, info.lbldistancia, info.lblEmpleados))
            // Método de la clase Imagen para mostrar datos adicionales y pasarle esos parametros a el Form Informacion
            {
                info.ShowDialog();  // Abrir el Form Informacion

            }
            else
            {
                MessageBox.Show("Error al cargar la informacion ", "Comunicarse con Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Eventos Focus
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            txtfecha.Focus();
        }

        private void txtpasaporte_Leave(object sender, EventArgs e)
        {
            cbxAsiento.Focus();
        }

        private void cbxAsiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Telefono.Focus();
        }

        private void txt_Telefono_Leave(object sender, EventArgs e)
        {
            cbxn_Nacionalidad.Focus();
        }

        private void cbxn_Nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxEquipaje.Focus();
        }


        //Funcion para validar la fecha de nacimiento  del pasajero
        private void pagCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Debe ingresar una fecha menor a la actual ", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop); //Fecha incorrecta
                txtfecha.Text = " ";
                return;
            }
            else
            {
                pagCalendar.Visible = false;
                txtfecha.Text = e.Start.ToString("yyyy/M/dd"); // Fecha Correcta menor a la fecha actual 
                txtpasaporte.Focus();
            }
        }

        // Validacion de el Pasaporte ingresado atraves de Regex visto en clases 
        private void txtpasaporte_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[A-Z]\d{9}$";  
            Regex validaPasaporte = new Regex(patron);

            if (validaPasaporte.IsMatch(txtpasaporte.Text))
            {
                erp.SetError(txtpasaporte, "");  // Dato Correcto
                btnContinuar.Enabled = true;
            }
            else
            {
                erp.SetError(txtpasaporte, "Pasaporte no válido. Debe ser una letra seguida de 9 dígitos."); // Dato Incorrecto
                btnContinuar.Enabled = false;
            }
        }

        // Validacion de el Telefono ingresado atraves de Regex visto en clases 
        private void txt_Telefono_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^\d{3}\s\d{8}$";
            Regex validaPasaporte = new Regex(patron);

            if (validaPasaporte.IsMatch(txt_Telefono.Text))
            {
                erp.SetError(txt_Telefono, "");  // Dato Correcto
                btnContinuar.Enabled = true;
            }
            else
            {
                erp.SetError(txt_Telefono, "El número de teléfono no es válido."); // Dato Incorrecto
                btnContinuar.Enabled = false;
            }
        }
    }
}
