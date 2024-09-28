using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RestauranteImplementacionAPI.Models;

namespace RestauranteImplementacionAPI.Services
{
    public class PedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

      
        public async Task<List<Pedido>> GetPedidos()
        {
            return await _httpClient.GetFromJsonAsync<List<Pedido>>("api/Pedido");
        }

        
        public async Task<Pedido> GetPedidoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Pedido>($"/api/Pedido/{id}");
        }

    
        public async Task<Pedido> CreatePedido(Pedido pedido)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Pedido", pedido);
            return await response.Content.ReadFromJsonAsync<Pedido>();
        }

        
        public async Task UpdatePedido(Pedido pedido)
        {
            await _httpClient.PutAsJsonAsync($"/api/Pedido/{pedido.id}", pedido);
        }

        
        public async Task DeletePedido(int id)
        {
            await _httpClient.DeleteAsync($"/api/Pedido/{id}");
        }
    }
}
