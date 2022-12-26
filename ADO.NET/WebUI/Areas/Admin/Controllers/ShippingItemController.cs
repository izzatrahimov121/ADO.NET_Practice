using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ShippingItemController : Controller
{
	//private readonly AppDbContext _context;
	private IShippingItemRepository _repository;
	public ShippingItemController(IShippingItemRepository repository)
	{
		_repository = repository;
	}

	public async Task<IActionResult> Index()
	{
		return View(await _repository.GetAllAsync());
	}


	#region Detail Shipping
	public async Task<IActionResult> Detail(int id)
	{
		var model = await _repository.GetAsync(id);
		if (model == null) { return NotFound(); }
		return View(model);
	}
	#endregion


	#region Created Shipping
	public IActionResult Created()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Created(ShippingItem item)
	{
		if (!ModelState.IsValid) { return View(item); }
		await _repository.CreateAsync(item);
		await _repository.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion


	#region Update Shipping
	public async Task<IActionResult> Update(int id)
	{
		var model = await _repository.GetAsync(id);
		if (model == null) { return NotFound(); }
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Update(int id, ShippingItem item)
	{
		if (id != item.Id) { return BadRequest(); }
		if (!ModelState.IsValid) { return View(item); }
		var model = await _repository.GetAsync(id);
		if (model == null) { return NotFound(); }
		model.Title = item.Title;
		model.Description = item.Description;
		model.Image = item.Image;
		_repository.Update(model);
		//_context.ShippingItems.Update(item);
		//_context.ShippingItems.UpdateRange(model);
		await _repository.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion


	#region Delete Shipping
	public async Task<IActionResult> Delete(int id)
	{
		var model = await _repository.GetAsync(id);
		if (model == null) { return NotFound(); }
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ActionName("Delete")]
	public async Task<IActionResult> DeletePost(int id)
	{
		var model = await _repository.GetAsync(id);
		if (model == null) { return NotFound(); }
		_repository.Delete(model);
		await _repository.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion
}
