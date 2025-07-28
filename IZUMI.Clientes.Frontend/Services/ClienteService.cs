using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IZUMI.Clientes.Shared.Models;

public class ClienteService
{
    private readonly HttpClient _http;

    public ClienteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Cliente>> ObtenerTodos() =>
        await _http.GetFromJsonAsync<List<Cliente>>("api/clientes");

    public async Task<Cliente> ObtenerPorId(int id) =>
        await _http.GetFromJsonAsync<Cliente>($"api/clientes/{id}");

    public async Task<string> Crear(Cliente cliente)
    {
        var res = await _http.PostAsJsonAsync("api/clientes", cliente);
        return await res.Content.ReadAsStringAsync();
    }

    public async Task<string> Actualizar(Cliente cliente)
    {
        var res = await _http.PutAsJsonAsync($"api/clientes/{cliente.Id}", cliente);
        return await res.Content.ReadAsStringAsync();
    }

    public async Task<string> Eliminar(int id)
    {
        var res = await _http.DeleteAsync($"api/clientes/{id}");
        return await res.Content.ReadAsStringAsync();
    }
}
