using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models
{
    public class Cliente
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string apellido { get; set; }

         [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos numéricos.")]
        public string telefono { get; set; } 
        

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string email { get; set; }
    }
}
