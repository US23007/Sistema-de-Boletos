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
    public partial class Reserva : Form
    {
        public Reserva()
        {
            InitializeComponent();
            panelVisa.Visible = false; 
            panelAmerican.Visible = false;
            panelMasterCard.Visible = false;
            panelBancoAgricola.Visible = false;
        }

        private void cbxVisa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxVisa.Checked)
            {

                Desmarcar(cbxVisa);
                panelVisa.Visible = true;
                gbMetodo.Text = "Visa";
            }
            else
            {
                panelVisa.Visible = false;
                gbMetodo.Text = " ";
            }
            
        }

        private void cbxMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMaster.Checked)
            {
                Desmarcar(cbxMaster);

                panelMasterCard.Visible = true;
                gbMetodo.Text = "MasterCard";
            }
            else
            {
                panelMasterCard.Visible = false;
                gbMetodo.Text = " ";
            }
            
        }

        private void cbxBitcoin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBitcoin.Checked)
            {
                Desmarcar(cbxBitcoin);
                panelBancoAgricola.Visible = true;
                gbMetodo.Text = "Banco Agricola";

            }
            else
            {
                panelBancoAgricola.Visible = false;
                gbMetodo.Text = " ";
            }

        }

        private void cbxEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxChivo.Checked)
            {
                Desmarcar(cbxChivo);
                panelAmerican.Visible = true;
                gbMetodo.Text = "American Express";

            }
            else
            {
                panelAmerican.Visible = false;
                gbMetodo.Text = " ";
            }

        }


        public void Desmarcar(CheckBox seleccionado)
        {
            if (seleccionado != cbxVisa) cbxVisa.Checked = false;
            if (seleccionado != cbxMaster) cbxMaster.Checked = false;
            if (seleccionado != cbxBitcoin) cbxBitcoin.Checked = false;
            if (seleccionado != cbxChivo) cbxChivo.Checked = false;
        }

        private void btnVisa_Click(object sender, EventArgs e)
        {
            if (cbxVisa.Checked)
            {
                if (string.IsNullOrEmpty(txtNombre_Visa.Text) || string.IsNullOrWhiteSpace(txtNombre_Visa.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Titular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre_Visa.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Fecha_Visa.Text) || string.IsNullOrWhiteSpace(txt_Fecha_Visa.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Fecha de Vencimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Fecha_Visa.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Número_Visa.Text) || string.IsNullOrWhiteSpace(txt_Número_Visa.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Número de Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Número_Visa.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_CVC_Visa.Text) || string.IsNullOrWhiteSpace(txt_CVC_Visa.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Codigo CV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_CVC_Visa.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Procesando Pago..", "Espere", MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
        }

      

        private void txt_Número_Visa_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^4[0-9]{12}(?:[0-9]{3})?$";
            Regex validaEmail = new Regex(patron);
            if (validaEmail.IsMatch(txt_Número_Visa.Text))
            {
                erp.SetError(txt_Número_Visa, "");
                btnVisa.Enabled = true;
                
            }
            else
            {
                erp.SetError(txt_Número_Visa, "Número de Tarjeta NO valida");
                btnVisa.Enabled = false;
            }
        }

        private void txt_Fecha_Visa_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^(0[1-9]|1[0-2])\/?([0-9]{2})$";
            Regex validaEmail = new Regex(patron);
            if (validaEmail.IsMatch(txt_Fecha_Visa.Text))
            {
                erp.SetError(txt_Fecha_Visa, "");
                btnVisa.Enabled = true;

            }
            else
            {
                erp.SetError(txt_Fecha_Visa, "Fecha NO valida");
                btnVisa.Enabled = false;
            }
        }

        private void txt_CVC_Visa_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[0-9]{3,4}$";
            Regex validaEmail = new Regex(patron);
            if (validaEmail.IsMatch(txt_CVC_Visa.Text))
            {
                erp.SetError(txt_CVC_Visa, "");
                btnVisa.Enabled = true;

            }
            else
            {
                erp.SetError(txt_CVC_Visa, "Código CVC NO valido");
                btnVisa.Enabled = false;
            }
        }

        private void btn_Master_Click(object sender, EventArgs e)
        {
            if (cbxMaster.Checked)
            {
                if (string.IsNullOrEmpty(txt_Nombre_Master.Text) || string.IsNullOrWhiteSpace(txt_Nombre_Master.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Titular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Nombre_Master.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Fecha_Master.Text) || string.IsNullOrWhiteSpace(txt_Fecha_Master.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Fecha de Vencimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Fecha_Master.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Numeros_Master.Text) || string.IsNullOrWhiteSpace(txt_Numeros_Master.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Número de Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Numeros_Master.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Codigo_Master.Text) || string.IsNullOrWhiteSpace(txt_Codigo_Master.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Codigo CV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Codigo_Master.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Procesando Pago..", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }
    }
}
