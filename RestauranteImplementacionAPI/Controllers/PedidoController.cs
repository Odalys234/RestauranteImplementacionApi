using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RestauranteImplementacionAPI.Controllers
{
     [Authorize]
    public class PedidoController : Controller
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // Mostrar todos los pedidos
        public async Task<ActionResult> Index()
        {
            var pedidos = await _pedidoService.GetPedidos();
            return View(pedidos);
        }

        // Mostrar detalles de un pedido específico
        public async Task<ActionResult> Details(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);
            return View(pedido);
        }

        // Mostrar formulario para crear un nuevo pedido
        public ActionResult Create()
        {
            return View();
        }

        // Crear un nuevo pedido (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Pedido pedido)
        {
            await _pedidoService.CreatePedido(pedido);
            return RedirectToAction(nameof(Index));
        }

        // Mostrar formulario para editar un pedido existente
        public async Task<ActionResult> Edit(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);
            return View(pedido);
        }

        // Actualizar un pedido existente (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Pedido pedido)
        {
            await _pedidoService.UpdatePedido(pedido);
            return RedirectToAction(nameof(Index));
        }

        // Mostrar vista de confirmación para eliminar un pedido
        public async Task<ActionResult> Delete(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);
            return View(pedido);
        }

        // Eliminar un pedido (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Pedido pedido)
        {
            await _pedidoService.DeletePedido(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
