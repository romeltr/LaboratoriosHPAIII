namespace Clasepruebas
{
    internal class PruebaLibroCalificaciones_1
    {
        static void Main(string[] args)
        {
            LibroCalificacion myLibro1 = new LibroCalificacion("CS101 Programacion en C#", 1);
            LibroCalificacion myLibro2 = new LibroCalificacion("CS102 Estructuras de Datos", 2 );
            Console.WriteLine("El nombre del curso es: {0}", myLibro1.NombreCurso);
            Console.WriteLine("El nombre del curso es: {0}", myLibro2.NombreCurso);

            Console.WriteLine("\nEscriba el nombre del curso: ");
            string elNombreCurso = Console.ReadLine();
            Console.WriteLine("\nEscriba la nota del curso: ");
            float laNota = float.Parse(Console.ReadLine());
            myLibro1.NombreCurso = elNombreCurso;
            myLibro1.Nota = laNota;
            Console.WriteLine("El nombre del curso es: {0}", myLibro1.NombreCurso);
            Console.WriteLine("La nota del curso es: {0}", myLibro1.Nota);

        }
    }
}
