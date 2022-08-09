using api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using share.Models;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        public IFood _food;

        public FoodsController(IFood food)
        {
            _food = food;
        }

        // GET api/foods
        [HttpGet]
        public async Task<dynamic> GetAll()
        {
            return await _food.GetAll();
        }

        //// GET api/foods
        //[HttpGet]
        //[Route("search")]
        //public async Task<dynamic> Search([FromQuery(Name = "keyword")] string keyword)
        //{
        //    return await _food.Search(keyword);
        //}

        // GET api/foods/3
        [HttpGet("{id}")]
        public async Task<dynamic> GetById(int id)
        {
            return await _food.GetById(id);
        }

        // POST api/foods
        [HttpPost]
        public async Task<dynamic> Add(FoodModel newFood)
        {
            return await _food.Add(newFood);
        }

        // PUT api/foods/3
        [HttpPut("{id}")]
        public async Task<dynamic> Update(IFormCollection formData, int id)
        {
            return await _food.Update(formData, id);
        }

        // DELETE api/foods/4
        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(int id)
        {
            return await _food.Delete(id);
        }
    }
}
