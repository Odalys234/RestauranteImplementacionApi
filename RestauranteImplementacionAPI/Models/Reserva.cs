using System;

namespace RestauranteImplementacionAPI.Models;

public class Reserva
{
            public int id { get; set; }
        public int clienteId { get; set; } 
        public DateTime fechaReserva { get; set; }
        public TimeSpan horaReserva { get; set; }
        public int numeroPersonas { get; set; }
        public string mesaAsignada { get; set; }

}
