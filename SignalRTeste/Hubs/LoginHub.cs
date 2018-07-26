using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRTeste.Hubs
{
    public class LoginHub : Hub
    {
        public string Logins(string logout)
        {
            return Environment.MachineName;
        }

        public void ForceLogout()
        {
            Clients.OthersInGroup(_sessionId).pleaseLogout();
        }

        private string _sessionId
        {
            get
            {
                return
                    Context != null &&
                    Context.RequestCookies != null &&
                    Context.RequestCookies.ContainsKey("ASP.NET_SessionId") ?
                    Context.RequestCookies["ASP.NET_SessionId"].Value :
                    String.Empty;
            }
        }
        private string connId { get { return Context.ConnectionId; } }

        public override Task OnConnected()
        {
            try
            {
                Groups.Add(connId, _sessionId);
            }
            catch (Exception ex)
            {
            }
            return base.OnConnected();
        }
    }
}