using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{

    //Clase para Validar el Usuario , Contraseña y Correo
    class ValidarIngreso : Vuelos
    {
        private static String Usuario { get; set; }
        private static int idUsuario { get; set; }
        private String Nombre_Usuario;
        private String Correo_Usuario;
        private String Contraseña_Usuario;


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
        public void Validar(string nombre, string contraseña, string correo)
        {
            this.Nombre_Usuario = nombre;
            this.Contraseña_Usuario = contraseña;
            this.Correo_Usuario = correo;

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

        public String Correo
        {
            get { return Correo_Usuario; }
            set { Correo_Usuario = value; }

        }


        public bool RegistrarEnDB(string usuario, string correo, string contraseña)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();

                    // Verificar si el usuario o correo ya existe
                    string query = @"SELECT COUNT(*) FROM usuario WHERE Usuario = @usuario OR Correo = @correo";
                    using (MySqlCommand cmd = new MySqlCommand(query, conector))
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
                    string consulta = @"INSERT INTO usuario (Usuario, Contraseña, Correo) 
                                VALUES (@usuario, @contraseña, @correo)";
                    using (MySqlCommand comando = new MySqlCommand(consulta, conector))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@contraseña", contraseña);
                        comando.Parameters.AddWithValue("@correo", correo);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            string input = "SELECT LAST_INSERT_ID()";
                            using (MySqlCommand obtenerIDCmd = new MySqlCommand(input, conector))
                            {
                                ObtenerIdUsuario = Convert.ToInt32(obtenerIDCmd.ExecuteScalar());
                            }
                            Console.WriteLine(ObtenerIdUsuario);
                            MessageBox.Show("Usuario registrado exitosamente.",
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
            }
        }

        public bool IngresoUsuario()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            MySqlConnection conector = new MySqlConnection(connectionString);

            try
            {
                conector.Open();
                string consulta = "SELECT ID FROM usuario WHERE Usuario = @nombre AND Contraseña = @contraseña AND Correo = @correo";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conector))
                {
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@contraseña", Contraseña);
                    cmd.Parameters.AddWithValue("@correo", Correo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ObtenerIdUsuario = reader.GetInt32("ID");
                            Console.WriteLine(ObtenerIdUsuario);
                            MessageBox.Show("Bienvenido Usuario", "Cuenta Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool IngresoAdministrador()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            MySqlConnection conector = new MySqlConnection(connectionString);

            try
            {
                conector.Open();
                string consulta = "SELECT * FROM administrador WHERE administrador.ID = 1 AND Usuario = @nombre AND Contraseña = @contraseña AND Correo = @correo";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conector))
                {
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@contraseña", Contraseña);
                    cmd.Parameters.AddWithValue("@correo", Correo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("Bienvenido Administrador", "Cuenta Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
             
}
