namespace Clasepruebas
{
    internal class PruebaLibroCalificaciones_1
    {
        static void Main(string[] args)
        {
            LibroCalificacion myLibro1 = new LibroCalificacion("CS101 Programacion en C#", 1);
            LibroCalificacion myLibro2 = new LibroCalificacion("CS102 Estructuras de Datos", 2);
            Console.WriteLine("El nombre del curso es: {0}", myLibro1.NombreCurso);
            Console.WriteLine("El nombre del curso es: {0}", myLibro2.NombreCurso);

            Console.WriteLine("\nEscriba el nombre del curso: ");
            string elNombreCurso = Console.ReadLine();

            while (int.TryParse(elNombreCurso, out int cursoId) || string.IsNullOrWhiteSpace(elNombreCurso))
            {
                Console.WriteLine("Escriba un nombre del curso válido: ");
                elNombreCurso = Console.ReadLine();
            }
            ;


            Console.WriteLine("\nEscriba la nota del curso: ");
            //float laNota = Console.ReadLine() is float ? float.Parse(Console.ReadLine()) : 0;

            string laNota = Console.ReadLine();
            while (!float.TryParse(laNota, out float nota))
            {
                Console.WriteLine("Escriba una nota válida: ");
                laNota = Console.ReadLine();
            }

            float.Parse(laNota);

            myLibro1.NombreCurso = elNombreCurso;
            myLibro1.Nota = float.Parse(laNota);
            Console.WriteLine("El nombre del curso es: {0}", myLibro1.NombreCurso);
            Console.WriteLine("La nota del curso es: {0}", myLibro1.Nota);
        }
    }
}

