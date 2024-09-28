using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;

namespace RestauranteImplementacionAPI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _categoriaService;
        public CategoriaController (CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public async Task<ActionResult> Index()
        {
            var categorias = await _categoriaService.GetCategorias();
            return View(categorias);
        }
        public async Task<ActionResult> Details(int id)
        {
            var categoria = await _categoriaService.GetCategoriaById(id);
            return View(categoria);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Create (Categoria categoria)
        {
            await _categoriaService.CreateCategoria(categoria);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.GetCategoriaById(id);
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult>Edit (int id, Categoria categoria)
        {
            await _categoriaService.UpdateCategoria(categoria);
            return RedirectToAction(nameof(Index));
        }
 public async Task<ActionResult>Delete(int id)
    {
        var categoria = await _categoriaService.GetCategoriaById(id);
        return View(categoria);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult>Delete (int id, Categoria categoria)
    {
        await _categoriaService.DeleteCategoria(id);
        return RedirectToAction(nameof(Index));
    }

    
    }
   

}
