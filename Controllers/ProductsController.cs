using E_Commerce_Last_Day_.Dtos.PostDtos;
using E_Commerce_Last_Day_.Repos.ProductRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Last_Day_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IproductRepo _repo;
        public ProductsController(IproductRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var p = _repo.GetAll();
            return Ok(p);
        }
        [HttpGet("{id}")]
        public IActionResult Getpproduct(int id)
        {
            var p = _repo.GetById(id);
            return Ok(p);
        }
        [HttpPost]
        public IActionResult AddProductOnly(Product_Post_Only_Dto p)
        {
            _repo.AddProductOnly(p);
            return Created();
        }
        [HttpPost("AddAll")]
        public IActionResult AddProductAll(Product_Dto p)
        {
            _repo.AddproductAll(p);
            return Created();
        }
        [HttpPut]
        public IActionResult updateProduct(Product_Dto product_Dto ,int id)
        {
            _repo.UpdateProductAll(product_Dto,id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
            return NoContent();
        }
    }
}
