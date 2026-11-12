using app_web_ventas.Data;
using app_web_ventas.Dtos;
using app_web_ventas.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace app_web_ventas.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task saveProduct(RegisterProductDto dto)
        {
            var parametros = new[]
            {
                new SqlParameter("@productname", dto.productname),
                new SqlParameter("@supplierid", dto.supplierid),
                new SqlParameter("@categoryid", dto.categoryid),
                new SqlParameter("@quantityperunit", dto.quantityperunit),
                new SqlParameter("@unitprice", dto.unitprice),
                new SqlParameter("@unitsinstock", dto.unitsinstock),
                new SqlParameter("@unitsonorder", dto.unitsonorder),
                new SqlParameter("@reorderlevel", dto.reorderlevel),
            };
            await _appDbContext.Database
                .ExecuteSqlRawAsync(
                "EXEC RegistrarProducto @productname,@supplierid,@categoryid,@quantityperunit,@unitprice,@unitsinstock,@unitsonorder,@reorderlevel", 
                parametros);
            
        }

        public async Task updateProduct(RegisterProductDto dto)
        {
            var parametros = new[]
            {
                new SqlParameter("@productid", dto.productid),
                new SqlParameter("@productname", dto.productname),
                new SqlParameter("@supplierid", dto.supplierid),
                new SqlParameter("@categoryid", dto.categoryid),
                new SqlParameter("@quantityperunit", dto.quantityperunit),
                new SqlParameter("@unitprice", dto.unitprice),
                new SqlParameter("@unitsinstock", dto.unitsinstock),
                new SqlParameter("@unitsonorder", dto.unitsonorder),
                new SqlParameter("@reorderlevel", dto.reorderlevel),
                new SqlParameter("@discontinued", dto.discontinued)
            };
            await _appDbContext.Database
                .ExecuteSqlRawAsync(
                "EXEC ActualizarProducto @productid,@productname," +
                "@supplierid,@categoryid,@quantityperunit,@unitprice," +
                "@unitsinstock,@unitsonorder,@reorderlevel,@discontinued",
                parametros);

        }

        public async Task<Product> getProductById(int id)
        {
            return await _appDbContext.Products.FindAsync(id);
        }

        public IQueryable<Product> getAllProducts()
        {
            return _appDbContext.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Supplier);
        }
    }
}
