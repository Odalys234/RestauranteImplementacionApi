using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models
{
    public class Empleado
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos.")]
        public string Telefono { get; set; } 

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El ID del puesto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del puesto debe ser mayor que 0.")]
        public int PuestoId { get; set; }
    }
}
