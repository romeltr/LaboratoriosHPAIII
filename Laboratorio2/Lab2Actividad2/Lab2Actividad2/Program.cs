namespace Lab2Actividad2
{
    public class LibroPruebaCalificaciones
    {
        static void Main(string[] args)
        {
            
            MiLibroCalificaciones MyLibro = new MiLibroCalificaciones();
            Console.WriteLine("Por favor ingrese el nombre del curso: ");

            string nombreDelCurso = Console.ReadLine(); 
            Console.WriteLine(); 
            MyLibro.MostrarMensaje(nombreDelCurso);
        }
    }
}
