using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class Imagen :Vuelos
    {
        public void CargarImagenes()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            MySqlConnection conector = new MySqlConnection(connectionString);
            try
            {
                conector.Open();
                byte[] imageBytes = ConvertImageToByteArray(@"C:/Users/MINEDUCYT/Downloads/Guatemala2.jpeg");
                string consulta = "UPDATE clave2_grupo3db.vuelos SET Imagen =@imagen WHERE ID = 2";
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




        public void MostrarLocales(Label id, Label nombre, Label disponible, TextBox direccion, PictureBox dibujo, TextBox texto, Label TipoLocal, Label Iluminacion, Label Sonido, Label Asientos)
        {

            string consulta = " ";
            try
            {
                MySqlCommand cmd = new MySqlCommand(consulta, objeto.Conectar());
                cmd.Parameters.AddWithValue("@ID", numero);
                using (MySqlDataReader leer = cmd.ExecuteReader())
                {
                    if (leer.Read())
                    {

                        id.Text = leer["idLocales"].ToString();
                        nombre.Text = leer["NombreLocal"].ToString();  // Corregido
                        disponible.Text = leer["DisponibilidadLocal"].ToString();  // Corregido
                        direccion.Text = leer["DireccionLocal"].ToString();  // Corregido

                        txtDescripcion.Text = leer["Descripcion"].ToString();  // Corregido
                        TipoLocal.Text = leer["TipoLocal"].ToString();  // Corregido
                        Iluminacion.Text = leer["Iluminacion"].ToString();  // Corregido
                        Sonido.Text = leer["Sonido"].ToString();  // Corregido
                        Asientos.Text = leer["Asientos"].ToString();  // Corregido


                        byte[] imageBytes = (byte[])leer["imgLocal"];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            dibujo.Image = Image.FromStream(ms);
                        }

                    }
                    else
                    {
                        //MessageBox.Show("No se encontraron datos para el ID proporcionado."); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salió mal: " + ex.Message);
            }
        }
    }
}
