using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class SatisHub:Hub
    {
        public async Task SendMessage()
        {
            Clients.All.SendAsync("receiveMessage","Merhaba");
        }
        
    }
}
