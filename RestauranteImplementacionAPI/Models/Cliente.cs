using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models;

 public class Cliente
    {
        
        public int id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede pasar de 50 caracteres.")]
        public string nombre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El apellido no puede pasar de 50 caracteres")]
        public string apellido { get; set; }
        [Required]
        [StringLength(8, ErrorMessage ="El numero telefono no puede tener mas de 8 caracteres")]
        public int  telefono { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="El formato Email no es valido")]
        public string email { get; set; }

       
    }
