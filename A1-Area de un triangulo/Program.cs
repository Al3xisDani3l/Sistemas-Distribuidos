using System;

namespace A1_Area_de_un_triangulo
{
  public class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Triangulo triangulo = new Triangulo();
            triangulo.LadoA = 12;
            triangulo.LadoB = 8;
            triangulo.LadoC = 5;

            Console.WriteLine($"EL area del triangulo es {AreaTriangulo(triangulo)}");
            
        }

         static double AreaTriangulo(Triangulo triangulo)
        {
            double s = (triangulo.LadoA + triangulo.LadoB + triangulo.LadoC) / 2;

            double A = Math.Sqrt(s * (s - triangulo.LadoA) * (s - triangulo.LadoB) * (s - triangulo.LadoC));

            return A;
        }

    }

    public struct Triangulo
    {
        public double LadoA { get; set; }
        public double LadoB { get; set; }
        public double LadoC { get; set; }
    }
}
