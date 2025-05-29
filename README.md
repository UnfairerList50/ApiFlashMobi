# ApiFlashMobi

Este projeto foi desenvolvido como parte de um exercício prático para aprendizado de desenvolvimento de APIs REST com .NET.

## Equipe
- Gabriel Anaya Brasílio da Rocha
- Jorge Fernando Kozloski de Aquino
- Juan Bernardo Ferreira
- Northon Henrique dos Santos

## Descrição

O ApiFlashMobi é uma API simples para gerenciamento de pedidos de frete. Ela permite cadastrar, consultar e remover pedidos, simulando um sistema de logística.

## Funcionalidades

- GET: Consulta de pedidos existentes (/pedidos)
- GET: Busca por pedido específico (/pedidos/{id})
- POST: Cadastro de pedidos de frete (/pedidos)
- DELETE: Remoção de pedidos (/pedidos/{id})

## Tecnologias utilizadas

- SQLite: banco de dados para armazenar os pedidos
- Entity Framework Core: simplifica a comunicação do .NET com o banco de dados

## Estrutura da entidade Pedido

```csharp
public class Pedido
{
        public int Id { get; set; }
        public int IdRemetente { get; set; }
        public DateTime DataPostagem { get; set; }
        public string NomeEndereco { get; set; }
        public int NumeroEndereco { get; set; }
        public long Cep { get; set; }
        public DateTime DataEntrega { get; set; }
        public string StatusEntrega { get; set; }
        public double Preco { get; set; }
        public int IdVeiculo { get; set; }
}
