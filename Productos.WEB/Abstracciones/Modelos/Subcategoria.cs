using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class SubCategoria
    {
        public Guid Id { get; set; }
        public Guid IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
    public class SubCategoriaBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres.")]
        public string Nombre { get; set; }
    }

    public class SubCategoriaRequest : SubCategoriaBase
    {
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public Guid IdCategoria { get; set; }
    }

    public class SubCategoriaResponse : SubCategoriaBase
    {
        public Guid Id { get; set; }

        public Guid IdCategoria { get; set; }

        public string NombreCategoria { get; set; }
    }
}