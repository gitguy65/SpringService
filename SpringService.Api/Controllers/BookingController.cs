using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Model.Dto;
using SpringService.Api.Models; 
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController(IBookingRepository bookingRepository, 
                                   ILogger<Booking> logger, 
                                   IMapper mapper) : Controller
    {
        private readonly IBookingRepository bookingRepository = bookingRepository;
        private readonly ILogger<Booking> logger = logger;
        private readonly IMapper mapper = mapper;


        [HttpGet]
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

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GeUserBookings(User user)
        {
            var Booking = mapper.Map<List<BookingDto>>(bookingRepository.GetUserBooking(user));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Booking);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetBooking(int id)
        {
            if (!bookingRepository.BookingExists(id))
                return BadRequest();

            BookingDto Booking = mapper.Map<BookingDto>(bookingRepository.GetBooking(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Booking);
        }

        [HttpPost("user")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateBooking([FromBody] BookingDto createBooking)
        {
            if (createBooking == null)
                return BadRequest(ModelState);
            var Booking = bookingRepository.GetAllBookings()
                .Where(c => c.Id == createBooking.Id)
                .FirstOrDefault();

            if (Booking != null)
            {
                ModelState.AddModelError("", "Booking with chosen email already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var BookingMap = mapper.Map<Booking>(createBooking);

            if (!bookingRepository.CreateBooking(BookingMap))
            {
                ModelState.AddModelError("", "An internal error occured");
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully created");
        }

        [HttpDelete("user/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBookingPost(int booking)
        {
            if (booking == null)
                return BadRequest();

            if (!bookingRepository.BookingExists(booking))
            {
                return NotFound();
            }
            var BookingToDelete = bookingRepository.GetBooking(booking);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!bookingRepository.DeleteBooking(BookingToDelete.Id))
            {
                ModelState.AddModelError("", "An error occured while deleting Booking");
            }

            return NoContent();
        }

        [HttpPut("user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateBooking(int BookingId, [FromBody] BookingDto updateBooking)
        {
            if (updateBooking == null)
                return BadRequest(ModelState);

            if (BookingId != updateBooking.Id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return BadRequest(ModelState);
            }

            if (!bookingRepository.BookingExists(BookingId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var BookingMap = mapper.Map<Booking>(updateBooking);
            if (!bookingRepository.UpdateBooking(BookingMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating Booking");
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully updated");
        }
    }
}
