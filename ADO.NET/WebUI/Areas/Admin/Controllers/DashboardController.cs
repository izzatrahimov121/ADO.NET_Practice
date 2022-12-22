using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewsModels;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{

		private readonly AppDbContext _context;

		public DashboardController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			HomViewModel newhomeVM = new()
			{
				SlideItems = _context.SlideItems,
				ShippingItems = _context.ShippingItems
			};
			return View(newhomeVM);
		}

		public IActionResult Detail(int id)
		{
			return View();
		}

		public IActionResult Update(int id)
		{
			return View();
		}

		public IActionResult Delete(int id)
		{
			return View();
		}
	}

}

