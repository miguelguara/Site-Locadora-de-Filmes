using Microsoft.AspNetCore.Mvc;
using Site_Locadora.Models;
using Site_Locadora.Models.DAO;

namespace Site_Locadora.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteDAO clienteDao = new ClienteDAO();


        public IActionResult Index()
        {
            var clientes = clienteDao.Listar();
            return View(clientes);
        }
  
        public IActionResult Details(int id)
        {
            var cliente = clienteDao.Buscar(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteDao.Inserir(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var cliente = clienteDao.Buscar(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteDao.Atualizar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            var cliente = clienteDao.Buscar(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            clienteDao.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
