using System;
using System.ComponentModel.DataAnnotations;


namespace RestauranteImplementacionAPI.Models
{
    public class Puesto
    {

        public int id { get; set; }
        [Required(ErrorMessage = "El nombre del puesto es obligatoria.")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "El nombre del puesto es obligatoria.")]

        public string Descripcion { get; set; }


    }
}