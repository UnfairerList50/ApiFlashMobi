using Microsoft.EntityFrameworkCore;
using APIFLASHMOBI.Models;
using APIFLASHMOBI.Rotas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PedidosContext>(options =>
    options.UseSqlite("Data Source=pedidos.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

app.MapGetRoutes();
app.MapPostRoutes();
app.MapDeleteRoutes();

GerarNovosPedidos(app);

app.Run();

void GerarNovosPedidos(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<PedidosContext>();

    context.Database.Migrate();

    if (!context.Pedidos.Any())
    {
        var pedidosIniciais = new List<Pedido>
        {
            new() { Id = 1, IdRemetente = 213, DataPostagem = new DateTime(2025, 05, 22), EnderecoDestinatario = "Rua das Flores, 125", DataEntrega = new DateTime(2025, 05, 24), StatusEntrega = "Entregue", Preco=12.90, IdVeiculo = 2 },
            new() { Id = 2, IdRemetente = 144, DataPostagem = new DateTime(2025, 05, 26), EnderecoDestinatario = "Rua das Laranjeiras, 1440", DataEntrega = new DateTime(2025, 05, 29), StatusEntrega = "Em trânsito", Preco=14.50, IdVeiculo = 1 },
            new() { Id = 3, IdRemetente = 321, DataPostagem = new DateTime(2025, 05, 20), EnderecoDestinatario = "Avenida Brasil, 500", DataEntrega = new DateTime(2025, 05, 23), StatusEntrega = "Entregue", Preco=18.75, IdVeiculo = 3 },
            new() { Id = 4, IdRemetente = 555, DataPostagem = new DateTime(2025, 05, 25), EnderecoDestinatario = "Rua do Sol, 77", DataEntrega = new DateTime(2025, 05, 28), StatusEntrega = "Aguardando postagem", Preco=10.00, IdVeiculo = 2 },
            new() { Id = 5, IdRemetente = 789, DataPostagem = new DateTime(2025, 05, 27), EnderecoDestinatario = "Praça Osório, 10", DataEntrega = new DateTime(2025, 05, 30), StatusEntrega = "Em trânsito", Preco=22.30, IdVeiculo = 1 },
            new() { Id = 6, IdRemetente = 888, DataPostagem = new DateTime(2025, 05, 21), EnderecoDestinatario = "Rua das Andorinhas, 300", DataEntrega = new DateTime(2025, 05, 25), StatusEntrega = "Entregue", Preco=16.40, IdVeiculo = 3 },
            new() { Id = 7, IdRemetente = 101, DataPostagem = new DateTime(2025, 05, 23), EnderecoDestinatario = "Rua do Porto, 45", DataEntrega = new DateTime(2025, 05, 27), StatusEntrega = "Aguardando postagem", Preco=19.90, IdVeiculo = 2 },
            new() { Id = 8, IdRemetente = 202, DataPostagem = new DateTime(2025, 05, 24), EnderecoDestinatario = "Alameda das Palmeiras, 900", DataEntrega = new DateTime(2025, 05, 28), StatusEntrega = "Em trânsito", Preco=25.00, IdVeiculo = 1 },
            new() { Id = 9, IdRemetente = 303, DataPostagem = new DateTime(2025, 05, 25), EnderecoDestinatario = "Rua do Artesão, 12", DataEntrega = new DateTime(2025, 05, 29), StatusEntrega = "Aguardando postagem", Preco=13.75, IdVeiculo = 3 },
            new() { Id = 10, IdRemetente = 404, DataPostagem = new DateTime(2025, 05, 26), EnderecoDestinatario = "Travessa das Oliveiras, 88", DataEntrega = new DateTime(2025, 05, 31), StatusEntrega = "Em trânsito", Preco=17.60, IdVeiculo = 2 }
        };

        context.Pedidos.AddRange(pedidosIniciais);
        context.SaveChanges();
    }
}
