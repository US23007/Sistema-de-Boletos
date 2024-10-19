using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class Imagen : Vuelos
    {
       
       
        public void CargarImagenes()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            MySqlConnection conector = new MySqlConnection(connectionString);
            try
            {
                conector.Open();
                byte[] imageBytes = ConvertImageToByteArray(@"C:/Users/MINEDUCYT/Downloads/Guatemala.jpeg");
                string consulta = "UPDATE clave2_grupo3db.rutas SET Imagen =@imagen WHERE ID = 1";
                MySqlCommand cmd = new MySqlCommand(consulta, conector);
                cmd.Parameters.AddWithValue("@imagen", imageBytes);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos ingresados");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Algo salio mal" + ex);
            }


        }

       
        //Metodo que convierte una imagen a un arreglo de Bytes 
        private byte[] ConvertImageToByteArray(string imagePath)
        {
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                return br.ReadBytes((int)fs.Length);
            }
        }

        public void MostrarInformacion(TextBox descripcion, Label horasalida, Label origen, Label duracion, PictureBox dibujo,
                           Label aerlinea, Label precio, Label destino, Label horallegada,
                           Label aerpuertOrigen, Label aeropuertoDestino, Label distancia)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                string consulta = @"SELECT 
                                    rutas.Descripcion, 
                                    rutas.Origen,
                                    rutas.Destino,
                                    vuelos.HoraSalida, 
                                    vuelos.HoraLlegada, 
	                                rutas.Duracion, 
                                    rutas.AeropuertoOrigen,
                                    rutas.AeropuertoDestino,
                                    rutas.Distancia,
                                    aerolinea.Nombre AS NombreAerolinea, 

                                    Precio,
                                    rutas.Imagen
                                    FROM vuelos
                                    INNER JOIN aviones ON vuelos.aviones_ID = aviones.ID
                                    INNER JOIN aerolinea ON aviones.aerolinea_ID = aerolinea.ID
                                    INNER JOIN rutas ON vuelos.rutas_ID = rutas.ID
                                    INNER JOIN tripulacion ON tripulacion.aviones_ID = aviones.ID
                                    INNER JOIN empleados ON tripulacion.ID = empleados.tripulacion_ID
                                    WHERE vuelos.ID = @id
                                    GROUP BY
                                        vuelos.ID, 
                                        rutas.Descripcion, 
                                        vuelos.HoraSalida, 
                                        vuelos.HoraLlegada, 
                                        rutas.Duracion, 
                                        aerolinea.Nombre; ";

                try
                {
                    conector.Open();
                    MySqlCommand cmd = new MySqlCommand(consulta, conector);
                    Console.WriteLine("valor en IdVuelo"+ObtenerId);
                    Console.WriteLine("valor en ID" + ObtenerId);
                    cmd.Parameters.AddWithValue("@id", ObtenerId);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {
                        if (leer.Read())
                        {
                            descripcion.Text = leer["Descripcion"].ToString();
                            origen.Text = leer["Origen"].ToString();
                            destino.Text = leer["Destino"].ToString();
                            TimeSpan horaSalida = (TimeSpan)leer["HoraSalida"];
                            horasalida.Text = horaSalida.ToString(@"hh\:mm");
                            TimeSpan hora = (TimeSpan)leer["HoraLlegada"];
                            horallegada.Text = hora.ToString(@"hh\:mm");
                            duracion.Text = string.Format("{0} minutos", leer["Duracion"]);
                            aerpuertOrigen.Text = leer["AeropuertoOrigen"].ToString();
                            aeropuertoDestino.Text = leer["AeropuertoDestino"].ToString();
                            distancia.Text = string.Format("{0} km", leer["Distancia"]);
                            aerlinea.Text = leer["NombreAerolinea"].ToString();
                            precio.Text = string.Format("${0:N2}", leer["Precio"]);

                            try
                            {
                                if (!leer.IsDBNull(leer.GetOrdinal("Imagen")))
                                {
                                    byte[] imageBytes = (byte[])leer["Imagen"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        dibujo.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La imagen no está disponible.");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("La imagen no está disponible."+ex.Message);
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




    }
}
