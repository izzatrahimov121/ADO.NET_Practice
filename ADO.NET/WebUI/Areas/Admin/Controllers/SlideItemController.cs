using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.Slider;
using WebUI.Utilites;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class SlideItemController : Controller
{
	private readonly ISlideItemReposiyory _reposiyory;
	private readonly IWebHostEnvironment _env;

	public SlideItemController(ISlideItemReposiyory reposiyory, IWebHostEnvironment env = null)
	{
		_reposiyory = reposiyory;
		_env = env;
	}
	public async Task<IActionResult> Index()
	{
		return View(await _reposiyory.GetAllAsync());
	}


	#region Cteate Slide 
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

		var fileName = String.Empty;
		try
		{
			fileName = await item.Photo.CopyFileAsync(_env.WebRootPath, "assets", "images", "website-images");
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
		await _reposiyory.CreateAsync(slide);
		await _reposiyory.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion

	#region Detail Slide
	public async Task<IActionResult> Detail(int id)
	{
		var model = await _reposiyory.GetAsync(id);
		if (model == null) { return NotFound(); }
		return View(model);
	}
	#endregion

	#region Delete Slide
	public async Task<IActionResult> Delete(int id)
	{
		var model = await _reposiyory.GetAsync(id);
		if (model == null) { return NotFound(); }
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ActionName("Delete")]
	public async Task<IActionResult> DeletePost(int id)
	{
		var model = await _reposiyory.GetAsync(id);
		if (model == null) { return NotFound(); }
		_reposiyory.Delete(model);
		await _reposiyory.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion


	#region Update Slide
	public async Task<IActionResult> Update(int id)
	{
		var model = await _reposiyory.GetAsync(id);
		if (model == null) { return NotFound(); }
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Update(int id, SlideItem item)
	{
		if (id != item.Id) { return BadRequest(); }
		if (!ModelState.IsValid) { return View(item); }
		var model = await _reposiyory.GetAsync(id);
		if (model == null) { return NotFound(); }
		model.Offer = item.Offer;
		model.Description = item.Description;
		model.Photo = item.Photo;
		//_context.SlideItems.Update(item);
		_reposiyory.Update(model);
		await _reposiyory.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion
}