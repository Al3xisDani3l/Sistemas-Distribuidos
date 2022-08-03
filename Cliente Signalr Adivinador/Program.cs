using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Protocol;
using UserInfo;

namespace Cliente_Signalr_Adivinador
{
    class Program
    {

        

        

        

        static async Task Main(string[] args)
        {



            AdivinatorGame game = new AdivinatorGame();

            await game.ConfigAsync();



            await game.SetNameAsync();



             game.IniciaJuegoAsync();





            Console.ReadLine();

        }

      
    }
}
