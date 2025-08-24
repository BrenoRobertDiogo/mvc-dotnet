using Microsoft.EntityFrameworkCore;
using Models.Clientes;
using mvc_dotnet.Contexts;

namespace Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<Cliente?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(int id);
    }

    public class ClienteRepository : IClienteRepository
    {
        private readonly LojaContext _context;

        public ClienteRepository(LojaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
            => await _context.Clientes.ToListAsync();

        public async Task<Cliente?> ObterPorIdAsync(int id)
            => await _context.Clientes.FindAsync(id);

        public async Task AdicionarAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }

}
