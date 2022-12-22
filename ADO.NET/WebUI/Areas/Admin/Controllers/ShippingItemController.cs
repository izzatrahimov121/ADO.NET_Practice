using Core.Entities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ShippingItemController : Controller
{
	private readonly AppDbContext _context;

	public ShippingItemController(AppDbContext context)
	{
		_context = context;
	}
	public IActionResult Index()
	{
		return View(_context.ShippingItems);
	}

	public async Task<IActionResult> Detail(int id)
	{
		var model =await _context.ShippingItems.FindAsync(id);
		return View(model);
	}

    public IActionResult Created()
    {
        return View();
    }

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Created(ShippingItem item)
	{
		if(!ModelState.IsValid) { return View(item); }
		await _context.ShippingItems.AddAsync(item);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}


	public async Task<IActionResult> Update(int id)
	{
		var model = await _context.ShippingItems.FindAsync(id);
		return View(model);
	}

	public async Task<IActionResult> Delete(int id)
	{
		var model = await _context.ShippingItems.FindAsync(id);
		return View(_context.ShippingItems);
	}
}
