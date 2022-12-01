using TestFacturaApi.Models;

namespace TestFacturaApi.Services.Contract
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetList();
    }
}
