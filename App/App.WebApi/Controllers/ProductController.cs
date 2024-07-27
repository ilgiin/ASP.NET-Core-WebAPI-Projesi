using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static private readonly List<Product> _products = new();

        [HttpGet]
        public IEnumerable<Product> GetList()
        {
            return _products;
        }

        [HttpGet("{id}")]
        public Product? GetProduct(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        [HttpPost]
        public void AddProduct(string name, decimal price, string category)
        {
            var item = new Product
            {
                Id = _products.Count + 1,
                Name = name,
                Price = price,
                Category = category
            };
            _products.Add(item);
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, string name, decimal price, string category)
        {
            var index = _products.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return;
            }
            _products[index].Name = name;
            _products[index].Price = price;
            _products[index].Category = category;
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var index = _products.FindIndex(x => x.Id == id);
          
            if (index == -1)
            {
                return;
            }
            _products.RemoveAt(index);
        }
    }
}