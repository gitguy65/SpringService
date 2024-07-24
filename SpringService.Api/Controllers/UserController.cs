using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Model.Dto;
using SpringService.Api.Models; 
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController(IUserRepository userRepository,
                              ILogger<UserController> logger,
                              IMapper mapper) : Controller
    {
        private readonly IUserRepository userRepository = userRepository;
        private readonly ILogger<UserController> logger = logger;
        private readonly IMapper mapper = mapper;

        [HttpGet("fetch-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAllUsers()
        {
            var users = mapper.Map<IEnumerable<UserDto>>(userRepository.GetUsers());
            
            if (users.Count() < 0)
                return BadRequest();

            return Ok(users);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetUser(string Id)
        {
            var findUser = userRepository.GetUser(Id);

            if (findUser is null)
                return NotFound();

            var user = mapper.Map<UserDto>(userRepository.GetUser(Id));
            return Ok(user);
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] UserDto createUser)
        {
            if (createUser == null)
                return BadRequest(ModelState);

            //check if valid email

            var checkUser = userRepository.GetUsers()
                .Where(c => c.Email == createUser.Email)
                .FirstOrDefault();

            if (checkUser != null)
            {
                ModelState.AddModelError("", "User with chosen email already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var UserMap = mapper.Map<User>(createUser);
            UserMap.Balance = 0; 
            // run image validation and upload
            //hash the password
            UserMap.ReceivedReviews = null;
            UserMap.GivenReviews = null;
            UserMap.Bookings = null;
            UserMap.Histories = null;

            if (!userRepository.CreateUser(UserMap))
            {
                ModelState.AddModelError("", "An internal error occured");
                logger.LogError(message: ModelState.ToString());
                return StatusCode(500, ModelState);
            }

            return StatusCode(201, "Succesfully created user");
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login(string email, string password)
        {
            if (email is null || password is null)
                return BadRequest(ModelState);

            //check if valid email

            var checkUser = userRepository.GetUsers()
                .Where(c => c.Email == email)
                .FirstOrDefault();

            if (checkUser != null)
            {
                ModelState.AddModelError("", "User with chosen email already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            return StatusCode(201, "Succesfully created user");
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateUser(string Id, UserDto user) 
        {
            if (user is null)
                return BadRequest(ModelState);

            if (Id != user.Id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return BadRequest(ModelState);
            }

            var userMap = mapper.Map<User>(user);

            if (!userRepository.UserExists(userMap))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating this user");
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully updated");
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUser(string slug)
        {
            if (slug is null)
                return BadRequest();

            var user = userRepository.GetUser(slug);

            if (!userRepository.UserExists(user))
                return NotFound();
            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!userRepository.DeleteUser(user))
                ModelState.AddModelError("", "An error occured while deleting this user");
            
            return NoContent();
        }
    }
}
