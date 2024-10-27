using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            
            try
            {
                byte[] imageBytes = ConvertImageToByteArray(@"C:/Users/su487/Downloads/GUA.jpg");
                string consulta = "UPDATE clave2_grupo3db.rutas SET Imagen =@imagen WHERE ID = 1";
                MySqlCommand cmd = new MySqlCommand(consulta, conn);
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


        public bool MostrarInformacion(Label descripcion,Label Corigen,Label Cdestino,Label horasalida, Label origen, Label duracion, PictureBox dibujo,
                           Label aerlinea, Label precio, Label destino, Label horallegada,
                           Label aerpuertOrigen, Label aeropuertoDestino, Label distancia,Label Empleados)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
           
                string consulta = @"SELECT 
                                    rutas.Descripcion, 
                                    rutas.Origen,
                                    rutas.Destino,
                                    rutas.CodigoOrigen,
                                    rutas.CodigoDestino,
                                    vuelos.HoraSalida, 
                                    vuelos.HoraLlegada, 
	                                rutas.Duracion, 
                                    rutas.AeropuertoOrigen,
                                    rutas.AeropuertoDestino,
                                    rutas.Distancia,
                                    aerolinea.Nombre AS NombreAerolinea, 
                                    GROUP_CONCAT(CONCAT(empleados.Cargo, ':  ', empleados.NombreCompleto, '  ') SEPARATOR '\n') AS EmpleadosConCargo,
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
                                    aerolinea.Nombre;";
                

                try
                {
                    
                    MySqlCommand cmd = new MySqlCommand(consulta, conn);
                    cmd.Parameters.AddWithValue("@id", ObtenerId);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {
                        if (leer.Read())
                        {
                            descripcion.Text = leer["Descripcion"].ToString();
                            origen.Text = leer["Origen"].ToString();
                            destino.Text = leer["Destino"].ToString();
                            Corigen.Text = leer["CodigoOrigen"].ToString();
                            Cdestino.Text = leer["CodigoDestino"].ToString();
                            TimeSpan horaSalida = (TimeSpan)leer["HoraSalida"];
                            horasalida.Text = horaSalida.ToString(@"hh\:mm");
                            TimeSpan hora = (TimeSpan)leer["HoraLlegada"];
                            horallegada.Text = hora.ToString(@"hh\:mm");
                            duracion.Text = string.Format("{0} min", leer["Duracion"]);
                            aerpuertOrigen.Text = leer["AeropuertoOrigen"].ToString();
                            aeropuertoDestino.Text = leer["AeropuertoDestino"].ToString();
                            distancia.Text = string.Format("{0} km", leer["Distancia"]);
                            aerlinea.Text = leer["NombreAerolinea"].ToString();
                            precio.Text = string.Format("${0:N2}", leer["Precio"]);
                            Empleados.Text = leer["EmpleadosConCargo"].ToString();

                            try
                            {
                                if (!leer.IsDBNull(leer.GetOrdinal("Imagen")))
                                {
                                    byte[] imageBytes = (byte[])leer["Imagen"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        dibujo.Image = Image.FromStream(ms);
                                    }

                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("La imagen no está disponible.","Hubo un error al cargar la imagen",MessageBoxButtons.OK,MessageBoxIcon.Error);

                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("La imagen no está disponible.", "Hubo un error al cargar la imagen"+ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return true;
                            }
                            
                           
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos.","Hubo un error al buscar el registro en la base de Datos",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            return false;

                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
