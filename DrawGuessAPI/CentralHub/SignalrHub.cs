using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DrawGuessAPI.CentralHub
{
    public class SignalrHub:Hub
    {
        public async Task BroadcastMessage()
        {
            await Clients.All.SendAsync("Connected");
        }

        public async Task CreateRoom()
        {
            await Clients.All.SendAsync("UpdateRoomList");
        }

        public async Task EnterRoom()
        {
            await Clients.All.SendAsync("AddToRoom");
        }

        public async Task ExitRoom()
        {
            await Clients.All.SendAsync("RemoveFromRoom");
        }

        public async Task SendChat()
        {
            await Clients.All.SendAsync("UpdateChat");
        }

        public async Task Draw()
        {
            await Clients.All.SendAsync("UpdateDraw");
        }
    }
}
