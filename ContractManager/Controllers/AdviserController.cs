using ContractManager.Data;
using ContractManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContractManager.Controllers
{
    public class AdviserController : Controller
    {
        private readonly AppDbContext _context;

        public AdviserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Adviser> objAdviserList = _context.Advisers;
            return View(objAdviserList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Adviser adviser)
        {
            if (ModelState.IsValid)
            {
                _context.Advisers.Add(adviser);
                _context.SaveChanges();
                TempData["success"] = "Adivser created successfully.";
                return RedirectToAction("Create");
            }

            return View();
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adviser = _context.Advisers.Find(id);

            if (adviser == null)
            {
                return NotFound();
            }

            return View(adviser);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Adviser adviser)
        {
            if (ModelState.IsValid)
            {
                _context.Advisers.Update(adviser);
                _context.SaveChanges();
                TempData["success"] = "Adviser edited successfully.";
                return RedirectToAction("Index");
            }

            return View(adviser);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adviser = _context.Advisers.Find(id);

            if (adviser == null)
            {
                return NotFound();
            }

            return View(adviser);
        }

        //POST
        [HttpPost]
        public IActionResult Delete(Adviser adviser)
        {
            _context.Advisers.Remove(adviser);
            _context.SaveChanges();
            TempData["success"] = "Adviser deleted successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            AdviserContractViewModel adviserContract = new()
            {
                Adviser = _context.Advisers.Find(id),
                ContractAdviser = _context.ContractAdvisers.Where(x => x.AdviserId == id)
            };        

            if(adviserContract.Adviser == null)
            {
                return NotFound();
            }

            return View(adviserContract);
        }
    }
}
