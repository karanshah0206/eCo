using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return Ok(await _repo.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        return await _repo.GetProductByIdAsync(id);
    }
}
