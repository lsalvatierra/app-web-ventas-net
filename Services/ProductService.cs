using app_web_ventas.Dtos;
using app_web_ventas.Models;
using app_web_ventas.Repositories;
using app_web_ventas.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace app_web_ventas.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task saveProduct(RegisterProductDto dto)
        {
            await _productRepository.saveProduct(dto);
        }
        public async Task updateProduct(RegisterProductDto dto)
        {
            await _productRepository.updateProduct(dto);
        }
        public async Task<RegisterProductDto> GetProductById(int id)
        {
            Product product = await _productRepository.getProductById(id);
            RegisterProductDto dto = new RegisterProductDto();
            dto.productid = product.Productid;
            dto.productname = product.Productname;
            dto.quantityperunit = product.Quantityperunit;
            dto.unitsinstock = (int)product.Unitsinstock;
            dto.unitsonorder = product.Unitsonorder;
            dto.unitprice = (float)product.Unitprice;
            dto.supplierid = (int)product.Supplierid;
            dto.categoryid = (int)product.Categoryid;
            dto.reorderlevel = (int)product.Reorderlevel;
            dto.discontinued = product.Discontinued;
            return dto;
        }

        public async Task<List<ProductListItemDto>> GetProducts()
        {
            return await _productRepository.getAllProducts()
                .OrderBy(p => p.Productid)
                .Select(p => new ProductListItemDto(
                    p.Productid,p.Productname,
                    p.Category!.Categoryname,
                    p.Supplier!.Companyname,
                    p.Quantityperunit,
                    p.Unitprice ?? 0f, 
                    p.Unitsinstock ?? 0, 
                    p.Discontinued))
                .ToListAsync();
        }

        public async Task<List<ProductListItemDto>> GetProductsWithFilters(
            ProductFilterVm productFilter)
        {
            var consulta = _productRepository.getAllProducts();
            if (productFilter.CategoryId.HasValue) 
                consulta = consulta.Where(p => p.Categoryid == 
                productFilter.CategoryId);

            if (productFilter.SupplierId.HasValue)
                consulta = consulta.Where(p => p.Supplierid ==
                productFilter.SupplierId);

            if (productFilter.MinPrice.HasValue)
                consulta = consulta.Where(p => (p.Unitprice ?? 0f) >=
                    productFilter.MinPrice.Value);

            if (productFilter.MaxPrice.HasValue)
                consulta = consulta.Where(p => (p.Unitprice ?? 0f) <=
                    productFilter.MaxPrice.Value);

            if (productFilter.OnlyAvailable)
                consulta = consulta.Where(p => (p.Unitsinstock ?? 0) > 0);

            if(productFilter.Discontinued.HasValue)
                consulta = consulta.Where(p => p.Discontinued 
                == productFilter.Discontinued.Value);

            return await consulta.OrderByDescending(p => p.Productid)
                .Select(p => new ProductListItemDto(
                    p.Productid, p.Productname,
                    p.Category!.Categoryname,
                    p.Supplier!.Companyname,
                    p.Quantityperunit,
                    p.Unitprice ?? 0f,
                    p.Unitsinstock ?? 0,
                    p.Discontinued))
                .ToListAsync();

        }

    }
}
