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
app.MapPutRoutes();
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
            new() { Id = 1, IdRemetente = "213", DataPostagem = new DateTime(2025, 05, 22), EnderecoDestinatario = "Rua das Flores, 125", DataEntrega = new DateTime(2025, 05, 24), TamanhoPacote = 2.40, Preco=12.90, IdVeiculo = 2 },
            new() { Id = 2, IdRemetente = "144", DataPostagem = new DateTime(2025, 05, 26), EnderecoDestinatario = "Rua das Laranjeiras, 1440", DataEntrega = new DateTime(2025, 05, 29), TamanhoPacote = 3.65, Preco=14.50, IdVeiculo = 1 }
        };

        context.Pedidos.AddRange(pedidosIniciais);
        context.SaveChanges();
    }
}
