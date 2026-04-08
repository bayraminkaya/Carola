using Carola.BusinessLayer.Abstract;
using Carola.EntityLayer.Entites;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Carola.WebUI.Controllers
{
    public class TestBrandController : Controller
    {
        private readonly IBrandService _brandService;

        public TestBrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> CreateBrand(Brand brand)
        {
            if (!ModelState.IsValid)
                return View(brand);
            try
            {
                await _brandService.TInsertAsync(brand);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(brand);
            }

            
        }
    }
}
