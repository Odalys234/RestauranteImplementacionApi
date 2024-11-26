using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models
{
    public class Pedido
    {
        public int? id { get; set; }
          [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]

         public string apellido { get; set; }
         [Required(ErrorMessage = "El apellido del cliente es obligatorio.")]
        public string gmail { get; set; }
         
        public int telefono { get; set; }
         [Required(ErrorMessage = "El telefono del cliente es obligatorio.")]
        public DateTime fechaPedido { get; set; }
         [Required(ErrorMessage = "La fecha de pedido es obligatoria.")]
        public string detallesPedido { get; set; }
        
    }
}
