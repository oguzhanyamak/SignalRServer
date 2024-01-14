﻿using Microsoft.AspNetCore.Builder;
using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR
{
    public static class HubRegister
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<SatisHub>("/satisHub");
        }
    }
}
