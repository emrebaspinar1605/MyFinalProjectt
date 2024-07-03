using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = productService.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpGet("getproductbyid/{id}")]
        public IActionResult GetByID(int id)
        {
            var result = productService.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("getproductsbycategoryid/{categoryId}")]
        public IActionResult GetProductByCategory(int categoryId)
        {
            var result = productService.GetAllByCategoryId(categoryId);

            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("getproductsbyunitprice/{min}/{max}")]
        public IActionResult GetByUnitPrice(decimal max, decimal min)
        {
            var result = productService.GetByUnitPrice(min, max);

            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("getproductsDetail")]
        public IActionResult GetProductDetails()
        {
            var result = productService.GetProductDetails();

            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(Product product)
        {
           
            var result = productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
