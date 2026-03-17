using Day56_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day56_01.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> _loans = new List<Loan>(){
    new(){ Id=1, Amount=20000, BorrowerName="Himanshu", LenderName="Nitin", IsSettled=false},
    new(){ Id=2, Amount=15000, BorrowerName="Rahul", LenderName="Aman", IsSettled=true},
    new(){ Id=3, Amount=5000, BorrowerName="Sandeep", LenderName="Rohit", IsSettled=false},
    new(){ Id=4, Amount=12000, BorrowerName="Ankit", LenderName="Deepak", IsSettled=true},
    new(){ Id=5, Amount=8000, BorrowerName="Karan", LenderName="Vikas", IsSettled=false},
    new(){ Id=6, Amount=22000, BorrowerName="Pankaj", LenderName="Arjun", IsSettled=false},
    new(){ Id=7, Amount=10000, BorrowerName="Sumit", LenderName="Manish", IsSettled=true},
    new(){ Id=8, Amount=7000, BorrowerName="Harsh", LenderName="Yash", IsSettled=false},
    new(){ Id=9, Amount=18000, BorrowerName="Abhishek", LenderName="Rajat", IsSettled=true},
    new(){ Id=10, Amount=9500, BorrowerName="Shubham", LenderName="Varun", IsSettled=false}
};
        // GET: LoanController
        public ActionResult Index()
        {
            return View(_loans);
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan loan)
        {
            try
            {
                loan.Id = _loans.Max(x => x.Id) + 1; // new id generate
                _loans.Add(loan); // list me add

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            var loan = _loans.FirstOrDefault(x => x.Id == id);
            return View(loan);
            //return View();
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Loan loan)
        {
            var existing = _loans.FirstOrDefault(x=>x.Id==id);
            if (existing != null)
            {
                existing.Amount = loan.Amount;
                existing.BorrowerName = loan.BorrowerName;
                existing.LenderName = loan.LenderName;
                existing.IsSettled=loan.IsSettled;
            }
                return RedirectToAction(nameof(Index));
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            var loan = _loans.FirstOrDefault(x => x.Id == id);
            return View(loan);
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var existingLoan = _loans.FirstOrDefault(x => x.Id == id);

            if (existingLoan != null)
            {
                _loans.Remove(existingLoan);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
