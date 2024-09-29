using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;

namespace RestauranteImplementacionAPI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        
        public async Task<ActionResult> Index()
        {
            var empleados = await _empleadoService.GetEmpleados();
            return View(empleados);
        }

                public async Task<ActionResult> Details(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound(); 
            }
            return View(empleado);
        }

        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Empleado empleado)
        {
            await _empleadoService.CreateEmpleado(empleado);
            return RedirectToAction(nameof(Index));
        }

      
        public async Task<ActionResult> Edit(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoById(id);
            return View(empleado);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Empleado empleado)
        {
            await _empleadoService.UpdateEmpleado(empleado);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound(); 
            }
            return View(empleado);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Empleado empleado)
        {
            await _empleadoService.DeleteEmpleado(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
