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
    /// Esta clase servira para la comprobacion de datos entre ael Admin y la Base de Datos 
    /// </summary>
    class Administrador
    {
        // Variables de Entrada
        private static String Usuario { get; set; } // Variable static para uso a lo largo de la ejecucion de el programa
        private String Nombre_Usuario;  // Variable String que recibira el valor del campo Usuario
        private String Contraseña_Usuario; // Variable String que recibira el valor del campo Contraseña


        public void Validar(string nombre, string contraseña)  //Constructor 
        {
            this.Nombre_Usuario = nombre;
            this.Contraseña_Usuario = contraseña;

        }

        // Propiedades de Clase 
        public String Nombre
        {
            get { return Nombre_Usuario; }
            set { Nombre_Usuario = value; }
        }
        public String Contraseña
        {
            get { return Contraseña_Usuario; }
            set { Contraseña_Usuario = value; }
        }

        public String ObtenerUsuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }


        // Método para Consultar si existe el Usuario y Constraseña Ingresados retornado un true si existe y un false en el caso contrario
        public bool IngresoAdministrador()
        {
           
            try
            {
                Conexion conexion = new Conexion();  // Instancia de Clase Conexion 
                 string consulta = "SELECT * FROM administrador WHERE Usuario = @nombre AND Contraseña = @contraseña";   //Consulta 

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@contraseña", Contraseña);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                    
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
