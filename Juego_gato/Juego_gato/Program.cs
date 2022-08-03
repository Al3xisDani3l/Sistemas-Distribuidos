using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_gato
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tablero = new char[3, 3];
           
            string jugador1 = "";
            string jugador2 = "";
            int jugador1puntos = 0;
            int jugador2puntos = 0;
            int pjugador1 =0;
            int pjugador2 = 0;

            string opc;
            char opcion;
            do
            {
                pjugador1 = 0;
                pjugador2 = 0;

                InicializarTablero(ref tablero);

            Console.WriteLine("Bienvenido al juego del gato");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
           //Pedimos el nombre al jugador 1, que sea un nombre decente
            while (jugador1.Length<2)
            {
                Console.WriteLine("Nombre del jugador 1 (X): ");
                jugador1 = Console.ReadLine();
                Console.WriteLine();
                if (jugador1.Length<2)
                {
                    Console.WriteLine("Introdusca un nombre mas largo");
                }
            }
            //Pedimos el nombre al jugador 2, que sea un nombre decente

            while (jugador2.Length < 2)
            {
                Console.WriteLine("Nombre del jugador 2 (O): ");
                jugador2 = Console.ReadLine();
                Console.WriteLine();
                if (jugador2.Length < 2)
                {
                    Console.WriteLine("Introdusca un nombre mas largo");
                }
            }
            bool TurnoJugador1 = true;
            while (!SomeoneWin(tablero))
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al juego del gato");
                Console.WriteLine("-----------------------------");
                    Console.WriteLine($" {jugador1} llevas {jugador1puntos} partidas ganadas");
                    Console.WriteLine($" {jugador2} llevas {jugador2puntos} partidas ganadas");
                    Console.WriteLine();
                Console.WriteLine(Tablero_(tablero));
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
                while (!CoordenadaValida(coordenada)|| CasillaOcupada(tablero,coordenada))
                {
                    Console.WriteLine($"{NombreDelJugador}, Introduce la coordenada donde quieres jugar");

                    coordenada = Console.ReadLine().ToUpper();

                    if (!CoordenadaValida(coordenada))
                    {
                        Console.WriteLine("La coordenada no es valida");
                        Console.WriteLine();
                    }

                    if (CasillaOcupada(tablero,coordenada))
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
                Coordenada(ref tablero, coordenada, caracterUsado);

                if (SomeoneWin(tablero))
                {
                    break; 
                }
                if (TableroCompleto(tablero))
                {
                    break;
                }

                TurnoJugador1 = !TurnoJugador1;
            }

            if (SomeoneWin(tablero))
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al juego del gato");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
                Console.WriteLine(Tablero_(tablero));
                Console.WriteLine();

                Console.WriteLine("Fin del juego");
                if ((Winer(tablero))=='X')
                 
                {
                       
                    Console.WriteLine($"{jugador1}, has ganado con {pjugador1} tiradas");
                        jugador1puntos++;
                      
                     
                }
                else
                {
                    Console.WriteLine($"{ jugador2}, has ganado con {pjugador2} tiradas");
                        jugador2puntos++;
                }
            }

            if (TableroCompleto(tablero))
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al juego del gato");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
                Console.WriteLine(Tablero_(tablero));
                Console.WriteLine();

                Console.WriteLine("Fin del juego");
                Console.WriteLine("Empate");

            }

                System.Console.WriteLine("Presiona  para volver a jugar o N para salir");
                opc= Console.ReadLine();
                opcion = Convert.ToChar(opc);
                
            } while (!(opcion=='n'|| opcion== 'N'));

            Console.ReadKey();
        }




        static void InicializarTablero(ref char[,] tablero)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    tablero[i, j] = ' ';
                }
            }
        }
       
        static string Tablero_(char[,] tablero)
        {
            string tablerovisual = " ";
            tablerovisual = "    1   2   3" +Environment.NewLine;
            tablerovisual += "  ┌───┬───┬───┐" + Environment.NewLine;
            tablerovisual += $"A │ {tablero[0,0]} │ {tablero[0, 1]} │ {tablero[0, 2]} │" + Environment.NewLine;
            tablerovisual += "  ├───┼───┼───┤" + Environment.NewLine;
            tablerovisual += $"B │ {tablero[1,0]} │ {tablero[1, 1]} │ {tablero[1, 2]} │" + Environment.NewLine;
            tablerovisual += "  ├───┼───┼───┤" + Environment.NewLine;
            tablerovisual += $"C │ {tablero[2, 0]} │ {tablero[2, 1]} │ {tablero[2, 2]} │" + Environment.NewLine;
           tablerovisual += "  └───┴───┴───┘" + Environment.NewLine;

            return tablerovisual;

        }

        static char Winer(char[,] tablero)
        {
            if (tablero[0,0]==tablero[0,1]&&tablero[0,1]==tablero[0,2]&&tablero[0,0] !=' ')
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
        static bool SomeoneWin(char[,]tablero)
        
        {
            return Winer(tablero) != ' ';

        } 

        static bool CasillaOcupada(char[,]tablero, int x, int y)
        {
            if (x<0||x>2)
            {
                throw new ArgumentException(" El valor de x debe ser 0, 1 o 2", "x");
            }

            if (y < 0 || y > 2)
            {
                throw new ArgumentException(" El valor de y debe ser 0, 1 o 2", "y");
            }
           return tablero[x, y] != ' ';
        } 

        static bool CasillaOcupada(char[,]tablero, string coordenada)
        {
            coordenada = coordenada.ToUpper();
            switch (coordenada)
            {
                case "A1":
                    return CasillaOcupada(tablero,0,0);
                case "A2":
                    return CasillaOcupada(tablero, 0, 1);
                case "A3":
                    return CasillaOcupada(tablero, 0, 2);
                case "B1":
                    return CasillaOcupada(tablero, 1, 0);
                case "B2":
                    return CasillaOcupada(tablero, 1, 1);
                case "B3":
                    return CasillaOcupada(tablero, 1, 2);
                case "C1":
                    return CasillaOcupada(tablero, 2, 0);
                case "C2":
                    return CasillaOcupada(tablero, 2, 1);
                case "C3":
                    return CasillaOcupada(tablero, 2, 2);

               
            }
            return false;

        }
        static void Coordenada(ref char[,]tablero, string coordenada, char letra)
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
        static bool CoordenadaValida(string coordenada)
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
        static bool TableroCompleto(char[,]tablero)
        {
            bool comp = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j   = 0; j < 3; j++)
                {
                   comp &= tablero[i, j] != ' ';
                }
            }

            return comp;
        }
    }
}
