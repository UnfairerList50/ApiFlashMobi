using APIFLASHMOBI.Models;

public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        app.MapDelete("/pedidos/{id}", async (int id, PedidosContext context) =>
        {
            var pedido = await context.Pedidos.FindAsync(id);
            if (pedido is null) return Results.NotFound();

            context.Pedidos.Remove(pedido);
            await context.SaveChangesAsync();
            return Results.Ok();
        });
    }
}
