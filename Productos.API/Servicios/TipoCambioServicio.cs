using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Servicios
{
    public class TipoCambioServicio : ITipoCambioServicio
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TipoCambioServicio(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<decimal> ObtenerTipoCambioAsync()
        {
            var urlBase = _configuration["BancoCentralCR:UrlBase"];
            var token = _configuration["BancoCentralCR:BearerToken"];

            var fecha = DateTime.Now.ToString("yyyy/MM/dd");

            var url = $"{urlBase}?fechaInicio={fecha}&fechaFin={fecha}&idioma=ES";

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<TipoCambioResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var tipoCambio = data.datos[0]
                .indicadores[0]
                .series[0]
                .valorDatoPorPeriodo;

            return tipoCambio;
        }
    }
}
