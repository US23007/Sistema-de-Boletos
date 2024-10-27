using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{

    //Clase Conexión nos ayudara a verificar desde ubn inicio si la conexión ala Base de Datos fue exitosa o no 
    class Conexion
    {
       
        static string query = "Server = localhost; Port=3306;Database= clave2_grupo3db ;Uid=root;Pwd=12345;";
        MySqlConnection conector = new MySqlConnection(query);

        public MySqlConnection Conectar()
        {
            try
            {
                conector.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se puedo conectar a la Base de Datos", "Verificar Conexion" + ex.ToString());
            } return conector;

        }


        public void Desconectar()
        {
            //Cierra la conexion a la BD
            conector.Close();
        }

    }
}
