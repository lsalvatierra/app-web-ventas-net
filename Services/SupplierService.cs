using app_web_ventas.Models;
using app_web_ventas.Repositories;

namespace app_web_ventas.Services
{
    public class SupplierService
    {
        private readonly SupplierRepository _supplierRepository;


        public SupplierService(SupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _supplierRepository.GetSuppliers();
        }
    }
}
