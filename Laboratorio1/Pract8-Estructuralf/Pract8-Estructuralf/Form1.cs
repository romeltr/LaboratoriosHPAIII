using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract8_Estructuralf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtnum1.Text, out decimal num1) && decimal.TryParse(txtnum2.Text, out decimal num2))
            {
                lblop.Text = "+";
                decimal result = num1 + num2;
                txtres.Text = result.ToString();
            }
            else 
            {
                MessageBox.Show("Coloque un valor válido", "Ha habido un problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtnum1.Text, out decimal num1) && decimal.TryParse(txtnum2.Text, out decimal num2))
            {
                lblop.Text = "-";
                decimal result = num1 - num2;
                txtres.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Coloque un valor válido", "Ha habido un problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtnum1.Text, out decimal num1) && decimal.TryParse(txtnum2.Text, out decimal num2))
            {
                lblop.Text = "x";
                decimal result = num1 * num2;
                txtres.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Coloque un valor válido", "Ha habido un problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtnum1.Text, out decimal num1) && decimal.TryParse(txtnum2.Text, out decimal num2))
            {
                lblop.Text = "/";
                decimal result = num1 / num2;
                txtres.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Coloque un valor válido", "Ha habido un problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblop_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult resultado = MessageBox.Show("¿Desea cerrar la ventana?", "Confirmar cierre", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
            else if (resultado == DialogResult.No)
            {
                // No cerrar la ventana
            }
            else if (resultado == DialogResult.Cancel)
            {
                // Cancelar la operación
            }
        }
    }
}
