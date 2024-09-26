using System;
using RestauranteImplementacionAPI.Models;

namespace RestauranteImplementacionAPI.Services;


public class CategoriaService
{
 private readonly HttpClient _httpClient;
 private CategoriaService(HttpClient httpClient){
    _httpClient = httpClient;
 }

 public async Task<List<Categoria>> GetCategorias()
 {
    return await _httpClient.GetFromJsonAsync<List<Categoria>>("api/Categoria");
 }

 public async Task<Categoria> GetCategoriaById(int id)
 {
    return await _httpClient.GetFromJsonAsync<Categoria>($"/api/Categoria/{id}");
 }
 public async Task<Categoria> CreateCategoria(Categoria categoria)
 {
    var response = await _httpClient.PostAsJsonAsync("/api/Categoria", categoria);
    return await response.Content.ReadFromJsonAsync<Categoria>();
 }
 public async Task UpdateCategoria(Categoria categoria)
 {
    await _httpClient.PutAsJsonAsync($"/api/Categoria/{categoria.id}", categoria);
 }
 public async Task DeleteCategoria(int id)
 {
    await _httpClient.DeleteAsync($"/api/Categoria/{id}");
 }
}
