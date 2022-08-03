using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace A9___Client_Signalr
{
    class Program
    {
        static void Main(string[] args)
        {

            int initFib = 1;

            int count = 1;

            var connection = new HubConnectionBuilder()
                .WithUrl(@"http://localhost:5000/fibonnaci")
                .WithAutomaticReconnect(new []{TimeSpan.Zero,TimeSpan.Zero,TimeSpan.FromSeconds(30)})
                .Build();




            connection.Reconnecting += (error)=>
            {

                Console.WriteLine(error.Message);
                Console.WriteLine("Coneccion perdida intentando reconectar!");

                return Task.CompletedTask;
            };

            connection.Reconnected += Connection_Reconnected;

           

            try
            {
                connection.On("recivefib", (int number) =>
                {

                   
                    Console.WriteLine(number);
               
                   

                        connection.InvokeAsync("SendNumber", number).Wait();
               

                });

                connection.StartAsync().Wait();
                connection.InvokeAsync("SendNumber", initFib);

               

                
            }
            catch (Exception err)
            {

                Console.WriteLine(err);
            }

            Console.ReadLine();


        }

        private static Task Connection_Reconnected(string arg)
        {

            Console.WriteLine("Conexion Recuperada!");

            return Task.CompletedTask;

        }
    }
}
