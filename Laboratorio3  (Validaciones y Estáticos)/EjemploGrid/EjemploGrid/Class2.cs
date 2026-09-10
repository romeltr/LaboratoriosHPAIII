using System;
using System.Text.RegularExpressions;

// Clase estática para funciones auxiliares de validación
public static class Utilidades
{
    // Evalúa si una cadena cumple con la estructura básica de un correo electrónico
    public static bool EsCorreoValido(string email)
    {
        // Llama al método auxiliar para verificar si está en blanco
        if (EstaEnBlanco(email))
        {
            return false;
        }

        // Expresión regular para validar formato de correo: texto + @ + texto + . + texto
        string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, patron);
    }

    // Comprueba si la cadena está nula, vacía o solo contiene espacios
    public static bool EstaEnBlanco(string texto)
    {
        return string.IsNullOrWhiteSpace(texto);
    }
} // fin de la clase Utilidades