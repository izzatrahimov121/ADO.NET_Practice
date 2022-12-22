using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using WebUI.ViewsModels;

namespace WebUI.Controllers;

public class HomeController : Controller
{

    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context= context;
    }

    public IActionResult Index()
    {
        HomViewModel homeVM = new()
        {
            SlideItems = _context.SlideItems,
            ShippingItems = _context.ShippingItems,
        };

		return View(homeVM);
    }
}
