using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Producto
{
    public class EliminarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public ProductoResponse producto { get; set; } = default;

        public EliminarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }


        public async Task<ActionResult> OnGet(Guid? id)
        {
            if (id == Guid.Empty)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerId");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };
            producto = JsonSerializer.Deserialize<ProductoResponse>(resultado, opciones);

            return Page();
        }

        public async Task<ActionResult> OnPost(Guid? id) {
            if (id == Guid.Empty)
                return NotFound();
            if (!ModelState.IsValid)
                return Page();

                string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "Eliminar");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./index");

        }
    }
}
