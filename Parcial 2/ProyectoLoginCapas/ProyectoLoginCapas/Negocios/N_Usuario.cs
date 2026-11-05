using System;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    /// <summary>
    /// Reglas de negocio de la entidad usuario: politica de contrasena, hash en el
    /// registro y verificacion en el login. Los forms solo llaman a esta clase.
    /// </summary>
    public class N_Usuario
    {
        private readonly IHashService _hash;

        public N_Usuario() : this(new HashService())
        {
        }

        public N_Usuario(IHashService hash)
        {
            if (hash == null)
                throw new ArgumentNullException("hash");
            _hash = hash;
        }

        // ------------------------------------------------------------ LOGIN
        /// <summary>
        /// Devuelve el usuario si el texto plano ingresado produce el mismo hash que el
        /// guardado en la BD; si no (usuario inexistente, inactivo o clave distinta) devuelve null.
        /// </summary>
        public E_Usuario Login(string strUsuario, string strPassword)
        {
            strUsuario = (strUsuario ?? "").Trim();
            if (strUsuario.Length == 0 || string.IsNullOrEmpty(strPassword))
                return null;

            E_Usuario usuario = D_Usuario.ObtenerParaLogin(strUsuario);
            if (usuario == null)
                return null;

            bool coincide = _hash.VerifyPassword(strPassword, usuario.dsPassword);
            usuario.dsPassword = null; // el hash no sale de la capa de negocio
            return coincide ? usuario : null;
        }

        // --------------------------------------------------------- REGISTRO
        /// <summary>
        /// Valida, hashea la contrasena y registra al usuario.
        /// Devuelve true si se registro; "mensaje" explica el resultado en ambos casos.
        /// </summary>
        public bool Registrar(string dsId, string dsUsuario, string password, string confirmacion,
                              int? idDepartamento, out string mensaje)
        {
            dsId = (dsId ?? "").Trim();
            dsUsuario = (dsUsuario ?? "").Trim();

            if (dsId.Length == 0 || dsUsuario.Length == 0)
            {
                mensaje = "La cuenta (ID) y el usuario son obligatorios.";
                return false;
            }
            if (dsId.Length > 50 || dsUsuario.Length > 50)
            {
                mensaje = "La cuenta y el usuario no pueden pasar de 50 caracteres.";
                return false;
            }
            if (password != confirmacion)
            {
                mensaje = "La contraseña y su confirmación no coinciden.";
                return false;
            }

            string errorPassword = ValidarPassword(password, dsUsuario);
            if (errorPassword != null)
            {
                mensaje = errorPassword;
                return false;
            }

            // Hasing de la contraseña antes de enviarla a la capa de datos.
            string hash = _hash.HashPassword(password);

            int codigo, idNuevo;
            D_Usuario.Registrar(dsId, dsUsuario, hash, idDepartamento, out codigo, out idNuevo);

            switch (codigo)
            {
                case 0:
                    mensaje = "Usuario registrado correctamente.";
                    return true;
                case 1:
                    mensaje = "Ya existe un usuario o una cuenta con esos datos.";
                    return false;
                case 3:
                    mensaje = "El departamento seleccionado no existe.";
                    return false;
                case 4:
                    mensaje = "Faltan datos obligatorios.";
                    return false;
                default:
                    mensaje = "No se pudo registrar el usuario (código " + codigo + ").";
                    return false;
            }
        }

        /// Politica de contrasena: minimo 8 caracteres, sin espacios, con mayuscula,
        /// minuscula y numero, y distinta del nombre de usuario. Devuelve null si es valida.

        public static string ValidarPassword(string password, string dsUsuario)
        {
            if (string.IsNullOrEmpty(password))
                return "La contraseña es obligatoria.";
            if (password.Length < 8)
                return "La contraseña debe tener al menos 8 caracteres.";
            if (password.Length > 100)
                return "La contraseña no puede pasar de 100 caracteres.";
            if (password.IndexOf(' ') >= 0)
                return "La contraseña no puede contener espacios.";

            bool mayuscula = false, minuscula = false, numero = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) mayuscula = true;
                else if (char.IsLower(c)) minuscula = true;
                else if (char.IsDigit(c)) numero = true;
            }

            if (!mayuscula || !minuscula || !numero)
                return "La contraseña debe incluir al menos una mayúscula, una minúscula y un número.";

            if (!string.IsNullOrEmpty(dsUsuario)
                && string.Equals(password, dsUsuario, StringComparison.OrdinalIgnoreCase))
                return "La contraseña no puede ser igual al nombre de usuario.";

            return null;
        }

        //  DEPARTAMENTO
        public DataTable ListarDepartamentos()
        {
            return D_Usuario.ListarDepartamentos();
        }

        public DataTable ListarUsuarios(string filtro)
        {
            return D_Usuario.ListarUsuarios(filtro);
        }

        /// Activa o desactiva un usuario. Un usuario no puede desactivarse a si mismo.
        public bool CambiarEstado(int idUsuario, bool activar, E_Usuario usuarioActual, out string mensaje)
        {
            if (usuarioActual == null)
            {
                mensaje = "No hay una sesión iniciada.";
                return false;
            }
            if (!activar && idUsuario == usuarioActual.id)
            {
                mensaje = "No puedes desactivar tu propia cuenta mientras tienes la sesión iniciada.";
                return false;
            }

            int codigo = D_Usuario.CambiarEstado(idUsuario, activar ? '1' : '0', usuarioActual.dsUsuario);
            switch (codigo)
            {
                case 0:
                    mensaje = activar ? "Usuario activado." : "Usuario desactivado.";
                    return true;
                case 1:
                    mensaje = "El usuario ya no existe.";
                    return false;
                default:
                    mensaje = "No se pudo cambiar el estado (código " + codigo + ").";
                    return false;
            }
        }
    }
}
