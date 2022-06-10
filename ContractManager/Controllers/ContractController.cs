using ContractManager.Data;
using ContractManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Controllers
{
    public class ContractController : Controller
    {
        private readonly AppDbContext _context;

        public ContractController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Contract> objContractList = _context.Contracts;
            return View(objContractList);
        }

        //GET
        public IActionResult Create()
        {
            var viewModel = new ContractForCreationViewModel
            {
                Advisers = _context.Advisers,
                Clients = _context.Clients,
                Contract = new(),
                SelectedAdviserIds = new()
            };
            return View(viewModel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContractForCreationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Contracts.Add(viewModel.Contract);
                _context.SaveChanges();
                var c = _context.Contracts.Single(x => x.RegistrationNumber == viewModel.Contract.RegistrationNumber);
                foreach (int adviserId in viewModel.SelectedAdviserIds)
                {
                    ContractAdviser contractAdviser = new()
                    {
                        AdviserId = adviserId,
                        ContractId = c.Id
                    };
                    _context.ContractAdvisers.Add(contractAdviser);
                }
                _context.SaveChanges();
                TempData["success"] = "Contract created successfully.";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = _context.Contracts.Find(id);

            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var contractAdvisers = _context.ContractAdvisers.Where(x => x.ContractId == id);
            foreach(var ca in contractAdvisers)
            {
                _context.ContractAdvisers.Remove(ca);
            }

            var contract = _context.Contracts.Find(id);
            if (contract != null)
            {
                _context.Contracts.Remove(contract);
            }

            _context.SaveChanges();
            TempData["success"] = "Contract deleted successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            AdviserContractViewModel contractDetails = new()
            {
                Contract = _context.Contracts.Find(id),
                ContractAdviser = _context.ContractAdvisers.Where(x => x.ContractId == id)
            };

            if (contractDetails.Contract == null)
            {
                return NotFound();
            }

            return View(contractDetails);
        }
    }
}
