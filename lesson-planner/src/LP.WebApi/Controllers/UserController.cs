using LP.ApplicationService.Interfaces;
using LP.ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LP.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [Route("api/User")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(userAppService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(userAppService.Get(id));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserViewModel viewModel)
        {
            var loggedUser = userAppService.Login(viewModel);
            if (loggedUser == null)
            {
                return Unauthorized();
            }

            return Ok(loggedUser);
        }
    }
}
