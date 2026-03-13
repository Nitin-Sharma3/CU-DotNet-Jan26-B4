using Microsoft.AspNetCore.Mvc;
using TheCorporatePulsePortal.Models;

namespace TheCorporatePulsePortal.Controllers
{
    public class CompanyController : Controller
    {
        List<ItEmployee> emp = new List<ItEmployee>()
        {
            new ItEmployee(){ EmpId=1, Jobrole="Analyst", Name="Nitin", Salary=50000,active=true},
            new ItEmployee(){ EmpId=2, Jobrole="Developer", Name="Ayush", Salary=40000,active=true},
            new ItEmployee(){ EmpId=3, Jobrole="DRS Tracker", Name="Aditya", Salary=55000,active=true},
            new ItEmployee(){ EmpId=4, Jobrole="CodeChef", Name="Aniket", Salary=60000,active=true},
            new ItEmployee(){ EmpId=5, Jobrole="Programmer Analyst", Name="Lovely", Salary=80000,active=false}
        };
        string DailyAnnouncement = "The Aim for today is maximum efficiency. All the best!";
        public IActionResult Index()
        {
            TempData["data"]=emp;
            ViewBag.DailyAnnouncement = DailyAnnouncement;
            return View();
        }
    }
}
