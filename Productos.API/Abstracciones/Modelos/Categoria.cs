using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class CategoriaBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres.")]
        public string Nombre { get; set; }
    }

    public class CategoriaRequest : CategoriaBase
    {
        // No necesita más campos para crear/editar
    }

    public class CategoriaResponse : CategoriaBase
    {
        public Guid Id { get; set; }
    }
}
