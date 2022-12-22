using Core.Entities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.Slider;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class SlideItemController : Controller
{
    private readonly AppDbContext _context;

    public SlideItemController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.SlideItems);
    }



    public IActionResult Created() 
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Created(SlideCreateVM item)
    {
        //if (!ModelState.IsValid) { return View(item); }
        //await _context.SlideItems.AddAsync(item);
        //await _context.SaveChangesAsync();
        //return RedirectToAction(nameof(Index));
        if (item.Photo==null)
        {
            return Content("Null");
        }
        return Content(item.Photo.FileName);
    }


}