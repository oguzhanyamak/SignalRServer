using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackProcess.Subscription.Middleware
{
    public static class DatabaseSubscrptionMid
    {
        public static void UseDatabaseSubscription<T>(this IApplicationBuilder builder,string tableName) where T : class,IDatabaseSubscription
        {
            var subscription = (T)builder.ApplicationServices.GetService(typeof(T));
            subscription.Configure(tableName);
        }
    }
}
