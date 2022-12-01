using TestFacturaApi.Models;
using TestFacturaApi.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace TestFacturaApi.Services.Implementation
{
    public class ClienteService : IClienteService
    {
        private readonly test_facturasContext _dbContext;

        public ClienteService(test_facturasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> GetList()
        {
            try
            {
                List<Cliente> clientlist = new List<Cliente>();

                clientlist = await _dbContext.Clientes.ToListAsync();

                return clientlist;
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
