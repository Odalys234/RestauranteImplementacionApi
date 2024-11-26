using System;
using System.ComponentModel.DataAnnotations;


namespace RestauranteImplementacionAPI.Models
{
    public class Reserva
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = "El id del cliente es obligatorio.")]
        public int clienteId { get; set; }
        
        [Required(ErrorMessage = "La fecha de la reserva es obligatoria.")]
        public DateTime fechaReserva { get; set; }
        
        [Required(ErrorMessage = "La hora de la reserva es obligatoria.")]
        public TimeSpan horaReserva { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "El número de personas debe ser mayor a 0.")]
        public int numeroPersonas { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "El número de mesa debe ser mayor a 0.")]
        public int mesaAsignada { get; set; }
    }
}

