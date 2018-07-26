using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SignalRTeste
{
    public class MyRedis
    {
        private static string _host = Get();

        private static string Get()
        {
#if DEBUG
            return "localhost";
#else
            return "10.0.0.4";
#endif
        }

        private IDatabase GetDataBase()
        {
            var con = ConnectionMultiplexer.Connect(_host);
            var data = con.GetDatabase();
            return data;
        }
    }
}