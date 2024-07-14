using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpringService.Api.Model.Dto;
using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Controllers
{
    [Route("api/category/")]
    [ApiController]
    public class CategoryController(ICategoryRepository categoryRepository,
                                    ILogger<CategoryController> logger,
                                    IMapper mapper) : Controller
    {
        private readonly ICategoryRepository categoryRepository = categoryRepository;
        private readonly ILogger<CategoryController> logger = logger;
        private readonly IMapper mapper = mapper;


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCategories()
        {
            var Category = mapper.Map<List<CategoryDto>>(categoryRepository.FetchAll());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Category); 
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCategory(int id)
        {
            if (!categoryRepository.CategoryExists(id))
                return BadRequest();

            var Category = mapper.Map<List<CategoryDto>>(categoryRepository.GetCategory(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Category); 
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody] CategoryDto createCategory)
        {
            if (createCategory == null)
                return BadRequest(ModelState);

            var Category = categoryRepository.FetchAll()
                .Where(c => c.Name.Trim().ToUpper() == createCategory.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (Category != null)
            {
                ModelState.AddModelError("", "Category with chosen email already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var CategoryMap = mapper.Map<Category>(createCategory);

            if (!categoryRepository.CreateCategory(CategoryMap))
            {
                ModelState.AddModelError("", "An internal error occured");
                logger.LogInformation(message: ModelState.ToString());
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully created");
        }

        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCategoryPost(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!categoryRepository.CategoryExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!categoryRepository.DeleteCategory(id))
            {
                ModelState.AddModelError("", "An error occured while deleting Category");
            }

            return NoContent();
        }
        

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCategory(int CategoryId, [FromBody] CategoryDto updateCategory)
        {
            if (updateCategory == null)
                return BadRequest(ModelState);

            if (CategoryId != updateCategory.Id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return BadRequest(ModelState);
            }

            if (!categoryRepository.CategoryExists(CategoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var CategoryMap = mapper.Map<Category>(updateCategory);
            if (!categoryRepository.UpdateCategory(CategoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating Category");
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully updated");
        }
    }
}
