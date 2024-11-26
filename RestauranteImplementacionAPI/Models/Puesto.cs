using System.ComponentModel.DataAnnotations;

public class Platillo
{
   
    public int id { get; set; }
     [Required(ErrorMessage = "El id de platillo es obligatoria.")]
    public string nombrePlatillo { get; set; }
     [Required(ErrorMessage = "El nombre de platillo es obligatoria.")]
   
    
    public string imagen { get; set; } 
     [Required(ErrorMessage = "La url de la imagen es obligatoria.")]

    public decimal precio { get; set; }
     [Required(ErrorMessage = "El precio es obligatoria.")]

    public int categoriaId { get; set; }
     [Required(ErrorMessage = "La categoria Id obligatoria.")]

     public string descripcion { get; set; }
  
  
}
