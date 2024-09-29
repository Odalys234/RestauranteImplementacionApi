using System;
using RestauranteImplementacionAPI.Models;

namespace RestauranteImplementacionAPI.Services;

public class PuestoService
{
     private readonly HttpClient _httpClient;

        public PuestoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Puesto>> GetPuestos()
        {
            return await _httpClient.GetFromJsonAsync<List<Puesto>>("api/Puesto");
        }

        public async Task<Puesto> GetPuestoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Puesto>($"api/Puesto/{id}");
        }

        public async Task<Puesto> CreatePuesto(Puesto Puesto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Puesto", Puesto);
            return await response.Content.ReadFromJsonAsync<Puesto>();
        }

        public async Task UpdatePuesto(Puesto Puesto)
        {
            await _httpClient.PutAsJsonAsync($"api/Puesto/{Puesto.id}", Puesto);
        }

        public async Task DeletePuesto(int id)
        {
            await _httpClient.DeleteAsync($"api/Puesto/{id}");
        }
}
