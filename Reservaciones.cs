﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    /// <summary>
    /// Esta Clase nos servira para el manejo de la reserva , y pagos como monto adicional por Equipaje 
    /// </summary>
    class Reservaciones : Pasajero  //Reservaciones Hereda de ID Pasajero
    {
        //Variables Static 
        private static int idAsiento { get; set;} 
        private static int idReserva { get; set; }

        private static decimal MontoVuelo {get; set;}

        //Métodos 
        public int ObtenerAsientoID
        {
            get { return idAsiento; }
            set { idAsiento = value; }
        }
        public int ObtenerReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }

        public decimal ObtenerMonto
        {
            get { return MontoVuelo;}
            set { MontoVuelo = value;}
        }


        //Método para Mostrar Informacion del Pasajero previamente ingresado y mostrar en el FormReservas 
        public bool MostrarInformacionPasajero(Label nombre,Label Pasaporte,Label Telefono,Label Nacimiento,Label Nacionalidad,Label Pasajero,Label Equipaje,Label Asiento)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            
                try
                {
                    
                    // Primera consulta para el pasajero
                    string consulta = @"Select NombreCompleto, Pasaporte, Telefono, Fechanacimiento, Nacionalidad, TipoPasajero, TipoEquipaje, PreferenciaAsiento 
                                 from pasajero 
                                 INNER JOIN usuario on pasajero.usuario_ID = usuario.ID 
                                 where pasajero.usuario_ID = @idUser";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                    {
                        comando.Parameters.AddWithValue("@idUser", ObtenerIdUsuario);
                        Console.WriteLine("Id User :" + ObtenerIdUsuario);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombre.Text = reader["NombreCompleto"].ToString();
                                Pasaporte.Text = reader["Pasaporte"].ToString();
                                Telefono.Text = reader["Telefono"].ToString();
                                Nacimiento.Text = Convert.ToDateTime(reader["Fechanacimiento"]).ToString("MM/yy/dd");
                                Nacionalidad.Text = reader["Nacionalidad"].ToString();
                                Pasajero.Text = reader["TipoPasajero"].ToString();
                                Equipaje.Text = reader["TipoEquipaje"].ToString();
                                Asiento.Text = reader["PreferenciaAsiento"].ToString();

                            //Console.WriteLine(nombre);
                            //Console.WriteLine(Pasaporte);
                            //Console.WriteLine(Telefono);
                            //Console.WriteLine(Nacimiento);
                            //Console.WriteLine(Nacionalidad);     //Comentarios opcionales en debug
                            //Console.WriteLine(Pasajero);
                            //Console.WriteLine(Equipaje);
                            //Console.WriteLine(Asiento);
                            return true;
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos del pasajero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            
        }

        //Método para Obtener Detalles del Vuelo seleccionado junto a sus parametros y asignarlos al FormReservas y mostrar Informacion Relevante 
        public bool ObtenerDetallesVuelo(Label Aerolinea, Label Numero_Vuelo, Label Origen, Label Destino, Label Salida, Label Llegada, Label Avion, Label Hora_Salida, Label Hora_Llegada, Label Puerta, Label Precio)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            
                try
                {
                    
                    string consulta = @"Select aerolinea.Nombre, vuelos.ID, rutas.CodigoOrigen, rutas.CodigoDestino, vuelos.FechaSalida,
                                 vuelos.FechaLlegada, Modelo, HoraSalida, HoraLlegada, vuelos.Puerta, vuelos.Precio
                                 from aviones 
                                 INNER join vuelos on aviones.ID = vuelos.aviones_ID
                                 INNER JOIN aerolinea on aviones.aerolinea_ID = aerolinea.ID
                                 INNER JOIN rutas on vuelos.rutas_ID = rutas.ID
                                 INNER JOIN asientos on aviones.ID = asientos.aviones_ID
                                 where vuelos.ID = @vuelos and aviones.ID = @aviones and asientos.NumeroAsiento = @asiento";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                    {
                        comando.Parameters.AddWithValue("@vuelos", ObtenerId);
                        comando.Parameters.AddWithValue("@aviones", ObtenerAvion);
                        comando.Parameters.AddWithValue("@asiento", ObtenerSitio);
                        //Console.WriteLine("Id Vuelo :" + ObtenerId);
                        //Console.WriteLine("Id Avion :" + ObtenerAvion); //Comentarios opcionales en debug
                        //Console.WriteLine("Id Asiento :" + ObtenerSitio);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                Aerolinea.Text = reader["Nombre"].ToString();
                                Numero_Vuelo.Text = reader["ID"].ToString();
                                Origen.Text = reader["CodigoOrigen"].ToString();
                                Destino.Text = reader["CodigoDestino"].ToString();
                                Salida.Text = Convert.ToDateTime(reader["FechaSalida"]).ToString("MM/yy/dd");
                                Llegada.Text = Convert.ToDateTime(reader["FechaLlegada"]).ToString("MM/yy/dd");
                                Avion.Text = reader["Modelo"].ToString();
                                Hora_Salida.Text = reader["HoraSalida"].ToString();
                                Hora_Llegada.Text = reader["HoraLlegada"].ToString();
                                Puerta.Text = reader["Puerta"].ToString();
                                Precio.Text = string.Format("${0:N2}", reader["Precio"]);
                                ObtenerMonto = Convert.ToDecimal(reader["Precio"]);


                            //Console.WriteLine(Aerolinea);
                            //Console.WriteLine(Numero_Vuelo);
                            //Console.WriteLine(Origen);
                            //Console.WriteLine(Destino);
                            //Console.WriteLine(Salida);                    //Comentarios opcionales en debug
                            //Console.WriteLine(Llegada);
                            //Console.WriteLine(Avion);
                            //Console.WriteLine(Hora_Llegada);
                            //Console.WriteLine("Soy precio" + Precio);
                            //Console.WriteLine("Monto de Vuelo" + ObtenerMonto);
                            return true;
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos del pasajero en obtener detalles de vuelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            
        }

        //Método para Reservar Vuelo 
        public bool ReservarEnDB()
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            
                try
                {
                 

                    string consultaAsiento = @"Select asientos.ID from asientos 
                                                INNER JOIN  aviones on asientos.aviones_ID = aviones.ID
                                                where NumeroAsiento = @numero and aviones.ID = @avion";

                    using (MySqlCommand comandoAsiento = new MySqlCommand(consultaAsiento, conn))
                    {
                        comandoAsiento.Parameters.AddWithValue("@numero", ObtenerSitio);
                        comandoAsiento.Parameters.AddWithValue("@avion", ObtenerAvion);
                        object resultado = comandoAsiento.ExecuteScalar();

                        if (resultado != null)
                        {
                            ObtenerAsientoID = Convert.ToInt32(resultado);
                            Console.WriteLine(ObtenerAsientoID);
                        }
                        else
                        {
                            MessageBox.Show("El número de asiento no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    string consulta = @"INSERT INTO reserva(Estado,Fecha,pasajero_ID,asientos_ID,vuelos_ID)
                                        VALUES(@estado, @fecha,@pasajero,@asientos,@vuelos)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                    {
                       // Console.WriteLine("Soy id Usuario"+ObtenerIdUsuario);
                        //Console.WriteLine("Soy id Pasajro"+Passenger);           //Comentarios opcionales en debug
                        //Console.WriteLine("Soy id asiento"+ObtenerAsientoID);
                        //Console.WriteLine("Soy id Vuelo"+ObtenerId);
                        comando.Parameters.AddWithValue("@estado", "Pendiente");
                        comando.Parameters.AddWithValue("@fecha", DateTime.Now);
                        comando.Parameters.AddWithValue("@pasajero", Passenger);
                        comando.Parameters.AddWithValue("@asientos", ObtenerAsientoID);
                        comando.Parameters.AddWithValue("@vuelos", ObtenerId);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            string input = "SELECT LAST_INSERT_ID()";
                            using (MySqlCommand obtenerIDCmd = new MySqlCommand(input, conn))
                            {
                                ObtenerReserva = Convert.ToInt32(obtenerIDCmd.ExecuteScalar());

                            }

                            MessageBox.Show("Reserva Ingresada exitosamente.",
                                            "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el usuario.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error en la base de datos en reserva db no nindo el error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

        }


        //Método para Obtener las politicas y condiciones de Cancelacion y Modificacion
        public bool ObtenerPoliticas(Label texto,Label tiempo)
        {
           
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            try
            {
                

                string consulta = @"SELECT politicas.Descripcion, politicas.TiempoPermitidoDias
                                    FROM politicas
                                    INNER JOIN aerolinea ON politicas.Aerolinea_ID = aerolinea.ID
                                    INNER JOIN aviones ON aerolinea.ID = aviones.Aerolinea_ID
                                    WHERE aviones.ID =@avion";

                using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                {
                    comando.Parameters.AddWithValue("@avion", ObtenerAvion);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            texto.Text = reader["Descripcion"].ToString();
                            tiempo.Text = string.Format("{0} dias", reader["TiempoPermitidoDias"]);
                            return true;
                            
                        }
                        else
                        {
                            return false;
                            MessageBox.Show("No se pudo mostrar las Politicas de la Aerolinea.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos en reserva db no nindo el error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
