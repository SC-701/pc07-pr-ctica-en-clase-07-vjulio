using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface ICategoriaDA
    {
        Task<IEnumerable<CategoriaResponse>> Obtener();
        Task<CategoriaResponse> ObtenerId(Guid Id);
        Task<Guid> Agregar(CategoriaRequest categoria);
        Task<Guid> Editar(Guid Id, CategoriaRequest categoria);
        Task<Guid> Eliminar(Guid Id);
    }
}