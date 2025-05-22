using Microsoft.EntityFrameworkCore;
using APIFLASHMOBI.Models;

namespace APIFLASHMOBI.Rotas
{
    public static class Rota_GET
    {
        public static void MapGetRoutes(this WebApplication app)
        {
            app.MapGet("/pedidos", async (PedidosContext context) =>
            {
                var pedidos = await context.Pedidos.ToListAsync();
                return Results.Ok(pedidos);
            });

            app.MapGet("/pedidos/{id}", async (int id, PedidosContext context) =>
            {
                var pedido = await context.Pedidos.FindAsync(id);
                return pedido is not null ? Results.Ok(pedido) : Results.NotFound();
            });
        }
    }
}
