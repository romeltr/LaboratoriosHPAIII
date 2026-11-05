using System;

namespace Entidades
{

    /// Entidad usuario (tabla "usuarios"). Solo datos, sin logica.
    /// dsPassword contiene el HASH guardado en la BD; la capa de negocio lo
    /// limpia (null) despues de verificar el login para que no viaje a los forms.

    public class E_Usuario
    {
        public int id { get; set; }
        public string dsId { get; set; }                   // cuenta / identificador de la cuenta
        public string dsUsuario { get; set; }              // nombre de usuario para iniciar sesion
        public string dsPassword { get; set; }             // hash PBKDF2 (nunca texto plano)
        public char dsEstado { get; set; }                 // '1' activo, '0' inactivo
        public int? idDepartamento { get; set; }
        public string dsDepartamento { get; set; }         // solo para mostrar (JOIN con departamento)
        public string dsUsuarioCreacion { get; set; }
        public DateTime dtFechaCreacion { get; set; }
        public string dsUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
    }
}
