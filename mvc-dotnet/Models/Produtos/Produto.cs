using Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Produtos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        // Relacionamento: Produto pode estar em vários itens de pedidos
        public ICollection<PedidoProduto> PedidoProduto { get; set; } = [];
    }
}
