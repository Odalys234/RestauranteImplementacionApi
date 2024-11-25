using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteImplementacionAPI.Models;

public class Empleado
    {
        public int id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="El nombre no puede tener mas de 50 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El apellido no puede tener mas de 50 caracteres" )]
        public string Apellido { get; set; }
        [Required]
        [StringLength(8, ErrorMessage ="El numero telefonico no puede tener mas de 8 caracteres")]
        public int Telefono { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="El formato Email no es valido")]
        public string Email { get; set; }

        public int PuestoId { get; set; }
    }
