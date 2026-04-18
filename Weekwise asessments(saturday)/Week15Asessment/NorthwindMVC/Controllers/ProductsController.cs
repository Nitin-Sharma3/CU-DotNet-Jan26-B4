using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Models;

public class ProductsController : Controller
{
    private readonly IHttpClientFactory _factory;

    public ProductsController(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<IActionResult> ByCategory(int id)
    {
        var client = _factory.CreateClient("NorthwindAPI");

        var products = await client.GetFromJsonAsync<List<ProductDto>>
            ($"api/products/by-category/{id}");

        return View(products);
    }
}