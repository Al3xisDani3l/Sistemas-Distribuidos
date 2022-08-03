using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo;

namespace Cliente_Signalr_Adivinador
{
   public class AdivinatorGame
    {

         HubConnection conn;

        bool win = false;

        bool lose = false;

        const string UrlBase = @"http://localhost:";

        const string Point = "/adivina";

        public int Port = 5000;

         InfoClient _currentInfo;

        public async Task ConfigAsync()
        {

            

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Introdusca el puerto del servidor: ");
                Port = Convert.ToInt32(Console.ReadLine());

                conn = await Init(Port);




            } while (conn == null);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nConexion exitosa!");
            Console.ResetColor();

        }

        public async Task SetNameAsync()
        {
            string nombre = "";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.Write("\nIntroduse un nombre: ");
            nombre = Console.ReadLine();
            Console.ReadLine();
            Console.ResetColor();
            await conn.InvokeAsync("SetName", nombre);
            Console.ReadLine();
        }


        public async void IniciaJuegoAsync()
        {

            string seguir = "s";
            int num;
            do
            {
                
                Console.Clear();

                Console.WriteLine("----EL ADIVINADOR----");
                Console.WriteLine();

                do
                {
                    Console.WriteLine("Introduce un numero:");

                    try
                    {
                        num = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                        num = Convert.ToInt32(Console.ReadLine());
                    }

                  

                    conn.InvokeAsync("Adivina", num).Wait();

                  



                } while (win == false && lose == false);

                Console.WriteLine("¿Desea volver a repetir la partida? S/N: ");

                seguir = Console.ReadLine();

                if (seguir.ToLower() == "s")
                {
                    conn.InvokeAsync("Reset");
                }




            } while (seguir.ToLower() == "s");



            conn.StopAsync();


        }


        async Task<HubConnection> Init(int port)
        {

            var connection = new HubConnectionBuilder()
               .WithUrl(UrlBase + port.ToString() + Point)
               .WithAutomaticReconnect().Build();




            connection.Reconnecting += Conn_Reconnecting;

            connection.Reconnected += Conn_Reconnected;

            connection.On("Logger", new Action<string>(Logger));

            connection.On("Lose", new Action(Lose));

            connection.On("Win", new Action<int>(Win));

            connection.On("Register", new Action<InfoClient>(Register));


            try
            {
                
                Console.WriteLine($"\nIniciando conexion: {UrlBase}{port}{Point}");
                await connection.StartAsync();
                return connection;
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError no hemos podido conectarnos al servidor\nMessage:{err.Message}");
                Console.ResetColor();
                return null;

            }


        }

        private void Register(InfoClient obj)
        {
            _currentInfo = obj;
        }

        private  void Win(int num)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Felicidades adivinaste si era {num}");
            Console.ResetColor();
            win = true;
        }

        private  void Lose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Excediste tu limite de intentos, has perdido!");
            Console.ResetColor();
            lose = true;
        }

        private  void Logger(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nServer: {message}\n");
            Console.ResetColor();
        }

        private async Task Conn_Reconnected(string arg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            await conn.InvokeAsync("Reconnection", _currentInfo);
            Console.WriteLine("\nConexion Recuperada!");
            Console.ResetColor();
            IniciaJuegoAsync();
            
        }

        private async Task Conn_Reconnecting(Exception arg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSe ha perdido la conexion!, Intentando reconectar...");
            Console.ResetColor();
            await Task.CompletedTask;
        }



    }
}
