using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Lab4Actividad1
{
    /// <summary>
    /// Métodos estáticos que resumen las conversiones de imágenes
    /// y la selección de una imagen desde un directorio del equipo.
    /// </summary>
    public static class ImagenUtil
    {
        // Imagen -> byte[]
        public static byte[] ImagenABytes(Image imagen)
        {
            if (imagen == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                // Se clona en un Bitmap nuevo para evitar errores GDI+ con ciertos formatos
                using (Bitmap bmp = new Bitmap(imagen))
                {
                    bmp.Save(ms, ImageFormat.Png);
                }
                return ms.ToArray();
            }
        }

        // byte[] -> Bitmap
        public static Bitmap BytesABitmap(byte[] datos)
        {
            if (datos == null || datos.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(datos))
            using (Image img = Image.FromStream(ms))
            {
                // Se devuelve una copia para poder cerrar el stream sin que falle la imagen
                return new Bitmap(img);
            }
        }

        // Selección desde directorio: devuelve la imagen elegida o null si el usuario cancela
        public static Bitmap SeleccionarImagen()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar imagen del producto";
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (Image img = Image.FromFile(ofd.FileName))
                    {
                        // Copia en memoria: el archivo original no queda bloqueado
                        return new Bitmap(img);
                    }
                }
            }
            return null;
        }
    }
}
