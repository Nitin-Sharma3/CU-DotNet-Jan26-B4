using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Models;

public class SummaryController : Controller
{
    private readonly IHttpClientFactory _factory;

    public SummaryController(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _factory.CreateClient("NorthwindAPI");

        var summary = await client.GetFromJsonAsync<List<CategorySummaryDto>>
            ("api/products/summary");

        return View(summary);
    }
}