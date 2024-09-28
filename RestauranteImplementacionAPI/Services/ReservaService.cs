using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using RestauranteImplementacionAPI.Models;

namespace RestauranteImplementacionAPI.Services
{
    public class ReservaService
    {
        private readonly HttpClient _httpClient;

        public ReservaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<List<Reserva>> GetReservas()
        {
            return await _httpClient.GetFromJsonAsync<List<Reserva>>("api/Reserva");
        }

        
        public async Task<Reserva> GetReservaById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Reserva>($"/api/Reserva/{id}");
        }

       
        public async Task<Reserva> CreateReserva(Reserva reserva)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Reserva", reserva);
            return await response.Content.ReadFromJsonAsync<Reserva>();
        }

   
        public async Task UpdateReserva(Reserva reserva)
        {
            await _httpClient.PutAsJsonAsync($"/api/Reserva/{reserva.id}", reserva);
        }

     
        public async Task DeleteReserva(int id)
        {
            await _httpClient.DeleteAsync($"/api/Reserva/{id}");
        }
    }
}
