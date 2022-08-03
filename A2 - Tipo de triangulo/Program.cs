using System;


namespace A2___Tipo_de_triangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Triangulo
    {
        public Triangulo(double a, double b, double c)
        {
            LadoA = a;
            LadoB = b;
            LadoC = c;
        }

        public double LadoA { get; set; }
        public double LadoB { get; set; }
        public double LadoC { get; set; }

        public double? AnguloA => CalcularAngulos(LadoA, LadoB, LadoC);

        public double? AnguloB => CalcularAngulos(LadoB, LadoA, LadoC);

        public double? AnguloC => CalcularAngulos(LadoC, LadoA, LadoB);


        

        public bool IsPosible()
        {
            bool _posible = LadoA + LadoB > LadoC
                          && LadoA + LadoC > LadoB
                          && LadoB + LadoC > LadoA;
            return _posible;
        }

        public string QueTipoSoy()
        {
            if (!IsPosible())
            {
                return "Soy un triangulo imposible!";
            }


        }

       
        private string Amplitud()
        {
            if (IsPosible())
            {
                if (AnguloA == 90 || AnguloB == 90 || AnguloC == 90)
                {
                    return "Rectangulo";
                }
                else if (( AnguloA > 90 && AnguloB < 90&& AnguloC <90)||
                         (AnguloB > 90 && AnguloA < 90 && AnguloC < 90)||
                         (AnguloC > 90 && AnguloA < 90 && AnguloB < 90))
                {
                    return "Obtusangulo";
                }
                else if ()
                {

                }
               
            }
            return "No es posible determinar la amplitud";

        }


        private double? CalcularAngulos(double l1,double l2, double l3)
        {
            if (IsPosible())
            {
                double first = ((l2 * l2) + (l3 * l3) - (l1 * l1)) / (2 * l2 * l3);

                return Math.Acos(first);
            }
            else
            {
                return null;
            }
         

        }
        
    }
}
