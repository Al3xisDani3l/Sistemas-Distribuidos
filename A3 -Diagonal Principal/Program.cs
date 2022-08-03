using System;

namespace A3__Diagonal_Principal
{
    class Program
    {
        static void Main(string[] args)
        {

            double[,] _matriz = RellenarMatriz(4);

            double resultado = SumarDiagonal(_matriz).GetValueOrDefault(0);

            Console.WriteLine($"El resultado de sumar la diagonal de la matriz es: {resultado}");
           


           
        }

        public static double[,] RellenarMatriz(int dimensiones)
        {
            double[,] buffer = new double[dimensiones, dimensiones];

            double contador = 1;

            for (int i = 0; i < dimensiones; i++)
            {
                for (int j = 0; j < dimensiones; j++)
                {
                    buffer[i, j] = contador;
                    contador++;
                }
            }

            return buffer;

        }

        public static double? SumarDiagonal(double[,] matriz)
        {
            double sum = 0;
            //comprovamos si es una matriz cuadrada
            if (matriz.GetLength(0) != matriz.GetLength(1)) 
            {
                return null;
            }

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                sum += matriz[i, i];
            }

            return sum;

        }

    }
}
