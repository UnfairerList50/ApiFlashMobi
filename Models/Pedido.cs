namespace APIFLASHMOBI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdRemetente { get; set; }
        public DateTime DataPostagem { get; set; }
        public string EnderecoDestinatario { get; set; }
        public DateTime DataEntrega { get; set; }
        public string StatusEntrega { get; set; }
        public double Preco { get; set; }
        public int IdVeiculo { get; set; }
        
    }
}