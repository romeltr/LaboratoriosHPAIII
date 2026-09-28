using System;
using DictionarioPracticasDatos;

namespace DictionarioPracticasDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Random numerosAleatorios = new Random();

            int frecuencia1 = 0;
            int frecuencia2 = 0;
            int frecuencia3 = 0;
            int frecuencia4 = 0;
            int frecuencia5 = 0;
            int frecuencia6 = 0;

            int cara; //Almacena el último valor que se tiró

            for (int tiro = 1; tiro <= 6000; tiro++)
            {
                //números del 1 al 6
                cara = numerosAleatorios.Next(1, 7);
                //determina el valor del tiro del 1 al 6
                //e incrementa el contador apropiado

                switch (cara)
                {
                    case 1:
                        frecuencia1++;
                        break;
                    case 2:
                        frecuencia2++;
                        break;
                    case 3:
                        frecuencia3++;
                        break;
                    case 4:
                        frecuencia4++;
                        break;
                    case 5:
                        frecuencia5++;
                        break;
                    case 6:
                        frecuencia6++;
                        break;
                    default:
                        Console.WriteLine("hubo un error de entrada");
                        break;

                } //fin del switch()

            } //fin del for

            Console.WriteLine("Cara \t Frecuencia");
            Console.WriteLine("1\t{0}\n2\t{1}\n3\t{2}\n4\t{3}\n5\t{4}\n6\t{5}",
            frecuencia1, frecuencia2, frecuencia3, frecuencia4, frecuencia5, frecuencia6);

        }
    }
}

///DICCIONARIOS
/*
 * Dictionary<string, object> datosInventario = new Dictionary<string, object>
            {
                { "Nombre", "Laptop HP Envy" } ,
                { "Precio", 1200.50 } ,
                { "Cantidad", 10 }
            };

            var setParts = new List<string>();
            foreach (var key in datosInventario.Keys)
            {
                setParts.Add($"{key} = @{key}");
            }
            string setClause = string.Join(", ", setParts);


            Console.WriteLine($"Clausula SET generada: {setClause}");

////DICCIONARIO 2
///
Dictionary<string, object> datosInventario = new Dictionary<string, object>
            {
                { "Nombre", "Laptop HP Envy" } ,
                { "Precio", 1200.50 } ,
                { "Cantidad", 10 }
            };

            var setParts = new List<string>();
            foreach (var key in datosInventario.Keys)
            {
                setParts.Add($"{key} = @{key}");
            }
            string setClause = string.Join(", ", setParts);


            Console.WriteLine($"Clausula SET generada: {setClause}");
        
        
            var columns = string.Join(", ", datosInventario.Keys);
            var placholders = "@" + string.Join(", @", datosInventario.Keys);

            string sql = $"INSERT INTO Inventario ({columns}) VALUES ({placholders})";
            Console.WriteLine($"SQL generado: {sql}");


        }
    }
*/




///ESTADISTICAS DE LANZAMIENTO DE DADOS
/*
 
Random numerosAleatorios = new Random();

int frecuencia1 = 0;
int frecuencia2 = 0;
int frecuencia3 = 0;
int frecuencia4 = 0;
int frecuencia5 = 0;
int frecuencia6 = 0;

int cara; //Almacena el último valor que se tiró

for (int tiro = 1; tiro <= 6000; tiro++)
{
    //números del 1 al 6
    cara = numerosAleatorios.Next(1,7);
    //determina el valor del tiro del 1 al 6
    //e incrementa el contador apropiado

    switch(cara)
    {
        case 1:
            frecuencia1++;
            break;
        case 2:
            frecuencia2 ++;
            break;
        case 3:
            frecuencia3++;
            break;
        case 4:
            frecuencia4++;
            break;
        case 5:
            frecuencia5++;
            break;
        case 6:
            frecuencia6++;
            break;
        default:
            Console.WriteLine("hubo un error de entrada");
            break;

    } //fin del switch()

} //fin del for

Console.WriteLine("Cara \t Frecuencia");
Console.WriteLine("1\t{0}\n2\t{1}\n3\t{2}\n4\t{3}\n5\t{4}\n6\t{5}",
frecuencia1, frecuencia2, frecuencia3, frecuencia4, frecuencia5, frecuencia6);
 */








///SOBRECARGA DE METODOS
///Class1, es la clase que contiene todos los métodos sobrecargados, y se encuentra en el proyecto DictionarioPracticasDatos
/*
 using System;
using DictionarioPracticasDatos;

// Instancias la clase y ejecutas el método
DictionarioPracticasDatos.SobreCarga varSobreCarga = new DictionarioPracticasDatos.SobreCarga();
varSobreCarga.ProbarMetodosSobreCargados();
varSobreCarga.Cuadrado(8);
Console.WriteLine("El cuadrado de {0}",varSobreCarga.Cuadrado(9));
 */





///RECURSIVIDAD
/*
 internal class Program
    {
        static void Main(string[] args)
        {


            //Cálculo del Factorial del 0 al 10
            for (long contador = 0; contador <=10; contador ++)
            {
                Console.WriteLine("{0}! ={1}", contador, Factorial(contador));

            }
            //fin del form
        }
        //fin dle método Main

        //declaración recursiva del método Factorial
        public static long Factorial(long numero)
        {
            //caso base
            if (numero <= 1)
                return 1;
            //paso de recursividad
            else return numero * Factorial(numero - 1);

        }//fin del método factorial

    }
 */