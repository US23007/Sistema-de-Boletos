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
    public partial class FormCarga : System.Windows.Forms.Form
    {
        public FormCarga()
        {
            InitializeComponent();
            timer1.Start();
        }

        int segundos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos > 1)
            {
                timer1.Stop();
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            
        }
    }
}
