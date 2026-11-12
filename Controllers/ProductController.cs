using app_web_ventas.Dtos;
using app_web_ventas.Models;
using app_web_ventas.Services;
using app_web_ventas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app_web_ventas.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly SupplierService _supplierService;

        public ProductController(ProductService productService,
            CategoryService categoryService,
            SupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetCategories();
            ViewBag.Suppliers = await _supplierService.GetSuppliers();
            return View(new RegisterProductDto());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _categoryService.GetCategories();
            ViewBag.Suppliers = await _supplierService.GetSuppliers();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.saveProduct(dto);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await _categoryService.GetCategories();
            ViewBag.Suppliers = await _supplierService.GetSuppliers();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegisterProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.updateProduct(dto);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await _categoryService.GetCategories();
            ViewBag.Suppliers = await _supplierService.GetSuppliers();
            return View(dto);
        }

        //Product/Consultas?CategoryId=1&SupplierId=9..
        [HttpGet]
        public async Task<IActionResult> Consultas(
            [FromQuery] ProductFilterVm filters)
        {
            var products = await _productService
                .GetProductsWithFilters(filters);
            ViewBag.Filters = filters;
            var categories = await _categoryService.GetCategories();
            ViewBag.Categories = categories.Select(c =>
            new SelectListItem
            {
                Value = c.Categoryid.ToString(),
                Text = c.Categoryname
            });
            var suppliers = await _supplierService.GetSuppliers();
            ViewBag.Suppliers = suppliers.Select(c =>
            new SelectListItem
           {
               Value = c.Supplierid.ToString(),
               Text = c.Companyname
           });
            return View(products);
        }

    }
}
