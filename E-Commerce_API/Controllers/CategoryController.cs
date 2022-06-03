using EcommerceServices.Services;
using EcommereCore.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await categoryRepository.GetAll();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] CtegoryDto categoydto)
        {
            if(categoydto == null)
            { 
                return BadRequest("try again");
            }
            var Category_Added = await categoryRepository.add(categoydto);
            return Ok(Category_Added);

        }

    }
}
