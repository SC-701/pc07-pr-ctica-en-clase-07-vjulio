using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flujo
{
    public class SubCategoriaFlujo : ISubCategoriaFlujo
    {
        private readonly ISubCategoriaDA subCategoriaDA;
 

        public SubCategoriaFlujo(ISubCategoriaDA subCategoriaDA)
        {
            this.subCategoriaDA = subCategoriaDA;

        }

        public Task<Guid> Agregar(SubCategoriaRequest subcategoria)
        {
            return subCategoriaDA.Agregar(subcategoria);
        }

        public Task<Guid> Editar(Guid Id, SubCategoriaRequest subcategoria)
        {
            return subCategoriaDA.Editar(Id, subcategoria);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return subCategoriaDA.Eliminar(Id);
        }

        public Task<IEnumerable<SubCategoriaResponse>> Obtener()
        {
            return subCategoriaDA.Obtener();
        }

        public async Task<SubCategoriaResponse> ObtenerId(Guid Id)
        {
            var subcategoria = await subCategoriaDA.ObtenerId(Id);

            // Aquí podrías agregar reglas si ocupás
            return subcategoria;
        }
    }
}
