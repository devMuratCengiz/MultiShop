using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetProductsWithCategoriesAsync();
            return View(values);
        }
        public async Task<IActionResult> Create()
        {

            var values = await _categoryService.GetAllCategoriesAsync();
                List<SelectListItem> categories = (from c in values
                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryId
                                                  }).ToList();
                ViewBag.Categories = categories;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(string id)
        {

            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categories = (from c in values
                                               select new SelectListItem
                                               {
                                                   Text = c.CategoryName,
                                                   Value = c.CategoryId
                                               }).ToList();
            ViewBag.Categories = categories;

            var productValues = await _productService.GetByIdProductAsync(id);
            return View(productValues);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index");
        }
    }
}
