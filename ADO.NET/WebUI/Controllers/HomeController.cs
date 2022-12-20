using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;

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
        return View(_context.SlideItems);
    }
}
