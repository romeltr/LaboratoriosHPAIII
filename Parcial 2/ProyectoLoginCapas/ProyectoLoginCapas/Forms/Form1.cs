using System;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Forms
{
    /// Inicio de sesion. Solo captura datos y muestra mensajes; la logica esta en Negocios.
    public partial class Form1 : Form
    {
        private readonly N_Usuario _negocio = new N_Usuario();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim().Length == 0 || txtContrasenia.Text.Length == 0)
            {
                MessageBox.Show("Ingresa tu usuario y tu contraseña.", "Inicio de sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                E_Usuario usuario = _negocio.Login(txtUsuario.Text.Trim(), txtContrasenia.Text);
                Cursor = Cursors.Default;

                if (usuario == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasenia.Clear();
                    txtContrasenia.Focus();
                    return;
                }

                AbrirPrincipal(usuario);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error de conexión o base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirPrincipal(E_Usuario usuario)
        {
            frmPrincipal principal = new frmPrincipal(usuario);
            principal.FormClosed += (s, args) =>
            {
                if (principal.CerrarSesion)
                {
                    // "Cerrar sesión": vuelve al login con los campos limpios.
                    txtUsuario.Clear();
                    txtContrasenia.Clear();
                    Show();
                    txtUsuario.Focus();
                }
                else
                {
                    Close(); // cerrar la ventana principal termina la aplicacion
                }
            };

            Hide();
            principal.Show();
        }

        private void btnRegistroUno_Click(object sender, EventArgs e)
        {
            FrmRegistro registro = new FrmRegistro();
            registro.FormClosed += (s, args) => Show(); // al terminar el registro se vuelve al login
            Hide();
            registro.Show();
        }
    }
}
