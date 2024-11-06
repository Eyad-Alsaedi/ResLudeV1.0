using Microsoft.AspNetCore.Mvc;

namespace ExpertsGulfPortal.Controllers
{
    public class LinkController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Link"); // Return the Link view directly
        }
    }
}
