using System.Net.Http;
using System.Net.Http.Json;
using RestauranteImplementacionAPI.Models;

namespace RestauranteImplementacionAPI.Services;

public class PlatilloService
{
    private readonly HttpClient _httpClient;

    public PlatilloService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    
    public async Task<List<Platillo>> GetPlatillos()
    {
        return await _httpClient.GetFromJsonAsync<List<Platillo>>("api/Platillo");
    }

    
    public async Task<Platillo> GetPlatilloById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Platillo>($"/api/Platillo/{id}");
    }

public async Task<Platillo> CreatePlatillo(Platillo platillo)
{
    var response = await _httpClient.PostAsJsonAsync("/api/Platillo", platillo);

    if (response.IsSuccessStatusCode)
    {
        return await response.Content.ReadFromJsonAsync<Platillo>();
    }
    else
    {
        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception($"Error al crear el platillo: {response.StatusCode}. Detalles: {errorMessage}");
    }
}


   
    public async Task UpdatePlatillo(Platillo platillo)
    {
        await _httpClient.PutAsJsonAsync($"/api/Platillo/{platillo.id}", platillo);
    }


    public async Task DeletePlatillo(int id)
    {
        await _httpClient.DeleteAsync($"/api/Platillo/{id}");
    }
}
