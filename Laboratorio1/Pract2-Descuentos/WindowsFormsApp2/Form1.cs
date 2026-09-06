using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bttcalc_Click(object sender, EventArgs e)
        {
            decimal valorventa; decimal descuentoPorcentaje; decimal descuentoventa; decimal valorfinalvennta;

            if (decimal.TryParse(txtvalor.Text, out valorventa))
            {
                if (valorventa >= 500)
                {
                    descuentoPorcentaje = 0.30m;
                }
                else if (valorventa >= 300 && valorventa <= 499)
                {
                    descuentoPorcentaje = 0.20m;
                }
                else if (valorventa >= 100 && valorventa <= 299)
                {
                    descuentoPorcentaje = 0.10m;
                }
                else
                {
                    descuentoPorcentaje = 0;
                }

                descuentoventa = valorventa * descuentoPorcentaje;
                valorfinalvennta = valorventa - descuentoventa;

                txtdescuento.Text = descuentoventa.ToString();
                txtdesc.Text = (descuentoPorcentaje*100).ToString()+"%";
                textventa.Text = valorfinalvennta.ToString();


            }
            else 
            { 
                MessageBox.Show("Ingrese un valor valido", "Ha habido un error!", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtdesc.Text = "";
            textventa.Text = "";
            txtdescuento.Text = "";
            txtvalor.Text = "";
            
        }

        private void txtdescuento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
