using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementUI.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
