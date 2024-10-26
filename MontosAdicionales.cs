using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    class MontosAdicionales : Reservaciones
    {

        private static decimal MontoVuelo{get; set;}
        private static decimal MontoConCargos { get; set; }

        public Decimal PagoVuelo
        {
            get { return MontoVuelo;}
            set { MontoVuelo = value; }
        }

        public Decimal PagoTotal
        {
            get { return MontoConCargos; }
            set { MontoConCargos = value; }
        }

        public bool AgregarMontos()
        {
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            decimal montoBase = 0;
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
              
                try
                    {
                        conector.Open();
                        string consultaPrecio = @"SELECT vuelos.Precio 
                                                    FROM vuelos  
                                                    JOIN reserva  ON vuelos.ID = reserva.vuelos_ID
                                                    JOIN pasajero on reserva.pasajero_ID = pasajero.ID
                                                    WHERE reserva.vuelos_ID = @reserva and pasajero.ID = @pasajero";
                            using (MySqlCommand comandoPrecio = new MySqlCommand(consultaPrecio, conector))
                            {
                                comandoPrecio.Parameters.AddWithValue("@reserva", ObtenerReserva);
                                comandoPrecio.Parameters.AddWithValue("@pasajero", Passenger);

                                object resultado = comandoPrecio.ExecuteScalar();


                                if (resultado != null) 
                                    {
                                        montoBase = Convert.ToDecimal(resultado); 
                                        MontoVuelo = montoBase;
                                        return true;
                                    }
                                else
                                {
                                    MessageBox.Show("No se encontró el precio para la reserva y pasajero especificados.",
                                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al obtener el precio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            decimal montoTotal = montoBase; 

            if (TipoMaletas == "De Mano")
            {
                montoTotal += montoBase * 0.10m;
                MontoConCargos = montoTotal;
            }
            else if (TipoMaletas == "De Bodega")
            {
                montoTotal += montoBase * 0.20m; 
            }


            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
                try
                {
                    conector.Open();

                    string consultaInsert = @"INSERT INTO pagos (Estado, reserva_ID, Monto, Fecha) 
                                      VALUES (@estado, @reservaId, @monto, NOW())";

                    using (MySqlCommand comandoInsert = new MySqlCommand(consultaInsert, conector))
                    {
                        comandoInsert.Parameters.AddWithValue("@estado", "Pendiente");
                        comandoInsert.Parameters.AddWithValue("@reservaId", ObtenerReserva);
                        comandoInsert.Parameters.AddWithValue("@monto", MontoConCargos);

                        int filasAfectadas = comandoInsert.ExecuteNonQuery();

                        return filasAfectadas > 0; 
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al insertar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
            }
        }

        
    }
}
