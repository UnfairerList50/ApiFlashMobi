using Microsoft.EntityFrameworkCore;

namespace APIFLASHMOBI.Models
{
    public class PedidosContext : DbContext
    {
        public PedidosContext(DbContextOptions<PedidosContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
