using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginBCrypt
{
    public partial class Form1 : Form
    {
        
        const string Cn = "Server=localhost;Database=logindb;Uid=root;Pwd=psswd;";

        public Form1()
        {
            InitializeComponent();
        }

   
        private void Registrar(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtUsuario.Text == "" || txtClave.Text == "")
            {
                lblMsg.Text = "Complete todos los campos.";
                return;
            }

            string hash = BCrypt.Net.BCrypt.HashPassword(txtClave.Text);

            try
            {
                using (var cn = new MySqlConnection(Cn))
                {
                    cn.Open();
                    var cmd = new MySqlCommand(
                        "INSERT INTO usuarios (nombre, usuario, password_hash) VALUES (@n, @u, @h)", cn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@u", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@h", hash);
                    cmd.ExecuteNonQuery();
                }
                lblMsg.Text = "Usuario registrado.\nHash: " + hash;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
            }
        }

        
        private void IniciarSesion(object sender, EventArgs e)
        {
            try
            {
                string nombre = null, hash = null;

                using (var cn = new MySqlConnection(Cn))
                {
                    cn.Open();
                    var cmd = new MySqlCommand(
                        "SELECT nombre, password_hash FROM usuarios WHERE usuario = @u", cn);
                    cmd.Parameters.AddWithValue("@u", txtUsuario.Text);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            nombre = rd.GetString(0);
                            hash = rd.GetString(1);
                        }
                    }
                }

                bool ok = hash != null && BCrypt.Net.BCrypt.Verify(txtClave.Text, hash);
                GuardarIntento(txtUsuario.Text, ok);

                if (ok)
                {
                    lblMsg.Text = "Acceso exitoso. Bienvenido, " + nombre;
                    MessageBox.Show("Bienvenido, " + nombre);
                }
                else
                {
                    lblMsg.Text = "Usuario o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
            }
        }

        private void GuardarIntento(string usuario, bool exitoso)
        {
            using (var cn = new MySqlConnection(Cn))
            {
                cn.Open();
                var cmd = new MySqlCommand(
                    "INSERT INTO intentos (usuario, exitoso) VALUES (@u, @e)", cn);
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@e", exitoso ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
