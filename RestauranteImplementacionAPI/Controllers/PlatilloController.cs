using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RestauranteImplementacionAPI.Controllers
{
    [Authorize]
    public class PlatilloController : Controller
    {
        private readonly PlatilloService _platilloService;
        private readonly CategoriaService _categoriaService; // Servicio para gestionar categorías

        public PlatilloController(PlatilloService platilloService, CategoriaService categoriaService)
        {
            _platilloService = platilloService;
            _categoriaService = categoriaService;
        }

        public async Task<ActionResult> Index()
        {
            var platillos = await _platilloService.GetPlatillos();
            return View(platillos);
        }

        public async Task<ActionResult> Details(int id)
        {
            var platillo = await _platilloService.GetPlatilloById(id);
            return View(platillo);
        }

        public async Task<ActionResult> Create()
        {
            var categorias = await _categoriaService.GetCategorias(); // Cargar categorías
            ViewBag.Categorias = categorias; // Pasar categorías a la vista
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Platillo platillo)
        {
            if (string.IsNullOrEmpty(platillo.imagen))
            {
                ModelState.AddModelError("imagen", "Debe proporcionar una URL de imagen válida.");

                // Cargar categorías si hay error
                var categorias = await _categoriaService.GetCategorias();
                ViewBag.Categorias = categorias;

                return View(platillo);
            }

            // Llama al servicio para crear el platillo
            await _platilloService.CreatePlatillo(platillo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var platillo = await _platilloService.GetPlatilloById(id);
            var categorias = await _categoriaService.GetCategorias(); // Cargar categorías
            ViewBag.Categorias = categorias; // Pasar categorías a la vista
            return View(platillo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Platillo platillo)
        {
            if (string.IsNullOrEmpty(platillo.imagen))
            {
                ModelState.AddModelError("imagen", "Debe proporcionar una URL de imagen válida.");

                // Cargar categorías si hay error
                var categorias = await _categoriaService.GetCategorias();
                ViewBag.Categorias = categorias;

                return View(platillo);
            }

            await _platilloService.UpdatePlatillo(platillo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var platillo = await _platilloService.GetPlatilloById(id);
            return View(platillo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Platillo platillo)
        {
            await _platilloService.DeletePlatillo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
