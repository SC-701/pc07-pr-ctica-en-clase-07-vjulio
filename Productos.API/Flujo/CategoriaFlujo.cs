using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class CategoriaFlujo : ICategoriaFlujo
    {
        private readonly ICategoriaDA categoriaDA;


        public CategoriaFlujo(ICategoriaDA categoriaDA)
        {
            this.categoriaDA = categoriaDA;
   
        }

        public Task<Guid> Agregar(CategoriaRequest categoria)
        {
            return categoriaDA.Agregar(categoria);
        }

        public Task<Guid> Editar(Guid Id, CategoriaRequest categoria)
        {
            return categoriaDA.Editar(Id, categoria);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return categoriaDA.Eliminar(Id);
        }

        public Task<IEnumerable<CategoriaResponse>> Obtener()
        {
            return categoriaDA.Obtener();
        }

        public async Task<CategoriaResponse> ObtenerId(Guid Id)
        {
            var categoria = await categoriaDA.ObtenerId(Id);

            // Aquí podrías meter lógica después
            return categoria;
        }
    }
}
