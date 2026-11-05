using System;
using System.Globalization;
using System.Security.Cryptography;

namespace Negocios
{
 
    /// Implementacion de IHashService con PBKDF2-HMAC-SHA256 (salt aleatorio de 16 bytes).
    /// Formato guardado en usuarios.dsPassword:
    ///     PBKDF2-SHA256$iteraciones$salt(base64)$hash(base64)
  
    public class HashService : IHashService
    {
        private const string Prefijo = "PBKDF2-SHA256";
        private const int TamanoSalt = 16;
        private const int TamanoHash = 32;
        private const int Iteraciones = 100000;

        public string HashPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            byte[] salt = new byte[TamanoSalt];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = Derivar(password, salt, Iteraciones, TamanoHash);

            return string.Join("$", new string[]
            {
                Prefijo,
                Iteraciones.ToString(CultureInfo.InvariantCulture),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash)
            });
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (password == null || string.IsNullOrEmpty(hashedPassword))
                return false;

            string[] partes = hashedPassword.Split('$');
            if (partes.Length != 4 || partes[0] != Prefijo)
                return false; // formato desconocido (p. ej. hash antiguo): no se acepta

            int iteraciones;
            if (!int.TryParse(partes[1], NumberStyles.None, CultureInfo.InvariantCulture, out iteraciones)
                || iteraciones < 1)
                return false;

            byte[] salt;
            byte[] esperado;
            try
            {
                salt = Convert.FromBase64String(partes[2]);
                esperado = Convert.FromBase64String(partes[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            if (salt.Length == 0 || esperado.Length == 0)
                return false;

            byte[] calculado = Derivar(password, salt, iteraciones, esperado.Length);
            return IgualesTiempoConstante(calculado, esperado);
        }

        private static byte[] Derivar(string password, byte[] salt, int iteraciones, int largo)
        {
            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(password, salt, iteraciones, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(largo);
            }
        }

        // Comparacion que no se corta al primer byte distinto (evita ataques de tiempo).
        private static bool IgualesTiempoConstante(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int diferencia = 0;
            for (int i = 0; i < a.Length; i++)
                diferencia |= a[i] ^ b[i];

            return diferencia == 0;
        }
    }
}
