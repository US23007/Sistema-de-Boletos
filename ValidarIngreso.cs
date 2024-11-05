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
/// <summary>
/// Esta clase servira para la validacion de datos de Usuario como el Nombre de Usuario y Contraseña Ingresados 
/// </summary>
    class ValidarIngreso : Vuelos  //ValidarIngreso Hereda de Vuelos el ID Vuelo
    {

        //Variables Static
        private static String Usuario { get; set; }
        private static int idUsuario { get; set; }
        private String Nombre_Usuario;
        private String Correo_Usuario;
        


        //Métodos 
        public String ObtenerUsuario
        {
            get { return Usuario;}
            set { Usuario = value;}
        }

        public int ObtenerIdUsuario
        {
            get { return idUsuario;}
            set { idUsuario = value;}
        }
        
        //Constructor 
        public void Validar(string nombre,  string correo)
        {
            this.Nombre_Usuario = nombre;
            this.Correo_Usuario = correo;
        }

        // Propiedades de Clase
        public String Nombre
        {
            get { return Nombre_Usuario; }
            set { Nombre_Usuario = value; }
        }

       

        public String Correo
        {
            get { return Correo_Usuario; }
            set { Correo_Usuario = value; }

        }


        //Método para Registrar un Usuario-Pasajero en la DB
        public bool RegistrarEnDB(string usuario, string correo)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            
                try
                {                  
                    // Verificar si el usuario o correo ya existe
                    string query = @"SELECT COUNT(*) FROM usuario WHERE Usuario = @usuario OR Correo = @correo";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@correo", correo);

                        int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                        if (resultado > 0)
                        {
                            MessageBox.Show("El Usuario o Correo Electrónico ya existe.",
                                            "Datos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }

                    // Registrar el nuevo usuario
                    string consulta = @"INSERT INTO usuario (Usuario, Correo) 
                                VALUES (@usuario, @correo)";
                    using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@correo", correo);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            string input = "SELECT LAST_INSERT_ID()";
                            using (MySqlCommand obtenerIDCmd = new MySqlCommand(input, conn))
                            {
                                ObtenerIdUsuario = Convert.ToInt32(obtenerIDCmd.ExecuteScalar());

                            }
                            Console.WriteLine(ObtenerIdUsuario);
                            MessageBox.Show("Usuario Ingresado exitosamente.",
                                            "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el usuario.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
