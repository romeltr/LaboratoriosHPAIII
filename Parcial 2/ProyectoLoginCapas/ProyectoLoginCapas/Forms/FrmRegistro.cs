using System;
using System.Data;
using System.Windows.Forms;
using Negocios;

namespace Forms
{

    /// Registro de usuario. No habla con MySQL ni hashea: entrega los datos a N_Usuario,
    /// que valida la contrasena, la hashea (IHashService) y la guarda mediante la capa de datos.
   
    public partial class FrmRegistro : Form
    {
        private readonly N_Usuario _negocio = new N_Usuario();

        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable departamentos = _negocio.ListarDepartamentos();

                // Primera opcion: registrar al usuario sin departamento (la columna admite NULL).
                DataRow sinDepartamento = departamentos.NewRow();
                sinDepartamento["id"] = DBNull.Value;
                sinDepartamento["dsDepartamento"] = "(Sin departamento)";
                departamentos.Rows.InsertAt(sinDepartamento, 0);

                cmbDepartamento.DisplayMember = "dsDepartamento";
                cmbDepartamento.ValueMember = "id";
                cmbDepartamento.DataSource = departamentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los departamentos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int? idDepartamento = null;
                object seleccion = cmbDepartamento.SelectedValue;
                if (seleccion != null && seleccion != DBNull.Value)
                    idDepartamento = Convert.ToInt32(seleccion);

                string mensaje;
                Cursor = Cursors.WaitCursor;
                bool ok = _negocio.Registrar(txtid.Text, txtUser.Text, txtPassword.Text,
                                             txtConfirmar.Text, idDepartamento, out mensaje);
                Cursor = Cursors.Default;

                if (ok)
                {
                    MessageBox.Show(mensaje, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close(); // al cerrarse, Form1 (login) vuelve a mostrarse
                }
                else
                {
                    MessageBox.Show(mensaje, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error de conexión o base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
