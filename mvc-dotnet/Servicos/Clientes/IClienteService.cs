using Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Clientes
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<Cliente?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(int id);
    }
}
