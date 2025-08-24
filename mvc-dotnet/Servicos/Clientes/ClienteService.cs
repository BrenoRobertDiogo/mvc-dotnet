using Models.Clientes;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Clientes
{

    

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
            => await _repository.ObterTodosAsync();

        public async Task<Cliente?> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id) ?? new Cliente();
        }

        public async Task AdicionarAsync(Cliente cliente)
            => await _repository.AdicionarAsync(cliente);

        public async Task AtualizarAsync(Cliente cliente)
            => await _repository.AtualizarAsync(cliente);

        public async Task RemoverAsync(int id)
            => await _repository.RemoverAsync(id);
    }
}
