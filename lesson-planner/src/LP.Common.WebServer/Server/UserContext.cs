using System;
using LP.Common.WebServer.Server.Interfaces;

namespace LP.Common.WebServer.Server
{
    public class UserContext : IUserContext
    {
        public Guid Id { get; set; }
    }
}