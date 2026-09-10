//Fig. 5.7: LibroCalificaciones.cs
// Clase LibroCalfiicaciones que resuelve el problema del promedi de la clase
// Usando la repetici[on controlada por un centinela
namespace EjemploWhile2
{

    using System;
    public class LibroCalificaciones
    {
        private string nombreCurso; //nombre del curso que representa este LibroCalificaciones

        //El constructor inicializa nombreCurso
        public LibroCalificaciones(string nombre)
        {
            nombreCurso = nombre; //inicializa nombreCurso utilizando la propiedad
        } //fin del constructor

        //propiedad para obtener (get) y establecer (set) el nombre del curso 
        public string NombreCurso
        {
            get
            {
                return nombreCurso;
            } //Fin del get

            set
            {
                nombreCurso = value; //set deber[ia validad
            }// fin de set
        }// fin de la propiedad NombreCurso

        //muestra un mensaje de bienvenida al usuario de LibroCalificaciones
        public void MostrarMensaje()
        {
            Console.WriteLine("Bienvenido al libro de calificaciones para \n{0}!\n", NombreCurso);
        } //Fin del m[etodo MostrarMensaje

        //determina el promedio de un n[umero arbitrario de calificaciones
        public void DeterminaPromedioClase()
        {
            int total; //Suma de calificaciones
            int contadorCalif; //numero de calificaciones introducidas
            int calificacion;//Valor de la calificacion
            double promedio; //n[umero con punto decimal para el promedio

            //fase de inicializacion 
            total = 0;
            contadorCalif = 0;

            Console.Write("Escriba la calificacion o -1 para terminar: ");
            calificacion = Convert.ToInt32(Console.ReadLine());

            while (calificacion != -1)
            {
                total = total + calificacion; //suma la calificacion a total
                contadorCalif = contadorCalif + 1; //incrementa el contador
                                                   //solicita la siguiente calificacion
                Console.Write("Escriba la calificacion o -1 para terminar: ");
                calificacion = Convert.ToInt32(Console.ReadLine());
            }

            if (contadorCalif != 0)
            {
                promedio = (double)total / contadorCalif;
                Console.WriteLine("El promedio de las {0} calificaciones es {1:F}", contadorCalif, promedio);
            }
            else
            {
                Console.WriteLine("No se ingresaron calificaciones.");
            }

        }
    }
}