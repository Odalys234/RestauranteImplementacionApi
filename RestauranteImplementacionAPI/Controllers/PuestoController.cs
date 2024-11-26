using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace RestauranteImplementacionAPI.Controllers
{
     [Authorize]
    public class PuestoController : Controller
    {
          private readonly PuestoService _puestoService;
        public PuestoController (PuestoService puestoService)
        {
            _puestoService = puestoService;
        }
        public async Task<ActionResult> Index()
        {
            var puestos = await _puestoService.GetPuestos();
            return View(puestos);
        }
        public async Task<ActionResult> Details(int id)
        {
            var puesto = await _puestoService.GetPuestoById(id);
            return View(puesto);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Create (Puesto puesto)
        {
            await _puestoService.CreatePuesto(puesto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Edit(int id)
        {
            var puesto = await _puestoService.GetPuestoById(id);
            return View(puesto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit (int id, Puesto Puesto)
        {
            await _puestoService.UpdatePuesto(Puesto);
            return RedirectToAction(nameof(Index));
        }
 public async Task<ActionResult>Delete(int id)
    {
        var puesto = await _puestoService.GetPuestoById(id);
        return View(puesto);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult>Delete (int id, Puesto puesto)
    {
        await _puestoService.DeletePuesto(id);
        return RedirectToAction(nameof(Index));
    }

    
    }
   
    
}
