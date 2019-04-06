using AutoMapper;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.WebServer.Server;

namespace LP.ApplicationService.Interfaces
{
    public interface IBaseAppService
    {
        IMessageBus MessageBus { get; set; }
        UserContext CurrentUser { get; set; }
        IMapper Mapper { get; set; }
    }
}
