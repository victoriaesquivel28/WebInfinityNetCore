using System;
using System.Collections.Generic;

#nullable disable

namespace WebInfinityNetCore.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoDetalles = new HashSet<PedidoDetalle>();
        }

        public int Id { get; set; }
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? RegistroActivo { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
