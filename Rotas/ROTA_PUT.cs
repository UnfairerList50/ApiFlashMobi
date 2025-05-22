using Microsoft.EntityFrameworkCore;
using APIFLASHMOBI.Models;

public static class Rota_PUT
{
    public static void MapPutRoutes(this WebApplication app)
    {
        app.MapPut("/pedidos/{id}", async (int id, Pedido input, PedidosContext context) =>
        {
            var pedido = await context.Pedidos.FindAsync(id);
            if (pedido is null) return Results.NotFound();

            pedido.Id = input.Id;
            pedido.IdRemetente = input.IdRemetente;
            pedido.DataPostagem = input.DataPostagem;
            pedido.EnderecoDestinatario = input.EnderecoDestinatario;
            pedido.DataEntrega = input.DataEntrega;
            pedido.TamanhoPacote = input.TamanhoPacote;
            pedido.Preco = input.Preco;
            pedido.IdVeiculo = input.IdVeiculo;

            await context.SaveChangesAsync();
            return Results.Ok(pedido);
        });
    }
}
