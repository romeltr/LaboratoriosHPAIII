namespace Negocios
{
  
    /// Contrato independiente para el manejo de contrasenas.
    /// Un solo servicio, dos contratos:
    ///   - HashPassword   : se usa en el REGISTRO, antes de guardar en la BD.
    ///   - VerifyPassword : se usa en el LOGIN, compara el texto plano ingresado
    ///                      con el hash guardado en la BD.
 
    public interface IHashService
    {
        /// Convierte la contrasena en texto plano en un hash con salt aleatorio.
        string HashPassword(string password);

        /// True solo si el hash de "password" coincide con el hash almacenado.
        bool VerifyPassword(string password, string hashedPassword);
    }
}
