using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface ISubCategoriaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> ObtenerId(Guid Id);
        Task<IActionResult> ObtenerPorCategoria(Guid IdCategoria);
        Task<IActionResult> Agregar(SubCategoriaRequest subcategoria);
        Task<IActionResult> Editar(Guid Id, SubCategoriaRequest subcategoria);
        Task<IActionResult> Eliminar(Guid Id);
    }
}
