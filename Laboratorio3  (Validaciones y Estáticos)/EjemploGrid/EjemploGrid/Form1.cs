using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;


namespace EjemploGrid
{
    public partial class Form1 : Form
    {
        // ArrayList para almacenar los objetos Persona
        // ArrayList pertenece al espacio de nombres System.Collections
        ArrayList listaPersonas = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        // Evento de carga inicial del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Instancia e inicialización de un registro por defecto
            Persona miColaborador1 = new Persona();

            miColaborador1.Id = 1;
            miColaborador1.Nombres = "Elena Carolina";
            miColaborador1.Apellidos = "González Rodríguez";
            miColaborador1.Correo = "elena.gonzalez@ejemplo.com";
            miColaborador1.FechaNacimiento = new DateTime(1990, 5, 15);

            // Se añade a la lista y se asigna como origen de datos del DataGridView
            listaPersonas.Add(miColaborador1);
            dgvdatos.DataSource = listaPersonas;
        }

        // Evento del botón para validar datos e ingresar un nuevo registro
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_2(object sender, EventArgs e)
        {

        }

        private void tsbNuevoClick_Click(object sender, EventArgs e)
        {
            // Validar campo ID
            if (txtID.Text == "")
            {
                errorProvider2.SetError(txtID, "Ingrese un ID;");

                txtID.Focus();
                return; // Interrumpe y finaliza la ejecución del método actual
            }
            else
            {
                errorProvider2.SetError(txtID, "");
            }

            // Validar campo Nombres
            if (txtNombres.Text == "")
            {
                errorProvider2.SetError(txtNombres, "Ingrese los nombres del Colaborador");
                txtNombres.Focus();
                return;
            }
            else
            {
                errorProvider2.SetError(txtNombres, "");
            }

            // Validar campo Apellidos
            if (txtApellidos.Text == "")
            {
                errorProvider2.SetError(txtApellidos, "Ingrese los apellidos del Colaborador");
                txtApellidos.Focus();
                return;
            }
            else
            {
                errorProvider2.SetError(txtApellidos, "");
            }

            // Validar formato de Correo

            if (Utilidades.EsCorreoValido(txtCorreo.Text) == false)
            {
                errorProvider2.SetError(txtCorreo, "Ingrese un correo válido");
                txtCorreo.Focus();
                return;
            }
            else
            {
                errorProvider2.SetError(txtCorreo, "");
            }

            // Validar conversión numérica del Salario
            decimal salario1;
            if (!decimal.TryParse(txtSalario.Text, out salario1))
            {
                errorProvider2.SetError(txtSalario, "Ingrese un salario válido");
                txtSalario.Focus();
                return;
            }
            else
            {
                errorProvider2.SetError(txtSalario, "");
            }

            // Mapeo e inserción de la nueva Persona tras superar las validaciones
            Persona colaborador1 = new Persona();
            colaborador1.Id = int.Parse(txtID.Text);
            colaborador1.Nombres = txtNombres.Text;
            colaborador1.Apellidos = txtApellidos.Text;
            colaborador1.Correo = txtCorreo.Text;
            colaborador1.Salario = salario1;
            colaborador1.FechaNacimiento = dtpFechaNacimiento.Value;

            listaPersonas.Add(colaborador1);

            // Refresco del DataGridView para mostrar el nuevo elemento
            dgvdatos.DataSource = null; // Limpiar el DataSource antes de asignar la nueva lista
            dgvdatos.DataSource = listaPersonas;
        }
    }
}