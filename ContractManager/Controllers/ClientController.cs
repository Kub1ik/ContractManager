using ContractManager.Data;
using ContractManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ContractManager.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Client> objClientList = _context.Clients;
            return View(objClientList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                TempData["success"] = "Client created successfully.";
                return RedirectToAction("Create");
            }

            return View(client);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var client = _context.Clients.Find(id);

            if(client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
                TempData["success"] = "Client edited successfully.";
                return RedirectToAction("Index");
            }

            return View(client);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _context.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        //POST
        [HttpPost]
        public IActionResult Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
            TempData["success"] = "Client deleted successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            ClientContractViewModel clientContract = new()
            {
                Client = _context.Clients.Find(id),
                Contracts = _context.Contracts.Where(x => x.ClientId == id)
            };

            if(clientContract.Client == null)
            {
                return NotFound();
            }

            return View(clientContract);
        }
    }
}
