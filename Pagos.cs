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
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
            panelVisa.Visible = false;
            panelAmerican.Visible = false;
            panelMasterCard.Visible = false;
            panelBancoAgricola.Visible = false;
            MontosAdicionales montos = new MontosAdicionales();
            montos.MostrarMontosAdicionales(lbl_Precio_Vuelo, lbl_Equipaje, lbl_Monto);
        }

        private void txt_Nombre_Banco_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(patron);

            if (regex.IsMatch(txt_Nombre_Banco.Text))
            {
                erp.SetError(txt_Nombre_Banco, ""); // Sin errores
                btnAgricola.Enabled = true;
            }
            else
            {
                erp.SetError(txt_Nombre_Banco, "Solo se permiten letras");
                btnAgricola.Enabled = false;
            }
        }

        private void txt_Cuenta_Banco_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^\d{10,12}$";
            Regex validar = new Regex(patron);
            if (validar.IsMatch(txt_Cuenta_Banco.Text))
            {
                erp.SetError(txt_Cuenta_Banco, "");
                btnAgricola.Enabled = true;

            }
            else
            {
                erp.SetError(txt_Cuenta_Banco, "Cuenta de Banco Agricola NO valida");
                btnAgricola.Enabled = false;

            }
        }

        private void btnAgricola_Click(object sender, EventArgs e)
        {
            if (cbxBanco.Checked)
            {
                if (string.IsNullOrEmpty(txt_Nombre_Banco.Text) || string.IsNullOrWhiteSpace(txt_Nombre_Banco.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Titular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Nombre_Banco.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Cuenta_Banco.Text) || string.IsNullOrWhiteSpace(txt_Cuenta_Banco.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Número de Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Cuenta_Banco.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Procesando Pago..", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void txtNombre_Visa_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(patron);

            if (regex.IsMatch(txtNombre_Visa.Text))
            {
                erp.SetError(txtNombre_Visa, ""); // Sin errores
                btnVisa.Enabled = true;
            }
            else
            {
                erp.SetError(txtNombre_Visa, "Solo se permiten letras");
                btnVisa.Enabled = false;
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
                    MessageBox.Show("Procesando Pago..", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void txt_Nombre_Master_TextChanged(object sender, EventArgs e)
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

        private void txt_Numeros_Master_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^5[1-5][0-9]{14}$|^2[2-7][0-9]{14}$";
            Regex validar = new Regex(patron);
            if (validar.IsMatch(txt_Numeros_Master.Text))
            {
                erp.SetError(txt_Numeros_Master, "");
                btn_Master.Enabled = true;

            }
            else
            {
                erp.SetError(txt_Numeros_Master, "Tarjeta MasterCard NO valida");
                btn_Master.Enabled = false;
            }

        }

        private void txt_Codigo_Master_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[0-9]{3,4}$";
            Regex validaEmail = new Regex(patron);
            if (validaEmail.IsMatch(txt_Codigo_Master.Text))
            {
                erp.SetError(txt_Codigo_Master, "");
                btn_Master.Enabled = true;

            }
            else
            {
                erp.SetError(txt_Codigo_Master, "Código CVC NO valido");
                btn_Master.Enabled = false;
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

        private void txt_Nombre_American_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(patron);

            if (regex.IsMatch(txt_Nombre_American.Text))
            {
                erp.SetError(txt_Nombre_American, ""); // Sin errores
                btn_American.Enabled = true;
            }
            else
            {
                erp.SetError(txt_Nombre_American, "Solo se permiten letras");
                btn_American.Enabled = false;
            }
        }

        private void txt_Numeros_American_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^3[47][0-9]{13}$";
            Regex validar = new Regex(patron);
            if (validar.IsMatch(txt_Numeros_American.Text))
            {
                erp.SetError(txt_Numeros_American, "");
                btn_American.Enabled = true;

            }
            else
            {
                erp.SetError(txt_Numeros_American, "Tarjeta American Express NO valida");
                btn_American.Enabled = false;
            }
        }

        private void txt_Codigo_American_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^[0-9]{3,4}$";
            Regex validaEmail = new Regex(patron);
            if (validaEmail.IsMatch(txt_Codigo_American.Text))
            {
                erp.SetError(txt_Codigo_American, "");
                btn_American.Enabled = true;

            }
            else
            {
                erp.SetError(txt_Codigo_American, "Código CVC NO valido");
                btn_American.Enabled = false;
            }
        }

        private void btn_American_Click(object sender, EventArgs e)
        {
            if (cbxAmerican.Checked)
            {
                if (string.IsNullOrEmpty(txt_Nombre_American.Text) || string.IsNullOrWhiteSpace(txt_Nombre_American.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Titular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Nombre_American.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Numeros_American.Text) || string.IsNullOrWhiteSpace(txt_Numeros_American.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Número de Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Numeros_American.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_Codigo_American.Text) || string.IsNullOrWhiteSpace(txt_Codigo_American.Text))
                {
                    MessageBox.Show("Rellenar Campos", "Codigo CV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Codigo_American.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Procesando Pago..", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        public void LimpiarTodo()
        {
            txtNombre_Visa.Text = string.Empty;
            txt_Nombre_Banco.Text = string.Empty;
            txt_Nombre_American.Text = string.Empty;
            txt_Nombre_Master.Text = string.Empty;


            txt_Número_Visa.Text = string.Empty;
            txt_Cuenta_Banco.Text = string.Empty;
            txt_Numeros_American.Text = string.Empty;
            txt_Numeros_Master.Text = string.Empty;

            txt_CVC_Visa.Text = string.Empty;
            txt_Codigo_Master.Text = string.Empty;
            txt_Codigo_American.Text = string.Empty;
        }

        public void Desmarcar(CheckBox seleccionado)
        {
            if (seleccionado != cbxVisa) cbxVisa.Checked = false;
            if (seleccionado != cbxMaster) cbxMaster.Checked = false;
            if (seleccionado != cbxBanco) cbxBanco.Checked = false;
            if (seleccionado != cbxAmerican) cbxAmerican.Checked = false;
        }

        private void cbxVisa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxVisa.Checked)
            {

                Desmarcar(cbxVisa);
                panelVisa.Visible = true;
                gbMetodo.Text = "Visa";
                LimpiarTodo();
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
                LimpiarTodo();
            }
            else
            {
                panelMasterCard.Visible = false;
                gbMetodo.Text = " ";
            }
        }

        private void cbxBanco_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBanco.Checked)
            {
                Desmarcar(cbxBanco);
                panelBancoAgricola.Visible = true;
                gbMetodo.Text = "Banco Agricola";
                LimpiarTodo();
            }
            else
            {
                panelBancoAgricola.Visible = false;
                gbMetodo.Text = " ";
            }
        }

        private void cbxAmerican_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAmerican.Checked)
            {
                Desmarcar(cbxAmerican);
                panelAmerican.Visible = true;
                gbMetodo.Text = "American Express";
                LimpiarTodo();
            }
            else
            {
                panelAmerican.Visible = false;
                gbMetodo.Text = " ";
            }
        }
    }
    
}
