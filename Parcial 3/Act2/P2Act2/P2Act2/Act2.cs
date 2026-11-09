using Newtonsoft.Json;
namespace P2Act2
{
    internal class Act2
    {
        static void Main(string[] args)
        {
            var persona = new
            {

                Nombre = "Rómel",
                Edad = 20,
                Ciudad = "Panamá"

            };

            string json = JsonConvert.SerializeObject(persona);
            Console.WriteLine(json);    
        }
    }
}
