using System;
using RestauranteImplementacionAPI.Models;

namespace RestauranteImplementacionAPI.Services;

public class ClienteService
{
     private readonly HttpClient _httpClient;
 private ClienteService(HttpClient httpClient){
    _httpClient = httpClient;
 }

 public async Task<List<Cliente>> GetClientes()
 {
    return await _httpClient.GetFromJsonAsync<List<Cliente>>("api/Cliente");
 }

 public async Task<Cliente> GetClienteById(int id)
 {
    return await _httpClient.GetFromJsonAsync<Cliente>($"/api/Cliente/{id}");
 }
 public async Task<Cliente> CreateCliente(Cliente cliente)
 {
    var response = await _httpClient.PostAsJsonAsync("/api/Cliente", cliente);
    return await response.Content.ReadFromJsonAsync<Cliente>();
 }
 public async Task UpdateCliente(Cliente cliente)
 {
    await _httpClient.PutAsJsonAsync($"/api/Cliente/{cliente.Id}", cliente);
 }
 public async Task DeleteCliente(int id)
 {
    await _httpClient.DeleteAsync($"/api/Cliente/{id}");
 }

}
