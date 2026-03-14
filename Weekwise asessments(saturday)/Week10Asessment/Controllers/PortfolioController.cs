using Microsoft.AspNetCore.Mvc;
using Week10Asessment.Models;

namespace Week10Asessment.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Assets> _assets = new List<Assets>(){
            new(){ Id=1, Name="Bitcoin", Amount=2000 },
            new(){ Id=2, Name="Dogecoin", Amount=4000 },
            new(){ Id=3, Name="NiftyFifty", Amount=9000 },
        };

        public IActionResult Index()
        {
            return View(_assets);
        }

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = _assets.FirstOrDefault(a => a.Id == id);
            return View(asset);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Assets asset)
        {
            asset.Id = _assets.Max(a => a.Id) + 1;
            _assets.Add(asset);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var asset = _assets.FirstOrDefault(a => a.Id == id);
            return View(asset);
        }

        [HttpPost]
        public IActionResult Delete(int id, Assets asset)
        {
            var data = _assets.FirstOrDefault(a => a.Id == id);

            if (data != null)
            {
                _assets.Remove(data);
                TempData["Message"] = "Asset deleted successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}