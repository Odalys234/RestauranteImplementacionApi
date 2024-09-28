using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RestauranteImplementacionAPI.Controllers
{
    public class PlatilloController : Controller
    {
        private readonly PlatilloService _platilloService;

        public PlatilloController(PlatilloService platilloService)
        {
            _platilloService = platilloService;
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

      
        public ActionResult Create()
        {
            return View();
        }

       
      [HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Create(Platillo platillo)
{
    // Aquí no se maneja la subida de archivos, solo se espera que `platillo.imagen` contenga la URL de la imagen
    if (string.IsNullOrEmpty(platillo.imagen))
    {
        ModelState.AddModelError("imagen", "Debe proporcionar una URL de imagen válida.");
        return View(platillo);
    }

    // Llama al servicio para crear el platillo
    await _platilloService.CreatePlatillo(platillo);
    return RedirectToAction(nameof(Index));
}
  public async Task<ActionResult> Edit(int id)
        {
            var platillo = await _platilloService.GetPlatilloById(id);
            return View(platillo);
        }
      [HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Edit(int id, Platillo platillo)
{
    
    if (string.IsNullOrEmpty(platillo.imagen))
    {
        ModelState.AddModelError("imagen", "Debe proporcionar una URL de imagen válida.");
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
