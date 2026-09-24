using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsActividad3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 ventanaTexto = Application.OpenForms.OfType < Form2>().FirstOrDefault();

            if (ventanaTexto != null)
            {
                ventanaTexto.BringToFront();
                ventanaTexto.Focus();
                // Si ya existía, volvemos a habilitar el botón de inmediato
            }
            else
            {
                //Si no hay ventana abierta
                ventanaTexto = new Form2();
                ventanaTexto.MdiParent = this;
                ventanaTexto.Show();
            }
        }
    }
}
