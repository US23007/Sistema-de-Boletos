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
    class Sistema
    {


        public bool Aerolineas(DataGridView aerolinea)
        {

            try
            {
                Conexion conexion = new Conexion();
                string consulta = @"SELECT * FROM aerolinea;";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.Conectar()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            aerolinea.DataSource = dt; 
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal y no se pudo cargar los Datos","Reiniciar Programa",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
            }catch(MySqlException ex)
            {
                MessageBox.Show("Algo salio mal y no se pudo cargar los Datos", "Reiniciar Programa"+ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

    }
}
