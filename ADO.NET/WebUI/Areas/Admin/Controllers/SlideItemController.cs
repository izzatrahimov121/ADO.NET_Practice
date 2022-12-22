using Core.Entities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.Slider;
using WebUI.Utilites;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class SlideItemController : Controller
{
	private readonly AppDbContext _context;
	private readonly IWebHostEnvironment _env;

	public SlideItemController(AppDbContext context, IWebHostEnvironment env = null)
	{
		_context = context;
		_env = env;
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
		if (item.Photo == null)
		{
			ModelState.AddModelError("Photo", "Şekilin daxil edilmeyib");
			return View(item);
		}
		if (!item.Photo.CheckFileSize(100))
		{
			ModelState.AddModelError("Photo", "Şekilin ölçüsü 100 KB-dan böyükdür");
			return View(item);
		}
		if (!ModelState.IsValid) { return View(item); }
		if (!item.Photo.CheckFileFormat("image/"))
		{
			ModelState.AddModelError("Photo", "Seçilən fayl 'Image' faylı deyil");
			return View(item);
		}

		var fileName=String.Empty;
		try
		{
			fileName = await item.Photo.CopyFileAsync(_env.WebRootPath, "assets", "image", "website-images");
		}
		catch (Exception)
		{
			throw;
		}


		SlideItem slide = new()
		{
			Offer = item.Offer,
			Photo = fileName,
			Description = item.Description
		};
		await _context.SlideItems.AddAsync(slide);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}


}