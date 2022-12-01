using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            var services = _context.Services.ToList();
            var portfolios = _context.Portfolios.Include(cat=>cat.Category).ToList();
            var abouts = _context.Abouts.ToList();
            var teams = _context.Teams.Include(x=>x.TeamsNetworks).ThenInclude(y=>y.SocialNetwork).ToList();
            HomeVM vm = new()
            {
                Banner = banner,
                Services = services,
                Portfolios = portfolios,
                Abouts = abouts,
                Teams= teams,
            };

            return View(vm);
        }



        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            _context.Contact.Add(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}