using System;
using System.Collections.Generic;

#nullable disable

namespace WebInfinityNetCore.Models
{
    public partial class Producto
    {
        public Producto()
        {
            PedidoDetalles = new HashSet<PedidoDetalle>();
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string NombreDelPlato { get; set; }
        public decimal Precio { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? RegistroActivo { get; set; }

        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
