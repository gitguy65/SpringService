using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Model.Dto;
using SpringService.Api.Models; 
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    public class BookingController(IBookingRepository bookingRepository, 
                                   IUserRepository userRepository,
                                   ILogger<Booking> logger, 
                                   IMapper mapper) : Controller
    {
        private readonly IBookingRepository bookingRepository = bookingRepository;
        private readonly IUserRepository userRepository = userRepository;
        private readonly ILogger<Booking> logger = logger;
        private readonly IMapper mapper = mapper;


        [HttpGet("fetch-all-bookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAllBookings()
        {
            var Booking = mapper.Map<List<BookingDto>>(bookingRepository.GetAllBookings());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Booking);
        }


        [HttpGet("fetch-all-user-bookings/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GeUserBookings(string Id)
        {
            var user = userRepository.GetUser(Id);

            if (!userRepository.UserExists(user))
                return NotFound();

            var Booking = mapper.Map<IEnumerable<BookingDto>>(bookingRepository.GetUserBooking(user));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Booking);
        }


        [HttpGet("fetch-booking/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBooking(int id)
        {
            if (!bookingRepository.BookingExists(id))
                return BadRequest();

            BookingDto Booking = mapper.Map<BookingDto>(bookingRepository.GetBooking(id));

            if (!ModelState.IsValid)
            {
                return BadRequest("Booking not found");
            }
            return Ok(Booking);
        }


        [HttpPost("create-booking/{Id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateBooking(string Id,[FromBody] BookingDto booking)
        {
            if (booking == null)
                return BadRequest(ModelState);

            var user = userRepository.GetUser(Id);

            if (user is null)
            {
                ModelState.AddModelError("", "no associated user");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookingMap = mapper.Map<Booking>(booking);
            bookingMap.User = user;
            bookingMap.UserId = user.Id;

            if (!bookingRepository.CreateBooking(bookingMap))
            {
                ModelState.AddModelError("", "An internal error occured");
                logger.LogError(message: ModelState.ToString());
                return StatusCode(500, ModelState);
            }

            return StatusCode(201, "Succesfully added user's booking");
        }


        [HttpPut("update-user-booking/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateBooking(string Id, [FromBody] BookingDto updateBooking)
        {
            if (updateBooking == null)
                return BadRequest(ModelState);

            if (Id != updateBooking.User.Id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return BadRequest(ModelState);
            }

            // get the booking Id
            int id = 0;
            
            if (!bookingRepository.BookingExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var BookingMap = mapper.Map<Booking>(updateBooking);
            if (!bookingRepository.UpdateBooking(BookingMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating Booking");
                logger.LogInformation(message: ModelState.ToString());
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully updated");
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBooking(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!bookingRepository.BookingExists(id))
            {
                return NotFound();
            }
            var BookingToDelete = bookingRepository.GetBooking(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!bookingRepository.DeleteBooking(BookingToDelete.Id))
            {
                ModelState.AddModelError("", "An error occured while deleting booking");
            }

            return NoContent();
        }         
    }
}
