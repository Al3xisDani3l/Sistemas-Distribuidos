using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo;

namespace Servidor_Signalr_Adivinador
{
    public class AdivinadorHub: Hub
    {


        static List<InfoClient> ClientsRegister = new List<InfoClient>();


        public override async Task OnConnectedAsync()
        {
            Random random = new Random();


            if (!ClientsRegister.Exists(c => c.IdClient == Context.ConnectionId))
            {
                InfoClient client = new InfoClient() { IdClient = Context.ConnectionId, Number = random.Next(1, 20), Intentos = 0 };
                ClientsRegister.Add(client) ;
                await Clients.Client(Context.ConnectionId).SendAsync("Register", client);
                return;
            }

           
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = ClientsRegister.FirstOrDefault(c => c.IdClient == Context.ConnectionId);
            if (user != null)
            {

                Console.WriteLine($"{user.Nombre} se ha desconectado!");
            }
            return Task.CompletedTask;
        }

        public async Task SetName(string name)
        {

            if (!string.IsNullOrEmpty(name))
            {

                var client = ClientsRegister.FirstOrDefault(c => c.IdClient == Context.ConnectionId);
                client.Nombre = name;
                await Clients.Client(Context.ConnectionId).SendAsync("Register", client);
                await Clients.Client(Context.ConnectionId).SendAsync("Logger", $"Hola {name}! tu nombre fue registrado con exito");

            }


        }

        public async Task Reset()
        {

            var user = ClientsRegister.FirstOrDefault(c => c.IdClient == Context.ConnectionId);

            user.Intentos = 0;

            user.Number = new Random().Next(1, 20);

            await Clients.Client(Context.ConnectionId).SendAsync("Register", user);

            await Clients.Client(Context.ConnectionId).SendAsync("Logger", $"Los datos han cambiado, tienes una nueva opurtunidad");


        }

        public async Task Reconnection(InfoClient clientInfo)
        {
            var client = ClientsRegister.FirstOrDefault(c => c.IdClient == Context.ConnectionId);
            ClientsRegister.Remove(clientInfo);
            client.Nombre = clientInfo.Nombre;
            client.Number = clientInfo.Number;
            client.Intentos = clientInfo.Intentos;

            await Clients.Client(Context.ConnectionId).SendAsync("Register", client);
            



        }

        public async Task Adivina(int number)
        {

           var currentUser = ClientsRegister.FirstOrDefault(c => c.IdClient == Context.ConnectionId);

            currentUser.Intentos++;

            if (currentUser.Intentos > 2)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("Lose");

                return;

            }
           else if (currentUser.Number == number)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("Win",currentUser.Intentos,number);
                return;
            }
            else if (currentUser.Number > number)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("Logger", $"{currentUser.Nombre} el {number} es menor, te quedan {3  - currentUser.Intentos} intentos ");
                await Clients.Client(Context.ConnectionId).SendAsync("Register", currentUser);
                return;
            }
            else if(currentUser.Number < number)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("Logger", $"{currentUser.Nombre} el {number} es mayor, te quedan {3 - currentUser.Intentos} intentos ");
                await Clients.Client(Context.ConnectionId).SendAsync("Register", currentUser);
                return;
            }
        }

    }

    


}
