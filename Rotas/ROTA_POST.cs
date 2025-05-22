using APIFLASHMOBI.Models;

public static class Rota_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        app.MapPost("/pedidos", async (Pedido pedido, PedidosContext context) =>
        {
            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();
            return Results.Created($"/pedidos/{pedido.Id}", pedido);
        });
    }
}
