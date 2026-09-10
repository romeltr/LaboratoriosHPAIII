using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploGrid
{
    // Clase modelo para representar a un individuo/colaborador
    class Persona
    {
        // Propiedades auto-implementadas para almacenar los datos personales
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Salario { get; set; }
    }
}
