using Microsoft.AspNetCore.Mvc;

namespace Week10Asessment.Controllers
{
    public class Marketcontroller : Controller
    {
        public IActionResult Index()
        {
            string marketstatus = "OPEN";
            string topgainer = "ButterPaper";
            double volume = 3500;
            ViewBag.Marketstatus = marketstatus;
            ViewData["topgainer"] = topgainer;
            ViewData["Volume"] = volume;
            return View();
        }
    }
}
