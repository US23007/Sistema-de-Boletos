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

        public bool MostrarInformacionPasajero()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            Reserva reserva = new Reserva();
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();

                    // Primera consulta para el pasajero
                    string consulta1 = @"Select NombreCompleto, Pasaporte, Telefono, Fechanacimiento, Nacionalidad, TipoPasajero, TipoEquipaje, PreferenciaAsiento 
                                 from pasajero 
                                 INNER JOIN usuario on pasajero.usuario_ID = usuario.ID 
                                 where pasajero.usuario_ID = @idUser";

                    using (MySqlCommand comando1 = new MySqlCommand(consulta1, conector))
                    {
                        comando1.Parameters.AddWithValue("@idUser", ObtenerIdUsuario);
                        Console.WriteLine("Id Vuelo:"+ObtenerIdUsuario);

                        using (MySqlDataReader reader = comando1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                reserva.lbl_Nombre.Text = reader["NombreCompleto"].ToString();
                                reserva.lblPasaporte.Text = reader["Pasaporte"].ToString();
                                reserva.lbl_Telefono.Text = reader["Telefono"].ToString();
                                reserva.lbl_Nacimiento.Text = reader["Fechanacimiento"].ToString();
                                reserva.lbl_Nacionalidad.Text = reader["Nacionalidad"].ToString();
                                reserva.lbl_Pasajero.Text = reader["TipoPasajero"].ToString();
                                reserva.lbl_Equipaje.Text = reader["TipoEquipaje"].ToString();
                                reserva.lbl_Asiento.Text = reader["PreferenciaAsiento"].ToString();

                                MessageBox.Show("Todo bien en Pasajero Datos");
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
