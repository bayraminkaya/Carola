using Carola.BusinessLayer.Abstract;
using Carola.EntityLayer.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Carola.WebUI.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> LocationList()
        {
            var values = await _locationService.TGetAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(Location location)
        {
            await _locationService.TInsertAsync(location);
            return RedirectToAction("LocationList");
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.TDeleteAsync(id);
            return RedirectToAction("LocationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var value = await _locationService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            await _locationService.TUpdateAsync(location);
            return RedirectToAction("LocationList");
        }

       
    }
}
