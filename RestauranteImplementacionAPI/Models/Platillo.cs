using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models
{
    public class Platillo
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre del platillo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del platillo no puede tener más de 100 caracteres.")]
        public string nombrePlatillo { get; set; }

        [Required(ErrorMessage = "La URL de la imagen es obligatoria.")]
        [Url(ErrorMessage = "El formato de la URL de la imagen no es válido.")]
        public string imagen { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "El ID de la categoría es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la categoría debe ser un número mayor que 0.")]
        public int categoriaId { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
        public string descripcion { get; set; }
        
    }
}
