﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class Pasajero : ValidarIngreso
    {
        private String Nombre_Completo;
        private DateTime Fecha_Nacimiento;
        private String Numero_Pasaporte;
        private int Asiento;
        private string Telefono;
        private String Nacionalidad;
        private String Tipo_Equipaje;
        private String Tipo_Pasajero;
        private static int idPasajero { get; set; }
        
       


        public void Ingresar_Pasajero(string nombre,DateTime fecha,string pasaporte,int asiento,string telefono, string nacionalidad,string tipo_equipaje,string tipo_pasajero)
        {
            this.Nombre_Completo = nombre;
            this.Fecha_Nacimiento = fecha;
            this.Numero_Pasaporte = pasaporte;
            this.Asiento = asiento;
            this.Telefono = telefono;
            this.Nacionalidad = nacionalidad;
            this.Tipo_Equipaje = tipo_equipaje;
            this.Tipo_Pasajero = tipo_pasajero;
        }

        public String NombrePasajero
        {
            get { return Nombre_Completo; }
            set { Nombre_Completo = value; }
        }

        public DateTime Fecha
        {
            get { return Fecha_Nacimiento; }
            set { Fecha_Nacimiento = value; }
        }

        public String Pasaporte
        {
            get { return Numero_Pasaporte; }
            set { Numero_Pasaporte = value; }
        }

        public int Butaca
        {
            get { return Asiento; }
            set { Asiento= value; }
        }

        public string Celular
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        public String Procedencia
        {
            get { return Nacionalidad; }
            set { Nacionalidad = value; }
        }

        public String Equipaje
        {
            get { return Tipo_Equipaje; }
            set { Tipo_Equipaje = value; }
        }

        public String Turista
        {
            get { return Tipo_Pasajero; }
            set { Tipo_Pasajero = value; }
        }

        public bool ObtenerAsientos(ComboBox asientos)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            MySqlConnection conector = new MySqlConnection(connectionString);

            try
            {
                conector.Open();
                string query = @"SELECT asientos.NumeroAsiento
                                        FROM asientos
                                        INNER JOIN aviones ON asientos.aviones_ID = aviones.ID
                                        INNER JOIN vuelos ON aviones.ID = vuelos.aviones_ID
                                        WHERE vuelos.ID = @vuelo AND aviones.ID = @avion AND asientos.Estado = 'Disponible';
                                        ";


                using (MySqlCommand comando = new MySqlCommand(query, conector))

                {
                    comando.Parameters.AddWithValue("@vuelo",ObtenerId);
                    comando.Parameters.AddWithValue("@avion", ObtenerAvion);
                    MySqlDataReader reader = comando.ExecuteReader();

                    asientos.Items.Clear();

                    while (reader.Read())
                    {
                        asientos.Items.Add(reader["NumeroAsiento"].ToString());
                        
                    }

                    reader.Close();
                }

                if(asientos.Items.Count == 0)
                {
                    MessageBox.Show("Hubo un error al cargar los asientos, porfavor reiniciar la aplicación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un problema al conectar a la base de Datos.", "Reiniciar" + ex.Message);
                return false;
            }
            
        }

        public bool RegistrarPasajero()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();
                    string query = @"SELECT COUNT(*) FROM pasajero WHERE Usuario_ID = @usuario ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conector))
                    {
                        cmd.Parameters.AddWithValue("@usuario", ObtenerIdUsuario);
                        int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                        if (resultado > 0)
                        {
                            MessageBox.Show("Los Datos del Pasajero ya existen en la base de  Datos",
                                            "Datos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }

                        string consulta = @"INSERT INTO pasajero (usuario_ID,NombreCompleto, Nacionalidad,TipoEquipaje,Pasaporte,Fechanacimiento,Telefono,TipoPasajero,PreferenciaAsiento) 
                                VALUES (@user,@nombre,@nacionalidad,@equipaje,@pasaporte,@fecha,@celular,@pasajero,@asiento)";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conector))
                        {
                            comando.Parameters.AddWithValue("@user", ObtenerIdUsuario);
                            comando.Parameters.AddWithValue("@nombre", NombrePasajero);
                            comando.Parameters.AddWithValue("@nacionalidad", Procedencia);
                            comando.Parameters.AddWithValue("@equipaje", Equipaje);
                            comando.Parameters.AddWithValue("@pasaporte", Pasaporte);
                            comando.Parameters.AddWithValue("@fecha", Fecha);
                            comando.Parameters.AddWithValue("@celular", Celular);
                            comando.Parameters.AddWithValue("@pasajero", Turista);
                            comando.Parameters.AddWithValue("@asiento", Butaca);

                            int filasAfectadas = comando.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Pasajero registrado exitosamente.",
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
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error en registrar pasajero al conectar con la base de datos: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public bool ObtenerCantidadAsientos(Label cantidad,Label asientos)
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();
                    string consulta = @"SELECT 
                                        COUNT(*) AS 'Cantidad de Asientos',
                                        SUM(CASE WHEN asientos.Estado = 'Disponible' THEN 1 ELSE 0 END) AS 'Asientos Disponibles'
                                        FROM asientos
                                        INNER JOIN aviones ON asientos.aviones_ID = aviones.ID
                                        INNER JOIN vuelos ON vuelos.aviones_ID = aviones.ID
                                        WHERE vuelos.ID = @id AND aviones.ID = @avionID;
";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conector))
                    {
                        comando.Parameters.AddWithValue("@id", ObtenerId);
                        comando.Parameters.AddWithValue("@avionID", ObtenerAvion);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                int cantidadAsientos = reader.GetInt32(0);
                                int asientosDisponibles = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                cantidad.Text = cantidadAsientos.ToString();
                                asientos.Text = asientosDisponibles.ToString();

                                return true;
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }



                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error en obtener cantidad asiento al conectar con la base de datos: " + ex.Message,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool ReservarAsiento()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();
                    string consulta = @"Update asientos
                                INNER JOIN aviones ON asientos.aviones_ID = aviones.ID
                                INNER JOIN vuelos ON vuelos.aviones_ID = aviones.ID
                                set asientos.Estado ='Reservado'
                                WHERE vuelos.ID = @id and aviones.ID = @avion and asientos.NumeroAsiento = @asiento";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conector))
                    {
                        comando.Parameters.AddWithValue("@id", ObtenerId);
                        comando.Parameters.AddWithValue("@avion", ObtenerAvion);
                        comando.Parameters.AddWithValue("@asiento", Butaca);


                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Asiento Reservado con exito.",
                                            "Asiento Reservado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reservar el asiento.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error en reservar asiento al conectar con la base de datos: " + ex.Message,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
