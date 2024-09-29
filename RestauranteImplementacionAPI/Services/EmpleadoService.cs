using System;
using RestauranteImplementacionAPI.Models;

namespace RestauranteImplementacionAPI.Services
{
    public class EmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
        public async Task<List<Empleado>> GetEmpleados()
        {
            return await _httpClient.GetFromJsonAsync<List<Empleado>>("api/Empleado");
        }


        public async Task<Empleado> GetEmpleadoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Empleado>($"api/Empleado/{id}");
        }

       
        public async Task<Empleado> CreateEmpleado(Empleado empleado)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Empleado", empleado);
            return await response.Content.ReadFromJsonAsync<Empleado>();
        }

      
        public async Task UpdateEmpleado(Empleado empleado)
        {
            await _httpClient.PutAsJsonAsync($"api/Empleado/{empleado.id}", empleado);
        }

        
        public async Task DeleteEmpleado(int id)
        {
            await _httpClient.DeleteAsync($"api/Empleado/{id}");
        }
    }
}
