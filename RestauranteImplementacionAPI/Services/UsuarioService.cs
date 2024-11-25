using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RestauranteImplementacionAPI.Models;
using Microsoft.Extensions.Configuration;

namespace RestauranteImplementacionAPI.Services
{
    public class UsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> LoginAsync(Login login)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", login);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error en el login: {errorContent}");
                return false;
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Excepción durante el login: {ex.Message}");
            return false;
        }
    }
}

}
