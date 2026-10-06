using Lab4Actividad1;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Lab4Actividad1
{
    public partial class Form1 : Form
    {
        int idProducto;
        bool todoOk = true;
        List<(TextBox txt, IValidatorCampo validador)> camposValidar = new List<(TextBox txt, IValidatorCampo validador)>();
        private List<Producto> listaProductos;
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();

        public Form1()
        {
            InitializeComponent();
            listaProductos = new List<Producto>();

            // Al hacer clic en una fila, sus datos se cargan en los campos del formulario
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora clics en el encabezado o en la fila vacía de "nuevo registro"
            if (e.RowIndex < 0 || dataGridView1.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            // Orden de columnas: Id, Nombre, Precio, Cantidad, Imagen
            idProducto = Convert.ToInt32(fila.Cells[0].Value);
            txtNombre.Text = Convert.ToString(fila.Cells[1].Value);
            txtPrecio.Text = Convert.ToString(fila.Cells[2].Value);
            txtCantidad.Text = Convert.ToString(fila.Cells[3].Value);

            Image img = fila.Cells[4].Value as Image;
            pictureBox1.Image = img != null ? new Bitmap(img) : null;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificarDatosBD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!DatosCorrectos())
            {
                return;
            }

            CargarDatosProductos();

            if (Conexion.InsertSeguro("productos", myProducto))
            {
                MessageBox.Show("Se ha guardado satisfactoriamente el registro");
                cargarProductos();
                limpiarCampos();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Permite cambiar la imagen haciendo clic directamente sobre el PictureBox
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            cargarProductos();
        }

        private void cargarProductos(string filtro = "")
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            listaProductos = Conexion.GetProductos(filtro);

            foreach (var prod in listaProductos)
            {
                // byte[] -> Bitmap con el método estático
                Image img = ImagenUtil.BytesABitmap(prod.Imagen);

                dataGridView1.Rows.Add(prod.Id, prod.Nombre, prod.Precio, prod.Cantidad, img, prod.fInsercion, prod.fModificacion);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatosProductos()
        {
            myProducto["cantidad"] = int.Parse(txtCantidad.Text.Trim());
            myProducto["precio"] = decimal.Parse(txtPrecio.Text.Trim());
            myProducto["nombre"] = txtNombre.Text.Trim();

            if (pictureBox1.Image != null)
            {
                // Imagen -> byte[] con el método estático
                myProducto["imagen"] = ImagenUtil.ImagenABytes(pictureBox1.Image);
            }
            else
            {
                // DBNull.Value para que el parámetro SQL se envíe como NULL
                myProducto["imagen"] = DBNull.Value;
            }
        }

        private bool DatosCorrectos()
        {
            // Se limpia la lista para que los validadores no se dupliquen en cada llamada
            camposValidar.Clear();
            todoOk = true;

            camposValidar.Add((txtNombre, new ValidatorTexto()));
            camposValidar.Add((txtPrecio, new ValidadorDecimal()));
            camposValidar.Add((txtCantidad, new ValidadorEntero()));

            foreach (var item in camposValidar)
            {
                if (!item.validador.EsValido(item.txt.Text))
                {
                    errorProvider1.SetError(item.txt, item.validador.MensajeError);
                    todoOk = false;
                    break;
                }
                else
                {
                    errorProvider1.SetError(item.txt, string.Empty);
                }
            }
            return todoOk;
        }

        // Selección desde directorio, centralizada en un solo método
        private void SeleccionarImagenProducto()
        {
            Bitmap nueva = ImagenUtil.SeleccionarImagen();

            if (nueva != null)
            {
                pictureBox1.Image = nueva;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // Botón/PictureBox auxiliar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SeleccionarImagenProducto();
        }

        // Clic directo sobre la imagen del producto
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SeleccionarImagenProducto();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //TXTBusqueda
        {
            cargarProductos(textBox1.Text.Trim());
        }

        private void ModificarDatosBD()
        {
            if (idProducto == 0)
            {
                MessageBox.Show("Seleccione un producto de la tabla para modificarlo");
                return;
            }

            if (!DatosCorrectos())
            {
                return;
            }

            CargarDatosProductos();

            bool resultado = Conexion.UpdateSeguro("productos", myProducto, "id", idProducto);

            if (resultado)
            {
                MessageBox.Show("Se ha actualizado satisfactoriamente el registro");
                cargarProductos(textBox1.Text.Trim());
            }
        }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            pictureBox1.Image = null;
            idProducto = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idProducto == 0)
            {
                MessageBox.Show("Seleccione un producto de la tabla para eliminarlo");
                return;
            }

            DialogResult confirmar = MessageBox.Show(
                "¿Está seguro de que desea eliminar el producto \"" + txtNombre.Text + "\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes)
                return;

            if (Conexion.DeleteSeguro("productos", "id", idProducto))
            {
                MessageBox.Show("Se ha eliminado satisfactoriamente el registro");
                limpiarCampos();
                cargarProductos(textBox1.Text.Trim());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show(
                "¿Desea salir del programa?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (salir == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}