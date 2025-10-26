using Microsoft.AspNetCore.Mvc;
using Site_Locadora.Models;
using Site_Locadora.Models.DAO;
using Site_Locadora.Services;

namespace Site_Locadora.Controllers
{
    public class FilmesController : Controller
    {
        private readonly FilmeDAO _filmeDao;
        private readonly OmdbService _omdb;

        public FilmesController(OmdbService omdb)
        {
            _filmeDao = new FilmeDAO();
            _omdb = omdb;
        }

        // GET: /Filmes
        public IActionResult Index()
        {
            var filmes = _filmeDao.Listar();
            return View(filmes);
        }

        // GET: /Filmes/Details/5
        public IActionResult Details(int id)
        {
            var filme = _filmeDao.Buscar(id);
            if (filme == null) return NotFound();
            return View(filme);
        }

        // GET: /Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        //Aqui ele primneiro pega o filme pela api Omdb
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                ModelState.AddModelError("", "Digite o título do filme.");
                return View();
            }

            // Buscar na OMDb
            var filmeOmdb = await _omdb.GetFilmeByTitleAsync(titulo);

            if (filmeOmdb == null || string.IsNullOrEmpty(filmeOmdb.Titulo))
            {
                ModelState.AddModelError("", "Filme não encontrado na OMDb.");
                return View();
            }

            // Mostrar preview para o usuário confirmar
            return View("ConfirmCreate", filmeOmdb);
        }

        // POST: /Filmes/ConfirmCreate
        // Usuário confirma o filme, salvamos no banco
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmCreate(Filme filme)
        {
            if (ModelState.IsValid)
            {
                _filmeDao.Inserir(filme);
                return RedirectToAction(nameof(Index));
            }

            return View(filme);
        }

        // GET: /Filmes/Edit/5
        public IActionResult Edit(int id)
        {
            var filme = _filmeDao.Buscar(id);
            if (filme == null) return NotFound();
            return View(filme);
        }

        // POST: /Filmes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Filme filme)
        {
            if (ModelState.IsValid)
            {
                _filmeDao.Atualizar(filme);
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: /Filmes/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var filme = _filmeDao.Buscar(id);
            if (filme == null) return NotFound();
            return View(filme);
        }

        // POST: /Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _filmeDao.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
