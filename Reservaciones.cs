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

        public bool MostrarInformacion(Label Nombre, Label Pasaporte, Label Telefono, Label nacimiento, Label nacionalidad, Label pasajero, Label Tipo, Label asiento, Label aerolinea, Label Vuelo, Label Origen, Label Destino, Label FSalida, Label FLlegada, Label avion, Label HSalida, Label HLlegada, Label Puerta, Label Precio)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();

                    // Primera consulta para el pasajero
                    string consulta1 = @"Select NombreCompleto, Pasaporte, Telefono, Fechanacimiento, Nacionalidad, TipoPasajero, TipoEquipaje, PreferenciaAsiento 
                                 from pasajero 
                                 INNER JOIN usuario on pasajero.usuario_ID = usuario.ID 
                                 where usuario.ID = @idUser";

                    using (MySqlCommand comando1 = new MySqlCommand(consulta1, conector))
                    {
                        comando1.Parameters.AddWithValue("@idUser", ObtenerId);
                        Console.WriteLine("Id Vuelo:"+ObtenerId);

                        using (MySqlDataReader reader = comando1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Nombre.Text = reader["NombreCompleto"].ToString();
                                Pasaporte.Text = reader["Pasaporte"].ToString();
                                Telefono.Text = reader["Telefono"].ToString();
                                nacimiento.Text = reader["Fechanacimiento"].ToString();
                                nacionalidad.Text = reader["Nacionalidad"].ToString();
                                pasajero.Text = reader["TipoPasajero"].ToString();
                                Tipo.Text = reader["TipoEquipaje"].ToString();
                                asiento.Text = reader["PreferenciaAsiento"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos del pasajero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false; // Salir si no hay datos
                            }
                        }
                    }

                    // Segunda consulta para los vuelos
                    string consulta2 = @"Select aerolinea.Nombre, vuelos.ID, rutas.CodigoOrigen, rutas.CodigoDestino, vuelos.FechaSalida,
                                 vuelos.FechaLlegada, Modelo, HoraSalida, HoraLlegada, vuelos.Puerta, vuelos.Precio
                                 from aviones 
                                 INNER join vuelos on aviones.ID = vuelos.ID
                                 INNER JOIN aerolinea on aviones.aerolinea_ID = aerolinea.ID
                                 INNER JOIN rutas on vuelos.rutas_ID = rutas.ID
                                 INNER JOIN asientos on aviones.ID = asientos.aviones_ID
                                 where vuelos.ID = @vuelos and aviones.ID = @aviones and asientos.NumeroAsiento = @asiento";

                    using (MySqlCommand comando2 = new MySqlCommand(consulta2, conector))
                    {
                        comando2.Parameters.AddWithValue("@vuelos", ObtenerId); // Asegúrate de que esto es correcto
                        comando2.Parameters.AddWithValue("@aviones", ObtenerAvion); // Asegúrate de que esto es correcto
                        comando2.Parameters.AddWithValue("@asiento", ObtenerSitio); // Asegúrate de que esto es correcto
                        Console.WriteLine("Id Vuelo parte 2:" + ObtenerId);
                        Console.WriteLine("Id Avion:" + ObtenerAvion);
                        Console.WriteLine("Id ASiento:" + ObtenerSitio);

                        using (MySqlDataReader reader2 = comando2.ExecuteReader())
                        {
                            if (reader2.Read())
                            {
                                aerolinea.Text = reader2["Nombre"].ToString();
                                Vuelo.Text = reader2["ID"].ToString();
                                Origen.Text = reader2["CodigoOrigen"].ToString();
                                Destino.Text = reader2["CodigoDestino"].ToString();
                                FSalida.Text = reader2["FechaSalida"].ToString();
                                FLlegada.Text = reader2["FechaLlegada"].ToString();
                                avion.Text = reader2["Modelo"].ToString();
                                HSalida.Text = reader2["HoraSalida"].ToString();
                                HLlegada.Text = reader2["HoraLlegada"].ToString();
                                Puerta.Text = reader2["Puerta"].ToString();
                                Precio.Text = reader2["Precio"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos del vuelo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false; // Salir si no hay datos
                            }
                        }
                    }

                    return true; // Todo salió bien
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
