using System;

namespace RestauranteImplementacionAPI.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string gmail { get; set; }
        public string detallesPedido { get; set; }
        public string telefono { get; set; }
        public DateTime fechaPedido { get; set; }
    }
}
