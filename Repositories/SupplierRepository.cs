using app_web_ventas.Data;
using app_web_ventas.Models;
using Microsoft.EntityFrameworkCore;

namespace app_web_ventas.Repositories
{
    public class SupplierRepository
    {
        private readonly AppDbContext _appDbContext;

        public SupplierRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _appDbContext.Suppliers.ToListAsync();
        }

    }
}
