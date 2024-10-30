using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class Sistema
    {


        public bool Aerolineas(DataGridView aerolinea)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM aerolinea;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            aerolinea.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar los Aerolineas", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        public bool vuelos(DataGridView vuelos)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM vuelos;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            vuelos.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar los Vuelos", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }


        public bool aviones(DataGridView aviones)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM aviones;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            aviones.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar los aviones", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }

        public bool asientos(DataGridView asientos)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM asientos;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            asientos.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar los Asientos", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }

        public bool Empleados(DataGridView empleados)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM empleados;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            empleados.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar los Vuelos", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }

        public bool Rutas(DataGridView rutas)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM rutas;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            rutas.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar las rutas", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }


        public bool Usuario(DataGridView usuario)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"Select usuario.ID as 'Número de Usuario',usuario.Usuario,usuario.Correo,pasajero.ID as 'Pasajero',pasajero.NombreCompleto as 'Nombre Completo',
                                    Fechanacimiento as 'Fecha de Nacimiento' , Telefono as 'Teléfono' , Pasaporte , Nacionalidad,TipoPasajero as 'Tipo de Pasajero',PreferenciaAsiento as 'Asiento',
                                    vuelos.ID as 'Número de Vuelo', aviones.ID as 'Número de Avion',
                                    reserva.ID as 'Número de Reserva' , reserva.Estado ,reserva.Fecha as 'Fecha de Reservación'
                                    from usuario
                                    inner join pasajero ON usuario.ID = pasajero.usuario_ID
                                    inner join reserva ON pasajero.ID = reserva.pasajero_ID 
                                    inner join vuelos ON reserva.vuelos_ID = vuelos.ID
                                    inner join aviones ON vuelos.aviones_ID = aviones.ID";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            usuario.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("El Usuario No Existe", "Usuario Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }



        public bool Consultar(DataGridView buscar, TextBox aceptar)
        {
            try
            {

                Conexion conexion = new Conexion();
                string consulta = @"Select usuario.ID as 'Número de Usuario',usuario.Usuario,usuario.Correo,pasajero.ID as 'Pasajero',pasajero.NombreCompleto as 'Nombre Completo',
                                    Fechanacimiento as 'Fecha de Nacimiento' , Telefono as 'Teléfono' , Pasaporte , Nacionalidad,TipoPasajero as 'Tipo de Pasajero',PreferenciaAsiento as 'Asiento',
                                    vuelos.ID as 'Número de Vuelo', aviones.ID as 'Número de Avion',
                                    reserva.ID as 'Número de Reserva' , reserva.Estado ,reserva.Fecha as 'Fecha de Reservación'
                                    from usuario
                                    inner join pasajero  on usuario.ID = pasajero.usuario_ID 
                                    inner join reserva on pasajero.ID = reserva.pasajero_ID
                                    inner join vuelos on reserva.vuelos_ID = vuelos.ID
                                    inner join aviones on vuelos.aviones_ID = aviones.ID
                                    WHERE pasajero.NombreCompleto LIKE @nombre;";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    comando.Parameters.AddWithValue("@nombre", aceptar.Text);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            buscar.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("El Usuario No Existe", "Usuario Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool ModificarUsuario(string nuevo, int id)
        {
            try
            {
                Conexion conexion = new Conexion(); // Asegúrate de tener correctamente implementada tu clase de conexión

                string consulta = "UPDATE usuario SET Usuario = @usuario WHERE ID = @idUsuario";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@usuario", nuevo);
                    comando.Parameters.AddWithValue("@idUsuario", id);

                    // Ejecutar la consulta
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true; // La actualización fue exitosa
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con el ID especificado.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error al actualizar el usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public bool ModificarNombreCompleto(string nuevo, int id)
        {
            try
            {
                Conexion conexion = new Conexion(); // Asegúrate de tener correctamente implementada tu clase de conexión

                string consulta = "UPDATE pasajero SET NombreCompleto = @nombre WHERE ID = @idpasajero";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@nombre", nuevo);
                    comando.Parameters.AddWithValue("@idpasajero", id);

                    // Ejecutar la consulta
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true; // La actualización fue exitosa
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el pasajero con el ID especificado.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error al actualizar el pasajerp: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ModificarCorreo(string nuevo, int id)
        {
            try
            {
                Conexion conexion = new Conexion(); // Asegúrate de tener correctamente implementada tu clase de conexión

                string consulta = "UPDATE usuario SET Correo = @correo WHERE ID = @idUsuario";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@correo", nuevo);
                    comando.Parameters.AddWithValue("@idUsuario", id);

                    // Ejecutar la consulta
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true; // La actualización fue exitosa
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el correo con el ID especificado.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error al actualizar el correo: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool ModificarAsiento(ComboBox asientos, int idVuelos, int idAviones) {

            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            try
            {

                string query = @"SELECT asientos.NumeroAsiento
                                        FROM asientos
                                        INNER JOIN aviones ON asientos.aviones_ID = aviones.ID
                                        INNER JOIN vuelos ON aviones.ID = vuelos.aviones_ID
                                        WHERE vuelos.ID = @vuelo AND aviones.ID = @avion AND asientos.Estado = 'Disponible';
                                        ";


                using (MySqlCommand comando = new MySqlCommand(query, conn))

                {
                    comando.Parameters.AddWithValue("@vuelo", idVuelos);
                    comando.Parameters.AddWithValue("@avion", idAviones);
                    MySqlDataReader reader = comando.ExecuteReader();

                    asientos.Items.Clear();

                    while (reader.Read())
                    {
                        asientos.Items.Add(reader["NumeroAsiento"].ToString());

                    }

                    reader.Close();
                }

                if (asientos.Items.Count == 0)
                {
                    MessageBox.Show("Hubo un error al cargar los asientos, porfavor reiniciar la aplicación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un problema al conectar a la base de Datos.", "Reiniciar" + ex.Message);
                return false;
            }
        }




        public bool ReservarNuevoAsiento(int idvuelo, int idAvion, int nuevoAsiento, int pasajero)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            try
            {
                // Iniciar la transacción
                using (var transaction = conn.BeginTransaction())
                {
                    // Actualizar el estado del asiento
                    string consulta = @"UPDATE asientos
                                INNER JOIN aviones ON asientos.aviones_ID = aviones.ID
                                INNER JOIN vuelos ON vuelos.aviones_ID = aviones.ID
                                SET asientos.Estado = 'Reservado'
                                WHERE vuelos.ID = @id AND aviones.ID = @avion AND asientos.NumeroAsiento = @asiento";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conn, transaction))
                    {
                        comando.Parameters.AddWithValue("@id", idvuelo);
                        comando.Parameters.AddWithValue("@avion", idAvion);
                        comando.Parameters.AddWithValue("@asiento", nuevoAsiento);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // Obtener el ID del nuevo asiento
                            string consultaAsiento = @"SELECT asientos.ID FROM asientos 
                                                INNER JOIN aviones ON asientos.aviones_ID = aviones.ID
                                                WHERE NumeroAsiento = @numero AND aviones.ID = @avion";

                            using (MySqlCommand comandoAsiento = new MySqlCommand(consultaAsiento, conn, transaction))
                            {
                                comandoAsiento.Parameters.AddWithValue("@numero", nuevoAsiento);
                                comandoAsiento.Parameters.AddWithValue("@avion", idAvion);
                                object resultado = comandoAsiento.ExecuteScalar();

                                if (resultado != null)
                                {
                                    int IdAsiento = Convert.ToInt32(resultado);
                                    Console.WriteLine(IdAsiento);

                                    // Actualizar la reserva
                                    string actualizar = @"UPDATE reserva 
                                                    INNER JOIN vuelos ON reserva.vuelos_ID = vuelos.ID
                                                    INNER JOIN pasajero ON reserva.pasajero_ID = pasajero.ID
                                                    SET asientos_ID = @idnuevo
                                                    WHERE vuelos.ID = @vuelos AND pasajero.ID = @pasajero";

                                    using (MySqlCommand comandoActualizar = new MySqlCommand(actualizar, conn, transaction))
                                    {
                                        comandoActualizar.Parameters.AddWithValue("@idnuevo", IdAsiento);
                                        comandoActualizar.Parameters.AddWithValue("@vuelos", idvuelo);
                                        comandoActualizar.Parameters.AddWithValue("@pasajero", pasajero);

                                        int filasActualizar = comandoActualizar.ExecuteNonQuery();

                                        if (filasActualizar > 0)
                                        {
                                            // Actualizar la preferencia del pasajero
                                            string updatePreferencia = @"UPDATE pasajero
                                                                SET PreferenciaAsiento = @butaca
                                                                WHERE ID = @passager;";

                                            using (MySqlCommand comandoPreferencia = new MySqlCommand(updatePreferencia, conn, transaction))
                                            {
                                                comandoPreferencia.Parameters.AddWithValue("@butaca", nuevoAsiento);
                                                comandoPreferencia.Parameters.AddWithValue("@passager", pasajero);

                                                int filasUpdate = comandoPreferencia.ExecuteNonQuery();

                                                if (filasUpdate > 0)
                                                {
                                                    // Confirmar la transacción
                                                    transaction.Commit();
                                                    return true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se pudo actualizar la preferencia del asiento del pasajero en filas update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El número de asiento no es válido en filas actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró el asiento con el ID especificado en comandoAsiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado del asiento en filas Afectadas. Verifique la información en nuevos asientos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error al actualizar el asiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    
















        public bool LiberarAntiguoAsiento(int idvuelo , int idAvion , int asiento)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            try
            {

                string consulta = @"Update asientos
                                    INNER JOIN aviones ON asientos.aviones_ID = aviones.ID
                                    INNER JOIN vuelos ON vuelos.aviones_ID = aviones.ID
                                    set asientos.Estado ='Disponible'
                                    WHERE vuelos.ID = @id and aviones.ID = @avion and asientos.NumeroAsiento = @asiento";
                using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                {
                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@id", idvuelo);
                    comando.Parameters.AddWithValue("@avion", idAvion);
                    comando.Parameters.AddWithValue("@asiento",asiento);

                    // Ejecutar la consulta
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true; // La actualización fue exitosa
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el asiento con el ID especificado.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error al actualizar el asiento en antiguo asiento: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        public bool EliminarUsuario(int idusuario)
        {
            try
            {
                Conexion conexion = new Conexion();
                MySqlConnection conn = conexion.Conectar();

                //Eliminar Pagos
                ExecuteQuery(conn,
                     "DELETE pagos FROM pagos " +
                     "INNER JOIN reserva ON pagos.reserva_ID = reserva.ID " +
                     "INNER JOIN pasajero ON reserva.pasajero_ID = pasajero.ID " +
                     "WHERE pasajero.usuario_ID = @usuarioID", idusuario);

                //Eliminar Reserva
                ExecuteQuery(conn,
                "DELETE reserva FROM reserva " +
                "INNER JOIN pasajero ON reserva.pasajero_ID = pasajero.ID " +
                "WHERE pasajero.usuario_ID = @usuarioID", idusuario);

                // Eliminar pasajero
                ExecuteQuery(conn,
                    "DELETE FROM pasajero WHERE usuario_ID = @usuarioID", idusuario);

                //  Eliminar usuario
                ExecuteQuery(conn,
                    "DELETE FROM usuario WHERE ID = @usuarioID", idusuario);

                MessageBox.Show("Usuario eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error al eliminar al usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ExecuteQuery(MySqlConnection conn, string query, int idusuario)
        {
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@usuarioID", idusuario);
                command.ExecuteNonQuery();
            }
        }


        public bool Reservaciones(DataGridView reserva)
        {
            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM reserva;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            reserva.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar las reservas", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Pagos(DataGridView pagos)
        {
            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM pagos;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            pagos.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar las reservas", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool Politicas(DataGridView politicas)
        {
            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT Descripcion,TiempoPermitidoDias as 'Dias Limite de Cambios antes del vuelo' FROM politicas;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            politicas.DataSource = dt;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar las politicas", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool Condiciones(int idvuelos,int idaviones)
        {
            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT vuelos.FechaSalida,politicas.TiempoPermitidoDias
                                    FROM reserva
                                    INNER JOIN vuelos ON reserva.Vuelos_ID = vuelos.ID
                                    INNER JOIN aviones ON vuelos.Aviones_ID = aviones.ID
                                    INNER JOIN aerolinea ON aviones.Aerolinea_ID = aerolinea.ID
                                    INNER JOIN politicas ON aerolinea.ID = politicas.Aerolinea_ID
                                    WHERE  aviones.ID = @avion AND vuelos.ID = @vuelo;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    comando.Parameters.AddWithValue("@avion", idaviones);
                    comando.Parameters.AddWithValue("@vuelo", idvuelos);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime fechaVuelo = Convert.ToDateTime(reader["FechaSalida"]);
                            int diasPermitidos = Convert.ToInt32(reader["TiempoPermitidoDias"]);
                            DateTime fechaLimite = fechaVuelo.AddDays(-diasPermitidos);

                            if (DateTime.Now <= fechaLimite)
                            {
                                
                                return true; // Se permiten cambios
                            }
                            else
                            {
                                MessageBox.Show("Ya no puede hacer Cambios o Cancelar la Reserva el tiempo Disponible para los cambios ha expirado", "Tiempo Vencido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false; // No se permiten cambios
                            }
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar las politicas", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

       public bool CancelarReserva(int idreserva)
        {
            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"Update reserva
                                    set Estado = 'Cancelada'
                                    where reserva.ID = @idreserva";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    comando.Parameters.AddWithValue("idreserva", idreserva);
                    int filasAfectadas = comando.ExecuteNonQuery();

                    
                        if (filasAfectadas >0)
                        {
                            
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo actualizar el Estado de la Reserva", "Reiniciar Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    


}

    



