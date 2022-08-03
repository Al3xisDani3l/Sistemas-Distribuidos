using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace A9___Server_SignalR
{
    
    
    public  class FibonnaciHub: Hub
    {

        static int aux;

        static int a = 0;

        public override Task OnConnectedAsync()
        {

            Console.WriteLine($"Nuevo cliente conectado : {Context.ConnectionId}!");

            return base.OnConnectedAsync();

        }

        public override Task OnDisconnectedAsync(Exception exception)
        {

            Console.WriteLine($"Cliente se ha desconectado : {Context.ConnectionId}!");
           

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendNumber(int number)
        {



            aux = a;

            a = number;

            number = aux + a;





            Console.WriteLine($"Fibonnacci : {number}");

            Console.ReadLine();
            await Clients.All.SendAsync("recivefib", number);

           

          
        }


    }
}
