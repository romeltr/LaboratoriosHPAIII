using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Actividad1
{

    //Validador de texto
    //Valida que los valores ingresados no sean nulos o vacíos, de lo contrario devuelve un mensaje de error
    public class ValidatorTexto : IValidatorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                MensajeError = "El campo de Texto no puede estar vacío";
                return false;
            }//Fin de IsNullOrWhiteSpaces

            return true;
        }//Fin del método EsValido
    }




    //Validador de numeros enteros
    //Valida que los valores ingresados sean enteros y mayores a 0, de  
    public class ValidadorEntero : IValidatorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || !int.TryParse(valor, out int resultado) || resultado < 0)
            {
                MensajeError = "Debe ingresar un número entero válido";
                return false;
            }//Fin de IsNullOrWhiteSpaces

            return true;
        }//Fin del método EsValido
    }





    //Validador de numeros decimales
    //Valida que los valores ingresados sean decimales y mayores a 0, de lo contrario devuelve un mensaje de error  
    public class ValidadorDecimal : IValidatorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || !decimal.TryParse(valor, out decimal resultado) || resultado < 0)
            {
                MensajeError = "Debe ingresar un número decimal válido";
                return false;
            }//Fin de IsNullOrWhiteSpaces

            return true;
        }//Fin del método EsValido
    }


}
