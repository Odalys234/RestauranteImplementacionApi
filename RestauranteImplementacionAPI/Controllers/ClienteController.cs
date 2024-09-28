using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;

namespace RestauranteImplementacionAPI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        
        public async Task<ActionResult> Index()
        {
            var clientes = await _clienteService.GetClientes();
            return View(clientes);
        }

       
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            return View(cliente);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            await _clienteService.CreateCliente(cliente);
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Cliente cliente)
        {
            await _clienteService.UpdateCliente(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Cliente cliente)
        {
            await _clienteService.DeleteCliente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
