using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.SignalR;


namespace ApplicationForMissingAnimals
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}