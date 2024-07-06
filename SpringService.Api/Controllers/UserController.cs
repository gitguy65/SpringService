using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserController> logger;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository,
                                  ILogger<UserController> logger,
                                  IMapper mapper)
        {
            this.userRepository = userRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}
