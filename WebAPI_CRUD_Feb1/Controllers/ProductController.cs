using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CRUD_Feb1.Models;
using WebAPI_CRUD_Feb1.Models.Repository;

namespace WebAPI_CRUD_Feb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IDataRepository<Product> _repository;

        public ProductController(IDataRepository<Product> repository)
        {
            _repository = repository;
        }
        //API VERBS=>GET(select),POST(insert),PUT(update),DELETE(delete)
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<ActionResult> Get()
        {
            var products = _repository.GetAll();
            if (products.Count() == 0)
            {
                return NotFound("No Product is there");
            }
            else
            {
                return Ok(products);
            }
        }
        
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product=_repository.GetById(id);
            if(product == null)
            {
                return NotFound("No product exist of given id");
            }
            else
            {
                return Ok(product);
            }
        }
        [HttpGet]
        [Route("SearchProductByName/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var products = _repository.GetByName(name);
            if (products.Count() == 0)
            {
                return NotFound("No Product Found by name");
            }
            else
            {
                return Ok(products);
            }
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> InsertProduct(Product obj)
        {
            string message;
            message = _repository.Add(obj);
            if(message== "Insert Success")
            {
                return Ok(message);
            }
            else
            {
                return BadRequest(message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product_to_Del=_repository.GetById(id);
            if(product_to_Del == null)
            {
                return NotFound("Can not delete/Not exist");
            }
            else
            {
                bool success=_repository.Remove(product_to_Del);
                if(success)
                {
                    return Ok("Delete Success");
                }
                else
                {
                    return BadRequest("Delete Failure");
                }
            }
        }
        [HttpPut]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id,Product obj_new)
        {
            var obj_old = _repository.GetById(id);
            if(obj_old==null)
            {
                return NotFound("No product to update");
            }
            else
            {
                bool success=_repository.Update(obj_old,obj_new);
                if(success)
                {
                    return Ok("Update Success");
                }
                else
                {
                    return BadRequest("Update Failure");
                }
            }
        }
    }
}
