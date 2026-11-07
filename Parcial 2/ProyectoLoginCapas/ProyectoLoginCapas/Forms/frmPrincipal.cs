using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Forms
{
    ///Demostración de los datos presentes en la tabla de usuarios.
    ///Aplicación de analisis de datos.

    public partial class frmPrincipal : Form
    {
        private readonly N_Usuario _negocio = new N_Usuario();
        private readonly E_Usuario _usuario;

        /// true si se cerro con "Cerrar sesion" (volver al login); false si se salio de la aplicacion.
        public bool CerrarSesion { get; private set; }

        public frmPrincipal(E_Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException("usuario");

            InitializeComponent();
            _usuario = usuario;

            lblBienvenida.Text = "¡Bienvenido, " + usuario.dsUsuario + "!";
            lblDatosSesion.Text = "Usuario: " + usuario.dsUsuario
                + "      Cuenta (ID): " + usuario.dsId
                + "      Departamento: " + (string.IsNullOrEmpty(usuario.dsDepartamento) ? "(sin departamento)" : usuario.dsDepartamento);

            ActualizarReloj();
        }

        // ------------------------------------------------------------ carga / reloj
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarUsuarios("");
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            ActualizarReloj();
        }

        private void ActualizarReloj()
        {
            DateTime ahora = DateTime.Now;
            lblReloj.Text = ahora.ToLongDateString() + Environment.NewLine + ahora.ToLongTimeString();
        }

        // ------------------------------------------------------------ barra lateral
        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlLateral.Visible = !pnlLateral.Visible; // muestra / oculta la barra lateral
        }

        private void btnOpcUsuarios_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios("");
        }

        private void btnOpcMiCuenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Usuario: " + _usuario.dsUsuario + Environment.NewLine +
                "Cuenta (ID): " + _usuario.dsId + Environment.NewLine +
                "Departamento: " + (string.IsNullOrEmpty(_usuario.dsDepartamento) ? "(sin departamento)" : _usuario.dsDepartamento) + Environment.NewLine +
                "Creada el: " + _usuario.dtFechaCreacion.ToString("g"),
                "Mi cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpcCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar la sesión de " + _usuario.dsUsuario + "?", "Cerrar sesión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CerrarSesion = true;
                Close();
            }
        }

        private void btnOpcSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Salir de la aplicación?", "Salir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CerrarSesion = false;
                Close();
            }
        }

        // ------------------------------------------------------------ botones + DataGridView
        private void btnListar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios("");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarUsuarios(txtBuscar.Text);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            dgvUsuarios.DataSource = null;
            lblConteo.Text = "Tabla vacía. Usa \"Listar usuarios\" para volver a cargarla.";
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            CambiarEstadoSeleccionado(true);
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            CambiarEstadoSeleccionado(false);
        }

        private void CambiarEstadoSeleccionado(bool activar)
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.Cells["Id"].Value == null)
            {
                MessageBox.Show("Selecciona primero un usuario de la tabla.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value);
            string nombre = Convert.ToString(dgvUsuarios.CurrentRow.Cells["Usuario"].Value);

            if (MessageBox.Show("¿" + (activar ? "Activar" : "Desactivar") + " al usuario \"" + nombre + "\"?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                string mensaje;
                bool ok = _negocio.CambiarEstado(id, activar, _usuario, out mensaje);
                MessageBox.Show(mensaje, "Usuarios", MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (ok)
                    CargarUsuarios(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión o base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios(string filtro)
        {
            try
            {
                DataTable tabla = _negocio.ListarUsuarios(filtro);
                dgvUsuarios.DataSource = tabla;

                // Los usuarios inactivos se muestran en gris.
                foreach (DataGridViewRow fila in dgvUsuarios.Rows)
                {
                    if (Convert.ToString(fila.Cells["Estado"].Value) == "Inactivo")
                        fila.DefaultCellStyle.ForeColor = Color.Gray;
                }

                lblConteo.Text = tabla.Rows.Count + " usuario(s)";
                ActualizarSumario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión o base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Actualiza las tarjetas: cantidad de empleados y cantidad de empleados activos.
        private void ActualizarSumario()
        {
            int total, activos;
            _negocio.ObtenerResumen(out total, out activos);
            lblCantEmpleados.Text = total.ToString("N0");
            lblCantActivos.Text = activos.ToString("N0");
        }
    }
}
