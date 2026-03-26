using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface ICategoriaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> ObtenerId(Guid Id);
        Task<IActionResult> Agregar(CategoriaRequest categoria);
        Task<IActionResult> Editar(Guid Id, CategoriaRequest categoria);
        Task<IActionResult> Eliminar(Guid Id);
    }
}