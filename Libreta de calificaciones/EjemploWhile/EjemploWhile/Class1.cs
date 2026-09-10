using System;

public class LibroCalificaciones
{

    private string nombreCurso;

    public LibroCalificaciones(string nombre)
    {
        nombreCurso = nombre;
    }

    public string NombreCurso
    {
        get
        {
            return nombreCurso;
        }
        set
        {
            nombreCurso = value;
        }
    }

    public void MostrarMensaje()
    {
        Console.WriteLine($"Bienvenido al libro de calificaciones de \n{0}!\n", NombreCurso);
    }

    public void DeterminarPromedioClase()
    {
        int total;
        int contadorCalif;
        int calificacion;
        int promedio;

        total = 0;
        contadorCalif = 1;

        while (contadorCalif <= 10)
        {
            Console.WriteLine("Escriba calificacion: ");
            calificacion = Convert.ToInt32(Console.ReadLine());
            total = total + calificacion;
            contadorCalif = contadorCalif + 1;
        }

        promedio = total / 10;
        Console.WriteLine("\nEl total de las 10 calificaciones es {0}", total);
        Console.WriteLine("El promedio de la clase es {0}", promedio);

    }
}
