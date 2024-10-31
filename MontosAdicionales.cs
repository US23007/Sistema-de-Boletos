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
    class MontosAdicionales : Reservaciones // MontoAdicional Hereda el ID Reserva  de la Clase Reserva
    {

        private static decimal MontoConCargos { get; set; } //Variable Static para la conservacion de datos durante la ejecucion 

        public static decimal Total { get; set; } //Variable Static para la conservacion de datos durante la ejecucion 
        public Decimal PagoTotal //Método para obtener el pago total 
        {
            get { return MontoConCargos; }
            set { MontoConCargos = value; }
        }


        //Agregar Monto adicional dependiendo de el tipo de Equipaje 
        public bool AgregarMontos()
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            
              
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
                   
                    //Consulta para ingresar el pago hecho 
                    string consultaInsert = @"INSERT INTO pagos (Estado, reserva_ID, Monto, Fecha) 
                                      VALUES (@estado, @reservaId, @monto, NOW())";

                    using (MySqlCommand comandoInsert = new MySqlCommand(consultaInsert, conn))
                    {
                        comandoInsert.Parameters.AddWithValue("@estado", "Pendiente");
                        comandoInsert.Parameters.AddWithValue("@reservaId", ObtenerReserva);
                        comandoInsert.Parameters.AddWithValue("@monto", MontoConCargos);

                        int filasAfectadas = comandoInsert.ExecuteNonQuery();

                        return filasAfectadas > 0;
                        //Console.WriteLine(MontoConCargos); //Comentario Adicional en debugs
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al insertar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //Mostrar el precio de Vuelo , Tipo de Equipaje y El monto Total con el porcentaje agregado 
        public bool MostrarMontosAdicionales(Label precioVuelo,Label Equipaje,Label total)
        {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();
            precioVuelo.Text = string.Format("${0:N2}", ObtenerMonto);
            Equipaje.Text = TipoMaletas;
           
            string monto = @"Select Monto from pagos where pagos.reserva_ID = @reserva";
            
                try{
                 
                    using (MySqlCommand comandoInsert = new MySqlCommand(monto, conn))
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
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

        }

        //Método para Cambiar el estado de la reserva como Completada despues de realizar el pago
        public bool ActualizarEstados() {
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            
            string actualizarReserva = "UPDATE reserva SET Estado = 'Completada' WHERE ID = @reserva;";
            string actualizarPago = @"UPDATE pagos
                                       INNER JOIN reserva ON reserva.ID = pagos.reserva_ID
                                       SET pagos.Estado = 'Completado'
                                       WHERE reserva.ID = @reservaId;";

            using (MySqlTransaction transaccion = conn.BeginTransaction())
            {
                try
                {
                    // Actualizar el estado de la reserva.
                    using (MySqlCommand cmdReserva = new MySqlCommand(actualizarReserva, conn, transaccion))
                    {
                        cmdReserva.Parameters.AddWithValue("@reserva", ObtenerReserva);
                        cmdReserva.ExecuteNonQuery();
                    }

                    // Actualizar el estado del pago.
                    using (MySqlCommand cmdPago = new MySqlCommand(actualizarPago, conn, transaccion))
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
}
