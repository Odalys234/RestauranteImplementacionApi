using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models;


public class Categoria
{
     public int id { get; set; }
     [Required]
     [StringLength(50, ErrorMessage ="El nombre no puede tener mas de 50 caracteres ")]
        public string nombre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "La descripcion no puede tener mas de 50 caracteres.")]
        public string descripcion { get; set; }
}
