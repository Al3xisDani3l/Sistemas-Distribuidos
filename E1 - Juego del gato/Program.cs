using System;

namespace E1___Juego_del_gato
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "El juego del gato";
            Console.ForegroundColor = ConsoleColor.Green;

            GatoGame juegoGato = new GatoGame();

            char opcion;
            Console.WriteLine();
            Console.WriteLine("\tHola! Empezemos a jugar al gato!\n");
            Console.WriteLine("\t****************************");
            Console.WriteLine(Environment.NewLine);

            //Obtenemos el nombre de los participantes
            juegoGato.SetNames();
            do
            {
               //Inicia los valores de el tablero 
                juegoGato.InicializarTablero();
                //Iniciamos el proceso del juego
                juegoGato.StartGame();


                System.Console.WriteLine("\tPresiona \"N\" para salir, cualquier otra tecla para continuar ");
                string lec = Console.ReadLine();
               opcion = Convert.ToChar(lec[0]);

            } while (!(opcion == 'n' || opcion == 'N'));
           


           



        }
    }

   

}
