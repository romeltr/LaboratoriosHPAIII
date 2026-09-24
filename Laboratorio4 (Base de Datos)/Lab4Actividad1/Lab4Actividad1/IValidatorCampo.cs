using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Actividad1
{
    public interface IValidatorCampo
    {
        bool EsValido(string valor);
        string MensajeError { get; }
    }
}
