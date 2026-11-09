
namespace Act1
{
    
    public abstract class Figura
    {
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();
    }

    public class Rectangulo : Figura
    {
        private double base_, altura;

        public Rectangulo(double b, double h)
        {
            base_ = b;
            altura = h;
        }

        public override double CalcularArea() => base_ * altura;
        public override double CalcularPerimetro() => 2 * (base_ + altura);
    }

    public class Cuadrado : Figura
    {
        private double lado;

        public Cuadrado(double l)
        {
            lado = l;
        }

        public override double CalcularArea() => lado * lado;
        public override double CalcularPerimetro() => 4 * lado;
    }

    public class Triangulo : Figura
    {
        private double a, b, c;

        public Triangulo(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double CalcularArea()
        {
            double s = CalcularPerimetro() / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override double CalcularPerimetro() => a + b + c;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Figura[] figuras = new Figura[3];
            figuras[0] = new Rectangulo(5, 3);
            figuras[1] = new Cuadrado(4);
            figuras[2] = new Triangulo(3, 4, 5);

            foreach (Figura f in figuras)
            {
                Console.WriteLine("Figura:    " + f.GetType().Name);
                Console.WriteLine("Área:      " + f.CalcularArea().ToString("F2"));
                Console.WriteLine("Perímetro: " + f.CalcularPerimetro().ToString("F2"));
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
