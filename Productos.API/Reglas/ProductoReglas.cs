using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;

namespace Reglas
{
    public class ProductoReglas : IProductoReglas
    {
        private readonly ITipoCambioServicio _tipoCambioServicio;

        public ProductoReglas(ITipoCambioServicio tipoCambioServicio)
        {
            _tipoCambioServicio = tipoCambioServicio;
        }

        public async Task<decimal> CalcularPrecioUSD(decimal precioCRC)
        {
            var tipoCambio = await _tipoCambioServicio.ObtenerTipoCambioAsync();

            var precioUSD = precioCRC / tipoCambio;

            return Math.Round(precioUSD, 2);
        }
    }
}
