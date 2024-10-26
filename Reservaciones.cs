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
                                Nacimiento.Text = reader["Fechanacimiento"].ToString();
                                Nacionalidad.Text = reader["Nacionalidad"].ToString();
                                Pasajero.Text = reader["TipoPasajero"].ToString();
                                Equipaje.Text = reader["TipoEquipaje"].ToString();
                                Asiento.Text = reader["PreferenciaAsiento"].ToString();

                                MessageBox.Show("Todo bien en Pasajero Datos");
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
                                Salida.Text = reader["FechaSalida"].ToString();
                                Llegada.Text = reader["FechaLlegada"].ToString();
                                Avion.Text = reader["Modelo"].ToString();
                                Hora_Salida.Text = reader["HoraSalida"].ToString();
                                Hora_Llegada.Text = reader["HoraLlegada"].ToString();
                                Puerta.Text = reader["Puerta"].ToString();
                                Precio.Text = reader["Precio"].ToString();


                                MessageBox.Show("Todo bien en Detalles");
                                Console.WriteLine(Aerolinea);
                                Console.WriteLine(Numero_Vuelo);
                                Console.WriteLine(Origen);
                                Console.WriteLine(Destino);
                                Console.WriteLine(Salida);
                                Console.WriteLine(Llegada);
                                Console.WriteLine(Avion);
                                Console.WriteLine(Hora_Llegada);
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

    }
}
