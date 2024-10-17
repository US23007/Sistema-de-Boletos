using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class Vuelos
    {
        private int ID;
        private String Origen;
        private String Destino;


        public void ObtenerVuelo(int id)
        {
            ID = id;
        }

        public int IdVuelo
        {
            get { return ID; }
            set { ID = value; }
        }


        public void ObtenrRutas(ComboBox origen,ComboBox destino)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            MySqlConnection conector = new MySqlConnection(connectionString);

            try
            {
                conector.Open();
                string query = "Select  DISTINCT Origen,Destino From vuelos";

                using (MySqlCommand comando = new MySqlCommand(query, conector))

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
        }
    }
}
