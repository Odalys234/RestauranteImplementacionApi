using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;
using System.Threading.Tasks;

namespace RestauranteImplementacionAPI.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

    
        public async Task<ActionResult> Index()
        {
            var reservas = await _reservaService.GetReservas();
            return View(reservas);
        }

      
        public async Task<ActionResult> Details(int id)
        {
            var reserva = await _reservaService.GetReservaById(id);
            return View(reserva);
        }

       
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Reserva reserva)
        {
            await _reservaService.CreateReserva(reserva);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<ActionResult> Edit(int id)
        {
            var reserva = await _reservaService.GetReservaById(id);
            return View(reserva);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Reserva reserva)
        {
            await _reservaService.UpdateReserva(reserva);
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<ActionResult> Delete(int id)
        {
            var reserva = await _reservaService.GetReservaById(id);
            return View(reserva);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Reserva reserva)
        {
            await _reservaService.DeleteReserva(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
