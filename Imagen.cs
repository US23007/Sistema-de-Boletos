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




        public void MostrarLocales(Label descripcion, Label horasalida, Label origen, Label duracion, PictureBox dibujo, Label aerlinea, Label precio, Label destino, Label horallegada, Label aerpuertOrigen ,Label aeropuertoDestino)
        {
            
        }
    }
}
