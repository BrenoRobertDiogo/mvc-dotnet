using Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Pedidos
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pendente";
        public decimal ValorTotal { get; set; }

        // Relacionamento: Pedido pertence a um Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento: Pedido tem vários itens
        public ICollection<PedidoProduto> Itens { get; set; } = [];
    }
}
