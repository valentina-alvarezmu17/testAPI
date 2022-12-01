using TestFacturaApi.Models;

namespace TestFacturaApi.Services.Contract
{
    public interface IFactura
    {
        Task<List<Factura>> GetList();
        Task <Factura> Get(int idFactura);
        Task<Factura> Add(Factura model);
        Task<Factura> Update(Factura model);
        Task <bool> Delete(Factura model);
    }
}
