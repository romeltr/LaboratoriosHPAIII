using System;

namespace Clasepruebas
{ 
	public class LibroCalificacion
	{

		private string nombreCurso;
		private float nNota;

		public LibroCalificacion(string nombre, float nota) 
		{
			nombreCurso = nombre;
			nNota = nota;
		}

		public string NombreCurso
		{
			get { return nombreCurso; }
			set { nombreCurso = value;}
		}

		public float Nota 
		{
            get { return nNota; }
            set { nNota = value; }

        }
		public void MostrarMensaje()
		{
			Console.WriteLine("Bienvenido al libro de calificaciones para:");

		}
	}
}