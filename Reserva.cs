using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    /// <summary>
    /// Este Form mostrara informacion sobre el pasajero previamente ingresado y el vuelo elegido anteriormente
    /// </summary>
    public partial class Reserva : Form
    {
        public Reserva()
        {
            InitializeComponent();
           
        }

        private void btnConfimar_Click(object sender, EventArgs e)
        {
            Reservaciones reservaciones = new Reservaciones(); //Instancia de clase Reservaciones 
            MontosAdicionales monto = new MontosAdicionales(); //Instancia de clase MontoAdicionales 
            Pagos pagos = new Pagos(); //Instancia de FormPagos
            if (reservaciones.ReservarEnDB()) // Método de la clase reserva para realizar la reservacion
            {
                if (monto.AgregarMontos() && monto.MostrarMontosAdicionales(pagos.lbl_Precio_Vuelo,pagos.lbl_Equipaje,pagos.lbl_Monto))
                    //el primer Método es para agregar el agregar el monto totol con los cargos adicionales  y el segundo para mostrar esa informacion en el FormPagos 
                {
                    pagos.Show(); //Abrir FormPagos
                    this.Hide();
                }
                
            }
        }

        private void picPoliticas_Click(object sender, EventArgs e)
        {
            Reservaciones reservaciones = new Reservaciones(); //Instancia de clase Reservaciones
            Politicas politicas = new Politicas(); //Instancia de Form Politicas 
            if (reservaciones.ObtenerPoliticas(politicas.lbl_Politicas,politicas.lbl_Horas)) ////Método Para vericar politicas y condiciones de Cancelacion y Modificacion
            {
                politicas.ShowDialog(); //Abrir FormPoliticas
            }
        }
    }
}
