using Microsoft.AspNetCore.Mvc;

namespace Food_ordering_3.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Index2()
		{
			return View(); 
		}
		public IActionResult cart()
		{
			return View();
		}
		public IActionResult Privacy() 
		{
			return View();
		}
		public IActionResult stall() 
		{
			return View();
		}
	}
}
