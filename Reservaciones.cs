using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class Reservaciones : Pasajero
    {
        private static int idAsiento { get; set;}
        private static int idReserva { get; set; }

        private static decimal MontoVuelo {get; set;}
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

        public bool MostrarInformacionPasajero(Label nombre,Label Pasaporte,Label Telefono,Label Nacimiento,Label Nacionalidad,Label Pasajero,Label Equipaje,Label Asiento)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();

                    // Primera consulta para el pasajero
                    string consulta = @"Select NombreCompleto, Pasaporte, Telefono, Fechanacimiento, Nacionalidad, TipoPasajero, TipoEquipaje, PreferenciaAsiento 
                                 from pasajero 
                                 INNER JOIN usuario on pasajero.usuario_ID = usuario.ID 
                                 where pasajero.usuario_ID = @idUser";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conector))
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
                              
                                Console.WriteLine(nombre);
                                Console.WriteLine(Pasaporte);
                                Console.WriteLine(Telefono);
                                Console.WriteLine(Nacimiento);
                                Console.WriteLine(Nacionalidad);
                                Console.WriteLine(Pasajero);
                                Console.WriteLine(Equipaje);
                                Console.WriteLine(Asiento);
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
            }
        }


        public bool ObtenerDetallesVuelo(Label Aerolinea, Label Numero_Vuelo, Label Origen, Label Destino, Label Salida, Label Llegada, Label Avion, Label Hora_Salida, Label Hora_Llegada, Label Puerta, Label Precio)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";

            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();
                    
                    string consulta = @"Select aerolinea.Nombre, vuelos.ID, rutas.CodigoOrigen, rutas.CodigoDestino, vuelos.FechaSalida,
                                 vuelos.FechaLlegada, Modelo, HoraSalida, HoraLlegada, vuelos.Puerta, vuelos.Precio
                                 from aviones 
                                 INNER join vuelos on aviones.ID = vuelos.ID
                                 INNER JOIN aerolinea on aviones.aerolinea_ID = aerolinea.ID
                                 INNER JOIN rutas on vuelos.rutas_ID = rutas.ID
                                 INNER JOIN asientos on aviones.ID = asientos.aviones_ID
                                 where vuelos.ID = @vuelos and aviones.ID = @aviones and asientos.NumeroAsiento = @asiento";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conector))
                    {
                        comando.Parameters.AddWithValue("@vuelos", ObtenerId);
                        comando.Parameters.AddWithValue("@aviones", ObtenerAvion);
                        comando.Parameters.AddWithValue("@asiento", ObtenerSitio);
                        Console.WriteLine("Id Vuelo :" + ObtenerId);
                        Console.WriteLine("Id Avion :" + ObtenerAvion);
                        Console.WriteLine("Id Vuelo :" + ObtenerSitio);

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

                                
                                Console.WriteLine(Aerolinea);
                                Console.WriteLine(Numero_Vuelo);
                                Console.WriteLine(Origen);
                                Console.WriteLine(Destino);
                                Console.WriteLine(Salida);
                                Console.WriteLine(Llegada);
                                Console.WriteLine(Avion);
                                Console.WriteLine(Hora_Llegada);
                                Console.WriteLine("Soy precio" + Precio);
                                Console.WriteLine("Monto de Vuelo" + ObtenerMonto);
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
            }
        }


        public bool ReservarEnDB()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";

            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();

                    string consultaAsiento = @"Select asientos.ID from asientos 
                                                INNER JOIN  aviones on asientos.aviones_ID = aviones.ID
                                                where NumeroAsiento = @numero and aviones.ID = @avion";

                    using (MySqlCommand comandoAsiento = new MySqlCommand(consultaAsiento, conector))
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

                    using (MySqlCommand comando = new MySqlCommand(consulta, conector))
                    {
                        comando.Parameters.AddWithValue("@estado", "Pendiente");
                        comando.Parameters.AddWithValue("@fecha", DateTime.Now);
                        comando.Parameters.AddWithValue("@pasajero", ObtenerIdUsuario);
                        comando.Parameters.AddWithValue("@asientos", ObtenerAsientoID);
                        comando.Parameters.AddWithValue("@vuelos", ObtenerId);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            string input = "SELECT LAST_INSERT_ID()";
                            using (MySqlCommand obtenerIDCmd = new MySqlCommand(input, conector))
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
                    MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
        }
    }
}
