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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
            gbModificar.Visible = false;
            picNombre.Enabled = false;
            picCorreo.Enabled = false;
           
            picAsiento.Enabled = false;
            picUsuario.Enabled = false;
            cbxAsientos.Visible = false;
            btneliminar.Visible = false;
            btnCancelar.Visible = false;

        }

        //Método para Obtener todos los datos del Pasajero 
        private void dgvPasajero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)   //Si selecciona una fila los diferentes labels , Texboxs obtendran los parametros establecidos 
            {
                cbxAsientos.Visible = false;
                gbModificar.Visible = true;
                picNombre.Enabled = true;
                picCorreo.Enabled = true;
                btnCancelar.Visible = true;
                picAsiento.Enabled = true;
                picUsuario.Enabled = true;
                btneliminar.Visible = true;
                DataGridViewRow fila = dgvPasajero.Rows[e.RowIndex];
                lbl_Usuario.Text = fila.Cells["Número de Usuario"].Value.ToString();
                txt_Nombre_Usuario.Text = fila.Cells["Usuario"].Value.ToString();
                txt_Correo.Text = fila.Cells["Correo"].Value.ToString();
                lblPasajero.Text = fila.Cells["Pasajero"].Value.ToString();
                txt_Nombre_Completo.Text = fila.Cells["Nombre Completo"].Value.ToString();
                DateTime fechaNacimiento = (DateTime)fila.Cells["Fecha de Nacimiento"].Value;
                lblfecha.Text = fechaNacimiento.ToString("MM/yy/dd");
                lbl_telefono.Text = fila.Cells["Teléfono"].Value.ToString();
                lbl_Pasaporte.Text = fila.Cells["Pasaporte"].Value.ToString();
                lbl_nacionalidad.Text = fila.Cells["Nacionalidad"].Value.ToString();
                lbl_tipo.Text = fila.Cells["Tipo de Pasajero"].Value.ToString();
                txt_asiento.Text = fila.Cells["Asiento"].Value.ToString();
                lblVuelos.Text = fila.Cells["Número de Vuelo"].Value.ToString();
                lblAviones.Text = fila.Cells["Número de Avion"].Value.ToString();
                lbl_reserva.Text = fila.Cells["Número de Reserva"].Value.ToString();
                lbl_Estado_Reserva.Text = fila.Cells["Estado"].Value.ToString();
                DateTime fechaReserva = (DateTime)fila.Cells["Fecha de Reservación"].Value;
                lbl_fecha_reserva.Text = fechaReserva.ToString("MM/yy/dd");
            }
            

        }


        //Método para Consultar al Usuario-Pasajero
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema(); // Instancia de la clase Sistema 
            if (string.IsNullOrEmpty(txtNombre_Buscar.Text) || string.IsNullOrWhiteSpace(txtNombre_Buscar.Text)) //Validaciones de Vacios 
            {
                MessageBox.Show("Rellenar Campo", "Nombre Completo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (sistema.Consultar(dgvPasajero, txtNombre_Buscar)) // Instancia de la clase Sistema para Consultar en la DB el Usuario ingresado , la busqueda es atraves de el Nombre de el Pasajero
                {
                    MessageBox.Show("Usuario Encontrado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(patron);

            if (regex.IsMatch(txtNombre_Buscar.Text))
            {
                erp.SetError(txtNombre_Buscar, ""); // Sin errores
                btnBuscar.Enabled = true;
            }
            else
            {
                erp.SetError(txtNombre_Buscar, "Solo se permiten letras");
                btnBuscar.Enabled = false;
            }
        }


        //Método para recargar o refrescar la tabla de Usuarios 
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            if (sistema.Usuario(dgvPasajero))
            {
                dgvPasajero.ClearSelection();
                txtNombre_Buscar.Text = " ";
                MessageBox.Show("Datos Actualizados", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     

   

        // Modificar el Nombre del Usuario
        private void picUsuario_Click(object sender, EventArgs e)
        {
            bool esValido = false;
            string input=" ";

            while (!esValido) {

                 input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo Nombre del Usuario:", "Modificar Usuario", ""); // Uso de Visual Basic usado en clases 

                if (string.IsNullOrWhiteSpace(input)) // Validacion de Vacios 
                {
                    MessageBox.Show("Rellenar Datos", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                if (!input.Any(char.IsLetter)) // Validacion de caracteres nulos 
                {
                    MessageBox.Show("Solo se permiten letras", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                esValido = true;
            }

            int id = int.Parse(lbl_Usuario.Text);  //Variables idusuario
            int idvuelos = int.Parse(lblVuelos.Text); //Variables idvuelos
            int idaviones = int.Parse(lblAviones.Text); //Variables idaviones 
            Sistema sistema = new Sistema(); //Instancia de la clase Sistema 
            if (sistema.Condiciones(idvuelos, idaviones))  //Método para la validacion de Modificacion segun las politicas y condiciones  de la clase sistema 
            {
                if (sistema.ModificarUsuario(input, id)) //Método para la modificacion de el nombre de el usuario 
                {

                    MessageBox.Show("Usuario modificado exitosamente", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information); // Proceso Completado
                    sistema.Usuario(dgvPasajero);
                    Limpiar();
                }
            }
            
        }

        //Limpiar Labels y Textboxs
        public void Limpiar()
        {

            lbl_Usuario.Text = string.Empty;
            lbl_tipo.Text = string.Empty;
            lbl_telefono.Text = string.Empty;
            lbl_Pasaporte.Text = string.Empty;
            lblPasajero.Text = string.Empty;
            lbl_fecha_reserva.Text = string.Empty;
            lbl_nacionalidad.Text = string.Empty;
            lblfecha.Text = string.Empty;
            txt_asiento.Text = string.Empty;
            lbl_reserva.Text = string.Empty;
            txt_Nombre_Usuario.Text = string.Empty;
            txt_Nombre_Completo.Text = string.Empty;
            lblAviones.Text = string.Empty;
            lblVuelos.Text = string.Empty;
        
            txt_Correo.Text = string.Empty;
            dgvPasajero.ClearSelection(); //Limpiar seleccion en la tabla 
            picNombre.Enabled = false;
            picCorreo.Enabled = false;
            lbl_Estado_Reserva.Text = string.Empty;
            picAsiento.Enabled = false;
            picUsuario.Enabled = false;
            btneliminar.Visible = false;
            btnCancelar.Visible = false;

        }



        // Modificar el Nombre Completo del Pasajero
        private void picNombre_Click(object sender, EventArgs e)
        {
            bool esValido = false;
            string input = " ";
            
            //Validaciones de vacios y caracteres nulos 
            while (!esValido)
            {

                input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo Nombre del Pasajero:", "Modificar Nombre del Pasajero", "");

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Rellenar Datos", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                if (!input.Any(char.IsLetter))
                {
                    MessageBox.Show("Solo se permiten letras", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }

                esValido = true;
            }

            // Variables Obtenidas 
            int id = int.Parse(lblPasajero.Text);
            Sistema sistema = new Sistema(); // Instancia de clase Sistema 
            int idvuelos = int.Parse(lblVuelos.Text);  // Parametros 
            int idaviones = int.Parse(lblAviones.Text);  // Parametros 
            if (sistema.Condiciones(idvuelos, idaviones)) //Método Para vericar politicas y condiciones de Cancelacion y Modificacion 
            {
                if (sistema.ModificarNombreCompleto(input, id)) //Modificar Nombre Completo del Pasajero 
                {

                    MessageBox.Show("Pasajero modificado exitosamente", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sistema.Usuario(dgvPasajero);
                    Limpiar();
                }
            }
        }

        //Modificar Correo 
        private void picCorreo_Click(object sender, EventArgs e)
        {
            bool esValido = false;
            string input = " ";

            // Validaciones 
            while (!esValido)
            {

                input = Microsoft.VisualBasic.Interaction.InputBox( "Ingrese el nuevo Correo Electrónico:", "Modificar Correo", "");


                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Rellenar Datos", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;  // Volver a solicitar el input.
                }
                if (!EsCorreoValido(input)) // Validar atraves de un Regex el Correo 
                {
                    MessageBox.Show("Correo no válido", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }


                esValido = true;
            }

            // Obtener e Ingresar Parametros 
            int id = int.Parse(lbl_Usuario.Text);
            Sistema sistema = new Sistema(); // Instancia de Clase Sistema 
            int idvuelos = int.Parse(lblVuelos.Text);
            int idaviones = int.Parse(lblAviones.Text);
            if (sistema.Condiciones(idvuelos, idaviones))//Método Para vericar politicas y condiciones de Cancelacion y Modificacion
            {
                if (sistema.ModificarCorreo(input, id)) //Modificar el Correo 
                {

                    MessageBox.Show("Correo modificado exitosamente", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sistema.Usuario(dgvPasajero);
                    cbxAsientos.Visible = false;
                    Limpiar();
                }
            }
            
        }

        //Método para Validar Correos 
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Patrón básico para correos.
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }

        //Comobobox para Obtener loa asientos Disponibles de Vuelos 
        private void picAsiento_Click(object sender, EventArgs e)
        {
            int idVuelos = int.Parse(lblVuelos.Text);
            int idaViones = int.Parse(lblAviones.Text);
            Sistema sistema = new Sistema();
            if (sistema.Condiciones(idVuelos, idaViones)) //Método Para vericar politicas y condiciones de Cancelacion y Modificacion
            {
                if (sistema.ModificarAsiento(cbxAsientos, idVuelos, idaViones)) // Método para Modificar el Asiento y ponerlo Disponible 
                {
                    cbxAsientos.Visible = true;
                }
                else
                {
                    cbxAsientos.Visible = false;
                }
            }
        }

        //Modificar el Asiento  por el nuevo seleccionado 
        private void cbxAsientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cambiar el asiento?", // Pregunta si desea continuar 
                                               "Confirmación de Cambio de Asiento",
                                               MessageBoxButtons.OKCancel,
                                               MessageBoxIcon.Question);


            if (resultado == DialogResult.OK) // OK 
            {
                Sistema sistema = new Sistema(); //// Instancia de la clase Sistema 
                int idVuelo = int.Parse(lblVuelos.Text);

                int idAvion = int.Parse(lblAviones.Text);
                int asientoAntiguo = int.Parse(txt_asiento.Text);
                int idpasajero = int.Parse(lblPasajero.Text);
                int idnuevoAsiento = int.Parse(cbxAsientos.SelectedItem.ToString());

                if (sistema.Condiciones(idVuelo, idAvion)) //Método Para vericar politicas y condiciones de Cancelacion y Modificacion
                {
                    if (sistema.LiberarAntiguoAsiento(idVuelo, idAvion, asientoAntiguo)) // Método para Hacer el Antiguio Asiento Disponible 
                    {
                        if (sistema.ReservarNuevoAsiento(idVuelo, idAvion, idnuevoAsiento, idpasajero)) // Método para Reservar el nuevo asiento,modificar en pasajero el asiento preferido y modificar en reserva el id del asiento del pasajero 
                        {
                            MessageBox.Show("Asiento Actualizado con Exito", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information); //Proceso Completado 
                            sistema.Usuario(dgvPasajero); //Recargar Tabla 
                            cbxAsientos.Visible = false;
                            Limpiar(); //Limpiar 
                        }
                    }
                }
                else
                {
                    sistema.Usuario(dgvPasajero); // Proceso Fallido 
                    cbxAsientos.Visible = false;
                    Limpiar();
                }
            }
            else if (resultado == DialogResult.Cancel) //Cancel 
            {
                cbxAsientos.Visible = false;
                MessageBox.Show("Cambio de asiento cancelado.","Proceso Cancelado",MessageBoxButtons.OK);  // No pasa nada 
            }
        }

        //Eliminar Usuario 
        private void btneliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas Eliminar al Usuario?", //Desea Continuar 
                                               "Confirmación de Eliminar Usuario",
                                               MessageBoxButtons.OKCancel,
                                               MessageBoxIcon.Question);

            if (resultado == DialogResult.OK) //OK 
            {
               
                Sistema sistema = new Sistema();
                int idVuelo = int.Parse(lblVuelos.Text);
                int idAvion = int.Parse(lblAviones.Text);
                int idUsuario = int.Parse(lbl_Usuario.Text);
                int asientoAntiguo = int.Parse(txt_asiento.Text);

                if (sistema.Condiciones(idVuelo, idAvion)) //Método Para vericar politicas y condiciones de Cancelacion y Modificacion
                {
                    if (sistema.LiberarAntiguoAsiento(idVuelo, idAvion, asientoAntiguo))  // Método para Hacer el Antiguio Asiento Disponible
                    {
                        if (sistema.EliminarUsuario(idUsuario)) //Elimina el pago , reserva,asiento,pasajero y usuario de la DB
                        {
                            sistema.Usuario(dgvPasajero);
                            cbxAsientos.Visible = false;
                            Limpiar(); //Limpiar 
                            MessageBox.Show("Usuario/Pasajero Eliminado con Exito", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information); //Proceso Exitoso
                        }
                    }
                }
                else
                {
                    sistema.Usuario(dgvPasajero); //Fallo
                    cbxAsientos.Visible = false;
                    Limpiar();
                }
                
            }
            else if(resultado == DialogResult.Cancel) //Cancel 
            {
                cbxAsientos.Visible = false;
                MessageBox.Show("Cambio de asiento cancelado.", "Proceso Cancelado", MessageBoxButtons.OK); // No hace nada
            }
        }

      

        //Cancelar la reserva 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas Cancelar la Reserva?", //Desea Continuar ? 
                                              "Confirmación de Cancelar Reserva",
                                              MessageBoxButtons.OKCancel,
                                              MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Sistema sistema = new Sistema();
                int idVuelo = int.Parse(lblVuelos.Text);
                int idAvion = int.Parse(lblAviones.Text);
                int idreserva = int.Parse(lbl_reserva.Text);
                int idasiento = int.Parse(txt_asiento.Text);
                if (sistema.Condiciones(idVuelo, idAvion))//Método Para vericar politicas y condiciones de Cancelacion y Modificacion
                {
                    if (sistema.CancelarReserva(idreserva)) // Método para Cancelar la reserva 
                    {
                        if (sistema.LiberarAntiguoAsiento(idVuelo, idAvion, idasiento)) // Poner el asiento como Disponible 
                        {
                            sistema.Usuario(dgvPasajero);
                            cbxAsientos.Visible = false;
                            Limpiar(); //Limpiar 
                            MessageBox.Show("La reserva fue Cancelada con Exito", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information); //Proceso Exitoso
                        }
                    }
                }
                else
                {
                    sistema.Usuario(dgvPasajero);
                    cbxAsientos.Visible = false; //Fallo 
                    Limpiar(); 
                }
            }
            else if (resultado == DialogResult.Cancel) //Cancel 
            {
                MessageBox.Show("Opcion Abortada por el Usuario", "Proceso Cancelado", MessageBoxButtons.OK); // No hace nada
            }
        }
    }
}
