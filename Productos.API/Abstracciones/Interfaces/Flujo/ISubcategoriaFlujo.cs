using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface ISubCategoriaFlujo
    {
        Task<IEnumerable<SubCategoriaResponse>> Obtener();
        Task<SubCategoriaResponse> ObtenerId(Guid Id);
        Task<IEnumerable<SubCategoriaResponse>> ObtenerPorCategoria(Guid IdCategoria);
        Task<Guid> Agregar(SubCategoriaRequest subcategoria);
        Task<Guid> Editar(Guid Id, SubCategoriaRequest subcategoria);
        Task<Guid> Eliminar(Guid Id);
    }
}
