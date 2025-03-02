using ApiDispositivos.Models;
using Newtonsoft.Json;

namespace ApiDispositivos.Services
{
    public class DispositivoService
    {
        private readonly HttpClient _httpClient;

        public DispositivoService( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Dispositivo>> ObterDispositivoAsync(string name)
        {
            string url = "https://api.restful-api.dev/objects";

            var response = await    _httpClient.GetStringAsync(url);
            var dispositivos = JsonConvert.DeserializeObject<List<Dispositivo>>(response);

            var dispositivosFiltrados = dispositivos.Where(d => d.Name.StartsWith(name, System.StringComparison.OrdinalIgnoreCase)).ToList();

            return dispositivosFiltrados;
        }
    }
}
