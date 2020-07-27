﻿namespace Sistema.Api.Models.Almacen.Producto
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres, ni menos de {2} caracteres.")]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres.")]
        public string? Marca { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1}.")]
        public int Stock { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres.")]
        public string? Descripcion { get; set; }
    }
}
