using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class ValidarIngreso
    {
        private String Nombre_Usuario;
        private String Correo_Usuario;
        private String Contraseña_Usuario;


        public ValidarIngreso(string nombre, string contraseña, string correo)
        {
            this.Nombre_Usuario = nombre;
            this.Contraseña_Usuario = contraseña;
            this.Correo_Usuario = correo;

        }

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
