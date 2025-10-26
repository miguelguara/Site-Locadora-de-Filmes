using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Site_Locadora.Models;
using Site_Locadora.Models.DAO;

namespace Site_Locadora.Controllers
{
    public class AlugueisController : Controller
    {
        private readonly AluguelDAO _aluguelDao;
        private readonly ClienteDAO _clienteDao;
        private readonly FilmeDAO _filmeDao;

        public AlugueisController()
        {
            _aluguelDao = new AluguelDAO();
            _clienteDao = new ClienteDAO();
            _filmeDao = new FilmeDAO();
        }

      
        public IActionResult Index()
        {
            var alugueis = _aluguelDao.Listar();
            return View(alugueis);
        }

        public IActionResult Details(int id)
        {
            var aluguel = _aluguelDao.Buscar(id);
            if (aluguel == null) return NotFound();
            return View(aluguel);
        }

  
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_clienteDao.Listar(), "Id", "Nome");
            ViewBag.Filmes = new SelectList(_filmeDao.Listar(), "Id", "Titulo");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluguel aluguel)
        {
            //checa se o modelo eh valido
            if (ModelState.IsValid)
            {
                _aluguelDao.Inserir(aluguel);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(_clienteDao.Listar(), "Id", "Nome");
            ViewBag.Filmes = new SelectList(_filmeDao.Listar(), "Id", "Titulo");
            return View(aluguel);
        }

       
        public IActionResult Edit(int id)
        {
            var aluguel = _aluguelDao.Buscar(id);
            if (aluguel == null) return NotFound();
            ViewBag.Clientes = _clienteDao.Listar();
            ViewBag.Filmes = _filmeDao.Listar();
            return View(aluguel);
        }

        [HttpPost]
        public IActionResult Edit(Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                _aluguelDao.Atualizar(aluguel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _clienteDao.Listar();
            ViewBag.Filmes = _filmeDao.Listar();
            return View(aluguel);
        }

        public IActionResult Delete(int id)
        {
            var aluguel = _aluguelDao.Buscar(id);
            if (aluguel == null) return NotFound();
            return View(aluguel);
        }

     
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _aluguelDao.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
