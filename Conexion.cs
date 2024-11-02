using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    /// <summary>
    /// Clase Conexión es el eje central de nuestro programa ya que todas la consultas , verficaciones utilizan esta clase para comuinicacion entre My SQL y C#
    /// </summary>

    //Proyecto Antes de Hacer Cambios en el Conector 
    //Creacion de una rama segundaria para cambiar de conector sin afectar a la rama main
    class Conexion
    {
       
        static string query = "Server = localhost; Port=3306;Database= clave2_grupo3db ;Uid=root;Pwd=root;"; //Cadena de Conexion a la DB
        MySqlConnection conector = new MySqlConnection(query);

        public MySqlConnection Conectar() // Conectar
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

        //Probando cambios en segunda rama 
    }
}
