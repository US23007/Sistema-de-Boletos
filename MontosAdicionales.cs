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

        private static decimal MontoConCargos { get; set; }

        public static decimal Total { get; set; }
        public Decimal PagoTotal
        {
            get { return MontoConCargos; }
            set { MontoConCargos = value; }
        }

        public bool AgregarMontos()
        {
            
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            using (MySqlConnection conector = new MySqlConnection(connectionString))
            {
              
                if(TipoMaletas == "De Mano")
                {
                    MontoConCargos = ObtenerMonto + ObtenerMonto * 0.10m;
                    MessageBox.Show("Se cobrará un 10% adicional al monto del vuelo por equipaje de mano","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    Console.WriteLine("Monto Total" + MontoConCargos);
                    Total = MontoConCargos;

                }
                else if(TipoMaletas == "De Bodega")
                {
                    MontoConCargos = ObtenerMonto + ObtenerMonto * 0.20m;
                    MessageBox.Show("Se cobrará un 20% adicional al monto del vuelo por equipaje de Bodega", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Console.WriteLine("Monto Total" + MontoConCargos);
                    Total = MontoConCargos;
                }
                
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
                        Console.WriteLine(MontoConCargos);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al insertar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
            }
        }

        public bool MostrarMontosAdicionales(Label precioVuelo,Label Equipaje,Label total)
        {
            precioVuelo.Text = string.Format("${0:N2}", ObtenerMonto);
            Equipaje.Text = TipoMaletas;
            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            string monto = @"Select Monto from pagos where pagos.reserva_ID = @reserva";
            using (MySqlConnection conector = new MySqlConnection(connectionString)){

                try{
                    conector.Open();
                    using (MySqlCommand comandoInsert = new MySqlCommand(monto, conector))
                    {
                        comandoInsert.Parameters.AddWithValue("@reserva", ObtenerReserva);
                        using (MySqlDataReader reader = comandoInsert.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                total.Text = string.Format("${0:N2}", reader["Monto"]);
                                MessageBox.Show("Datos Cargados Correctamente", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al insertar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

        }


        public bool ActualizarEstados() {

            string connectionString = "Server=localhost;Port=3306;Database='clave2_grupo3db';Uid=root;Pwd=12345;";
            string actualizarReserva = "UPDATE reserva SET Estado = 'Completada' WHERE ID = @reserva;";
            string actualizarPago = @"UPDATE pagos
                                       INNER JOIN reserva ON reserva.ID = pagos.reserva_ID
                                       SET pagos.Estado = 'Completado'
                                       WHERE reserva.ID = @reservaId;";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // Actualizar el estado de la reserva.
                        using (MySqlCommand cmdReserva = new MySqlCommand(actualizarReserva, conexion, transaccion))
                        {
                            cmdReserva.Parameters.AddWithValue("@reserva", ObtenerReserva);
                            cmdReserva.ExecuteNonQuery();
                        }

                        // Actualizar el estado del pago.
                        using (MySqlCommand cmdPago = new MySqlCommand(actualizarPago, conexion, transaccion))
                        {
                            cmdPago.Parameters.AddWithValue("@reservaId", ObtenerReserva);
                            cmdPago.ExecuteNonQuery();
                        }

                        // Confirmar los cambios si ambas actualizaciones son exitosas.
                        transaccion.Commit();
                        MessageBox.Show("Estados actualizados correctamente.", "Proceso Completado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        // Revertir cambios en caso de error.
                        transaccion.Rollback();
                        MessageBox.Show($"Error al actualizar los estados: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

        }
    }
}
