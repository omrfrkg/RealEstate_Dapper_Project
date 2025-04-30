using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProducListWithCategory")]
        public async Task<IActionResult> ProducListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi!");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı!");
        }

        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmplooyeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmplooyeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmplooyeByTrueAsync(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmplooyeByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmplooyeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmplooyeByFalseAsync(id);
            return Ok(values);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İlan Başarıyla Eklendi");
        }

        [HttpGet("GetProductByProductID")]
        public async Task<IActionResult> GetProductByProductID(int id)
        {
            var values = await _productRepository.GetProductByProductID(id);
            return Ok(values);
        }

        [HttpGet("GetProductWithSearchList")]
        public async Task<IActionResult> GetProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.GetProductWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }

    }
}
