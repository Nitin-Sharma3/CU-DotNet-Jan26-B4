using Microsoft.AspNetCore.Mvc;
using Week11AsessmentDI.Services;

namespace Week11AsessmentDI.Controllers
{
    public class ProductsController : Controller
    {
        private IPricingService _pricingService { get; set; }

        public ProductsController(IPricingService service)
        {
             _pricingService=service;
        }
        public IActionResult Index()
        {
            ViewBag.Price = 50;
            Console.WriteLine("Enter promocode:");
            string promocode = Console.ReadLine();
            ViewBag.DiscountedPrice = _pricingService.ApplyDiscount(ViewBag.Price,promocode);
            return View();
        }
    }
}
