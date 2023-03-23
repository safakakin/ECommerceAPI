using ECommerceAPI.Application.Repositories.ProductRepository;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }


        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id=Guid.NewGuid(), Name="Product 1",Price=100,CreationDate=DateTime.UtcNow, Stock=10},
            //    new() {Id=Guid.NewGuid(), Name="Product 2",Price=200,CreationDate=DateTime.UtcNow, Stock=20},
            //    new() {Id=Guid.NewGuid(), Name="Product 3",Price=300,CreationDate=DateTime.UtcNow, Stock=30},
            //});
            //await _productWriteRepository.SaveAsync();
            Product p   =  await _productReadRepository.GetByIdAsync("398623b2-ad4c-4652-9d5f-cb51ee555f9f");
            p.Name = "Ahmet";
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            Product product=await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
