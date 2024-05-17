using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var productDTO = await _productService.GetByIdAsync(id);

            if (productDTO == null) return NotFound();

            return View(productDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            await _productService.CreateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productDTO = await _productService.GetByIdAsync(id);
            if (productDTO == null) return NotFound();

            var categories = await _categoryService.GetAllAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productDTO.CategoryId);

            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            await _productService.UpdateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var productDTO = await _productService.GetByIdAsync(id);

            if (productDTO == null) return NotFound();

            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            await _productService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
