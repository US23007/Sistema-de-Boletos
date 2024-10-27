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
    class Vuelos
    {
        private static int ID { get; set; }
        private static int Avion { get; set;}
        private String Origen;
        private String Destino;
        private DateTime Fecha_Salida;
        private TimeSpan Hora_Salida;



        public int ObtenerAvion
        {
            get { return Avion; }
            set { Avion = value; }
        }

        public int ObtenerId
        {
            get { return ID;}
            set { ID = value;}
        }


        public void Viaje(string origen, string destino,DateTime fecha,TimeSpan hora)
        {
            Origen = origen;
            Destino = destino;
            Fecha_Salida = fecha;
            Hora_Salida = hora;
        }
        public String OrigenVuelo
        {
            get { return Origen; }
            set { Origen = value;}

        }

        public String DestinoVuelo
        {
            get { return Destino; }
            set { Destino = value; }


        }

       public DateTime FechaSalida
        {
            get { return Fecha_Salida; }
            set { Fecha_Salida = value; }
        }

        public TimeSpan HoraSalida
        {
            get { return Hora_Salida;}
            set { Hora_Salida = value;}
        }




        public void ObtenrRutas(ComboBox origen,ComboBox destino)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            try
            {
                string query = "Select  DISTINCT Origen,Destino From rutas";

                using (MySqlCommand comando = new MySqlCommand(query, conn))

                {
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        origen.Items.Add(reader["Origen"].ToString());
                        destino.Items.Add(reader["Destino"].ToString());
                    }

                    reader.Close();
                    //Microsoft.VisualBasic.Interaction.MsgBox("Datos Cargados");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un problema al conectar a la base de Datos.","Reiniciar"+ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void ObtenerVuelosDisponibles(DataGridView informacion)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            try {
                    

                string consulta = "SELECT vuelos.ID, aerolinea.Nombre, aerolinea.Codigo, Origen, Destino, FechaSalida, FechaLlegada, Duracion, HoraSalida, HoraLlegada,aviones.ID,aviones.TipoAvion, Precio " +
                                      "FROM vuelos " +
                                      "INNER JOIN aviones ON vuelos.aviones_ID = aviones.ID " +
                                      "INNER JOIN aerolinea ON aviones.aerolinea_ID = aerolinea.ID " +
                                      "INNER JOIN rutas ON vuelos.rutas_ID = rutas.ID " +
                                      "WHERE Origen = @origen AND Destino = @destino AND FechaSalida = @fecha AND HoraSalida = @hora";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                    {
                        comando.Parameters.AddWithValue("@origen", OrigenVuelo);
                        comando.Parameters.AddWithValue("@destino", DestinoVuelo);
                        comando.Parameters.AddWithValue("@fecha", FechaSalida);
                        comando.Parameters.AddWithValue("@hora", HoraSalida);

                        DataTable data = new DataTable(); // Crear el DataTable antes del bucle
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                data.Load(reader); // Cargar todos los datos en el DataTable
                                informacion.DataSource = data; // Asignar el DataTable al DataGridView
                                MessageBox.Show("Coincidencias Encontradas", "Datos Encontrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                reader.Close();
                                MessageBox.Show("No hay resultados en la Busqueda", "Resultados No encontrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show("Mostrando coincidencias para Ciudad de Origen:" + OrigenVuelo +
                                                "-- Ciudad de Destino: " + DestinoVuelo,
                                                "Resultados No Encontrados",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);

                                string consultaGeneral = "SELECT vuelos.ID, aerolinea.Nombre, aerolinea.Codigo, Origen, Destino, FechaSalida, FechaLlegada, Duracion, HoraSalida, HoraLlegada,aviones.ID as 'ID del Avión',aviones.TipoAvion, Precio " +
                                                         "FROM vuelos " +
                                                         "INNER JOIN aviones ON vuelos.aviones_ID = aviones.ID " +
                                                         "INNER JOIN aerolinea ON aviones.aerolinea_ID = aerolinea.ID " +
                                                         "INNER JOIN rutas ON vuelos.rutas_ID = rutas.ID " +
                                                         "WHERE Origen = @ciudadorigen AND Destino = @ciudaddestino";

                                using (MySqlCommand nuevocomando = new MySqlCommand(consultaGeneral, conn))
                                {
                                    nuevocomando.Parameters.AddWithValue("@ciudadorigen", OrigenVuelo);
                                    nuevocomando.Parameters.AddWithValue("@ciudaddestino", DestinoVuelo);

                                    using (MySqlDataReader lector = nuevocomando.ExecuteReader())
                                    {
                                        if (lector.HasRows)
                                        {
                                            data.Load(lector); // Cargar datos de la segunda consulta
                                            informacion.DataSource = data; // Asignar el DataTable al DataGridView
                                            MessageBox.Show("Coincidencias Encontradas en la búsqueda general", "Datos Encontrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se encontraron coincidencias en la búsqueda general", "Resultados No encontrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Hubo un problema al conectar a la base de datos. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
