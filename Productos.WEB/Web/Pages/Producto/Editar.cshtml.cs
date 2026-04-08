    using Abstracciones.Modelos;
    using Abstracciones.Reglas;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text.Json;

    namespace Web.Pages.Producto
    {
        public class EditarModel : PageModel
        {
            private readonly IConfiguracion _configuracion;

            public EditarModel(IConfiguracion configuracion)
            {
                _configuracion = configuracion;
            }

            [BindProperty]
            public ProductoRequest productoRequest { get; set; }
        
        [BindProperty]
        public ProductoResponse productoResponse { get; set; }

        [BindProperty]
            public List<SelectListItem> subcategorias { get; set; }

            [BindProperty]
            public List<SelectListItem> categorias { get; set; }

            [BindProperty]
            public Guid subcategoriaseleccionada { get; set; }

            [BindProperty]
            public Guid categoriaseleccionada { get; set; }

            public async Task<ActionResult> OnGet(Guid? Id)
            {
            if (Id == Guid.Empty)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerId");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK) {
                await ObtenerCategorias();
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true };
                productoResponse = JsonSerializer.Deserialize<ProductoResponse>(resultado, opciones);
                if (productoResponse != null) { 
                    //categoriaseleccionada = productoResponse.SubCategoria
                }

                
            }

                return Page();
            }

            public async Task<ActionResult> OnPost() {
                if (!ModelState.IsValid)
                    return Page();
            producto.IdSubCategoria = subcategoriaseleccionada;
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "Agregar");
                var cliente = new HttpClient();
                var solicitud = new HttpRequestMessage(HttpMethod.Post, endpoint);
                var respuesta = await cliente.PostAsJsonAsync(endpoint, producto);
                respuesta.EnsureSuccessStatusCode();
                return RedirectToPage("./Index");
            }

            private async Task ObtenerCategorias() {
                string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerCategorias");
                var cliente = new HttpClient();
                var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

                var respuesta = await cliente.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true };
                var resultadodeserializado =JsonSerializer.Deserialize <List<Categoria>>(resultado,opciones);
                categorias = resultadodeserializado.Select(c =>
                new SelectListItem
                { 
                    Value = c.Id.ToString(),
                    Text = c.Nombre,
                }
                ).ToList();
            }

            private async Task<List<SubCategoria>> ObtenerSubCategoriasporCategoria(Guid categoriaId)
            {
                string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerSubCategoriasporCategoria");
                var cliente = new HttpClient();
                var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint,categoriaId));

                var respuesta = await cliente.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK) {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<List<SubCategoria>>(resultado, opciones);
            }
        
                return new List<SubCategoria>();
        
                
            
            }

            public async Task<JsonResult> OnGetObtenerSubCategoriasporCategoria(Guid categoriaId) {
                var subcategorias = await ObtenerSubCategoriasporCategoria(categoriaId);
                return new JsonResult(subcategorias);
            }
        }
    }
