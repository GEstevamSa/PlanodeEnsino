using AutoMapper;
using LP.ApplicationService.ViewModels;
using LP.Domain.Models;

namespace LP.ApplicationService.Mappings
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {            
            CreateMap<User, UserViewModel>();
        }
    }
}
