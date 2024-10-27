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

        public void MostrarMontosAdicionales(Label precioVuelo,Label Equipaje,Label total)
        {
            precioVuelo.Text = string.Format("${0:N2}", ObtenerMonto);
            Equipaje.Text = TipoMaletas;
            total.Text = string.Format("${0:N2}",Total);
            Console.WriteLine("Soy Total" + Total);

        }

        
    }
}
