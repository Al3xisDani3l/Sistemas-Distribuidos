using System;
using System.Collections.Generic;
using System.Text;

namespace E1___Juego_del_gato
{
    /// <summary>
    /// Maneja toda la logica del juego del gato.
    /// </summary>
    public class GatoGame
    {
        string jugador1 = "";
        string jugador2 = "";
        int jugador1puntos;
        int jugador2puntos;
        int pjugador1;
        int pjugador2;

        char[,] tablero = new char[3, 3];


        public string Jugador1 {get => jugador1; set => jugador1 = value;  }
        public string Jugador2 { get => jugador2; set => jugador2 = value; }

       

        public GatoGame(string name1 ="", string name2 ="")
        {
            jugador1 = name1;
            jugador2 = name2;

            jugador1puntos = 0;
            jugador2puntos = 0;
            pjugador1 = 0;
            pjugador2 = 0;

            InicializarTablero();
        }

        public void InicializarTablero()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tablero[i, j] = ' ';
                }
            }
        }

        public void SetNames()
        {
            while (Jugador1.Length < 2)
            {
                Console.Write("\nJugador numero uno introduce tu nombre  (X): ");
                Jugador1 = Console.ReadLine();
                Console.WriteLine();
                if (Jugador1.Length < 2)
                {
                    Console.WriteLine("Introduce un nombre mas largo ");
                }
            }

            while (Jugador2.Length < 2)
            {
                Console.Write("\nJugador numero dos introduce tu nombre  (O): ");
                Jugador2 = Console.ReadLine();
                Console.WriteLine();
                if (Jugador2.Length < 2)
                {
                    Console.WriteLine("Introduce un nombre mas largo ");
                }
            }
        }

        public void StartGame()
        {
            bool TurnoJugador1 = true;
            //comprobamos si alguien gano por cada tirada
            while (!SomeoneWin())
            {
                //mostramos la informacion de cada vez que gana.
                Console.Clear();
                Console.WriteLine("Hola! Empezemos a jugar al gato!");
                Console.WriteLine("****************************");
                Console.WriteLine($" {jugador1} llevas {jugador1puntos} partidas ganadas");
                Console.WriteLine($" {jugador2} llevas {jugador2puntos} partidas ganadas");
                Console.WriteLine();
                Console.WriteLine(DrawTablero());
                Console.WriteLine();

                string NombreDelJugador = "";
                if (TurnoJugador1)
                {
                    NombreDelJugador = jugador1;
                    pjugador1++;

                }
                else
                {
                    NombreDelJugador = jugador2;
                    pjugador2++;
                }


                string coordenada = "";
                // validamos la posicion y si la casilla no esta ocupada
                while (!CoordenadaValida(coordenada) || CasillaOcupada(coordenada))
                {
                    Console.WriteLine($"{NombreDelJugador}, Introduce la coordenada donde quieres jugar");

                    coordenada = Console.ReadLine().ToUpper();

                    if (!CoordenadaValida(coordenada))
                    {
                        Console.WriteLine("La coordenada no es valida");
                        Console.WriteLine();
                    }

                    if (CasillaOcupada(coordenada))
                    {
                        Console.WriteLine("La coordenada ya esta ocupada");
                        Console.WriteLine();
                    }
                }

                char caracterUsado = ' ';
                if (TurnoJugador1)
                {
                    caracterUsado = 'X';
                }
                else
                {
                    caracterUsado = 'O';
                }
                Coordenada(coordenada, caracterUsado);

                if (SomeoneWin())
                {
                    break;
                }
                if (TableroCompleto(tablero))
                {
                    break;
                }

                TurnoJugador1 = !TurnoJugador1;
            }


            if (SomeoneWin())
            {
                Console.Clear();
                Console.WriteLine("\tHola! Empezemos a jugar al gato!");
                Console.WriteLine("\t****************************");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(DrawTablero());
                Console.WriteLine();

                Console.WriteLine("\t\tFin del juego");
                if ((Winer()) == 'X')

                {

                    Console.WriteLine($"\t {jugador1}, has ganado con {pjugador1} movimientos");
                    jugador1puntos++;


                }
                else
                {
                    Console.WriteLine($"\t { jugador2}, has ganado con {pjugador2} movimientos");
                    jugador2puntos++;
                }
            }

            //Aqui determinamos si hubo un empate
            if (TableroCompleto(tablero))
            {
                Console.Clear();
                Console.WriteLine("\tHola! Empezemos a jugar al gato!");
                Console.WriteLine("\t****************************");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(DrawTablero());
                //Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("Fin del juego!"+Environment.NewLine);
                Console.WriteLine("Ha sido un empate!");

            }

           
        }

        //dibujamos el tablero
        public string DrawTablero()
        {
            string result = " ";
            result =  "\t    1   2   3" + Environment.NewLine;
            result += "\t  ┌───┬───┬───┐" + Environment.NewLine;
            result += $"\tA │ {tablero[0, 0]} │ {tablero[0, 1]} │ {tablero[0, 2]} │" + Environment.NewLine;
            result += "\t  ├───┼───┼───┤" + Environment.NewLine;
            result += $"\tB │ {tablero[1, 0]} │ {tablero[1, 1]} │ {tablero[1, 2]} │" + Environment.NewLine;
            result += "\t  ├───┼───┼───┤" + Environment.NewLine;
            result += $"\tC │ {tablero[2, 0]} │ {tablero[2, 1]} │ {tablero[2, 2]} │" + Environment.NewLine;
            result += "\t  └───┴───┴───┘" + Environment.NewLine;

            return result;

        }

        //determinas por el caracter quien gano
        public char Winer()
        {
            if (tablero[0, 0] == tablero[0, 1] && tablero[0, 1] == tablero[0, 2] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];
            }

            if (tablero[1, 0] == tablero[1, 1] && tablero[1, 1] == tablero[1, 2] && tablero[1, 0] != ' ')
            {
                return tablero[1, 0];
            }

            if (tablero[2, 0] == tablero[2, 1] && tablero[2, 1] == tablero[2, 2] && tablero[2, 0] != ' ')
            {
                return tablero[2, 0];
            }

            if (tablero[0, 0] == tablero[1, 0] && tablero[1, 0] == tablero[2, 0] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];
            }
            if (tablero[0, 1] == tablero[1, 1] && tablero[1, 1] == tablero[2, 1] && tablero[0, 0] != ' ')
            {
                return tablero[0, 1];
            }
            if (tablero[0, 2] == tablero[1, 2] && tablero[1, 2] == tablero[2, 2] && tablero[0, 0] != ' ')
            {
                return tablero[0, 2];
            }
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];
            }
            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != ' ')
            {
                return tablero[0, 0];
            }

            return ' ';
        }

        public bool SomeoneWin()

        {
            return Winer() != ' ';

        }

        public bool CasillaOcupada(int x, int y)
        {
            if (x < 0 || x > 2)
            {
                throw new ArgumentException(" El valor de x debe ser 0, 1 o 2", "x");
            }

            if (y < 0 || y > 2)
            {
                throw new ArgumentException(" El valor de y debe ser 0, 1 o 2", "y");
            }
            return tablero[x, y] != ' ';
        }

        public bool CasillaOcupada(string coordenada)
        {
            coordenada = coordenada.ToUpper();
            switch (coordenada)
            {
                case "A1":
                    return CasillaOcupada(0, 0);
                case "A2":
                    return CasillaOcupada(0, 1);
                case "A3":
                    return CasillaOcupada(0, 2);
                case "B1":
                    return CasillaOcupada(1, 0);
                case "B2":
                    return CasillaOcupada(1, 1);
                case "B3":
                    return CasillaOcupada(1, 2);
                case "C1":
                    return CasillaOcupada(2, 0);
                case "C2":
                    return CasillaOcupada(2, 1);
                case "C3":
                    return CasillaOcupada(2, 2);


            }
            return false;

        }

        public void Coordenada(string coordenada, char letra)
        {
            coordenada = coordenada.ToUpper();
            switch (coordenada)
            {
                case "A1":
                    tablero[0, 0] = letra;
                    return;
                case "A2":
                    tablero[0, 1] = letra;
                    return;
                case "A3":
                    tablero[0, 2] = letra;
                    return;
                case "B1":
                    tablero[1, 0] = letra;
                    return;
                case "B2":
                    tablero[1, 1] = letra;
                    return;
                case "B3":
                    tablero[1, 2] = letra;
                    return;
                case "C1":
                    tablero[2, 0] = letra;
                    return;
                case "C2":
                    tablero[2, 1] = letra;
                    return;
                case "C3":
                    tablero[2, 2] = letra;
                    return;


            }


        }

        public bool CoordenadaValida(string coordenada)
        {
            switch (coordenada)
            {
                case "A1":

                case "A2":

                case "A3":

                case "B1":

                case "B2":

                case "B3":

                case "C1":

                case "C2":

                case "C3":
                    return true;
                default:
                    return false;


            }
        }

        public bool TableroCompleto(char[,] tablero)
        {
            bool comp = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    comp &= tablero[i, j] != ' ';
                }
            }

            return comp;
        }



    }
}
