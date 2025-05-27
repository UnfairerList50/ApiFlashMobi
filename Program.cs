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

app.MapGet("/", () => "API de pedidos de frete FlashMobi");
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
            new() { Id = 1, IdRemetente = 213, DataPostagem = new DateTime(2025, 05, 22), NomeEndereco = "Rua das Flores", NumeroEndereco = 125, Cep = 80010000, DataEntrega = new DateTime(2025, 05, 24), StatusEntrega = "Entregue", Preco = 12.90, IdVeiculo = 2 },
            new() { Id = 2, IdRemetente = 144, DataPostagem = new DateTime(2025, 05, 26), NomeEndereco = "Rua das Laranjeiras", NumeroEndereco = 1440, Cep = 80020000, DataEntrega = new DateTime(2025, 05, 29), StatusEntrega = "Em trânsito", Preco = 14.50, IdVeiculo = 1 },
            new() { Id = 3, IdRemetente = 321, DataPostagem = new DateTime(2025, 05, 20), NomeEndereco = "Avenida Brasil", NumeroEndereco = 500, Cep = 80030000, DataEntrega = new DateTime(2025, 05, 23), StatusEntrega = "Entregue", Preco = 18.75, IdVeiculo = 3 },
            new() { Id = 4, IdRemetente = 555, DataPostagem = new DateTime(2025, 05, 25), NomeEndereco = "Rua do Sol", NumeroEndereco = 77, Cep = 80040000, DataEntrega = new DateTime(2025, 05, 28), StatusEntrega = "Aguardando postagem", Preco = 10.00, IdVeiculo = 2 },
            new() { Id = 5, IdRemetente = 789, DataPostagem = new DateTime(2025, 05, 27), NomeEndereco = "Praça Osório", NumeroEndereco = 10, Cep = 80050000, DataEntrega = new DateTime(2025, 05, 30), StatusEntrega = "Em trânsito", Preco = 22.30, IdVeiculo = 1 },
            new() { Id = 6, IdRemetente = 888, DataPostagem = new DateTime(2025, 05, 21), NomeEndereco = "Rua das Andorinhas", NumeroEndereco = 300, Cep = 80060000, DataEntrega = new DateTime(2025, 05, 25), StatusEntrega = "Entregue", Preco = 16.40, IdVeiculo = 3 },
            new() { Id = 7, IdRemetente = 101, DataPostagem = new DateTime(2025, 05, 23), NomeEndereco = "Rua do Porto", NumeroEndereco = 45, Cep = 80070000, DataEntrega = new DateTime(2025, 05, 27), StatusEntrega = "Aguardando postagem", Preco = 19.90, IdVeiculo = 2 },
            new() { Id = 8, IdRemetente = 202, DataPostagem = new DateTime(2025, 05, 24), NomeEndereco = "Alameda das Palmeiras", NumeroEndereco = 900, Cep = 80080000, DataEntrega = new DateTime(2025, 05, 28), StatusEntrega = "Em trânsito", Preco = 25.00, IdVeiculo = 1 },
            new() { Id = 9, IdRemetente = 303, DataPostagem = new DateTime(2025, 05, 25), NomeEndereco = "Rua do Artesão", NumeroEndereco = 12, Cep = 80090000, DataEntrega = new DateTime(2025, 05, 29), StatusEntrega = "Aguardando postagem", Preco = 13.75, IdVeiculo = 3 },
            new() { Id = 10, IdRemetente = 404, DataPostagem = new DateTime(2025, 05, 26), NomeEndereco = "Travessa das Oliveiras", NumeroEndereco = 88, Cep = 80100000, DataEntrega = new DateTime(2025, 05, 31), StatusEntrega = "Em trânsito", Preco = 17.60, IdVeiculo = 2 }
        };

        context.Pedidos.AddRange(pedidosIniciais);
        context.SaveChanges();
    }
}
