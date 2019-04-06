using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LP.ApplicationService.Configuration;
using LP.ApplicationService.Interfaces;
using LP.ApplicationService.ViewModels;
using LP.Domain.CommandHandlers.User;
using LP.Domain.Models;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.Repository.Contracts.Core.Exceptions;
using LP.Common.Repository.Contracts.Core.Repository;
using LP.Common.Repository.Contracts.Core.Validations;
using Microsoft.AspNetCore.Http;

namespace LP.ApplicationService.Services
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IMapper mapper;
        private readonly ProfileConfiguration profileConfig;
        private readonly IRepository<User> userRepository;

        public UserAppService(
            IHttpContextAccessor contextAccessor,
            IMessageBus bus,
            IMapper mapper,
            IRepository<User> userRepository,
            ProfileConfiguration profileConfig) : base(contextAccessor, bus, mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.profileConfig = profileConfig;
        }
        
        public void Delete(DeleteUserCommand commandDelete)
        {
            MessageBus.DispatchCommand(commandDelete);
        }

        public UserViewModel Get(Guid id)
        {
            return mapper.Map<UserViewModel>(userRepository.FindById(id));
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<UserViewModel>>(userRepository.All());
        }

        public UserViewModel Login(UserViewModel viewModel)
        {
            if (viewModel.ValidateModelAnnotations().Count > 0)
                throw new ModelException(
                    "This object instance is not valid based on DataAnnotation definitions. See more details on Errors list.",
                    viewModel.ValidateModelAnnotations());

            var command = new LoginUserCommand(viewModel.Name, viewModel.Login);
            var user = Mapper.Map<UserViewModel>(MessageBus.DispatchCommandTwoWay<LoginUserCommand, User>(command)
                .Result);

            return user;
        }    
    }
}
