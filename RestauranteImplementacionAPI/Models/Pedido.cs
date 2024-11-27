using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models
{
    public class Pedido
    {
        public int? id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido del cliente es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string gmail { get; set; }
        
        public string detallesPedido { get; set; }

        [Required(ErrorMessage = "El teléfono del cliente es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos.")]
        public string telefono { get; set; } 

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        public DateTime fechaPedido { get; set; }

       
    }
}
