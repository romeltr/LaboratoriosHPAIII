using System;
using JuegodeCraps;

namespace JuegodeCraps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de Craps! \n");
            Craps juego = new Craps();
            juego.Jugar();
        }
    }
}
