using System;

namespace RestauranteImplementacionAPI.Models;

public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int PuestoId { get; set; }
    }
