using System;
using System.Linq;
using System.Collections.Generic;

namespace T6___Rank
{
   public class Program
    {
        static void Main(string[] args)
        {

            string[] entrada = { "ab", "ab", "abc" };

            string[] query = { "ab", "abc", "bc" };

            int[] resultados = Consulta(entrada,query);

            for (int i = 0; i < resultados.Length; i++)
            {
                Console.WriteLine($"{resultados[i]} coincidencias encontradas de \"{query[i]}\"");
            }

            
        }

        public static int[] Consulta(string[] entrada, params string[] queries)
        {

            int[] resultados = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                resultados[i] = entrada.Count(u => u == queries[i]);
            }

            return resultados;

        }
    }

  

}
