namespace EjemploWhile
{
    public class PruebaCalificaciones
    {
        public static void Main(string[] args)
        {
            //Crea un objeto LibroCalificaciones y lo inicializa
            LibroCalificaciones miLibroCalificaciones = new LibroCalificaciones("CS101 Introduccion a la Programacion en C#");
            miLibroCalificaciones.MostrarMensaje(); //muestra el mensaje de bienvenida
            miLibroCalificaciones.DeterminarPromedioClase(); //determina el promedio de las calificaciones
        } //fin de Main
    }
}