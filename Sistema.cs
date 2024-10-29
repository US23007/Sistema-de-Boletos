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
                                    reserva.ID as 'Número de Reserva' , reserva.Estado ,reserva.Fecha as 'Fecha de Reservación'
                                    from usuario
                                    inner join pasajero  on usuario.ID = pasajero.usuario_ID 
                                    inner join reserva on pasajero.ID = reserva.ID";

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
                                    reserva.ID as 'Número de Reserva' , reserva.Estado ,reserva.Fecha as 'Fecha de Reservación'
                                    from usuario
                                    inner join pasajero  on usuario.ID = pasajero.usuario_ID 
                                    inner join reserva on pasajero.ID = reserva.ID
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

    }



}

    



