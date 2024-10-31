using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave2_Grupo3_US23007_
{
    /// <summary>
    /// Este Form lo agregue para darle "Estilo" al programa 
    /// </summary>
    public partial class FormCarga : System.Windows.Forms.Form
    {
        public FormCarga()
        {
            InitializeComponent();
            timer1.Start(); // Iniciar Contador Timer
        }

        int segundos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos > 1)   // Cuando las milesimas de segundos lleguen al segundo
            {
                timer1.Stop(); // Detendran el Timer
                Admin admin = new Admin(); // Abriran el Form Admin
                admin.Show(); // Se mostrara en pantalla 
                this.Hide(); // el Form Carga sera invisible 
            }
            
        }
    }
}
