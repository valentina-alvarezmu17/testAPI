using TestFacturaApi.Models;
using TestFacturaApi.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace TestFacturaApi.Services.Implementation
{
    public class FacturaService : IFactura
    {

        private readonly test_facturasContext _dbContext;

        public FacturaService(test_facturasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Factura>> GetList()
        {
            try
            {
                List<Factura> facturasList = new List<Factura>();
                facturasList = await _dbContext.Facturas.Include(factura => factura.IdClienteNavigation).ToListAsync();
                return facturasList;
            }catch(Exception e)
            {
                throw e;
            }
        }


        public async Task<Factura> Get(int idFactura)
        {
            try
            {
                Factura? facturaFound = new Factura();
                facturaFound = await _dbContext.Facturas.Include(factura => factura.IdClienteNavigation)
                    .Where(e => e.IdCliente == idFactura)
                    .FirstOrDefaultAsync();
                return facturaFound;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Factura> Add(Factura model)
        {
            try
            {
                _dbContext.Facturas.Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Factura> Update(Factura model)
        {
            try
            {
                _dbContext.Facturas.Update(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(Factura model)
        {
            try
            {
                _dbContext.Facturas.Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
