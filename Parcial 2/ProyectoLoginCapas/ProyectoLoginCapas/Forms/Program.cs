using System;
using System.Windows.Forms;

namespace Forms
{
    internal static class Program
    {
        /// <summary>Punto de entrada: la aplicacion arranca en el inicio de sesion (Form1).</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
