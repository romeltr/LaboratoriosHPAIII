using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Lab4Actividad1;
using System.Drawing.Imaging;


namespace Lab4Actividad1
{
    public partial class Form1 : Form
    {
        int idProducto;
        bool todoOk = true;
        List<(TextBox txt, IValidatorCampo validador)> camposValidar = new();
        private List<Producto> listaProductos;
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();

        // Id del producto seleccionado en el grid (0 = ninguno seleccionado)
        

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
                return; // No vamos hacer nada - se detine en este punto, puedes crear un punto de interrupcíon
            }

            CargarDatosProductos();

            if (Conexion.InsertSeguro("productos", myProducto))
            {
                MessageBox.Show("Se ha guardado satisfactoriamente el registro");
                // Aquí refrescas el grid volviendo a consultar la base de datos
                cargarProductos();
                limpiarCampos();
            }//fin del if InsertSeguro
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cargarProductos(string filtro = "")
        {
            dataGridView1.Rows.Clear(); // "NombredelDataGRidView.Rows.Clear()"
            dataGridView1.Refresh();
            listaProductos = Conexion.GetProductos(filtro);

            foreach (var prod in listaProductos)
            {
                Image img = null;

                if (prod.Imagen != null && prod.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(prod.Imagen))
                    {
                        using (Bitmap bmp = new Bitmap(ms))
                        {
                            img = new Bitmap(bmp); //Esto clona la imagen y evita que falle
                        }
                    }
                }

                dataGridView1.Rows.Add(prod.Id, prod.Nombre, prod.Precio, prod.Cantidad, img);
            }//Fin del foreach listProductos
        }//fin de cargarProductosa

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
                // Convierte la imagen en un arreglo de bytes
                myProducto["imagen"] = ImageToByteArray(pictureBox1.Image);
            }
            else
            {
                // DBNull.Value en lugar de null, para que el parámetro SQL se envíe como NULL
                myProducto["imagen"] = DBNull.Value;
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (MemoryStream mMemoryStream = new MemoryStream())
            {
                image.Save(mMemoryStream, ImageFormat.Png);
                return mMemoryStream.ToArray();
            }
        }

        private bool DatosCorrectos()
        {
            //Levantamos lista (txt, validador)
            //el otro parámetro recibe un método
            //de las clases que implementan la interface

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
                    todoOk = true;
                }

            }//fin del for

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen del producto";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Carga la imagen seleccionada en el PictureBox y ajusta su tamaño
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //TXTBusqueda
        {
            //Funcion que permite filtrar los productos en el DataGridView a medida que el usuario escribe en el TextBox de búsqueda
            cargarProductos(textBox1.Text.Trim());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void ModificarDatosBD() { throw new NotImplementedException(); }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            //button2_Click.Enabled = false; // Deshabilita el botón de modificar 
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            pictureBox1.Image = null;
            idProducto = 0; // Reinicia el id del producto seleccionado
        }



        
    }
}