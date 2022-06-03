using EcommerceServices.Services;
using EcommereCore.DataModel;
using EcommereCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        private new readonly List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;

        public bool Isvalidtype { get; private set; }
        public ProductController(IProductRepository productRepository , ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;

        }
        [HttpGet]
        public async Task<ActionResult<Product>> GetAllAsync()
        {
            var products = await productRepository.GetAll();

            return Ok(products.OrderByDescending(w => w.Id));

        }

        [HttpPost]
        public async Task<IActionResult> Create ( [FromForm]ProductDto productDto )
        {
            if (productDto.Image == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(productDto.Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (productDto.Image.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for poster is 1MB!");
            //check if typemovie is found
            var isValidmovietype = await categoryRepository.Isvalidtype(productDto.Categid);

            if (!isValidmovietype)
                return BadRequest("Invalid type movie ID!");
            if (productDto == null)
            {
                return BadRequest("try agin ,error");
            }
            var pro=productRepository.Create(productDto);
            return Ok(pro);

        }

    }
}
