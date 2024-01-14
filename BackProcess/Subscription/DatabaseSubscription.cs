using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace BackProcess.Subscription
{
    public class DatabaseSubscription<T> : IDatabaseSubscription where T : class,new()
    {
        IConfiguration _configuration;
        IHubContext<SatisHub> _hubContext;

        public DatabaseSubscription(IConfiguration configuration, IHubContext<SatisHub> hubContext)
        {
            _configuration = configuration;
            _hubContext = hubContext;
        }

        SqlTableDependency<T> _tableDependency;
        public void Configure(string tableName)
        {
            _tableDependency = new SqlTableDependency<T>(_configuration.GetConnectionString("SQL"),tableName);
            _tableDependency.OnChanged += async (o,e) => {
                await _hubContext.Clients.All.SendAsync("receiveMessage", "Eklendi");
            };
            _tableDependency.OnError += (o,e) => { };

            _tableDependency.Start();
        }


        ~DatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }

    public interface IDatabaseSubscription {

        void Configure(string tableName);
    }
}
